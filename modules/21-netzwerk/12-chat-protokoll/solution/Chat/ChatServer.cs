using System.Net.Sockets;

public static class ChatServer
{
    // Bedient EINEN Klienten: NAME x -> OK, SAGE text -> "x: text", ENDE beendet, alles andere -> FEHLER.
    public static void BedieneKlienten(TcpListener l)
    {
        using var klient = l.AcceptTcpClient();
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        var name = "Gast";
        string? zeile;
        while ((zeile = leser.ReadLine()) is not null && zeile != "ENDE")
        {
            var leer = zeile.IndexOf(' ');
            var befehl = leer < 0 ? zeile : zeile[..leer];
            var rest = leer < 0 ? "" : zeile[(leer + 1)..].Trim();

            if (befehl == "NAME" && rest.Length > 0)
            {
                name = rest;
                schreiber.WriteLine("OK");
            }
            else if (befehl == "SAGE" && rest.Length > 0)
            {
                schreiber.WriteLine($"{name}: {rest}");
            }
            else
            {
                schreiber.WriteLine("FEHLER");
            }
        }
    }
}
