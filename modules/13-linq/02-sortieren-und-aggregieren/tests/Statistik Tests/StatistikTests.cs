public class StatistikTests
{
    private static List<Produkt> Daten() =>
    [
        new("Stift", "Büro", 1.20m, 100),
        new("Heft", "Büro", 2.50m, 0),
        new("Lampe", "Möbel", 12.50m, 5),
        new("Stuhl", "Möbel", 89.90m, 2),
        new("Tisch", "Möbel", 199m, 0),
        new("Kaffee", "Küche", 7.99m, 40),
        new("Leuchte", "Möbel", 12.50m, 3),
    ];

    private static IEnumerable<string> Namen(IEnumerable<Produkt> ps) => ps.Select(p => p.Name);

    [Fact]
    public void Teuerste_sortiert_absteigend_und_behaelt_bei_Gleichstand_die_Quellreihenfolge()
    {
        Assert.Equal(["Tisch", "Stuhl", "Lampe", "Leuchte"], Namen(Statistik.Teuerste(Daten(), 4)));
        Assert.Equal(["Tisch"], Namen(Statistik.Teuerste(Daten(), 1)));
        Assert.Equal(7, Statistik.Teuerste(Daten(), 100).Count);
        Assert.Empty(Statistik.Teuerste(Daten(), 0));
    }

    [Fact]
    public void NachKategorieDannPreis_sortiert_zweistufig()
    {
        Assert.Equal(
            ["Heft", "Stift", "Kaffee", "Tisch", "Stuhl", "Lampe", "Leuchte"],
            Namen(Statistik.NachKategorieDannPreis(Daten())));
    }

    [Fact]
    public void Seite_liefert_die_gewuenschte_Seite()
    {
        var daten = Daten();

        Assert.Equal(["Stift", "Heft", "Lampe"], Namen(Statistik.Seite(daten, 0, 3)));
        Assert.Equal(["Stuhl", "Tisch", "Kaffee"], Namen(Statistik.Seite(daten, 1, 3)));
        Assert.Equal(["Leuchte"], Namen(Statistik.Seite(daten, 2, 3)));
        Assert.Empty(Statistik.Seite(daten, 3, 3));
    }

    [Fact]
    public void Preisspanne_liefert_Minimum_Maximum_und_Mittel()
    {
        var ps = new List<Produkt> { new("A", "x", 10m, 1), new("B", "x", 20m, 1), new("C", "x", 60m, 1) };

        Assert.Equal((10m, 60m, 30m), Statistik.Preisspanne(ps));
    }

    [Fact]
    public void Preisspanne_einer_leeren_Quelle_ist_null()
    {
        Assert.Equal((0m, 0m, 0m), Statistik.Preisspanne([]));
    }

    [Fact]
    public void Lagerwert_summiert_Preis_mal_Lager()
    {
        Assert.Equal(719.4m, Statistik.Lagerwert(Daten()));
        Assert.Equal(0m, Statistik.Lagerwert([]));
    }

    [Fact]
    public void AnzahlTeurerAls_zaehlt_strikt_groesser()
    {
        Assert.Equal(4, Statistik.AnzahlTeurerAls(Daten(), 10m));
        Assert.Equal(2, Statistik.AnzahlTeurerAls(Daten(), 12.50m));
        Assert.Equal(0, Statistik.AnzahlTeurerAls(Daten(), 500m));
    }

    [Fact]
    public void Pakete_teilt_in_Gruppen()
    {
        var pakete = Statistik.Pakete(Daten(), 3);

        Assert.Equal([3, 3, 1], pakete.Select(p => p.Length));
        Assert.Equal(["Stift", "Heft", "Lampe"], Namen(pakete[0]));
        Assert.Equal(["Leuchte"], Namen(pakete[2]));
        Assert.Empty(Statistik.Pakete([], 3));
    }

    [Fact]
    public void BisZumErstenLeeren_endet_beim_ersten_Produkt_ohne_Lager()
    {
        Assert.Equal(["Stift"], Namen(Statistik.BisZumErstenLeeren(Daten())));

        var voll = new List<Produkt> { new("A", "x", 1m, 1), new("B", "x", 1m, 2) };
        Assert.Equal(["A", "B"], Namen(Statistik.BisZumErstenLeeren(voll)));

        var leerZuerst = new List<Produkt> { new("A", "x", 1m, 0), new("B", "x", 1m, 2) };
        Assert.Empty(Statistik.BisZumErstenLeeren(leerZuerst));
    }

    [Fact]
    public void Die_Quelle_bleibt_unveraendert()
    {
        var quelle = Daten();

        Statistik.Teuerste(quelle, 3);
        Statistik.NachKategorieDannPreis(quelle);
        Statistik.Seite(quelle, 1, 2);

        Assert.Equal(Daten(), quelle);
    }
}
