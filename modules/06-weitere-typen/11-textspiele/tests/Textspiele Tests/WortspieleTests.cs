public class WortspieleTests
{
    [Fact]
    public void Einfache_Palindrome()
    {
        Assert.True(Wortspiele.IstPalindrom("Lagerregal"));
        Assert.True(Wortspiele.IstPalindrom("Otto"));
        Assert.True(Wortspiele.IstPalindrom("a"));
        Assert.True(Wortspiele.IstPalindrom(""));
        Assert.False(Wortspiele.IstPalindrom("Lager"));
    }

    [Fact]
    public void Palindrom_ignoriert_Satzzeichen_Leerzeichen_und_Grossschreibung()
    {
        Assert.True(Wortspiele.IstPalindrom("Eine güldne, gute Tugend: Lüge nie!"));
        Assert.True(Wortspiele.IstPalindrom("Rentner"));
        Assert.True(Wortspiele.IstPalindrom("  ...!  "));
        Assert.False(Wortspiele.IstPalindrom("Eine gute Tugend"));
    }

    [Fact]
    public void Anagramme_werden_erkannt()
    {
        Assert.True(Wortspiele.IstAnagramm("Lampe", "Palme"));
        Assert.True(Wortspiele.IstAnagramm("Ampel", "Palme"));
        Assert.True(Wortspiele.IstAnagramm("Eber", "Rebe"));
    }

    [Fact]
    public void Anagramm_ignoriert_Grossschreibung_und_Nicht_Buchstaben()
    {
        Assert.True(Wortspiele.IstAnagramm("Ein Tor!", "Toni-Re"));
        Assert.True(Wortspiele.IstAnagramm("Dormitory", "dirty room"));
    }

    [Fact]
    public void Keine_Anagramme()
    {
        Assert.False(Wortspiele.IstAnagramm("Lampe", "Palmen"));
        Assert.False(Wortspiele.IstAnagramm("aab", "abb"));
    }

    [Fact]
    public void Kodiere_zaehlt_Laeufe()
    {
        Assert.Equal("3A1B2C", Wortspiele.Kodiere("AAABCC"));
        Assert.Equal("1a1b1a", Wortspiele.Kodiere("aba"));
        Assert.Equal("12x", Wortspiele.Kodiere("xxxxxxxxxxxx"));
        Assert.Equal("", Wortspiele.Kodiere(""));
    }

    [Fact]
    public void Dekodiere_mit_mehrstelligen_Zahlen()
    {
        Assert.Equal("AAABCC", Wortspiele.Dekodiere("3A1B2C"));
        Assert.Equal("xxxxxxxxxxxx", Wortspiele.Dekodiere("12x"));
        Assert.Equal("", Wortspiele.Dekodiere(""));
    }

    [Fact]
    public void Dekodiere_hebt_Kodiere_auf()
    {
        string text = "WWWWWWWWWWWWBWWWWWWWWWWWWBBBWWWWWWWWWWWWWWWWWWWWWWWWB  ..";

        Assert.Equal(text, Wortspiele.Dekodiere(Wortspiele.Kodiere(text)));
    }
}
