# TCP Server and Client in Loopback Mode

Read Section **21.6, "Socket Programming**" (page 1525), along with **Subsections 21.6.1, "TCP Server"** (page 1526), and **21.6.2, "TCP Client"** (page 1530). The sample projects `Netzwerk/Socket/TcpServer` and `TcpClient` in the `Sample` folder demonstrate the process using a Windows console.

A server and a client communicate via TCP using a **line-based protocol**: The client sends a line, and the server responds with a line. A `TcpListener` (server) and a `TcpClient` (client) are used; you read from and write to the `NetworkStream` using `StreamReader` and `StreamWriter`, just like a file. The tests run entirely on your own computer: You create a `TcpListener` on `127.0.0.1` with port 0 (the operating system searches for an available port), start **your** server method in a task, and call **your** client.

The log, one line per request:

| Inquiry | Answer |
|---|---|
| `ADD 2 3` | `5` |
| `MUL 4 5` | `20` |
| anything else (unknown command, incorrect number of operands, non-integer, `int` overflow) | `FEHLER` |
| `ENDE` | No response; the server terminates the session and closes the connection |

Open `RechenServer.cs` and `Klient.cs`:

1. `RechenServer.BedieneEinenKlienten(listener)` accepts **a** client (`AcceptTcpClient()`) and serves it line by line until it reaches the `ENDE` or the connection is closed. Don't forget to set `AutoFlush = true`.
2. `RechenServer.Antwort(zeile)` calculates the response for a row. An overflow results in an `FEHLER` (`checked` and `OverflowException`).
3. `Klient.Frage(ziel, zeilen)` connects, sends the lines, collects one response for each, and ends the session with `ENDE`.

A safety limit in the tests simply prevents a test from getting stuck (for example, if the server never responds).

The following tests must be passed:

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
