using System.Globalization;

public static class Abfragen
{
    private static readonly NumberFormatInfo Deutsch = new() { NumberDecimalSeparator = "," };

    // vorgegeben: 12.5m -> "12,50 EUR", unabhängig von der Spracheinstellung des Rechners
    public static string Euro(decimal preis) => preis.ToString("F2", Deutsch) + " EUR";

    public static IEnumerable<Produkt> Guenstige(IEnumerable<Produkt> produkte, decimal max) =>
        produkte.Where(p => p.Preis <= max);

    public static IEnumerable<string> Namen(IEnumerable<Produkt> produkte) =>
        produkte.Select(p => p.Name);

    public static List<(string Name, string Preis)> Etiketten(IEnumerable<Produkt> produkte) =>
        produkte.Select(p => (p.Name, Preis: Euro(p.Preis))).ToList();

    public static IEnumerable<string> VorraetigeGuenstige(IEnumerable<Produkt> produkte, decimal max) =>
        produkte.Where(p => p.Lager > 0).Where(p => p.Preis <= max).Select(p => p.Name);

    public static Dictionary<string, decimal> Preisliste(IEnumerable<Produkt> produkte) =>
        produkte.ToDictionary(p => p.Name, p => p.Preis);

    public static Produkt[] Schnappschuss(IEnumerable<Produkt> produkte) =>
        produkte.ToArray();
}
