using System.Net.Sockets;

public static class ChatServer
{
    // TODO 1: Nimm mit l.AcceptTcpClient() EINEN Klienten an (der Listener ist schon gestartet) und lege über
    // den Stream einen StreamReader und einen StreamWriter mit AutoFlush = true an (alles mit "using").
    // Der Server merkt sich den Namen des Klienten, am Anfang "Gast". Lies Zeile für Zeile. Eine Zeile
    // besteht aus einem Befehlswort und einem Rest ("SAGE Hallo Welt": Befehl SAGE, Rest "Hallo Welt").
    //   NAME x      -> Name merken, Antwort "OK" (x darf Leerzeichen enthalten; ohne x: FEHLER)
    //   SAGE text   -> Antwort "<Name>: <text>" (ohne text: FEHLER)
    //   ENDE        -> beenden, keine Antwort
    //   alles andere -> FEHLER
    // Auch wenn der Klient die Verbindung ohne ENDE schließt (ReadLine liefert null), endet die Methode.
    public static void BedieneKlienten(TcpListener l) => throw new NotImplementedException();
}
