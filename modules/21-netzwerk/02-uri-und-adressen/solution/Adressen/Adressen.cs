using System.Net;

public record UrlTeile(string Schema, string Host, int Port, string Pfad, string Abfrage);

public static class Adressen
{
    // Zerlegt eine absolute URL; für ungültige oder relative Zeichenketten null.
    public static UrlTeile? Zerlege(string url)
    {
        try
        {
            var uri = new Uri(url);
            return new UrlTeile(uri.Scheme, uri.Host, uri.Port, uri.AbsolutePath, uri.Query.TrimStart('?'));
        }
        catch (UriFormatException)
        {
            return null;
        }
    }

    // Hängt die Parameter (in Einfügereihenfolge, mit Prozent-Kodierung) an die Basisadresse an.
    // Eine ungültige Basis wirft UriFormatException.
    public static string Baue(string basis, Dictionary<string, string> parameter)
    {
        if (parameter.Count == 0)
            return basis;

        _ = new Uri(basis); // wirft UriFormatException bei ungültiger Basis
        var neu = string.Join("&", parameter.Select(p => $"{Uri.EscapeDataString(p.Key)}={Uri.EscapeDataString(p.Value)}"));
        // Deep Dive: new UriBuilder(basis) { Query = ... }.Uri.AbsoluteUri leistet dasselbe ohne Verkettung.
        return basis + (basis.Contains('?') ? "&" : "?") + neu;
    }

    // Liest die Abfrage einer URL als Wörterbuch (dekodiert). Doppelte Namen: der letzte gewinnt.
    public static Dictionary<string, string> Parameter(string url)
    {
        var ergebnis = new Dictionary<string, string>();
        var ohneFragment = url.Split('#')[0];
        var fragezeichen = ohneFragment.IndexOf('?');
        if (fragezeichen < 0)
            return ergebnis;

        foreach (var paar in ohneFragment[(fragezeichen + 1)..].Split('&', StringSplitOptions.RemoveEmptyEntries))
        {
            var gleich = paar.IndexOf('=');
            var name = gleich < 0 ? paar : paar[..gleich];
            var wert = gleich < 0 ? "" : paar[(gleich + 1)..];
            ergebnis[Uri.UnescapeDataString(name)] = Uri.UnescapeDataString(wert);
        }
        return ergebnis;
    }

    public static bool TryAbsolut(string? s, out Uri? uri) => Uri.TryCreate(s, UriKind.Absolute, out uri);

    // Loopback (127.x.x.x, ::1) und die privaten IPv4-Bereiche 10/8, 172.16/12, 192.168/16.
    public static bool IstLokal(string ip)
    {
        if (!IPAddress.TryParse(ip, out var adresse))
            return false;
        if (IPAddress.IsLoopback(adresse))
            return true;
        if (adresse.AddressFamily != System.Net.Sockets.AddressFamily.InterNetwork)
            return false;

        var b = adresse.GetAddressBytes();
        return b[0] == 10
            || (b[0] == 172 && b[1] >= 16 && b[1] <= 31)
            || (b[0] == 192 && b[1] == 168);
    }

    // localhost wird lokal aufgelöst, dafür braucht es kein Internet.
    public static bool LoopbackAufgeloest() => Dns.GetHostAddresses("localhost").Any(IPAddress.IsLoopback);
}
