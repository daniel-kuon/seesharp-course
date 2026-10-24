public class EinleserTests
{
    [Fact]
    public void LiesZahlen_liest_gueltige_Zahlen_in_Reihenfolge()
    {
        var e = Einleser.LiesZahlen("3;-4;10");

        Assert.Equal(new[] { 3, -4, 10 }, e.Werte);
        Assert.Empty(e.Fehler);
    }

    [Fact]
    public void LiesZahlen_meldet_Teile_die_keine_Zahl_sind()
    {
        var e = Einleser.LiesZahlen("1;x;2;1,5");

        Assert.Equal(new[] { 1, 2 }, e.Werte);
        Assert.Equal(new[] { "x: keine Zahl", "1,5: keine Zahl" }, e.Fehler);
    }

    [Fact]
    public void LiesZahlen_meldet_zu_grosse_Zahlen()
    {
        var e = Einleser.LiesZahlen("5;99999999999;-99999999999");

        Assert.Equal(new[] { 5 }, e.Werte);
        Assert.Equal(new[] { "99999999999: zu groß", "-99999999999: zu groß" }, e.Fehler);
    }

    [Fact]
    public void LiesZahlen_mit_gemischter_Eingabe()
    {
        var e = Einleser.LiesZahlen("10;abc;2147483648;20;;30");

        Assert.Equal(new[] { 10, 20, 30 }, e.Werte);
        Assert.Equal(new[] { "abc: keine Zahl", "2147483648: zu groß" }, e.Fehler);
    }

    [Fact]
    public void LiesZahlen_grenzwerte_des_int_Bereichs_sind_gueltig()
    {
        var e = Einleser.LiesZahlen("2147483647;-2147483648");

        Assert.Equal(new[] { int.MaxValue, int.MinValue }, e.Werte);
        Assert.Empty(e.Fehler);
    }

    [Fact]
    public void LiesZahlen_leerer_Text_ergibt_ein_leeres_Ergebnis()
    {
        var e = Einleser.LiesZahlen("");

        Assert.Empty(e.Werte);
        Assert.Empty(e.Fehler);
    }

    [Fact]
    public void Mittelwert_der_gueltigen_Zahlen()
    {
        var e = Einleser.LiesZahlen("2;4;x;9");

        Assert.Equal(5.0, Einleser.Mittelwert(e), 10);
    }

    [Fact]
    public void Mittelwert_ist_nicht_ganzzahlig()
    {
        Assert.Equal(1.5, Einleser.Mittelwert(Einleser.LiesZahlen("1;2")), 10);
    }

    [Fact]
    public void Mittelwert_ohne_gueltige_Zahl_ist_NaN()
    {
        Assert.True(double.IsNaN(Einleser.Mittelwert(Einleser.LiesZahlen("a;b"))));
        Assert.True(double.IsNaN(Einleser.Mittelwert(Einleser.LiesZahlen(""))));
    }
}
