using System.Reflection;
using System.Runtime.CompilerServices;

public class UmrechnerTests
{
    [Fact]
    public void Koerpertemperatur_in_Fahrenheit() => Assert.Equal(98.6, Umrechner.CelsiusInFahrenheit(37), 9);

    [Fact]
    public void Gefrierpunkt_und_Siedepunkt()
    {
        Assert.Equal(32.0, Umrechner.CelsiusInFahrenheit(0), 9);
        Assert.Equal(212.0, Umrechner.CelsiusInFahrenheit(100), 9);
        Assert.Equal(0.0, Umrechner.FahrenheitInCelsius(32), 9);
        Assert.Equal(100.0, Umrechner.FahrenheitInCelsius(212), 9);
    }

    [Fact]
    public void Minus_40_Grad_sind_gleich()
    {
        Assert.Equal(-40.0, Umrechner.CelsiusInFahrenheit(-40), 9);
        Assert.Equal(-40.0, Umrechner.FahrenheitInCelsius(-40), 9);
    }

    [Fact]
    public void Kurs_ist_eine_decimal_Konstante()
    {
        var feld = typeof(Umrechner).GetField("DmProEuro", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static);
        Assert.True(feld is not null, "Umrechner braucht eine Konstante namens DmProEuro.");
        Assert.Equal(typeof(decimal), feld.FieldType);
        // Ein const decimal landet im IL als static readonly mit DecimalConstantAttribute.
        Assert.True(feld.IsDefined(typeof(DecimalConstantAttribute)), "DmProEuro soll mit const deklariert sein.");
        Assert.Equal(1.95583m, (decimal)feld.GetValue(null)!);
    }

    [Fact]
    public void Euro_in_DM()
    {
        Assert.Equal(19.56m, Umrechner.EuroInDm(10m));
        Assert.Equal(1.96m, Umrechner.EuroInDm(1m));
    }

    [Fact]
    public void Mark_und_Pfennig_in_Euro()
    {
        Assert.Equal(51.13m, Umrechner.DmInEuro(100, 0));
        Assert.Equal(10.00m, Umrechner.DmInEuro(19, 56));
    }

    [Fact]
    public void Pfennige_gehen_nicht_verloren() => Assert.Equal(0.51m, Umrechner.DmInEuro(0, 99));

    [Fact]
    public void Kassenbon_trennt_Euro_und_Cent()
    {
        Assert.Equal("12 Euro und 34 Cent", Umrechner.Kassenbon(12.34m));
        Assert.Equal("0 Euro und 5 Cent", Umrechner.Kassenbon(0.05m));
        Assert.Equal("7 Euro und 0 Cent", Umrechner.Kassenbon(7m));
    }
}
