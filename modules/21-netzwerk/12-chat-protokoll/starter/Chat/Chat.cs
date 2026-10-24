using System.Net;
using System.Net.Sockets;

public static class Chat
{
    // TODO 2: Verbinde dich mit TcpClient.Connect(ziel), sende nacheinander jede Zeile und lies zu jeder genau
    // eine Antwortzeile (liefert ReadLine null: IOException). Sende am Ende "ENDE" und gib die Antworten
    // in der Reihenfolge der Zeilen zurück. StreamWriter mit AutoFlush = true, alles mit "using".
    public static string[] Gespraech(IPEndPoint ziel, string[] zeilen) => throw new NotImplementedException();
}
