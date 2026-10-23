public class AbschiedTests
{
    [Fact]
    public void Text_liefert_Tschuess_SeeSharp() => Assert.Equal("Tschüss, SeeSharp!", Abschied.Text());

    [Fact]
    public void Unterschrift_liefert_Bis_morgen() => Assert.Equal("Bis morgen!", Abschied.Unterschrift());
}
