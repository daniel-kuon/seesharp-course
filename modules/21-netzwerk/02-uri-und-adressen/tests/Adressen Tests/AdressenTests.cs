public class AdressenTests
{
    // ----- Zerlege -------------------------------------------------------------------------

    [Fact]
    public void Zerlege_liefert_alle_Teile_einer_https_URL()
    {
        var teile = Adressen.Zerlege("https://Example.com/a/b.html?x=1&y=2#abschnitt");

        Assert.Equal(new UrlTeile("https", "example.com", 443, "/a/b.html", "x=1&y=2"), teile);
    }

    [Fact]
    public void Zerlege_ergaenzt_Standardports()
    {
        Assert.Equal(80, Adressen.Zerlege("http://example.org/")!.Port);
        Assert.Equal(443, Adressen.Zerlege("https://example.org/")!.Port);
    }

    [Fact]
    public void Zerlege_uebernimmt_einen_ausdruecklichen_Port()
    {
        var teile = Adressen.Zerlege("http://localhost:8080/api/status");

        Assert.Equal(new UrlTeile("http", "localhost", 8080, "/api/status", ""), teile);
    }

    [Fact]
    public void Zerlege_ohne_Pfad_und_Abfrage()
    {
        var teile = Adressen.Zerlege("http://example.org");

        Assert.Equal("/", teile!.Pfad);
        Assert.Equal("", teile.Abfrage);
    }

    [Theory]
    [InlineData("")]
    [InlineData("nur text")]
    [InlineData("relativ/pfad.html")]
    [InlineData("http://")]
    public void Zerlege_liefert_null_fuer_ungueltige_oder_relative_Eingaben(string url)
    {
        Assert.Null(Adressen.Zerlege(url));
    }

    // ----- Baue ----------------------------------------------------------------------------

    [Fact]
    public void Baue_kodiert_Sonderzeichen_mit_Prozentzeichen()
    {
        var url = Adressen.Baue("http://example.org/suche", new() { ["q"] = "a b&c" });

        Assert.Equal("http://example.org/suche?q=a%20b%26c", url);
    }

    [Fact]
    public void Baue_behaelt_die_Einfuegereihenfolge()
    {
        var url = Adressen.Baue("http://h/p", new() { ["z"] = "1", ["a"] = "2", ["m"] = "3" });

        Assert.Equal("http://h/p?z=1&a=2&m=3", url);
    }

    [Fact]
    public void Baue_kodiert_Umlaute_und_Namen()
    {
        var url = Adressen.Baue("https://h/p", new() { ["größe"] = "Käse=lecker" });

        Assert.Equal("https://h/p?gr%C3%B6%C3%9Fe=K%C3%A4se%3Dlecker", url);
    }

    [Fact]
    public void Baue_ohne_Parameter_liefert_die_Basis_unveraendert()
    {
        Assert.Equal("http://h/p", Adressen.Baue("http://h/p", new()));
    }

    [Fact]
    public void Baue_haengt_an_eine_vorhandene_Abfrage_an()
    {
        var url = Adressen.Baue("http://h/p?a=1", new() { ["b"] = "2" });

        Assert.Equal("http://h/p?a=1&b=2", url);
    }

    [Fact]
    public void Baue_mit_ungueltiger_Basis_wirft_UriFormatException()
    {
        Assert.Throws<UriFormatException>(() => Adressen.Baue("keine url", new() { ["a"] = "1" }));
    }

    // ----- Parameter -----------------------------------------------------------------------

    [Fact]
    public void Parameter_dekodiert_die_Abfrage()
    {
        var p = Adressen.Parameter("http://h/p?q=a%20b%26c&n=1");

        Assert.Equal(2, p.Count);
        Assert.Equal("a b&c", p["q"]);
        Assert.Equal("1", p["n"]);
    }

    [Fact]
    public void Parameter_ist_die_Umkehrung_von_Baue()
    {
        var original = new Dictionary<string, string> { ["größe"] = "Käse=lecker & mehr", ["leer"] = "", ["n"] = "42" };

        var url = Adressen.Baue("https://h/p", original);

        Assert.Equal(original, Adressen.Parameter(url));
    }

    [Fact]
    public void Parameter_ohne_Abfrage_ist_leer_und_Fragment_wird_ignoriert()
    {
        Assert.Empty(Adressen.Parameter("http://h/p"));
        Assert.Equal("1", Adressen.Parameter("http://h/p?a=1#x=2")["a"]);
        Assert.Single(Adressen.Parameter("http://h/p?a=1#x=2"));
    }

    [Fact]
    public void Parameter_ohne_Gleichheitszeichen_hat_den_Wert_leer_und_doppelte_Namen_der_letzte()
    {
        var p = Adressen.Parameter("http://h/p?flag&a=1&a=2");

        Assert.Equal("", p["flag"]);
        Assert.Equal("2", p["a"]);
    }

    [Fact]
    public void Parameter_trennt_nur_am_ersten_Gleichheitszeichen()
    {
        Assert.Equal("x=y", Adressen.Parameter("http://h/p?a=x%3Dy")["a"]);
        Assert.Equal("x=y", Adressen.Parameter("http://h/p?a=x=y")["a"]);
    }

    // ----- TryAbsolut ----------------------------------------------------------------------

    [Fact]
    public void TryAbsolut_erkennt_absolute_Adressen()
    {
        Assert.True(Adressen.TryAbsolut("https://example.org/a?b=c", out var uri));
        Assert.NotNull(uri);
        Assert.Equal("example.org", uri!.Host);
    }

    [Theory]
    [InlineData("relativ/pfad.html")]
    [InlineData("nur text")]
    [InlineData("")]
    [InlineData(null)]
    public void TryAbsolut_lehnt_andere_Eingaben_ab(string? s)
    {
        Assert.False(Adressen.TryAbsolut(s, out var uri));
        Assert.Null(uri);
    }

    // ----- IstLokal ------------------------------------------------------------------------

    [Theory]
    [InlineData("127.0.0.1")]
    [InlineData("127.0.0.2")]
    [InlineData("::1")]
    [InlineData("10.0.0.5")]
    [InlineData("10.255.255.255")]
    [InlineData("172.16.0.1")]
    [InlineData("172.31.255.255")]
    [InlineData("192.168.1.20")]
    public void IstLokal_ist_true_fuer_Loopback_und_private_Bereiche(string ip)
    {
        Assert.True(Adressen.IstLokal(ip));
    }

    [Theory]
    [InlineData("8.8.8.8")]
    [InlineData("172.15.0.1")]
    [InlineData("172.32.0.1")]
    [InlineData("192.169.0.1")]
    [InlineData("11.0.0.1")]
    [InlineData("2001:db8::1")]
    public void IstLokal_ist_false_fuer_oeffentliche_Adressen(string ip)
    {
        Assert.False(Adressen.IstLokal(ip));
    }

    [Theory]
    [InlineData("")]
    [InlineData("abc")]
    [InlineData("999.1.1.1")]
    [InlineData("1.2.3.4.5")]
    public void IstLokal_ist_false_fuer_unlesbare_Eingaben(string ip)
    {
        Assert.False(Adressen.IstLokal(ip));
    }

    // ----- DNS -----------------------------------------------------------------------------

    [Fact]
    public void Localhost_wird_zu_einer_Loopback_Adresse_aufgeloest()
    {
        Assert.True(Adressen.LoopbackAufgeloest());
    }
}
