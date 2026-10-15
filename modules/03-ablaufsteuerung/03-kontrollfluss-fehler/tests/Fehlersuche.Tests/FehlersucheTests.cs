public class FehlersucheTests
{
    [Fact]
    public void Durch_13_teilbar_gewinnt_100() => Assert.Equal(100, Fehlersuche.Gewinn(26));

    [Fact]
    public void Nur_durch_7_teilbar_gewinnt_1() => Assert.Equal(1, Fehlersuche.Gewinn(14));

    [Fact]
    public void Durch_7_und_13_teilbar_gewinnt_100() => Assert.Equal(100, Fehlersuche.Gewinn(91));

    [Fact]
    public void Sonst_gewinnt_nichts() => Assert.Equal(0, Fehlersuche.Gewinn(3));

    [Fact]
    public void Beschreibe_false() => Assert.Equal("b ist False", Fehlersuche.Beschreibe(false));

    [Fact]
    public void Beschreibe_true() => Assert.Equal("b ist True", Fehlersuche.Beschreibe(true));
}
