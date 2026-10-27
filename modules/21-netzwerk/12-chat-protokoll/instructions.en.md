# Extra: Mini Chat Protocol

Extra exercise: optional; it unlocks nothing. For further reading: **21.6.1 TCP Server** (page 1526) and **21.6.2 TCP Client** (page 1530).

Here, you design your own small line protocol: a chat for **one** client. The server recognizes three commands:

| Line | Response |
|---|---|
| `NAME x` | `OK`; from now on, the client is called `x` (initially `Gast`) |
| `SAGE text` | `x: text` |
| `ENDE` | No response; the server ends the session |
| anything else, including `NAME` or `SAGE` without a remainder | `FEHLER` |

Names and text may contain spaces (`NAME Max Mustermann`). Command words are written in ALL CAPS; `sage x` is an error.

Open `ChatServer.cs` and `Chat.cs`:

1. `ChatServer.BedieneKlienten(l)` accepts a client at the (already started) `TcpListener` and serves it according to the protocol. `AutoFlush = true`; if the connection is disconnected (`ReadLine` returns `null`), the method terminates.
2. `Chat.Gespraech(ziel, zeilen)` connects, sends the lines, reads one response at a time, and ends the conversation with `ENDE`.

The tests start the listener on `127.0.0.1`, port 0; no Internet connection is required.

The following tests must be passed:

- `ChatTests.SAGE_ohne_NAME_kommt_von_Gast_und_der_Server_endet`
- `ChatTests.NAME_setzt_den_Namen_fuer_die_folgenden_SAGE_Zeilen`
- `ChatTests.Name_und_Text_duerfen_Leerzeichen_enthalten`
- `ChatTests.Text_mit_Umlauten_und_Satzzeichen`
- `ChatTests.Unbekanntes_und_Unvollstaendiges_ergibt_FEHLER_und_der_Name_bleibt`
- `ChatTests.Ohne_Zeilen_verbindet_und_beendet_nur`
- `ChatTests.Der_Server_antwortet_sofort_und_schliesst_nach_ENDE`
- `ChatTests.Trennt_der_Klient_ohne_ENDE_endet_der_Server_ohne_Fehler`
