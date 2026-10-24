public class TaschenrechnerTests
{
    [Theory]
    [InlineData("2", "+", "3", "5")]
    [InlineData("7", "-", "10", "-3")]
    [InlineData("6", "*", "7", "42")]
    [InlineData("7", "/", "2", "3")]
    [InlineData("7", "%", "4", "3")]
    [InlineData("-5", "*", "-5", "25")]
    public void Berechne_rechnet_mit_ganzen_Zahlen(string a, string op, string b, string erwartet)
    {
        Assert.Equal(erwartet, Taschenrechner.Berechne(a, op, b));
    }

    [Theory]
    [InlineData("x", "+", "3", "Keine Zahl: x")]
    [InlineData("3", "+", "y", "Keine Zahl: y")]
    [InlineData("1.5", "*", "2", "Keine Zahl: 1.5")]
    [InlineData("", "+", "1", "Keine Zahl: ")]
    [InlineData("a", "-", "b", "Keine Zahl: a")]
    public void Berechne_meldet_Text_der_keine_Zahl_ist(string a, string op, string b, string erwartet)
    {
        Assert.Equal(erwartet, Taschenrechner.Berechne(a, op, b));
    }

    [Theory]
    [InlineData("3000000000", "+", "1")]
    [InlineData("2147483647", "+", "1")]
    [InlineData("2147483647", "*", "2")]
    [InlineData("-2147483648", "-", "1")]
    [InlineData("-2147483648", "/", "-1")]
    [InlineData("1", "+", "99999999999")]
    public void Berechne_meldet_Ueberlauf(string a, string op, string b)
    {
        Assert.Equal("Zahl zu groß", Taschenrechner.Berechne(a, op, b));
    }

    [Theory]
    [InlineData("5", "/", "0")]
    [InlineData("0", "/", "0")]
    [InlineData("5", "%", "0")]
    public void Berechne_meldet_Division_durch_null(string a, string op, string b)
    {
        Assert.Equal("Division durch null", Taschenrechner.Berechne(a, op, b));
    }

    [Theory]
    [InlineData("^")]
    [InlineData("")]
    [InlineData("plus")]
    public void Berechne_wirft_bei_unbekanntem_Operator_ArgumentException(string op)
    {
        var ex = Assert.Throws<ArgumentException>(() => Taschenrechner.Berechne("1", op, "2"));

        Assert.Equal("op", ex.ParamName);
    }

    [Fact]
    public void SummeAusText_addiert_gueltige_Zahlen_und_zaehlt_Fehler()
    {
        var (summe, fehler, arten) = Taschenrechner.SummeAusText("1;2;x;4");

        Assert.Equal(7, summe);
        Assert.Equal(1, fehler);
        Assert.Equal(new[] { "FormatException" }, arten);
    }

    [Fact]
    public void SummeAusText_unterscheidet_FormatException_und_OverflowException()
    {
        var (summe, fehler, arten) = Taschenrechner.SummeAusText("10;abc;99999999999;5;1,5");

        Assert.Equal(15, summe);
        Assert.Equal(3, fehler);
        Assert.Equal(new[] { "FormatException", "OverflowException", "FormatException" }, arten);
    }

    [Fact]
    public void SummeAusText_ohne_Fehler()
    {
        var (summe, fehler, arten) = Taschenrechner.SummeAusText("5;6;-1");

        Assert.Equal(10, summe);
        Assert.Equal(0, fehler);
        Assert.Empty(arten);
    }

    [Fact]
    public void SummeAusText_ueberspringt_leere_Teile_und_den_leeren_Text()
    {
        var (summe, fehler, arten) = Taschenrechner.SummeAusText("1;;2;");
        Assert.Equal((3, 0), (summe, fehler));
        Assert.Empty(arten);

        var leer = Taschenrechner.SummeAusText("");
        Assert.Equal(0, leer.summe);
        Assert.Equal(0, leer.fehler);
    }

    [Fact]
    public void SummeAusText_nur_Fehler()
    {
        var (summe, fehler, _) = Taschenrechner.SummeAusText("a;b;c");

        Assert.Equal(0, summe);
        Assert.Equal(3, fehler);
    }
}
