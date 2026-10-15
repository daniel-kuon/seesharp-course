public class ArtikelTests
{
    [Fact]
    public void Gleiche_Werte_sind_gleich()
    {
        var a = new Artikel("Apfel", 3);
        var b = new Artikel("Apfel", 3);

        Assert.True(a == b);
        Assert.True(a.Equals(b));
        Assert.Equal(a.GetHashCode(), b.GetHashCode());
        Assert.False(a == new Artikel("Apfel", 4));
    }

    [Fact]
    public void ToString_zeigt_alle_Eigenschaften()
    {
        Assert.Equal("Artikel { Name = Apfel, Menge = 3 }", new Artikel("Apfel", 3).ToString());
    }

    [Fact]
    public void Positionaler_Record_laesst_sich_dekonstruieren()
    {
        var (name, menge) = new Artikel("Birne", 7);

        Assert.Equal(("Birne", 7), (name, menge));
    }

    [Fact]
    public void MitMenge_kopiert_und_laesst_das_Original_unveraendert()
    {
        var a = new Artikel("Apfel", 3);

        var c = a.MitMenge(10);

        Assert.Equal(10, c.Menge);
        Assert.Equal("Apfel", c.Name);
        Assert.Equal(3, a.Menge);
        Assert.NotSame(a, c);
    }

    [Fact]
    public void Plus_erhoeht_die_Menge_in_der_Kopie()
    {
        var a = new Artikel("Apfel", 3);

        Assert.Equal(new Artikel("Apfel", 5), a.Plus(2));
    }

    [Fact]
    public void Artikel_ist_ein_Record()
    {
        // Der Compiler erzeugt für Records eine Methode <Clone>$ (Basis des with-Ausdrucks).
        Assert.NotNull(typeof(Artikel).GetMethod("<Clone>$"));
    }
}
