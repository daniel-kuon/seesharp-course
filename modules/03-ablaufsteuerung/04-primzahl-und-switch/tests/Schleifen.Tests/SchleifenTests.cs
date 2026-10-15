public class SchleifenTests
{
    [Theory]
    [InlineData(2)]
    [InlineData(3)]
    [InlineData(17)]
    [InlineData(97)]
    [InlineData(7919)]
    public void Primzahlen_werden_erkannt(long n) => Assert.True(Schleifen.IstPrim(n));

    [Theory]
    [InlineData(0)]
    [InlineData(1)]
    [InlineData(4)]
    [InlineData(91)]
    [InlineData(7917)]
    public void Nicht_Primzahlen_werden_abgelehnt(long n) => Assert.False(Schleifen.IstPrim(n));

    [Fact]
    public void Wochentag_1_ist_Montag() => Assert.Equal("Montag", Schleifen.Wochentag(1));

    [Fact]
    public void Wochentag_7_ist_Sonntag() => Assert.Equal("Sonntag", Schleifen.Wochentag(7));

    [Fact]
    public void Wochentag_ausserhalb_ist_ungueltig()
    {
        Assert.Equal("ungültig", Schleifen.Wochentag(0));
        Assert.Equal("ungültig", Schleifen.Wochentag(8));
    }

    [Fact]
    public void Vokale_werden_gezaehlt()
    {
        Assert.Equal(5, Schleifen.AnzahlVokale("Programmieren"));
        Assert.Equal(5, Schleifen.AnzahlVokale("AEIOU"));
    }

    [Fact]
    public void Vokale_ohne_Treffer() => Assert.Equal(0, Schleifen.AnzahlVokale("xyz"));
}
