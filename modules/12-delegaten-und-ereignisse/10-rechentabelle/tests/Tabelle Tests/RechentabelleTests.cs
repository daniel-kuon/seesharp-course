public class RechentabelleTests
{
    [Fact]
    public void Berechne_ruft_die_registrierte_Operation_auf()
    {
        var t = new Rechentabelle();
        t.Registriere("plus", (a, b) => a + b);
        t.Registriere("mal", (a, b) => a * b);

        Assert.Equal(7, t.Berechne("plus", 3, 4));
        Assert.Equal(12, t.Berechne("mal", 3, 4));
    }

    [Fact]
    public void Unbekannter_Name_liefert_NaN()
    {
        var t = new Rechentabelle();

        Assert.True(double.IsNaN(t.Berechne("gibt es nicht", 1, 2)));
    }

    [Fact]
    public void Registriere_ueberschreibt()
    {
        var t = new Rechentabelle();
        t.Registriere("op", (a, b) => a + b);
        t.Registriere("op", (a, b) => a - b);

        Assert.Equal(-1, t.Berechne("op", 1, 2));
    }

    [Fact]
    public void Tabelle_ist_ein_Einmaleins()
    {
        var t = new Rechentabelle();
        t.Registriere("mal", (a, b) => a * b);

        double[,] gitter = t.Tabelle("mal", 1, 3);

        Assert.Equal(3, gitter.GetLength(0));
        Assert.Equal(3, gitter.GetLength(1));
        Assert.Equal(1, gitter[0, 0]);
        Assert.Equal(6, gitter[1, 2]);
        Assert.Equal(6, gitter[2, 1]);
        Assert.Equal(9, gitter[2, 2]);
    }

    [Fact]
    public void Tabelle_mit_Subtraktion()
    {
        var t = new Rechentabelle();
        t.Registriere("minus", (a, b) => a - b);

        double[,] gitter = t.Tabelle("minus", 5, 6);

        Assert.Equal(0, gitter[0, 0]);
        Assert.Equal(-1, gitter[0, 1]);   // Zeile 5, Spalte 6
        Assert.Equal(1, gitter[1, 0]);    // Zeile 6, Spalte 5
    }

    [Fact]
    public void Tabelle_mit_leerem_Bereich()
    {
        var t = new Rechentabelle();
        t.Registriere("plus", (a, b) => a + b);

        double[,] gitter = t.Tabelle("plus", 5, 4);

        Assert.Equal(0, gitter.GetLength(0));
        Assert.Equal(0, gitter.GetLength(1));
    }

    [Fact]
    public void Tabelle_mit_unbekanntem_Namen()
    {
        var t = new Rechentabelle();

        double[,] gitter = t.Tabelle("nope", 1, 2);

        Assert.Equal(2, gitter.GetLength(0));
        Assert.True(double.IsNaN(gitter[0, 0]));
        Assert.True(double.IsNaN(gitter[1, 1]));
    }
}
