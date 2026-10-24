public static class UrlSammler
{
    // Nur absolute http- und https-Adressen zählen.
    private static Uri? Lese(string? url)
        => Uri.TryCreate(url, UriKind.Absolute, out var uri) && uri.Scheme is "http" or "https" ? uri : null;

    // Die verschiedenen Hosts, aufsteigend sortiert (Groß-/Kleinschreibung egal, Uri.Host ist klein).
    // Relative und ungültige Eingaben werden übersprungen.
    public static List<string> Hosts(IEnumerable<string> urls)
        => urls.Select(Lese).OfType<Uri>().Select(u => u.Host).Distinct().OrderBy(h => h, StringComparer.Ordinal).ToList();

    // Entfernt die Abfrage; für relative oder ungültige Eingaben null.
    public static string? OhneParameter(string url)
    {
        var uri = Lese(url);
        if (uri is null)
            return null;
        return new UriBuilder(uri) { Query = "" }.Uri.AbsoluteUri;
    }

    // Setzt den Parameter (ersetzt einen vorhandenen mit gleichem Namen); für relative oder ungültige Eingaben null.
    public static string? MitParameter(string url, string name, string wert)
    {
        var uri = Lese(url);
        if (uri is null)
            return null;

        var paare = new List<KeyValuePair<string, string>>();
        foreach (var teil in uri.Query.TrimStart('?').Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var gleich = teil.IndexOf('=');
            var n = Uri.UnescapeDataString(gleich < 0 ? teil : teil[..gleich]);
            var w = gleich < 0 ? "" : Uri.UnescapeDataString(teil[(gleich + 1)..]);
            paare.Add(new(n, w));
        }

        var index = paare.FindIndex(p => p.Key == name);
        if (index >= 0)
            paare[index] = new(name, wert);
        else
            paare.Add(new(name, wert));

        var query = string.Join("&", paare.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));
        return new UriBuilder(uri) { Query = query }.Uri.AbsoluteUri;
    }
}
