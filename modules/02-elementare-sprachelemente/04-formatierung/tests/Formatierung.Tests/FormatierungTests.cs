public class FormatierungTests
{
    [Fact]
    public void SummeText_rechnet_in_Klammern() => Assert.Equal("3 + 2 = 5", Formatierung.SummeText());

    [Fact]
    public void Bruchzeile_interpoliert() => Assert.Equal("3/4", Formatierung.Bruchzeile(3, 4));

    [Fact]
    public void Ausgerichtet_rechts_und_linksbuendig()
    {
        var erwartet = "Rechtsbündig:\n\ti = 4711\n\tj =  471\n\tk =   47\n\tm =    4" +
                       "\n\nLinksbündig:\n\t4711 (i)\n\t471  (j)\n\t47   (k)\n\t4    (m)";

        Assert.Equal(erwartet, Formatierung.Ausgerichtet(4711, 471, 47, 4));
    }
}
