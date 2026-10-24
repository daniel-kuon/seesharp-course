using System.Net.Sockets;

public static class RechenServer
{
    // Wartet auf EINEN Klienten und bedient ihn zeilenweise, bis er ENDE sendet (oder die Verbindung schließt).
    public static void BedieneEinenKlienten(TcpListener listener)
    {
        using var klient = listener.AcceptTcpClient();
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        string? zeile;
        while ((zeile = leser.ReadLine()) is not null && zeile != "ENDE")
            schreiber.WriteLine(Antwort(zeile));
    }

    // "ADD 2 3" -> "5", "MUL 4 5" -> "20", alles andere (auch Überlauf) -> "FEHLER".
    public static string Antwort(string zeile)
    {
        var teile = zeile.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        if (teile.Length != 3 || !int.TryParse(teile[1], out var a) || !int.TryParse(teile[2], out var b))
            return "FEHLER";

        try
        {
            return teile[0] switch
            {
                "ADD" => checked(a + b).ToString(),
                "MUL" => checked(a * b).ToString(),
                _ => "FEHLER",
            };
        }
        catch (OverflowException)
        {
            return "FEHLER";
        }
    }
}
