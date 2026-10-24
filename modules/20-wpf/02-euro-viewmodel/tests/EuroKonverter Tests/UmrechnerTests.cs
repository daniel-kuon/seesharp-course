using System.ComponentModel;

public class UmrechnerTests
{
    private class Testmodell : ViewModelBase
    {
        private int _wert;
        private string? _name;

        public int Wert
        {
            get => _wert;
            set => SetProperty(ref _wert, value);
        }

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public bool Setze(int wert) => SetProperty(ref _wert, wert, "Frei");

        public void Melde(string? name) => OnPropertyChanged(name);
    }

    private static List<string> Mitschnitt(INotifyPropertyChanged vm)
    {
        var namen = new List<string>();
        vm.PropertyChanged += (_, e) => namen.Add(e.PropertyName!);
        return namen;
    }

    // ----- ViewModelBase -------------------------------------------------------------------

    [Fact]
    public void ViewModelBase_implementiert_INotifyPropertyChanged()
    {
        Assert.IsAssignableFrom<INotifyPropertyChanged>(new Testmodell());
    }

    [Fact]
    public void OnPropertyChanged_meldet_den_Namen_mit_this_als_Sender()
    {
        var m = new Testmodell();
        object? sender = null;
        string? name = null;
        m.PropertyChanged += (s, e) => { sender = s; name = e.PropertyName; };

        m.Melde("Irgendwas");

        Assert.Same(m, sender);
        Assert.Equal("Irgendwas", name);
    }

    [Fact]
    public void OnPropertyChanged_ohne_Abonnenten_wirft_nicht()
    {
        var m = new Testmodell();
        m.Melde("X");
        m.Wert = 5;
    }

    [Fact]
    public void SetProperty_setzt_den_Wert_und_meldet_den_Eigenschaftsnamen_genau_einmal()
    {
        var m = new Testmodell();
        var namen = Mitschnitt(m);

        m.Wert = 7;

        Assert.Equal(7, m.Wert);
        Assert.Equal(new[] { "Wert" }, namen);
    }

    [Fact]
    public void SetProperty_mit_gleichem_Wert_meldet_nichts_und_liefert_false()
    {
        var m = new Testmodell { Wert = 3, Name = null };
        var namen = Mitschnitt(m);

        m.Wert = 3;
        m.Name = null;

        Assert.Empty(namen);
        Assert.False(m.Setze(3));
    }

    [Fact]
    public void SetProperty_liefert_true_und_nimmt_einen_ausdruecklichen_Namen()
    {
        var m = new Testmodell();
        var namen = Mitschnitt(m);

        Assert.True(m.Setze(9));

        Assert.Equal(9, m.Wert);
        Assert.Equal(new[] { "Frei" }, namen);
    }

    // ----- UmrechnerViewModel --------------------------------------------------------------

    [Fact]
    public void Der_Umrechner_ist_ein_ViewModelBase()
    {
        Assert.IsAssignableFrom<ViewModelBase>(new UmrechnerViewModel());
    }

    [Fact]
    public void Startzustand_ist_leer_und_ohne_Fehler()
    {
        var vm = new UmrechnerViewModel();
        Assert.Equal("", vm.EuroText);
        Assert.Equal("", vm.DmText);
        Assert.Equal("", vm.Fehlermeldung);
        Assert.False(vm.HatFehler);
    }

    [Fact]
    public void Euro_eingeben_berechnet_DM_mit_zwei_Nachkommastellen()
    {
        var vm = new UmrechnerViewModel { EuroText = "10" };
        Assert.Equal("19,56", vm.DmText);

        vm.EuroText = "1,5";
        Assert.Equal("2,93", vm.DmText);
    }

    [Fact]
    public void DM_eingeben_berechnet_Euro()
    {
        var vm = new UmrechnerViewModel { DmText = "3,91" };
        Assert.Equal("2,00", vm.EuroText);

        vm.DmText = "100";
        Assert.Equal("51,13", vm.EuroText);
    }

