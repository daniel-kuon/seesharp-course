public class RechnerTests
{
    // Tippt eine Tastenfolge: Ziffern und Komma, + - * /, = und C (löschen).
    private static RechnerViewModel Tippe(string tasten, RechnerViewModel? vm = null)
    {
        vm ??= new RechnerViewModel();
        foreach (var t in tasten)
        {
            var befehl = t switch
            {
                '=' => vm.GleichCommand,
                'C' => vm.LoeschenCommand,
                '+' or '-' or '*' or '/' => vm.OperatorCommand,
                _ => vm.ZifferCommand,
            };
            var parameter = t is '=' or 'C' ? null : t.ToString();
            Assert.True(befehl.CanExecute(parameter), $"Taste {t}");
            befehl.Execute(parameter);
        }
        return vm;
    }

    private static int Meldungen(RechnerViewModel vm, Action aktion)
    {
        var namen = new List<string?>();
        vm.PropertyChanged += (_, e) => namen.Add(e.PropertyName);
        aktion();
        Assert.All(namen, n => Assert.Equal("Anzeige", n));
        return namen.Count;
    }

    [Fact]
    public void Startanzeige_ist_0()
    {
        var vm = new RechnerViewModel();
        Assert.IsAssignableFrom<ViewModelBase>(vm);
        Assert.Equal("0", vm.Anzeige);
    }

    [Fact]
    public void Ziffern_werden_angehaengt()
    {
        Assert.Equal("123", Tippe("123").Anzeige);
    }

    [Fact]
    public void Fuehrende_Null_wird_ersetzt()
    {
        Assert.Equal("5", Tippe("005").Anzeige);
        Assert.Equal("0", Tippe("00").Anzeige);
    }

    [Fact]
    public void Komma_wird_einmal_angehaengt_und_ergibt_bei_leerer_Eingabe_0_Komma()
    {
        Assert.Equal("1,5", Tippe("1,5").Anzeige);
        Assert.Equal("1,5", Tippe("1,,5").Anzeige);
        Assert.Equal("0,5", Tippe(",5").Anzeige);
    }

    [Fact]
    public void Addition()
    {
        Assert.Equal("12", Tippe("7+5=").Anzeige);
    }

    [Theory]
    [InlineData("9-4=", "5")]
    [InlineData("4-9=", "-5")]
    [InlineData("6*7=", "42")]
    [InlineData("7/2=", "3,5")]
    [InlineData("1/3=", "0,33333333")]
    [InlineData("1,5+1,25=", "2,75")]
    public void Grundrechenarten(string tasten, string erwartet)
    {
        Assert.Equal(erwartet, Tippe(tasten).Anzeige);
    }

    [Fact]
    public void Es_wird_von_links_nach_rechts_gerechnet()
    {
        Assert.Equal("20", Tippe("2+3*4=").Anzeige);
    }

    [Fact]
    public void Ein_zweiter_Operator_zeigt_das_Zwischenergebnis()
    {
        var vm = Tippe("2+3*");
        Assert.Equal("5", vm.Anzeige);
        Assert.Equal("20", Tippe("4=", vm).Anzeige);
    }

    [Fact]
    public void Ein_zweiter_Operator_ersetzt_den_ersten()
    {
        Assert.Equal("10", Tippe("5+*2=").Anzeige);
    }

    [Fact]
    public void Nach_dem_Operator_zeigt_die_Anzeige_noch_den_linken_Operand()
    {
        Assert.Equal("7", Tippe("7+").Anzeige);
        Assert.Equal("5", Tippe("7+5").Anzeige);
    }

    [Fact]
    public void Nach_Gleich_kann_mit_dem_Ergebnis_weitergerechnet_werden()
    {
        var vm = Tippe("7+5=");
        Assert.Equal("17", Tippe("+5=", vm).Anzeige);
    }

    [Fact]
    public void Nach_Gleich_beginnt_eine_Ziffer_eine_neue_Rechnung()
    {
        var vm = Tippe("7+5=");
        Assert.Equal("3", Tippe("3", vm).Anzeige);
        Assert.Equal("4", Tippe("+1=", vm).Anzeige);
    }

    [Fact]
    public void Division_durch_0_zeigt_Fehler()
    {
        Assert.Equal("Fehler", Tippe("5/0=").Anzeige);
        Assert.Equal("Fehler", Tippe("5/0+").Anzeige);
    }

    [Fact]
    public void Im_Fehlerzustand_wirkt_nur_C()
    {
        var vm = Tippe("5/0=");

        var meldungen = Meldungen(vm, () => Tippe("7+=", vm));

        Assert.Equal(0, meldungen);
        Assert.Equal("Fehler", vm.Anzeige);

        Tippe("C", vm);
        Assert.Equal("0", vm.Anzeige);
        Assert.Equal("9", Tippe("4+5=", vm).Anzeige);
    }

    [Fact]
    public void C_setzt_alles_zurueck()
    {
        var vm = Tippe("7+5");
        Tippe("C", vm);
        Assert.Equal("0", vm.Anzeige);
        Assert.Equal("3", Tippe("3=", vm).Anzeige); // der alte Operator ist weg
    }

    [Fact]
    public void Jede_wirksame_Taste_meldet_Anzeige_genau_einmal()
    {
        var vm = new RechnerViewModel();

        Assert.Equal(1, Meldungen(vm, () => Tippe("7", vm)));
        Assert.Equal(1, Meldungen(vm, () => Tippe("+", vm)));
        Assert.Equal(1, Meldungen(vm, () => Tippe("5", vm)));
        Assert.Equal(1, Meldungen(vm, () => Tippe("=", vm)));
        Assert.Equal(1, Meldungen(vm, () => Tippe("C", vm)));
    }

    [Fact]
    public void Wirkungslose_Tasten_melden_nichts()
    {
        var vm = new RechnerViewModel();

        Assert.Equal(0, Meldungen(vm, () => Tippe("=", vm)));  // nichts zu berechnen
        Assert.Equal(0, Meldungen(vm, () => Tippe("+", vm)));  // noch kein Operand
        Tippe("1,5", vm);
        Assert.Equal(0, Meldungen(vm, () => Tippe(",", vm)));  // zweites Komma
        Assert.Equal(0, Meldungen(vm, () => Tippe("=", vm)));  // kein Operator
    }

    [Fact]
    public void Anzeige_ist_eine_berechnete_Eigenschaft()
    {
        var anzeige = typeof(RechnerViewModel).GetProperty("Anzeige")!;
        Assert.False(anzeige.CanWrite);
        Assert.Null(typeof(RechnerViewModel).GetField("_anzeige",
            System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic));
    }

    [Fact]
    public void Die_Eingabe_ist_auf_15_Zeichen_begrenzt()
    {
        Assert.Equal("123456789012345", Tippe("12345678901234567890").Anzeige);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("12")]
    [InlineData("x")]
    [InlineData(7)]
    public void ZifferCommand_lehnt_ungueltige_Parameter_ab(object? parameter)
    {
        Assert.False(new RechnerViewModel().ZifferCommand.CanExecute(parameter));
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("%")]
    [InlineData("++")]
    [InlineData('+')]
    public void OperatorCommand_lehnt_ungueltige_Parameter_ab(object? parameter)
    {
        Assert.False(new RechnerViewModel().OperatorCommand.CanExecute(parameter));
    }

    [Fact]
    public void Gueltige_Parameter_sind_ausfuehrbar()
    {
        var vm = new RechnerViewModel();
        foreach (var z in "0123456789,")
            Assert.True(vm.ZifferCommand.CanExecute(z.ToString()));
        foreach (var o in new[] { "+", "-", "*", "/" })
            Assert.True(vm.OperatorCommand.CanExecute(o));
        Assert.True(vm.GleichCommand.CanExecute(null));
        Assert.True(vm.LoeschenCommand.CanExecute(null));
    }
}
