public static class Statistik
{
    public static List<Produkt> Teuerste(IEnumerable<Produkt> produkte, int n) =>
        produkte.OrderByDescending(p => p.Preis).Take(n).ToList();

    public static List<Produkt> NachKategorieDannPreis(IEnumerable<Produkt> produkte) =>
        produkte.OrderBy(p => p.Kategorie).ThenByDescending(p => p.Preis).ToList();

    public static List<Produkt> Seite(IEnumerable<Produkt> produkte, int seite, int groesse) =>
        produkte.Skip(seite * groesse).Take(groesse).ToList();

    public static (decimal min, decimal max, decimal mittel) Preisspanne(IEnumerable<Produkt> produkte)
    {
        var preise = produkte.Select(p => p.Preis).ToList();
        if (!preise.Any()) return (0, 0, 0);
        return (preise.Min(), preise.Max(), preise.Average());
    }

    public static decimal Lagerwert(IEnumerable<Produkt> produkte) =>
        produkte.Sum(p => p.Preis * p.Lager);

    public static int AnzahlTeurerAls(IEnumerable<Produkt> produkte, decimal grenze) =>
        produkte.Count(p => p.Preis > grenze);

    public static List<Produkt[]> Pakete(IEnumerable<Produkt> produkte, int n) =>
        produkte.Chunk(n).ToList();

    public static List<Produkt> BisZumErstenLeeren(IEnumerable<Produkt> produkte) =>
        produkte.TakeWhile(p => p.Lager > 0).ToList();
}
