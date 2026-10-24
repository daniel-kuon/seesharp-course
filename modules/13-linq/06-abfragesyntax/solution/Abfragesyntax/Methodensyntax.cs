// Fertig: dieselben Abfragen in Methodensyntax. Nicht ändern.
public static class Methodensyntax
{
    public static List<string> Teuer(IEnumerable<Produkt> produkte, decimal grenze) =>
        produkte.Where(p => p.Preis > grenze).OrderBy(p => p.Name).Select(p => p.Name).ToList();

    public static List<(string Name, decimal Brutto)> MitMehrwertsteuer(IEnumerable<Produkt> produkte) =>
        produkte
            .Select(p => new { p, Brutto = p.Preis * 1.19m })
            .Where(x => x.Brutto > 20m)
            .Select(x => (x.p.Name, x.Brutto))
            .ToList();

    public static List<(string Kategorie, int Anzahl)> GroessteKategorien(IEnumerable<Produkt> produkte) =>
        produkte
            .GroupBy(p => p.Kategorie)
            .Where(g => g.Count() > 1)
            .OrderByDescending(g => g.Count())
            .ThenBy(g => g.Key)
            .Select(g => (g.Key, g.Count()))
            .ToList();

    public static List<(string Name, decimal Betrag)> KundenMitBestellung(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        kunden.Join(bestellungen, k => k.Id, b => b.KundeId, (k, b) => (k.Name, b.Betrag)).ToList();

    public static List<(string Name, decimal Summe)> KundenSummen(
        IEnumerable<Kunde> kunden, IEnumerable<Bestellung> bestellungen) =>
        kunden
            .GroupJoin(bestellungen, k => k.Id, b => b.KundeId, (k, bs) => (k.Name, bs.Sum(b => b.Betrag)))
            .ToList();
}
