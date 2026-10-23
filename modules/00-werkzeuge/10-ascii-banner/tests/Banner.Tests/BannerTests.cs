public class BannerTests
{
    [Fact]
    public void Rahmenlinie_hat_Plus_an_den_Enden_und_Minus_dazwischen()
    {
        var linie = Banner.Rahmenlinie();
        Assert.StartsWith("+", linie);
        Assert.EndsWith("+", linie);
        Assert.All(linie[1..^1], zeichen => Assert.Equal('-', zeichen));
    }

    [Fact]
    public void Rahmenlinie_ist_mindestens_10_Zeichen_breit() => Assert.True(Banner.Rahmenlinie().Length >= 10);

    [Fact]
    public void Titelzeile_steht_zwischen_senkrechten_Strichen()
    {
        var titel = Banner.Titelzeile();
        Assert.StartsWith("|", titel);
        Assert.EndsWith("|", titel);
    }

    [Fact]
    public void Titelzeile_nennt_SeeSharp() => Assert.Contains("SeeSharp", Banner.Titelzeile());

    [Fact]
    public void Titelzeile_ist_so_breit_wie_die_Rahmenlinie() =>
        Assert.Equal(Banner.Rahmenlinie().Length, Banner.Titelzeile().Length);

    [Fact]
    public void Banner_besteht_aus_Linie_Titel_Linie()
    {
        var zeilen = Banner.Komplett().ReplaceLineEndings("\n").Trim('\n').Split('\n');
        Assert.Equal([Banner.Rahmenlinie(), Banner.Titelzeile(), Banner.Rahmenlinie()], zeilen);
    }
}
