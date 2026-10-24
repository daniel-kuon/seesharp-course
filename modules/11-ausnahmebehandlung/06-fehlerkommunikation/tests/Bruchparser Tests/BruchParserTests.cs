public class BruchParserTests
{
    // ---- Parse (Ausnahmen) ----

    [Theory]
    [InlineData("3/4", 3, 4)]
    [InlineData("-1/2", -1, 2)]
    [InlineData("0/5", 0, 5)]
    [InlineData("7/-3", 7, -3)]
    public void Parse_liest_gueltige_Brueche(string text, int zaehler, int nenner)
    {
        var b = BruchParser.Parse(text);

        Assert.Equal(zaehler, b.Zaehler);
        Assert.Equal(nenner, b.Nenner);
    }

    [Theory]
    [InlineData("3/")]
    [InlineData("/3")]
    [InlineData("a/b")]
    [InlineData("1.5/2")]
    [InlineData("3")]
    [InlineData("")]
    [InlineData("1/2/3")]
    public void Parse_wirft_FormatException_bei_ungueltigem_Format(string text)
    {
        Assert.Throws<FormatException>(() => BruchParser.Parse(text));
    }

    [Fact]
    public void Parse_wirft_ArgumentException_bei_Nenner_null()
    {
        Assert.Throws<ArgumentException>(() => BruchParser.Parse("1/0"));
    }

    // ---- TryParse (Try-Muster) ----

    [Theory]
    [InlineData("3/4", 3, 4)]
    [InlineData("-1/2", -1, 2)]
    public void TryParse_liefert_true_und_den_Bruch(string text, int zaehler, int nenner)
    {
        bool ok = BruchParser.TryParse(text, out Bruch? b);

        Assert.True(ok);
        Assert.NotNull(b);
        Assert.Equal(zaehler, b.Zaehler);
        Assert.Equal(nenner, b.Nenner);
    }

    [Theory]
    [InlineData(null)]
    [InlineData("")]
    [InlineData("/")]
    [InlineData("3/")]
    [InlineData("/3")]
    [InlineData("a/b")]
    [InlineData("1/0")]
    [InlineData("1/2/3")]
    [InlineData("99999999999/1")]
    [InlineData("1/99999999999")]
    [InlineData("1.5/2")]
    public void TryParse_liefert_false_und_wirft_nie(string? text)
    {
        bool ok = BruchParser.TryParse(text, out Bruch? b);

        Assert.False(ok);
        Assert.Null(b);
    }

    // ---- Rückgabecode oder Ausnahme ----

    [Theory]
    [InlineData(12, 4, 3)]
    [InlineData(-9, 3, -3)]
    [InlineData(0, 5, 0)]
    public void TeileRc_meldet_Erfolg_mit_0_und_liefert_das_Ergebnis(int a, int b, int erwartet)
    {
        int rc = BruchParser.TeileRc(a, b, out int ergebnis);

        Assert.Equal(0, rc);
        Assert.Equal(erwartet, ergebnis);
    }

    [Fact]
    public void TeileRc_meldet_Division_durch_null_mit_1()
    {
        int rc = BruchParser.TeileRc(5, 0, out int ergebnis);

        Assert.Equal(1, rc);
        Assert.Equal(0, ergebnis);
    }

    [Fact]
    public void Teile_liefert_das_Ergebnis_und_wirft_bei_null()
    {
        Assert.Equal(3, BruchParser.Teile(12, 4));
        Assert.Throws<DivideByZeroException>(() => BruchParser.Teile(5, 0));
    }

    // ---- Viele Eingaben: beide Wege müssen dasselbe zählen ----

    [Fact]
    public void ParseAlle_zaehlt_gueltige_und_ungueltige_Eingaben()
    {
        string[] eingaben = { "1/2", "x", "3/4", "1/0", "5/", "-7/9", "99999999999/1", "a/b", "2/3" };

        Assert.Equal((4, 5), BruchParser.ParseAlleMitAusnahmen(eingaben));
        Assert.Equal((4, 5), BruchParser.ParseAlleMitTry(eingaben));
    }

    [Fact]
    public void ParseAlle_mit_vielen_fehlerhaften_Eingaben_stimmt_in_beiden_Varianten()
    {
        var eingaben = new string[2000];
        for (int i = 0; i < eingaben.Length; i++)
            eingaben[i] = i % 4 == 0 ? "1/" + (i + 1) : "kein Bruch";

        var mitAusnahmen = BruchParser.ParseAlleMitAusnahmen(eingaben);
        var mitTry = BruchParser.ParseAlleMitTry(eingaben);

        Assert.Equal((500, 1500), mitAusnahmen);
        Assert.Equal(mitAusnahmen, mitTry);
    }

    [Fact]
    public void ParseAlle_ohne_Eingaben()
    {
        Assert.Equal((0, 0), BruchParser.ParseAlleMitAusnahmen(Array.Empty<string>()));
        Assert.Equal((0, 0), BruchParser.ParseAlleMitTry(Array.Empty<string>()));
    }
}
