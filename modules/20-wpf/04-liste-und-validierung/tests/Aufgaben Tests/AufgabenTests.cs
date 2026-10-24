using System.Collections.Specialized;
using System.ComponentModel;

public class AufgabenTests
{
    private static List<string?> Namen(INotifyPropertyChanged vm)
    {
        var namen = new List<string?>();
        vm.PropertyChanged += (_, e) => namen.Add(e.PropertyName);
        return namen;
    }

    private static List<string> Fehler(AufgabenViewModel vm, string? name = "NeuerTitel")
        => vm.GetErrors(name).Cast<string>().ToList();

    // ----- Validierung ---------------------------------------------------------------------

    [Fact]
    public void Das_ViewModel_implementiert_INotifyDataErrorInfo()
    {
        Assert.IsAssignableFrom<INotifyDataErrorInfo>(new AufgabenViewModel());
    }

    [Fact]
    public void Im_Startzustand_ist_der_leere_Titel_ein_Fehler()
    {
        var vm = new AufgabenViewModel();

        Assert.True(vm.HasErrors);
        Assert.Equal(new[] { "Titel darf nicht leer sein" }, Fehler(vm));
    }

    [Fact]
    public void Gueltiger_Titel_entfernt_den_Fehler_und_meldet_das_genau_einmal()
    {
        var vm = new AufgabenViewModel();
        var meldungen = new List<string?>();
        vm.ErrorsChanged += (s, e) => { Assert.Same(vm, s); meldungen.Add(e.PropertyName); };
        var namen = Namen(vm);

        vm.NeuerTitel = "Einkaufen";

        Assert.False(vm.HasErrors);
        Assert.Empty(Fehler(vm));
        Assert.Equal(new[] { "NeuerTitel" }, meldungen);
        Assert.Equal(new string?[] { "HasErrors", "NeuerTitel" }, namen.Order());
    }

    [Fact]
    public void ErrorsChanged_kommt_nur_bei_geaenderter_Meldung()
    {
        var vm = new AufgabenViewModel();
        var meldungen = 0;
        vm.ErrorsChanged += (_, _) => meldungen++;

        vm.NeuerTitel = "a";   // leer -> gültig: 1
        vm.NeuerTitel = "ab";  // gültig -> gültig: nichts
        vm.NeuerTitel = "  ";  // gültig -> leer: 2
        vm.NeuerTitel = "";    // leer -> leer: nichts

        Assert.Equal(2, meldungen);
    }

    [Fact]
    public void Zu_langer_Titel_ist_ein_Fehler_50_Zeichen_sind_erlaubt()
    {
        var vm = new AufgabenViewModel { NeuerTitel = new string('x', 50) };
        Assert.False(vm.HasErrors);

        vm.NeuerTitel = new string('x', 51);

        Assert.True(vm.HasErrors);
        Assert.Equal(new[] { "Titel zu lang" }, Fehler(vm));
    }

    [Fact]
    public void Nur_Leerraum_gilt_als_leer()
    {
        var vm = new AufgabenViewModel { NeuerTitel = "x" };

        vm.NeuerTitel = "   ";

        Assert.Equal(new[] { "Titel darf nicht leer sein" }, Fehler(vm));
    }

    [Fact]
    public void GetErrors_fuer_unbekannte_Eigenschaften_ist_leer_und_fuer_null_liefert_alles()
    {
        var vm = new AufgabenViewModel();

        Assert.Empty(Fehler(vm, "Gibts_nicht"));
        Assert.Equal(new[] { "Titel darf nicht leer sein" }, Fehler(vm, null));
        Assert.Equal(new[] { "Titel darf nicht leer sein" }, Fehler(vm, ""));
    }

    [Fact]
    public void Gleicher_Titel_loest_nichts_aus()
    {
        var vm = new AufgabenViewModel { NeuerTitel = "x" };
        var namen = Namen(vm);
        var meldungen = 0;
        vm.ErrorsChanged += (_, _) => meldungen++;

        vm.NeuerTitel = "x";

        Assert.Empty(namen);
        Assert.Equal(0, meldungen);
    }

    // ----- Befehle -------------------------------------------------------------------------

    [Fact]
    public void Hinzufuegen_ist_nur_ohne_Fehler_ausfuehrbar_und_meldet_CanExecuteChanged()
    {
        var vm = new AufgabenViewModel();
        var geaendert = 0;
        vm.HinzufuegenCommand.CanExecuteChanged += (_, _) => geaendert++;
        Assert.False(vm.HinzufuegenCommand.CanExecute(null));

        vm.NeuerTitel = "Aufgabe";
        Assert.True(vm.HinzufuegenCommand.CanExecute(null));
        Assert.Equal(1, geaendert);

        vm.NeuerTitel = "";
        Assert.False(vm.HinzufuegenCommand.CanExecute(null));
        Assert.Equal(2, geaendert);
    }

