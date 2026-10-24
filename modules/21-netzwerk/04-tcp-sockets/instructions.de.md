# TCP-Server und -Klient im Loopback

Lies im Buch **21.6 Socket-Programmierung** (Seite 1525) mit **21.6.1
TCP-Server** (Seite 1526) und **21.6.2 TCP-Klient** (Seite 1530). Die
Beispielprojekte `Netzwerk/Socket/TcpServer` und `TcpClient` im Sample-Ordner
zeigen den Ablauf mit einer Windows-Konsole.

Ein Server und ein Klient unterhalten sich über TCP in einem
**zeilenbasierten Protokoll**: Der Klient schickt eine Zeile, der Server
antwortet mit einer Zeile. Verwendet wird ein `TcpListener` (Server) und ein
`TcpClient` (Klient); den `NetworkStream` liest und beschreibst du mit
`StreamReader` und `StreamWriter` wie eine Datei. Die Tests laufen ganz auf
dem eigenen Rechner: Sie legen einen `TcpListener` auf `127.0.0.1` mit
Port 0 an (das Betriebssystem sucht einen freien Port), starten **deine**
Servermethode auf einer Task und rufen **deinen** Klienten auf.

Das Protokoll, eine Zeile je Anfrage:

| Anfrage | Antwort |
|---|---|
| `ADD 2 3` | `5` |
| `MUL 4 5` | `20` |
| alles andere (unbekannter Befehl, falsche Anzahl der Teile, keine ganze Zahl, Überlauf von `int`) | `FEHLER` |
| `ENDE` | keine Antwort, der Server beendet die Sitzung und schließt die Verbindung |

Öffne `RechenServer.cs` und `Klient.cs`:

1. `RechenServer.BedieneEinenKlienten(listener)` nimmt **einen** Klienten an
   (`AcceptTcpClient()`) und bedient ihn Zeile für Zeile, bis `ENDE` kommt
   oder die Verbindung getrennt wird. `AutoFlush = true` nicht vergessen.
2. `RechenServer.Antwort(zeile)` berechnet die Antwort zu einer Zeile. Ein
   Überlauf ergibt `FEHLER` (`checked` und `OverflowException`).
3. `Klient.Frage(ziel, zeilen)` verbindet sich, schickt die Zeilen, sammelt
   je eine Antwort und beendet die Sitzung mit `ENDE`.

Eine Sicherheitsgrenze in den Tests verhindert nur, dass ein Test hängen
bleibt (zum Beispiel, wenn der Server nie antwortet).

Diese Tests müssen bestehen:

- `RechenserverTests.WarteAufServerAsync`
- `RechenserverTests.Dispose`
- `RechenserverTests.Addiert_und_multipliziert_und_beendet_sich_nach_ENDE`
- `RechenserverTests.Negative_und_grosse_Zahlen`
- `RechenserverTests.Unbekanntes_und_Fehlerhaftes_ergibt_FEHLER`
- `RechenserverTests.Ueberlauf_ergibt_FEHLER_und_der_Server_macht_weiter`
- `RechenserverTests.Klient_ohne_Fragen_liefert_ein_leeres_Array_und_der_Server_endet`
- `RechenserverTests.Die_Antworten_kommen_in_der_Reihenfolge_der_Fragen`
- `RechenserverTests.Der_Server_antwortet_sofort_pro_Zeile_ohne_auf_ENDE_zu_warten`
- `RechenserverTests.Nach_ENDE_schliesst_der_Server_die_Verbindung`
- `RechenserverTests.Trennt_der_Klient_ohne_ENDE_endet_der_Server_ohne_Fehler`
- `RechenserverTests.Antwort_rechnet_Zeile_fuer_Zeile`
