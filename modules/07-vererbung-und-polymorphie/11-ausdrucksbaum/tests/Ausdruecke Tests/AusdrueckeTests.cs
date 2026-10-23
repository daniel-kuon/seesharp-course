public class AusdrueckeTests
{
    // ((2 + 3) * 4)
    static Ausdruck Beispiel() => new Mal(new Plus(new Zahl(2), new Zahl(3)), new Zahl(4));

    [Fact]
    public void Zahl_wertet_zu_sich_selbst_aus()
    {
        Ausdruck z = new Zahl(7);

        Assert.Equal(7.0, z.Auswerten());
        Assert.Equal(1, z.Knoten);
        Assert.Equal("7", z.ToString());
    }

    [Fact]
    public void Baum_wird_rekursiv_ausgewertet()
    {
        Assert.Equal(20.0, Beispiel().Auswerten());
        Assert.Equal(8.0, new Minus(new Zahl(10), new Geteilt(new Zahl(4), new Zahl(2))).Auswerten());
        Assert.Equal(-1.0, new Minus(new Zahl(2), new Zahl(3)).Auswerten());
    }

    [Fact]
    public void ToString_setzt_Klammern()
    {
        Assert.Equal("((2 + 3) * 4)", Beispiel().ToString());
        Assert.Equal("(10 - (4 / 2))", new Minus(new Zahl(10), new Geteilt(new Zahl(4), new Zahl(2))).ToString());
    }

    [Fact]
    public void Knoten_zaehlt_alle_Knoten()
    {
        Assert.Equal(5, Beispiel().Knoten);
        Assert.Equal(3, new Plus(new Zahl(1), new Zahl(1)).Knoten);
    }

    [Fact]
    public void Auswerten_und_Knoten_sind_in_BinaererAusdruck_versiegelt()
    {
        var auswerten = typeof(BinaererAusdruck).GetMethod("Auswerten")!;
        var knoten = typeof(BinaererAusdruck).GetProperty("Knoten")!.GetMethod!;

        Assert.Equal(typeof(BinaererAusdruck), auswerten.DeclaringType);
        Assert.True(auswerten.IsFinal, "Auswerten muss in BinaererAusdruck sealed override sein");
        Assert.True(knoten.IsFinal, "Knoten muss in BinaererAusdruck sealed override sein");
        Assert.Equal(typeof(BinaererAusdruck), typeof(Mal).GetMethod("Auswerten")!.DeclaringType);
    }

    [Fact]
    public void Vereinfache_faltet_Konstanten()
    {
        var summe = new Plus(new Zahl(2), new Zahl(3)).Vereinfache();
        var produkt = new Mal(new Zahl(2), new Zahl(3)).Vereinfache();
        Ausdruck gemischt = new Plus(new Zahl(2), Beispiel());

        Assert.Equal(5.0, Assert.IsType<Zahl>(summe).Wert);
        Assert.Equal(6.0, Assert.IsType<Zahl>(produkt).Wert);
        Assert.Same(gemischt, gemischt.Vereinfache());
        Assert.IsType<Mal>(Beispiel().Vereinfache());
    }

    [Fact]
    public void Mal_vereinfacht_mit_0_und_1()
    {
        var rest = new Minus(new Zahl(10), new Zahl(4));

        Assert.Equal(0.0, Assert.IsType<Zahl>(new Mal(new Zahl(0), rest).Vereinfache()).Wert);
        Assert.Equal(0.0, Assert.IsType<Zahl>(new Mal(rest, new Zahl(0)).Vereinfache()).Wert);
        Assert.Same(rest, new Mal(new Zahl(1), rest).Vereinfache());
        Assert.Same(rest, new Mal(rest, new Zahl(1)).Vereinfache());
    }
}