    [Fact]
    public void Hinzufuegen_fuegt_die_Aufgabe_ein_trimmt_den_Titel_und_leert_das_Eingabefeld()
    {
        var vm = new AufgabenViewModel { NeuerTitel = "  Wäsche waschen  " };
        var aenderungen = new List<NotifyCollectionChangedAction>();
        vm.Aufgaben.CollectionChanged += (_, e) => aenderungen.Add(e.Action);

        vm.HinzufuegenCommand.Execute(null);

        var aufgabe = Assert.Single(vm.Aufgaben);
        Assert.Equal("Wäsche waschen", aufgabe.Titel);
        Assert.False(aufgabe.Erledigt);
        Assert.Equal(new[] { NotifyCollectionChangedAction.Add }, aenderungen);
        Assert.Equal("", vm.NeuerTitel);
        Assert.True(vm.HasErrors);
        Assert.False(vm.HinzufuegenCommand.CanExecute(null));
    }

    [Fact]
    public void Aufgaben_ist_eine_ObservableCollection()
    {
        Assert.IsType<System.Collections.ObjectModel.ObservableCollection<Aufgabe>>(new AufgabenViewModel().Aufgaben);
    }

    // ----- OffeneAnzahl --------------------------------------------------------------------

    [Fact]
    public void OffeneAnzahl_aendert_sich_bei_Hinzufuegen_Abhaken_und_Entfernen()
    {
        var vm = new AufgabenViewModel();
        var namen = Namen(vm);
        Assert.Equal(0, vm.OffeneAnzahl);

        var a = new Aufgabe("A");
        var b = new Aufgabe("B");
        vm.Aufgaben.Add(a);
        vm.Aufgaben.Add(b);
        Assert.Equal(2, vm.OffeneAnzahl);
        Assert.Equal(2, namen.Count(n => n == "OffeneAnzahl"));

        a.Erledigt = true;
        Assert.Equal(1, vm.OffeneAnzahl);
        Assert.Equal(3, namen.Count(n => n == "OffeneAnzahl"));

        a.Erledigt = true; // unverändert: keine Meldung
        Assert.Equal(3, namen.Count(n => n == "OffeneAnzahl"));

        vm.Aufgaben.Remove(b);
        Assert.Equal(0, vm.OffeneAnzahl);
        Assert.Equal(4, namen.Count(n => n == "OffeneAnzahl"));
    }

    [Fact]
    public void Entfernte_Aufgaben_beeinflussen_OffeneAnzahl_nicht_mehr()
    {
        var vm = new AufgabenViewModel();
        var a = new Aufgabe("A");
        vm.Aufgaben.Add(a);
        vm.Aufgaben.Remove(a);
        var namen = Namen(vm);

        a.Erledigt = true; // Handler muss abgemeldet sein

        Assert.DoesNotContain("OffeneAnzahl", namen);
    }

    [Fact]
    public void Eine_Aufgabe_meldet_nur_Erledigt_nicht_andere_Namen_weiter()
    {
        var vm = new AufgabenViewModel();
        var a = new Aufgabe("A");
        vm.Aufgaben.Add(a);
        var namen = Namen(vm);

        a.Erledigt = true;

        Assert.Equal(1, namen.Count(n => n == "OffeneAnzahl"));
    }

    // ----- ErledigteEntfernen --------------------------------------------------------------

    [Fact]
    public void ErledigteEntfernen_ist_nur_ausfuehrbar_wenn_etwas_erledigt_ist()
    {
        var vm = new AufgabenViewModel();
        var a = new Aufgabe("A");
        vm.Aufgaben.Add(a);
        var geaendert = 0;
        vm.ErledigteEntfernenCommand.CanExecuteChanged += (_, _) => geaendert++;
        Assert.False(vm.ErledigteEntfernenCommand.CanExecute(null));

        a.Erledigt = true;

        Assert.True(vm.ErledigteEntfernenCommand.CanExecute(null));
        Assert.Equal(1, geaendert);
    }

    [Fact]
    public void ErledigteEntfernen_entfernt_nur_erledigte_Aufgaben_einzeln()
    {
        var vm = new AufgabenViewModel();
        var a = new Aufgabe("A") { Erledigt = true };
        var b = new Aufgabe("B");
        var c = new Aufgabe("C") { Erledigt = true };
        foreach (var x in new[] { a, b, c })
            vm.Aufgaben.Add(x);
        var entfernt = 0;
        vm.Aufgaben.CollectionChanged += (_, e) => { if (e.Action == NotifyCollectionChangedAction.Remove) entfernt++; };

        vm.ErledigteEntfernenCommand.Execute(null);

        Assert.Equal(new[] { b }, vm.Aufgaben);
        Assert.Equal(2, entfernt);
        Assert.Equal(1, vm.OffeneAnzahl);
        Assert.False(vm.ErledigteEntfernenCommand.CanExecute(null));

        // Die entfernten Aufgaben beeinflussen nichts mehr.
        var namen = Namen(vm);
        a.Erledigt = false;
        c.Erledigt = false;
        Assert.DoesNotContain("OffeneAnzahl", namen);
    }
}
