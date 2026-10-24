using System.Net;
using System.Net.Sockets;

public static class Klient
{
    // TODO 3: Verbinde dich mit TcpClient.Connect(ziel). Lege über den Stream einen StreamReader und einen
    // StreamWriter (AutoFlush = true) an. Sende nacheinander jede Zeile und lies zu jeder genau eine
    // Antwortzeile; liefert ReadLine null, hat der Server die Verbindung beendet: wirf eine IOException.
    // Sende zum Schluss "ENDE", damit der Server sich beendet, und gib die Antworten in der Reihenfolge der
    // Fragen als Array zurück. Alles Einwegartige gibst du mit "using" frei.
    public static string[] Frage(IPEndPoint ziel, params string[] zeilen) => throw new NotImplementedException();
}
