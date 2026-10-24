using Musterabgleich;

public class MusterTests
{
    [Theory]
    [InlineData(-1, Kategorie.Ungueltig)]
    [InlineData(0, Kategorie.Kind)]
    [InlineData(12, Kategorie.Kind)]
    [InlineData(13, Kategorie.Jugendlicher)]
    [InlineData(17, Kategorie.Jugendlicher)]
    [InlineData(18, Kategorie.Erwachsener)]
    [InlineData(64, Kategorie.Erwachsener)]
    [InlineData(65, Kategorie.Senior)]
    [InlineData(150, Kategorie.Senior)]
    [InlineData(151, Kategorie.Ungueltig)]
    public void Alterskategorie_an_den_Grenzen(int alter, Kategorie erwartet)
    {
        Assert.Equal(erwartet, Muster.Alterskategorie(alter));
    }

    [Fact]
    public void Beschreibe_erkennt_null_und_Ganzzahlen()
    {
        Assert.Equal("null", Muster.Beschreibe(null));
        Assert.Equal("Ganzzahl 5", Muster.Beschreibe(5));
        Assert.Equal("Ganzzahl -3", Muster.Beschreibe(-3));
    }

    [Fact]
    public void Beschreibe_erkennt_Text()
    {
        Assert.Equal("Text mit 4 Zeichen", Muster.Beschreibe("abcd"));
        Assert.Equal("Text mit 0 Zeichen", Muster.Beschreibe(""));
    }

    [Fact]
    public void Beschreibe_erkennt_Dezimalzahlen()
    {
        Assert.Equal("Dezimalzahl", Muster.Beschreibe(1.5));
        Assert.Equal("Dezimalzahl", Muster.Beschreibe(1.5f));
        Assert.Equal("Dezimalzahl", Muster.Beschreibe(1.5m));
    }

    [Fact]
    public void Beschreibe_kennt_den_Rest_nicht()
    {
        Assert.Equal("unbekannt", Muster.Beschreibe(new object()));
        Assert.Equal("unbekannt", Muster.Beschreibe('x'));
        Assert.Equal("unbekannt", Muster.Beschreibe(5L));
    }

    [Theory]
    [InlineData('a', true)]
    [InlineData('z', true)]
    [InlineData('A', true)]
    [InlineData('Z', true)]
    [InlineData('_', true)]
    [InlineData('0', false)]
    [InlineData('-', false)]
    [InlineData('ä', false)]
    [InlineData('{', false)]
    [InlineData('@', false)]
    public void IstIdentifierZeichen_prueft_die_Bereiche(char c, bool erwartet)
    {
        Assert.Equal(erwartet, Muster.IstIdentifierZeichen(c));
    }

    [Fact]
    public void IstPositiv_behandelt_null_und_Grenzwerte()
    {
        Assert.False(Muster.IstPositiv(null));
        Assert.False(Muster.IstPositiv(0));
        Assert.False(Muster.IstPositiv(-5));
        Assert.True(Muster.IstPositiv(1));
        Assert.True(Muster.IstPositiv(int.MaxValue));
    }
}
