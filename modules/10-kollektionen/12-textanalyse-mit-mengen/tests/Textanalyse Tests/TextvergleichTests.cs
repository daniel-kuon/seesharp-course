public class TextvergleichTests
{
    const string TextA = "Der Hund bellt laut, der Hase schläft.";
    const string TextB = "Der Hase und der Hund schlafen!";

    [Fact]
    public void Woerter_liefert_verschiedene_Woerter_in_Kleinbuchstaben()
    {
        var w = Textvergleich.Woerter(TextA);

        Assert.True(w.SetEquals(new[] { "der", "hund", "bellt", "laut", "hase", "schläft" }));
        Assert.Equal(6, w.Count);
    }

    [Fact]
    public void Woerter_ignoriert_Satzzeichen_und_mehrfache_Leerzeichen()
    {
        var w = Textvergleich.Woerter("  Ja,  ja!  Nein?  ");

        Assert.True(w.SetEquals(new[] { "ja", "nein" }));
        Assert.Empty(Textvergleich.Woerter(""));
        Assert.Empty(Textvergleich.Woerter(" , . "));
    }

    [Fact]
    public void Gemeinsam_liefert_die_gemeinsamen_Woerter_alphabetisch()
    {
        var g = Textvergleich.Gemeinsam(Textvergleich.Woerter(TextA), Textvergleich.Woerter(TextB));

        Assert.Equal(new[] { "der", "hase", "hund" }, g);
    }

    [Fact]
    public void NurInA_liefert_die_Woerter_die_in_b_fehlen()
    {
        var n = Textvergleich.NurInA(Textvergleich.Woerter(TextA), Textvergleich.Woerter(TextB));

        Assert.Equal(new[] { "bellt", "laut", "schläft" }, n);
    }

    [Fact]
    public void NurInA_ist_nicht_symmetrisch()
    {
        var n = Textvergleich.NurInA(Textvergleich.Woerter(TextB), Textvergleich.Woerter(TextA));

        Assert.Equal(new[] { "schlafen", "und" }, n);
    }

    [Fact]
    public void Aehnlichkeit_ist_Schnittmenge_durch_Vereinigung()
    {
        var a = Textvergleich.Woerter(TextA);
        var b = Textvergleich.Woerter(TextB);

        // |A ∩ B| = 3 (der, hase, hund), |A ∪ B| = 8
        Assert.Equal(3.0 / 8.0, Textvergleich.Aehnlichkeit(a, b), 10);
        Assert.Equal(3.0 / 8.0, Textvergleich.Aehnlichkeit(b, a), 10);
    }

    [Fact]
    public void Aehnlichkeit_gleicher_und_verschiedener_Texte()
    {
        var a = Textvergleich.Woerter("eins zwei drei");

        Assert.Equal(1.0, Textvergleich.Aehnlichkeit(a, Textvergleich.Woerter("Drei Zwei Eins")), 10);
        Assert.Equal(0.0, Textvergleich.Aehnlichkeit(a, Textvergleich.Woerter("vier fünf")), 10);
        Assert.Equal(0.0, Textvergleich.Aehnlichkeit(new HashSet<string>(), new HashSet<string>()), 10);
    }

    [Fact]
    public void Die_Eingabemengen_bleiben_unveraendert()
    {
        var a = Textvergleich.Woerter(TextA);
        var b = Textvergleich.Woerter(TextB);

        Textvergleich.Gemeinsam(a, b);
        Textvergleich.NurInA(a, b);
        Textvergleich.Aehnlichkeit(a, b);

        Assert.Equal(6, a.Count);
        Assert.Equal(5, b.Count);
    }
}
