public static class UrlSammler
{
    // Fertig: Nur absolute http- und https-Adressen zählen; alles andere (relativ, ungültig, null, ftp: ...)
    // liefert null. Benutze diese Hilfsmethode in den Methoden unten.
    private static Uri? Lese(string? url)
        => Uri.TryCreate(url, UriKind.Absolute, out var uri) && uri.Scheme is "http" or "https" ? uri : null;

    // TODO 1: Die verschiedenen Hosts der gültigen Adressen, aufsteigend sortiert (StringComparer.Ordinal).
    // Ungültige und relative Eingaben werden übersprungen, doppelte Hosts nur einmal geliefert.
    // Uri.Host ist schon kleingeschrieben: "Example.COM" und "example.com" sind derselbe Host.
    public static List<string> Hosts(IEnumerable<string> urls) => throw new NotImplementedException();

    // TODO 2: Die Adresse ohne Abfrage ("http://h/p?a=1" -> "http://h/p"); ein Fragment bleibt erhalten.
    // Für relative oder ungültige Eingaben null. Nimm UriBuilder (Query = "") und Uri.AbsoluteUri.
    public static string? OhneParameter(string url) => throw new NotImplementedException();

    // TODO 3: Setze den Parameter name auf wert: Gibt es ihn schon, wird sein Wert ersetzt (an derselben
    // Stelle), sonst kommt er ans Ende. Die anderen Parameter bleiben in ihrer Reihenfolge erhalten.
    // Namen und Werte werden mit Uri.EscapeDataString kodiert (vorhandene erst mit UnescapeDataString lesen,
    // damit nichts doppelt kodiert wird). Für relative oder ungültige Eingaben null.
    public static string? MitParameter(string url, string name, string wert) => throw new NotImplementedException();
}
