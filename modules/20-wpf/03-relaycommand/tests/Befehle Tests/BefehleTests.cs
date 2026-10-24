using System.Windows.Input;

public class BefehleTests
{
    // ----- RelayCommand --------------------------------------------------------------------

    [Fact]
    public void RelayCommand_ist_ein_ICommand()
    {
        ICommand befehl = new RelayCommand(_ => { });
        Assert.NotNull(befehl);
    }

    [Fact]
    public void Ohne_Bedingung_ist_der_Befehl_immer_ausfuehrbar()
    {
        var befehl = new RelayCommand(_ => { });
        Assert.True(befehl.CanExecute(null));
        Assert.True(befehl.CanExecute("irgendwas"));
    }

    [Fact]
    public void CanExecute_ruft_die_Bedingung_mit_dem_Parameter_auf()
    {
        object? gesehen = null;
        var befehl = new RelayCommand(_ => { }, p => { gesehen = p; return p is "ja"; });

        Assert.True(befehl.CanExecute("ja"));
        Assert.Equal("ja", gesehen);
        Assert.False(befehl.CanExecute("nein"));
        Assert.Equal("nein", gesehen);
    }

    [Fact]
    public void Execute_ruft_die_Aktion_mit_dem_Parameter_auf()
    {
        var aufrufe = new List<object?>();
        var befehl = new RelayCommand(aufrufe.Add);

        befehl.Execute(42);
        befehl.Execute(null);

        Assert.Equal(new object?[] { 42, null }, aufrufe);
    }

    [Fact]
    public void RaiseCanExecuteChanged_loest_das_Ereignis_mit_dem_Befehl_als_Sender_aus()
    {
        var befehl = new RelayCommand(_ => { });
        object? sender = null;
        var zaehler = 0;
        befehl.CanExecuteChanged += (s, _) => { sender = s; zaehler++; };

        befehl.RaiseCanExecuteChanged();

        Assert.Equal(1, zaehler);
        Assert.Same(befehl, sender);
    }

    [Fact]
    public void RaiseCanExecuteChanged_ohne_Abonnenten_wirft_nicht()
    {
        new RelayCommand(_ => { }).RaiseCanExecuteChanged();
    }

    [Fact]
    public void Konstruktor_ohne_Aktion_wirft_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new RelayCommand(null!));
    }

    // ----- ZaehlerViewModel ----------------------------------------------------------------

    [Fact]
    public void Der_Zaehler_ist_ein_ViewModelBase_und_startet_bei_0()
    {
        var vm = new ZaehlerViewModel();
        Assert.IsAssignableFrom<ViewModelBase>(vm);
        Assert.Equal(0, vm.Wert);
    }

    [Fact]
    public void Erhoehen_und_Verringern_aendern_den_Wert()
    {
        var vm = new ZaehlerViewModel();

        vm.Erhoehen.Execute(null);
        vm.Erhoehen.Execute(null);
        vm.Verringern.Execute(null);

        Assert.Equal(1, vm.Wert);
    }

    [Fact]
    public void Verringern_ist_nur_ausfuehrbar_solange_der_Wert_groesser_0_ist()
    {
        var vm = new ZaehlerViewModel();
        Assert.False(vm.Verringern.CanExecute(null));
        Assert.True(vm.Erhoehen.CanExecute(null));

        vm.Erhoehen.Execute(null);
        Assert.True(vm.Verringern.CanExecute(null));

        vm.Verringern.Execute(null);
        Assert.False(vm.Verringern.CanExecute(null));
    }

    [Fact]
    public void Verringern_meldet_CanExecuteChanged_bei_jeder_Wertaenderung()
    {
        var vm = new ZaehlerViewModel();
        var zaehler = 0;
        ((ICommand)vm.Verringern).CanExecuteChanged += (_, _) => zaehler++;

        vm.Erhoehen.Execute(null);
        Assert.Equal(1, zaehler);

        vm.Erhoehen.Execute(null);
        Assert.Equal(2, zaehler);

        vm.Verringern.Execute(null);
        Assert.Equal(3, zaehler);
    }

    [Fact]
    public void Wert_meldet_PropertyChanged_genau_einmal_pro_Aenderung()
    {
        var vm = new ZaehlerViewModel();
        var namen = new List<string?>();
        vm.PropertyChanged += (_, e) => namen.Add(e.PropertyName);

        vm.Erhoehen.Execute(null);
        vm.SetzeAuf.Execute(1); // gleicher Wert: nichts melden

        Assert.Equal(new string?[] { "Wert" }, namen);
    }

    [Fact]
    public void SetzeAuf_nimmt_einen_int_als_Parameter()
    {
        var vm = new ZaehlerViewModel();
        Assert.True(vm.SetzeAuf.CanExecute(5));

        vm.SetzeAuf.Execute(5);

        Assert.Equal(5, vm.Wert);
    }

    [Fact]
    public void SetzeAuf_nimmt_auch_eine_Zeichenkette_wie_aus_XAML()
    {
        var vm = new ZaehlerViewModel();
        Assert.True(vm.SetzeAuf.CanExecute("12"));

        vm.SetzeAuf.Execute("12");

        Assert.Equal(12, vm.Wert);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("abc")]
    [InlineData("")]
    [InlineData("-3")]
    [InlineData(-3)]
    [InlineData(2.5)]
    public void SetzeAuf_ist_bei_ungueltigem_Parameter_nicht_ausfuehrbar(object? parameter)
    {
        var vm = new ZaehlerViewModel();
        Assert.False(vm.SetzeAuf.CanExecute(parameter));
    }

    [Fact]
    public void SetzeAuf_auf_0_schaltet_Verringern_wieder_ab()
    {
        var vm = new ZaehlerViewModel();
        vm.SetzeAuf.Execute("4");
        Assert.True(vm.Verringern.CanExecute(null));

        vm.SetzeAuf.Execute(0);

        Assert.False(vm.Verringern.CanExecute(null));
    }
}
