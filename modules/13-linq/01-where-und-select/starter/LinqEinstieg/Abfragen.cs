using System.Globalization;

public static class Abfragen
{
    private static readonly NumberFormatInfo Deutsch = new() { NumberDecimalSeparator = "," };

    // vorgegeben: 12.5m -> "12,50 EUR", unabhängig von der Spracheinstellung des Rechners
    public static string Euro(decimal preis) => preis.ToString("F2", Deutsch) + " EUR";

    // TODO: Where mit einem Lambda: Preis <= max
    public static IEnumerable<Produkt> Guenstige(IEnumerable<Produkt> produkte, decimal max) => throw new NotImplementedException();

    // TODO: Select
    public static IEnumerable<string> Namen(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: Select mit einem Tupel (Name, Preis als Text via Euro), dann ToList()
    public static List<(string Name, string Preis)> Etiketten(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: Where (Lager > 0), Where (Preis <= max), Select (Name) hintereinander
    public static IEnumerable<string> VorraetigeGuenstige(IEnumerable<Produkt> produkte, decimal max) => throw new NotImplementedException();

    // TODO: ToDictionary(Schlüssel: Name, Wert: Preis)
    public static Dictionary<string, decimal> Preisliste(IEnumerable<Produkt> produkte) => throw new NotImplementedException();

    // TODO: ToArray
    public static Produkt[] Schnappschuss(IEnumerable<Produkt> produkte) => throw new NotImplementedException();
}
