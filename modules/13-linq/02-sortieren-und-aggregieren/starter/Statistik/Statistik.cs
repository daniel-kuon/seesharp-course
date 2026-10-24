public static class Statistik
{
    // TODO: OrderByDescending nach Preis, dann Take(n), ToList()
    public static List<Produkt> Teuerste(IEnumerable<Produkt> produkte, int n) => throw new NotImplementedException();

    // TODO: OrderBy(Kategorie) und ThenByDescending(Preis)
    public static List<Produkt> NachKategorieDannPreis(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: Skip(seite * groesse) und Take(groesse); Seiten zählen ab 0
    public static List<Produkt> Seite(IEnumerable<Produkt> produkte, int seite, int groesse) => throw new NotImplementedException();

    // TODO: Min, Max, Average der Preise; leere Quelle: (0, 0, 0)
    public static (decimal min, decimal max, decimal mittel) Preisspanne(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: Sum von Preis * Lager
    public static decimal Lagerwert(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: Count mit Bedingung (strikt größer)
    public static int AnzahlTeurerAls(IEnumerable<Produkt> produkte, decimal grenze) => throw new NotImplementedException();

    // TODO: Chunk(n)
    public static List<Produkt[]> Pakete(IEnumerable<Produkt> produkte, int n) => throw new NotImplementedException();

    // TODO: TakeWhile, solange Lager > 0
    public static List<Produkt> BisZumErstenLeeren(IEnumerable<Produkt> produkte) => throw new NotImplementedException();
}