    [Fact]
    public void Kein_Ping_Pong_die_Eingabe_des_Benutzers_bleibt_unveraendert()
    {
        var vm = new UmrechnerViewModel();
        var namen = Mitschnitt(vm);

        vm.EuroText = "10";

        Assert.Equal("10", vm.EuroText);
        Assert.Equal("19,56", vm.DmText);
        Assert.Equal(new[] { "DmText", "EuroText" }, namen.Order());
    }

    [Fact]
    public void Jede_Aenderung_meldet_jede_Eigenschaft_genau_einmal()
    {
        var vm = new UmrechnerViewModel { EuroText = "10" };
        var namen = Mitschnitt(vm);

        vm.DmText = "50";

        Assert.Equal("50", vm.DmText);
        Assert.Equal("25,56", vm.EuroText);
        Assert.Equal(new[] { "DmText", "EuroText" }, namen.Order());
    }

    [Fact]
    public void Gleicher_Text_loest_nichts_aus()
    {
        var vm = new UmrechnerViewModel { EuroText = "10" };
        var namen = Mitschnitt(vm);

        vm.EuroText = "10";

        Assert.Empty(namen);
    }

    [Fact]
    public void Ungueltige_Eingabe_setzt_Fehlermeldung_und_laesst_den_Partner_unveraendert()
    {
        var vm = new UmrechnerViewModel { EuroText = "10" };
        var namen = Mitschnitt(vm);

        vm.EuroText = "zehn";

        Assert.Equal("zehn", vm.EuroText);
        Assert.Equal("19,56", vm.DmText);
        Assert.NotEqual("", vm.Fehlermeldung);
        Assert.True(vm.HatFehler);
        Assert.Equal(new[] { "EuroText", "Fehlermeldung", "HatFehler" }, namen.Order());
    }

    [Fact]
    public void Punkt_als_Dezimaltrenner_ist_ungueltig()
    {
        var vm = new UmrechnerViewModel { EuroText = "1.5" };
        Assert.True(vm.HatFehler);
        Assert.Equal("", vm.DmText);
    }

    [Fact]
    public void Gueltige_Eingabe_loescht_den_Fehler_und_meldet_ihn()
    {
        var vm = new UmrechnerViewModel { DmText = "abc" };
        Assert.True(vm.HatFehler);
        var namen = Mitschnitt(vm);

        vm.DmText = "2";

        Assert.False(vm.HatFehler);
        Assert.Equal("", vm.Fehlermeldung);
        Assert.Equal("1,02", vm.EuroText);
        Assert.Equal(new[] { "DmText", "EuroText", "Fehlermeldung", "HatFehler" }, namen.Order());
    }

    [Fact]
    public void Zweite_ungueltige_Eingabe_mit_gleicher_Meldung_meldet_den_Fehler_nicht_erneut()
    {
        var vm = new UmrechnerViewModel { EuroText = "a" };
        var namen = Mitschnitt(vm);

        vm.EuroText = "a";
        Assert.Empty(namen);
        vm.EuroText = "b";

        Assert.Equal(new[] { "EuroText" }, namen);
        Assert.True(vm.HatFehler);
    }

    [Fact]
    public void Leere_Eingabe_leert_den_Partner_ohne_Fehler()
    {
        var vm = new UmrechnerViewModel { EuroText = "10" };

        vm.EuroText = "";

        Assert.Equal("", vm.DmText);
        Assert.False(vm.HatFehler);
    }

    [Fact]
    public void HatFehler_ist_eine_berechnete_Eigenschaft_ohne_eigenes_Feld()
    {
        var feld = typeof(UmrechnerViewModel).GetField("_hatFehler",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
        Assert.Null(feld);
        Assert.False(typeof(UmrechnerViewModel).GetProperty("HatFehler")!.CanWrite);
    }

    [Fact]
    public void Der_Kurs_ist_1_95583()
    {
        Assert.Equal(1.95583m, UmrechnerViewModel.Kurs);
    }
}
