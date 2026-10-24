public class WarteschlangenTests
{
    // ---- Druckerwarteschlange ----

    [Fact]
    public void Warteschlange_liefert_in_Ankunftsreihenfolge()
    {
        var q = new Druckerwarteschlange();
        q.Einreihen("A");
        q.Einreihen("B");
        q.Einreihen("C");

        Assert.Equal(3, q.Anzahl);
        Assert.Equal("A", q.Naechster());
        Assert.Equal("B", q.Naechster());
        Assert.Equal(1, q.Anzahl);
        Assert.Equal("C", q.Naechster());
        Assert.Equal(0, q.Anzahl);
    }

    [Fact]
    public void Warteschlange_leer_liefert_null_statt_Ausnahme()
    {
        var q = new Druckerwarteschlange();

        Assert.Null(q.Naechster());
        Assert.Null(q.Peek());
        Assert.Equal(0, q.Anzahl);
    }

    [Fact]
    public void Peek_entnimmt_nichts()
    {
        var q = new Druckerwarteschlange();
        q.Einreihen("A");
        q.Einreihen("B");

        Assert.Equal("A", q.Peek());
        Assert.Equal("A", q.Peek());
        Assert.Equal(2, q.Anzahl);
    }

    [Fact]
    public void Warteschlange_kann_nach_dem_Leeren_weiterverwendet_werden()
    {
        var q = new Druckerwarteschlange();
        q.Einreihen("A");
        q.Naechster();
        q.Naechster();
        q.Einreihen("B");

        Assert.Equal("B", q.Naechster());
    }

    // ---- KlammernPruefer ----

    [Theory]
    [InlineData("([]{})", true)]
    [InlineData("", true)]
    [InlineData("kein Klammerzeichen", true)]
    [InlineData("a(b[c]{d})e", true)]
    [InlineData("{[()()]}", true)]
    [InlineData("([)]", false)]
    [InlineData("((", false)]
    [InlineData("))", false)]
    [InlineData(")(", false)]
    [InlineData("}", false)]
    [InlineData("{(})", false)]
    public void Klammern_werden_richtig_geprueft(string text, bool erwartet)
    {
        Assert.Equal(erwartet, KlammernPruefer.IstAusgeglichen(text));
    }

    // ---- Verlauf ----

    [Fact]
    public void Verlauf_vor_dem_ersten_Besuch_ist_leer()
    {
        var v = new Verlauf();

        Assert.Null(v.Aktuell);
        Assert.Null(v.Zurueck());
        Assert.Null(v.Vor());
    }

    [Fact]
    public void Verlauf_zurueck_und_vor()
    {
        var v = new Verlauf();
        v.Besuche("a");
        v.Besuche("b");
        v.Besuche("c");

        Assert.Equal("c", v.Aktuell);
        Assert.Equal("b", v.Zurueck());
        Assert.Equal("a", v.Zurueck());
        Assert.Null(v.Zurueck());
        Assert.Equal("a", v.Aktuell);
        Assert.Equal("b", v.Vor());
        Assert.Equal("c", v.Vor());
        Assert.Null(v.Vor());
        Assert.Equal("c", v.Aktuell);
    }

    [Fact]
    public void Neuer_Besuch_loescht_den_Vor_Stapel()
    {
        var v = new Verlauf();
        v.Besuche("a");
        v.Besuche("b");
        v.Zurueck();

        v.Besuche("x");

        Assert.Equal("x", v.Aktuell);
        Assert.Null(v.Vor());
        Assert.Equal("a", v.Zurueck());
    }

    // ---- ZuletztGeoeffnet ----

    [Fact]
    public void Zuletzt_geoeffnet_stellt_den_neuesten_Namen_nach_vorn()
    {
        var z = new ZuletztGeoeffnet(5);
        z.Oeffne("a");
        z.Oeffne("b");
        z.Oeffne("c");

        Assert.Equal(new[] { "c", "b", "a" }, z.Liste());
    }

    [Fact]
    public void Zuletzt_geoeffnet_verschiebt_vorhandene_Namen()
    {
        var z = new ZuletztGeoeffnet(5);
        z.Oeffne("a");
        z.Oeffne("b");
        z.Oeffne("c");
        z.Oeffne("a");

        Assert.Equal(new[] { "a", "c", "b" }, z.Liste());
    }

    [Fact]
    public void Zuletzt_geoeffnet_wirft_den_aeltesten_Namen_bei_voller_Liste_raus()
    {
        var z = new ZuletztGeoeffnet(3);
        z.Oeffne("a");
        z.Oeffne("b");
        z.Oeffne("c");
        z.Oeffne("d");

        Assert.Equal(new[] { "d", "c", "b" }, z.Liste());
    }

    [Fact]
    public void Zuletzt_geoeffnet_erneutes_Oeffnen_bei_voller_Liste_wirft_nichts_raus()
    {
        var z = new ZuletztGeoeffnet(3);
        z.Oeffne("a");
        z.Oeffne("b");
        z.Oeffne("c");
        z.Oeffne("b");

        Assert.Equal(new[] { "b", "c", "a" }, z.Liste());
    }

    [Fact]
    public void Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge()
    {
        var z = new ZuletztGeoeffnet(4);
        z.Oeffne("a");
        z.Oeffne("b");
        z.Oeffne("c");

        Assert.Equal(new[] { "a", "b", "c" }, z.ListeRueckwaerts());
        Assert.Empty(new ZuletztGeoeffnet(2).ListeRueckwaerts());
    }
}
