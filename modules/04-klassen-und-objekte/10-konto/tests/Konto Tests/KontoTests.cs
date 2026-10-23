public class KontoTests
{
    [Fact]
    public void Konstruktor_setzt_Inhaber_und_Startguthaben()
    {
        var k = new Konto("Otto", 100m);

        Assert.Equal("Otto", k.Inhaber);
        Assert.Equal(100m, k.Kontostand);
    }

    [Fact]
    public void Negatives_Startguthaben_wird_zu_null()
    {
        var k = new Konto("Otto", -5m);

        Assert.Equal(0m, k.Kontostand);
    }

    [Fact]
    public void Leerer_Inhaber_wird_ignoriert()
    {
        var k = new Konto("   ");
        Assert.Equal("unbekannt", k.Inhaber);

        k.Inhaber = "Ilse";
        k.Inhaber = "";
        Assert.Equal("Ilse", k.Inhaber);
    }

    [Fact]
    public void Negativer_Dispo_wird_ignoriert()
    {
        var k = new Konto("Otto");
        k.Dispo = 200m;
        k.Dispo = -1m;

        Assert.Equal(200m, k.Dispo);
    }

    [Fact]
    public void Nummern_sind_fortlaufend_und_Anzahl_zaehlt_beide_Konstruktoren()
    {
        int vorher = Konto.Anzahl;

        var a = new Konto("A");
        var b = new Konto("B", 10m);

        Assert.True(a.Nummer >= 1000);
        Assert.Equal(a.Nummer + 1, b.Nummer);
        Assert.Equal(vorher + 2, Konto.Anzahl);
    }

    [Fact]
    public void Einzahlen_nur_positive_Betraege()
    {
        var k = new Konto("Otto", 10m);

        Assert.True(k.Einzahlen(5.50m));
        Assert.False(k.Einzahlen(0m));
        Assert.False(k.Einzahlen(-3m));
        Assert.Equal(15.50m, k.Kontostand);
    }

    [Fact]
    public void Abheben_bis_zum_Dispo()
    {
        var k = new Konto("Otto", 100m);
        k.Dispo = 50m;

        Assert.True(k.Abheben(150m));
        Assert.Equal(-50m, k.Kontostand);
        Assert.False(k.Abheben(0.01m));
        Assert.Equal(-50m, k.Kontostand);
    }

    [Fact]
    public void Abheben_ohne_Dispo_und_mit_ungueltigem_Betrag()
    {
        var k = new Konto("Otto", 20m);

        Assert.False(k.Abheben(20.01m));
        Assert.False(k.Abheben(-5m));
        Assert.Equal(20m, k.Kontostand);
    }

    [Fact]
    public void Ueberweise_bucht_auf_beiden_Konten()
    {
        var a = new Konto("A", 100m);
        var b = new Konto("B", 5m);

        Assert.True(a.Ueberweise(b, 30m));
        Assert.Equal(70m, a.Kontostand);
        Assert.Equal(35m, b.Kontostand);
    }

    [Fact]
    public void Ueberweise_scheitert_ohne_Deckung_und_an_sich_selbst()
    {
        var a = new Konto("A", 10m);
        var b = new Konto("B");

        Assert.False(a.Ueberweise(b, 11m));
        Assert.False(a.Ueberweise(a, 5m));
        Assert.Equal(10m, a.Kontostand);
        Assert.Equal(0m, b.Kontostand);
    }
}
