using System.Net;
using System.Net.Sockets;

public static class Chat
{
    // Schickt die Zeilen, liest je eine Antwort und beendet das Gespräch mit ENDE.
    public static string[] Gespraech(IPEndPoint ziel, string[] zeilen)
    {
        using var klient = new TcpClient();
        klient.Connect(ziel);
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        var antworten = new List<string>();
        foreach (var zeile in zeilen)
        {
            schreiber.WriteLine(zeile);
            antworten.Add(leser.ReadLine() ?? throw new IOException("Der Server hat die Verbindung beendet."));
        }
        schreiber.WriteLine("ENDE");
        return antworten.ToArray();
    }
}
