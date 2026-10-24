public class DruckauftraegeTests
{
    // ---- Texteditor ----

    [Fact]
    public void Tippe_haengt_Text_an()
    {
        var e = new Texteditor();

        e.Tippe("Hallo");
        e.Tippe(" Welt");

        Assert.Equal("Hallo Welt", e.Text);
    }

    [Fact]
    public void Neuer_Editor_ist_leer_und_hat_nichts_zurueckzunehmen()
    {
        var e = new Texteditor();

        Assert.Equal("", e.Text);
        Assert.False(e.Rueckgaengig());
        Assert.False(e.Wiederholen());
    }

    [Fact]
    public void Rueckgaengig_nimmt_die_letzte_Aenderung_zurueck()
    {
        var e = new Texteditor();
        e.Tippe("Hallo");
        e.Tippe(" Welt");

        Assert.True(e.Rueckgaengig());
        Assert.Equal("Hallo", e.Text);
        Assert.True(e.Rueckgaengig());
        Assert.Equal("", e.Text);
        Assert.False(e.Rueckgaengig());
    }

    [Fact]
    public void Wiederholen_stellt_zurueckgenommene_Aenderungen_wieder_her()
    {
        var e = new Texteditor();
        e.Tippe("a");
        e.Tippe("b");
        e.Tippe("c");
        e.Rueckgaengig();
        e.Rueckgaengig();

        Assert.True(e.Wiederholen());
        Assert.Equal("ab", e.Text);
        Assert.True(e.Wiederholen());
        Assert.Equal("abc", e.Text);
        Assert.False(e.Wiederholen());
        Assert.Equal("abc", e.Text);
    }

    [Fact]
    public void Neues_Tippen_loescht_den_Wiederholen_Stapel()
    {
        var e = new Texteditor();
        e.Tippe("a");
        e.Tippe("b");
        e.Rueckgaengig();

        e.Tippe("X");

        Assert.Equal("aX", e.Text);
        Assert.False(e.Wiederholen());
        Assert.True(e.Rueckgaengig());
        Assert.Equal("a", e.Text);
    }

    // ---- Druckwarteschlange ----

    [Fact]
    public void Auftraege_werden_in_Ankunftsreihenfolge_Seite_fuer_Seite_gedruckt()
    {
        var d = new Druckwarteschlange();
        d.Auftrag("Bericht", 2);
        d.Auftrag("Brief", 1);

        Assert.Equal(3, d.Wartend);
        Assert.Equal("Bericht 1/2", d.NaechsteSeite());
        Assert.Equal("Bericht 2/2", d.NaechsteSeite());
        Assert.Equal("Brief 1/1", d.NaechsteSeite());
        Assert.Equal(0, d.Wartend);
    }

    [Fact]
    public void Leere_Warteschlange_liefert_null()
    {
        var d = new Druckwarteschlange();

        Assert.Null(d.NaechsteSeite());

        d.Auftrag("A", 1);
        d.NaechsteSeite();

        Assert.Null(d.NaechsteSeite());
    }

    [Fact]
    public void Neuer_Auftrag_reiht_sich_hinten_an_auch_waehrend_gedruckt_wird()
    {
        var d = new Druckwarteschlange();
        d.Auftrag("A", 2);
        Assert.Equal("A 1/2", d.NaechsteSeite());

        d.Auftrag("B", 1);

        Assert.Equal("A 2/2", d.NaechsteSeite());
        Assert.Equal("B 1/1", d.NaechsteSeite());
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-3)]
    public void Auftrag_ohne_Seiten_wird_nicht_eingereiht(int seiten)
    {
        var d = new Druckwarteschlange();

        d.Auftrag("Leer", seiten);

        Assert.Equal(0, d.Wartend);
        Assert.Null(d.NaechsteSeite());
    }
}
