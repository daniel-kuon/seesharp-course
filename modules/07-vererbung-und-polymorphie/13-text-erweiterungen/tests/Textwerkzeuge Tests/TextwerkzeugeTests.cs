public class TextwerkzeugeTests
{
    [Fact]
    public void IstPalindrom_ignoriert_Gross_und_Satzzeichen()
    {
        Assert.True("Anna".IstPalindrom);
        Assert.True("Ein Esel lese nie.".IstPalindrom);
        Assert.True("Reliefpfeiler".IstPalindrom);
        Assert.True("12321".IstPalindrom);
        Assert.True("".IstPalindrom);
        Assert.False("Hallo".IstPalindrom);
        Assert.False("ab, ca".IstPalindrom);
    }

    [Fact]
    public void AnzahlWoerter_ueberspringt_mehrfache_Leerzeichen()
    {
        Assert.Equal(4, "Ein Esel lese nie.".AnzahlWoerter);
        Assert.Equal(2, "  zwei   Wörter ".AnzahlWoerter);
        Assert.Equal(0, "   ".AnzahlWoerter);
        Assert.Equal(0, "".AnzahlWoerter);
    }

    [Fact]
    public void Umgedreht_liefert_den_Text_rueckwaerts()
    {
        Assert.Equal("ollaH", "Hallo".Umgedreht());
        Assert.Equal("", "".Umgedreht());
        Assert.Equal("cba", TextExtensions.Umgedreht("abc")); // auch als statische Methode aufrufbar
    }

    [Fact]
    public void WortanfaengeGross_aendert_nur_Wortanfaenge()
    {
        Assert.Equal("Hallo Welt", "hallo welt".WortanfaengeGross());
        Assert.Equal("Hallo  Welt", "hallo  welt".WortanfaengeGross());
        Assert.Equal(" Über Allen GIPFELN", " über allen GIPFELN".WortanfaengeGross());
        Assert.Equal("", "".WortanfaengeGross());
    }

    [Fact]
    public void Wiederhole_ist_ein_statisches_Erweiterungsmitglied()
    {
        Assert.Equal("nananana", string.Wiederhole("na", 4));
        Assert.Equal("x", string.Wiederhole("x", 1));
        Assert.Equal("", string.Wiederhole("x", 0));
        Assert.Equal("", string.Wiederhole("x", -3));
    }

    [Fact]
    public void Operator_Mal_wiederholt_den_Text()
    {
        Assert.Equal("ababab", "ab" * 3);
        Assert.Equal("", "ab" * 0);
    }

    [Fact]
    public void Zaehle_ist_eine_klassische_Erweiterungsmethode()
    {
        Assert.Equal(4, "Mississippi".Zaehle('s'));
        Assert.Equal(0, "Mississippi".Zaehle('S'));
        Assert.Equal(0, "".Zaehle('a'));
    }
}
