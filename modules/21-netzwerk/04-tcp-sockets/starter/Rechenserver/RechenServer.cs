using System.Net.Sockets;

public static class RechenServer
{
    // TODO 1: Warte mit listener.AcceptTcpClient() auf EINEN Klienten (der Listener ist schon gestartet).
    // Lege über den NetworkStream (klient.GetStream()) einen StreamReader und einen StreamWriter mit
    // AutoFlush = true an (sonst bleiben die Antworten im Puffer und der Klient wartet ewig).
    // Lies Zeile für Zeile (ReadLine) und antworte auf jede mit WriteLine(Antwort(zeile)).
    // Ende: wenn der Klient "ENDE" sendet oder die Verbindung schließt (ReadLine liefert null).
    // Klient, Stream, Leser und Schreiber gibst du mit "using" wieder frei.
    public static void BedieneEinenKlienten(TcpListener listener) => throw new NotImplementedException();

    // TODO 2: "ADD 2 3" ergibt "5", "MUL 4 5" ergibt "20". Alles andere ergibt "FEHLER": ein unbekannter
    // Befehl, falsche Anzahl der Teile, keine ganze Zahl (int.TryParse) und ein Überlauf (checked und
    // OverflowException abfangen, sonst liefert int.MaxValue + 1 stillschweigend eine negative Zahl).
    public static string Antwort(string zeile) => throw new NotImplementedException();
}
