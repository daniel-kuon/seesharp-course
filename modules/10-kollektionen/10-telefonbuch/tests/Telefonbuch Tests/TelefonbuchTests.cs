public class TelefonbuchTests
{
    static Telefonbuch Beispiel()
    {
        var buch = new Telefonbuch();
        buch.Setze("Cem", "030 555");
        buch.Setze("Ann", "040 111");
        buch.Setze("Ben", "030 222");
        return buch;
    }

    [Fact]
    public void Suche_findet_vorhandene_Namen()
    {
        var buch = Beispiel();

        Assert.Equal("040 111", buch.Suche("Ann"));
        Assert.Equal("030 555", buch.Suche("Cem"));
    }

    [Fact]
    public void Suche_liefert_null_fuer_unbekannte_Namen()
    {
        var buch = Beispiel();

        Assert.Null(buch.Suche("Zoe"));
        Assert.Null(new Telefonbuch().Suche("Ann"));
    }

    [Fact]
    public void Setze_ueberschreibt_vorhandene_Eintraege()
    {
        var buch = Beispiel();

        buch.Setze("Ann", "999");

        Assert.Equal("999", buch.Suche("Ann"));
        Assert.Equal(3, buch.Namen().Count);
    }

    [Fact]
    public void Namen_sind_alphabetisch_sortiert()
    {
        Assert.Equal(new[] { "Ann", "Ben", "Cem" }, Beispiel().Namen());
        Assert.Empty(new Telefonbuch().Namen());
    }

    [Fact]
    public void MitVorwahl_listet_passende_Namen_sortiert()
    {
        var buch = Beispiel();

        Assert.Equal(new[] { "Ben", "Cem" }, buch.MitVorwahl("030"));
        Assert.Equal(new[] { "Ann" }, buch.MitVorwahl("040"));
    }

    [Fact]
    public void MitVorwahl_ohne_Treffer_ist_leer()
    {
        Assert.Empty(Beispiel().MitVorwahl("089"));
        Assert.Empty(new Telefonbuch().MitVorwahl("030"));
    }

    [Fact]
    public void Entferne_meldet_ob_etwas_entfernt_wurde()
    {
        var buch = Beispiel();

        Assert.True(buch.Entferne("Ben"));
        Assert.False(buch.Entferne("Ben"));
        Assert.False(buch.Entferne("Zoe"));
        Assert.Null(buch.Suche("Ben"));
        Assert.Equal(new[] { "Ann", "Cem" }, buch.Namen());
    }
}
