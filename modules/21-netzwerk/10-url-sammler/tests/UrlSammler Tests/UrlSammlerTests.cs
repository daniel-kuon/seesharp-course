public class UrlSammlerTests
{
    private static readonly string[] Zehn =
    {
        "https://www.example.com/index.html?lang=de",
        "http://example.org/",
        "https://Example.COM/produkte?id=7&farbe=rot",
        "ftp://dateien.example.net/pub",
        "relativ/pfad.html",
        "",
        "https://shop.example.com:8443/korb#oben",
        "nur text",
        "http://example.org/kontakt",
        "https://api.example.com/v1/items?page=2&size=10",
    };

    [Fact]
    public void Hosts_liefert_die_verschiedenen_Hosts_sortiert()
    {
        Assert.Equal(
            new[] { "api.example.com", "example.com", "example.org", "shop.example.com", "www.example.com" },
            UrlSammler.Hosts(Zehn));
    }

    [Fact]
    public void Hosts_ignoriert_Grossschreibung_und_Duplikate()
    {
        var hosts = UrlSammler.Hosts(new[] { "http://A.de/x", "http://a.DE/y", "https://a.de/z" });

        Assert.Equal(new[] { "a.de" }, hosts);
    }

    [Fact]
    public void Hosts_einer_leeren_Folge_ist_leer()
    {
        Assert.Empty(UrlSammler.Hosts(Array.Empty<string>()));
        Assert.Empty(UrlSammler.Hosts(new[] { "", "kein url", "relativ/x" }));
    }

    [Theory]
    [InlineData("https://www.example.com/index.html?lang=de", "https://www.example.com/index.html")]
    [InlineData("https://Example.COM/produkte?id=7&farbe=rot", "https://example.com/produkte")]
    [InlineData("https://api.example.com/v1/items?page=2&size=10", "https://api.example.com/v1/items")]
    [InlineData("http://example.org/kontakt", "http://example.org/kontakt")]
    [InlineData("https://shop.example.com:8443/korb?a=1#oben", "https://shop.example.com:8443/korb#oben")]
    public void OhneParameter_entfernt_die_Abfrage(string url, string erwartet)
    {
        Assert.Equal(erwartet, UrlSammler.OhneParameter(url));
    }

    [Theory]
    [InlineData("relativ/pfad.html")]
    [InlineData("")]
    [InlineData("nur text")]
    [InlineData("ftp://dateien.example.net/pub")]
    public void OhneParameter_und_MitParameter_liefern_null_fuer_relative_oder_ungueltige_Eingaben(string url)
    {
        Assert.Null(UrlSammler.OhneParameter(url));
        Assert.Null(UrlSammler.MitParameter(url, "a", "1"));
    }

    [Fact]
    public void MitParameter_haengt_einen_neuen_Parameter_an()
    {
        Assert.Equal("http://example.org/kontakt?ref=mail", UrlSammler.MitParameter("http://example.org/kontakt", "ref", "mail"));
        Assert.Equal("https://example.com/produkte?id=7&farbe=rot&gr=XL",
            UrlSammler.MitParameter("https://example.com/produkte?id=7&farbe=rot", "gr", "XL"));
    }

    [Fact]
    public void MitParameter_ersetzt_einen_vorhandenen_an_derselben_Stelle()
    {
        var url = UrlSammler.MitParameter("https://api.example.com/v1/items?page=2&size=10", "page", "3");

        Assert.Equal("https://api.example.com/v1/items?page=3&size=10", url);
    }

    [Fact]
    public void MitParameter_kodiert_Name_und_Wert()
    {
        var url = UrlSammler.MitParameter("http://h/p", "suche", "Käse & Brot");

        Assert.Equal("http://h/p?suche=K%C3%A4se%20%26%20Brot", url);
    }

    [Fact]
    public void MitParameter_kodiert_vorhandene_Werte_nicht_doppelt()
    {
        var url = UrlSammler.MitParameter("http://h/p?q=a%20b%26c", "n", "1");

        Assert.Equal("http://h/p?q=a%20b%26c&n=1", url);
    }

    [Fact]
    public void MitParameter_behaelt_das_Fragment()
    {
        var url = UrlSammler.MitParameter("https://shop.example.com:8443/korb#oben", "x", "1");

        Assert.Equal("https://shop.example.com:8443/korb?x=1#oben", url);
    }

    [Fact]
    public void MitParameter_ersetzt_nur_einmal_und_auch_leere_Werte()
    {
        Assert.Equal("http://h/p?a=&b=2", UrlSammler.MitParameter("http://h/p?a=1&b=2", "a", ""));
    }
}
