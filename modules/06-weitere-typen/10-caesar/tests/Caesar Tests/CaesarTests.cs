public class CaesarTests
{
    const string Klartext = "Wer reitet so spaet durch Nacht und Wind? Es ist der Vater mit seinem Kind. "
        + "Er hat den Knaben wohl in dem Arm, er fasst ihn sicher, er haelt ihn warm.";

    [Fact]
    public void Verschluessele_verschiebt_Gross_und_Kleinbuchstaben()
    {
        Assert.Equal("DEF", Caesar.Verschluessele("ABC", 3));
        Assert.Equal("Khoor", Caesar.Verschluessele("Hello", 3));
    }

    [Fact]
    public void Verschluessele_laeuft_am_Alphabetende_herum()
    {
        Assert.Equal("ABC", Caesar.Verschluessele("XYZ", 3));
        Assert.Equal("abc", Caesar.Verschluessele("xyz", 3));
    }

    [Fact]
    public void Andere_Zeichen_bleiben_unveraendert()
    {
        Assert.Equal("Iß 3 Äpfel, Bob!", Caesar.Verschluessele("Hß 3 Äoedk, Ana!", 1));
    }

    [Fact]
    public void Negative_und_grosse_Schluessel()
    {
        Assert.Equal("XYZ", Caesar.Verschluessele("ABC", -3));
        Assert.Equal("DEF", Caesar.Verschluessele("ABC", 29));
        Assert.Equal("ABC", Caesar.Verschluessele("ABC", 26));
        Assert.Equal("XYZ", Caesar.Verschluessele("ABC", -55));
    }

    [Fact]
    public void Entschluessele_hebt_Verschluessele_auf()
    {
        foreach (int k in new[] { 0, 1, 7, 13, 25, -4, 100 })
            Assert.Equal(Klartext, Caesar.Entschluessele(Caesar.Verschluessele(Klartext, k), k));
    }

    [Fact]
    public void Haeufigkeiten_zaehlt_ohne_Gross_Kleinschreibung()
    {
        int[] h = Caesar.Haeufigkeiten("AaB zz!");

        Assert.Equal(26, h.Length);
        Assert.Equal(2, h[0]);
        Assert.Equal(1, h[1]);
        Assert.Equal(0, h[2]);
        Assert.Equal(2, h[25]);
    }

    [Fact]
    public void Knacke_findet_den_Schluessel()
    {
        Assert.Equal(3, Caesar.Knacke(Caesar.Verschluessele(Klartext, 3)));
        Assert.Equal(17, Caesar.Knacke(Caesar.Verschluessele(Klartext, 17)));
        Assert.Equal(0, Caesar.Knacke(Klartext));
    }

    [Fact]
    public void Knacke_liefert_Werte_von_0_bis_25()
    {
        Assert.Equal(22, Caesar.Knacke(Caesar.Verschluessele(Klartext, -4)));
    }
}
