public class StringUtilTests
{
    const string Satz = "Dieser  Satz - bitte beachten - passt nicht in eine Schmal-Zeile, die nur wenige Spalten umfasst.";

    [Fact]
    public void WrapLine_haelt_die_Spaltenbreite_ein_und_verliert_kein_Wort()
    {
        var zeilen = StringUtil.WrapLine(Satz, 30);

        Assert.All(zeilen, z => Assert.True(z.Length <= 30, $"zu lang: '{z}'"));
        Assert.Equal(
            Satz.Split(' ', StringSplitOptions.RemoveEmptyEntries),
            string.Join(" ", zeilen).Split(' ', StringSplitOptions.RemoveEmptyEntries));
    }

    [Fact]
    public void WrapLine_fuellt_jede_Zeile_so_weit_wie_moeglich()
    {
        Assert.Equal(
            ["Dieser Satz - bitte beachten -", "passt nicht in eine", "Schmal-Zeile, die nur wenige", "Spalten umfasst."],
            StringUtil.WrapLine(Satz, 30));
    }

    [Fact]
    public void WrapLine_trennt_mit_hypSep_hinter_dem_Bindestrich()
    {
        Assert.Equal(
            ["Dieser Satz - bitte beachten -", "passt nicht in eine Schmal-", "Zeile, die nur wenige Spalten", "umfasst."],
            StringUtil.WrapLine(Satz, 30, true));
    }

    [Fact]
    public void WrapLine_teilt_ueberlange_Woerter_hart()
    {
        Assert.Equal(["Donaudamp", "fschiff"], StringUtil.WrapLine("Donaudampfschiff", 9));
    }

    [Fact]
    public void WrapLine_ohne_Umbruch_liefert_eine_Zeile()
    {
        Assert.Equal(["kurz und gut"], StringUtil.WrapLine("kurz und gut"));
    }

    [Fact]
    public void Glueckszahl_ist_reproduzierbar_und_liegt_zwischen_1_und_100()
    {
        var erwartet = new Random('O' + 'R').Next(100) + 1;

        Assert.Equal(erwartet, StringUtil.Glueckszahl("Otto", "Meier"));
        Assert.Equal(erwartet, StringUtil.Glueckszahl("otto", "meier"));
        Assert.InRange(StringUtil.Glueckszahl("Anna", "Zorn"), 1, 100);
    }

    [Fact]
    public void ZaehleVokale_zaehlt_gross_und_klein()
    {
        Assert.Equal(6, StringUtil.ZaehleVokale("Eine Idee"));
        Assert.Equal(0, StringUtil.ZaehleVokale("xyz"));
    }

    [Fact]
    public void Umkehren_dreht_die_Zeichen_um()
    {
        Assert.Equal("ottO", StringUtil.Umkehren("Otto"));
        Assert.Equal("", StringUtil.Umkehren(""));
    }
}
