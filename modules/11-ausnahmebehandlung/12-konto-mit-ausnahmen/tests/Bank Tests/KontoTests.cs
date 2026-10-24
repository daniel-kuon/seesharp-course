public class KontoTests
{
    // ---- Eigene Ausnahme ----

    [Fact]
    public void GuthabenZuNiedrig_ist_eine_InvalidOperationException_mit_Fehlbetrag()
    {
        var ex = new GuthabenZuNiedrigException(12.5m);

        Assert.IsAssignableFrom<InvalidOperationException>(ex);
        Assert.Equal(typeof(InvalidOperationException), typeof(GuthabenZuNiedrigException).BaseType);
        Assert.Equal(12.5m, ex.Fehlbetrag);
        Assert.False(string.IsNullOrWhiteSpace(ex.Message));
        Assert.NotEqual(new Exception().Message, ex.Message);
    }

    // ---- Konstruktor ----

    [Fact]
    public void Neues_Konto_hat_Startguthaben_oder_null()
    {
        Assert.Equal(0m, new Konto().Kontostand);
        Assert.Equal(50m, new Konto(50m).Kontostand);
    }

    [Fact]
    public void Negatives_Startguthaben_wirft_ArgumentOutOfRangeException()
    {
        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => new Konto(-1m));

        Assert.Equal("startguthaben", ex.ParamName);
    }

    // ---- Einzahlen ----

    [Fact]
    public void Einzahlen_erhoeht_den_Kontostand()
    {
        var k = new Konto(10m);

        k.Einzahlen(5.5m);

        Assert.Equal(15.5m, k.Kontostand);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Einzahlen_von_null_oder_negativ_wirft_und_aendert_nichts(int betrag)
    {
        var k = new Konto(10m);

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => k.Einzahlen(betrag));

        Assert.Equal("betrag", ex.ParamName);
        Assert.Equal(10m, k.Kontostand);
    }

    // ---- Abheben ----

    [Fact]
    public void Abheben_verringert_den_Kontostand_auch_bis_auf_null()
    {
        var k = new Konto(100m);

        k.Abheben(30m);
        k.Abheben(70m);

        Assert.Equal(0m, k.Kontostand);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-5)]
    public void Abheben_von_null_oder_negativ_wirft_ArgumentOutOfRangeException(int betrag)
    {
        var k = new Konto(10m);

        var ex = Assert.Throws<ArgumentOutOfRangeException>(() => k.Abheben(betrag));

        Assert.Equal("betrag", ex.ParamName);
        Assert.Equal(10m, k.Kontostand);
    }

    [Fact]
    public void Abheben_ueber_das_Guthaben_wirft_GuthabenZuNiedrigException_mit_Fehlbetrag()
    {
        var k = new Konto(40m);

        var ex = Assert.Throws<GuthabenZuNiedrigException>(() => k.Abheben(100m));

        Assert.Equal(60m, ex.Fehlbetrag);
        Assert.Equal(40m, k.Kontostand);
    }

    [Fact]
    public void GuthabenZuNiedrigException_kann_als_InvalidOperationException_gefangen_werden()
    {
        var k = new Konto(1m);

        var ex = Assert.ThrowsAny<InvalidOperationException>(() => k.Abheben(2m));

        Assert.IsType<GuthabenZuNiedrigException>(ex);
    }

    // ---- Ueberweisen ----

    [Fact]
    public void Ueberweisen_bewegt_Geld_von_einem_Konto_aufs_andere()
    {
        var von = new Konto(100m);
        var nach = new Konto(5m);

        von.Ueberweisen(nach, 40m);

        Assert.Equal(60m, von.Kontostand);
        Assert.Equal(45m, nach.Kontostand);
    }

    [Fact]
    public void Ueberweisen_an_null_wirft_ArgumentNullException_und_aendert_nichts()
    {
        var von = new Konto(100m);

        var ex = Assert.Throws<ArgumentNullException>(() => von.Ueberweisen(null!, 40m));

        Assert.Equal("ziel", ex.ParamName);
        Assert.Equal(100m, von.Kontostand);
    }

    [Fact]
    public void Ueberweisen_ohne_Deckung_laesst_beide_Konten_unveraendert()
    {
        var von = new Konto(10m);
        var nach = new Konto(5m);

        var ex = Assert.Throws<GuthabenZuNiedrigException>(() => von.Ueberweisen(nach, 25m));

        Assert.Equal(15m, ex.Fehlbetrag);
        Assert.Equal(10m, von.Kontostand);
        Assert.Equal(5m, nach.Kontostand);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Ueberweisen_mit_ungueltigem_Betrag_laesst_beide_Konten_unveraendert(int betrag)
    {
        var von = new Konto(10m);
        var nach = new Konto(5m);

        Assert.Throws<ArgumentOutOfRangeException>(() => von.Ueberweisen(nach, betrag));

        Assert.Equal(10m, von.Kontostand);
        Assert.Equal(5m, nach.Kontostand);
    }
}
