using System.Collections.Specialized;
using System.ComponentModel;

public class NotizenTests
{
    private static List<string?> Namen(INotifyPropertyChanged vm)
    {
        var namen = new List<string?>();
        vm.PropertyChanged += (_, e) => namen.Add(e.PropertyName);
        return namen;
    }

    [Fact]
    public void Startzustand_ist_leer_und_beide_Befehle_sind_gesperrt()
    {
        var vm = new NotizenViewModel();

        Assert.IsAssignableFrom<ViewModelBase>(vm);
        Assert.Empty(vm.Notizen);
        Assert.Equal("", vm.Text);
        Assert.Null(vm.Ausgewaehlt);
        Assert.False(vm.Hinzufuegen.CanExecute(null));
        Assert.False(vm.Loeschen.CanExecute(null));
    }

    [Fact]
    public void Hinzufuegen_ist_nur_mit_Text_ausfuehrbar()
    {
        var vm = new NotizenViewModel();
        var geaendert = 0;
        vm.Hinzufuegen.CanExecuteChanged += (_, _) => geaendert++;

        vm.Text = "Milch";
        Assert.True(vm.Hinzufuegen.CanExecute(null));
        Assert.Equal(1, geaendert);

        vm.Text = "   ";
        Assert.False(vm.Hinzufuegen.CanExecute(null));
        Assert.Equal(2, geaendert);
    }

    [Fact]
    public void Text_meldet_PropertyChanged_nur_bei_Aenderung()
    {
        var vm = new NotizenViewModel();
        var namen = Namen(vm);

        vm.Text = "a";
        vm.Text = "a";

        Assert.Equal(new string?[] { "Text" }, namen);
    }

    [Fact]
    public void Hinzufuegen_fuegt_die_getrimmte_Notiz_ein_und_leert_den_Text()
    {
        var vm = new NotizenViewModel { Text = "  Milch kaufen " };
        var aktionen = new List<NotifyCollectionChangedAction>();
        vm.Notizen.CollectionChanged += (_, e) => aktionen.Add(e.Action);

        vm.Hinzufuegen.Execute(null);

        Assert.Equal(new[] { "Milch kaufen" }, vm.Notizen);
        Assert.Equal("", vm.Text);
        Assert.False(vm.Hinzufuegen.CanExecute(null));
        Assert.Equal(new[] { NotifyCollectionChangedAction.Add }, aktionen);
    }

    [Fact]
    public void Notizen_bleiben_in_der_Eingabereihenfolge()
    {
        var vm = new NotizenViewModel();
        foreach (var t in new[] { "eins", "zwei", "drei" })
        {
            vm.Text = t;
            vm.Hinzufuegen.Execute(null);
        }

        Assert.Equal(new[] { "eins", "zwei", "drei" }, vm.Notizen);
    }

    [Fact]
    public void Loeschen_ist_nur_mit_Auswahl_ausfuehrbar()
    {
        var vm = new NotizenViewModel();
        var geaendert = 0;
        vm.Loeschen.CanExecuteChanged += (_, _) => geaendert++;

        vm.Ausgewaehlt = "x";
        Assert.True(vm.Loeschen.CanExecute(null));
        Assert.Equal(1, geaendert);

        vm.Ausgewaehlt = null;
        Assert.False(vm.Loeschen.CanExecute(null));
        Assert.Equal(2, geaendert);
    }

    [Fact]
    public void Ausgewaehlt_meldet_PropertyChanged_nur_bei_Aenderung()
    {
        var vm = new NotizenViewModel();
        var namen = Namen(vm);

        vm.Ausgewaehlt = "x";
        vm.Ausgewaehlt = "x";
        vm.Ausgewaehlt = null;

        Assert.Equal(new string?[] { "Ausgewaehlt", "Ausgewaehlt" }, namen);
    }

    [Fact]
    public void Loeschen_entfernt_die_ausgewaehlte_Notiz_und_hebt_die_Auswahl_auf()
    {
        var vm = new NotizenViewModel();
        foreach (var t in new[] { "eins", "zwei", "drei" })
        {
            vm.Text = t;
            vm.Hinzufuegen.Execute(null);
        }
        vm.Ausgewaehlt = "zwei";

        vm.Loeschen.Execute(null);

        Assert.Equal(new[] { "eins", "drei" }, vm.Notizen);
        Assert.Null(vm.Ausgewaehlt);
        Assert.False(vm.Loeschen.CanExecute(null));
    }

    [Fact]
    public void Gleiche_Notiz_zweimal_loescht_nur_einen_Eintrag()
    {
        var vm = new NotizenViewModel();
        foreach (var t in new[] { "a", "a" })
        {
            vm.Text = t;
            vm.Hinzufuegen.Execute(null);
        }
        vm.Ausgewaehlt = "a";

        vm.Loeschen.Execute(null);

        Assert.Equal(new[] { "a" }, vm.Notizen);
    }
}
