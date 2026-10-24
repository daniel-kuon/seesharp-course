using System.Net;

// Ergebnis von Zerlege: Port ist der tatsächliche Port (80 bzw. 443, wenn die URL keinen nennt),
// Pfad beginnt mit "/", Abfrage ist ohne das führende "?" (leer, wenn es keine gibt).
public record UrlTeile(string Schema, string Host, int Port, string Pfad, string Abfrage);

public static class Adressen
{
    // TODO 1: Zerlege eine absolute URL mit new Uri(url) in ihre Teile (Scheme, Host, Port, AbsolutePath, Query).
    // Eine ungültige oder relative Zeichenkette ("a/b", "", "nur text") wirft UriFormatException:
    // fange sie ab und gib null zurück.
    public static UrlTeile? Zerlege(string url) => throw new NotImplementedException();

    // TODO 2: Hänge die Parameter an die Basisadresse an: "http://h/p" + {q = "a b&c", n = "1"}
    // ergibt "http://h/p?q=a%20b%26c&n=1" (Einfügereihenfolge; Namen und Werte mit Uri.EscapeDataString
    // kodieren). Ohne Parameter bleibt die Basis unverändert. Hat die Basis schon eine Abfrage, kommen die
    // neuen Parameter mit "&" dahinter. Nimm UriBuilder (Eigenschaft Query, am Ende Uri.AbsoluteUri).
    // Eine ungültige Basis wirft UriFormatException (nicht abfangen).
    public static string Baue(string basis, Dictionary<string, string> parameter) => throw new NotImplementedException();

    // TODO 3: Lies die Abfrage einer URL als Wörterbuch zurück: am ersten "?" trennen, ein "#Fragment" ignorieren,
    // an "&" in Paare und am ersten "=" in Name und Wert teilen und beides mit Uri.UnescapeDataString
    // dekodieren. Ein Paar ohne "=" hat den Wert "". Ohne Abfrage: leeres Wörterbuch. Doppelter Name: letzter gewinnt.
    public static Dictionary<string, string> Parameter(string url) => throw new NotImplementedException();

    // TODO 4: true, wenn s eine absolute URI ist (Uri.TryCreate mit UriKind.Absolute), sonst false.
    public static bool TryAbsolut(string? s, out Uri? uri) => throw new NotImplementedException();

    // TODO 5: true für Loopback-Adressen (IPAddress.IsLoopback) und die privaten IPv4-Bereiche
    // 10.0.0.0/8, 172.16.0.0/12 (172.16 bis 172.31) und 192.168.0.0/16. Ist ip keine gültige Adresse
    // (IPAddress.TryParse), ist das Ergebnis false. IPv6-Adressen außer ::1 sind hier nicht lokal.
    public static bool IstLokal(string ip) => throw new NotImplementedException();

    // TODO 6: Löse "localhost" mit Dns.GetHostAddresses auf und prüfe, ob eine der Adressen Loopback ist.
    public static bool LoopbackAufgeloest() => throw new NotImplementedException();
}
