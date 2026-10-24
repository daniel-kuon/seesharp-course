# Zusatz: Mini-Chat-Protokoll

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**21.6.1 TCP-Server** (Seite 1526) und **21.6.2 TCP-Klient** (Seite 1530).

Hier entwirfst du ein eigenes kleines Zeilenprotokoll: einen Chat für
**einen** Klienten. Der Server kennt drei Befehle:

| Zeile | Antwort |
|---|---|
| `NAME x` | `OK`; ab jetzt heißt der Klient `x` (am Anfang `Gast`) |
| `SAGE text` | `x: text` |
| `ENDE` | keine Antwort, der Server beendet die Sitzung |
| alles andere, auch `NAME` oder `SAGE` ohne Rest | `FEHLER` |

Name und Text dürfen Leerzeichen enthalten (`NAME Max Mustermann`). Die
Befehlswörter sind GROSS geschrieben; `sage x` ist ein Fehler.

Öffne `ChatServer.cs` und `Chat.cs`:

1. `ChatServer.BedieneKlienten(l)` nimmt einen Klienten am (schon gestarteten)
   `TcpListener` an und bedient ihn nach dem Protokoll. `AutoFlush = true`; bei
   getrennter Verbindung (`ReadLine` liefert `null`) endet die Methode.
2. `Chat.Gespraech(ziel, zeilen)` verbindet sich, schickt die Zeilen,
   liest je eine Antwort und beendet das Gespräch mit `ENDE`.

Die Tests starten den Listener auf `127.0.0.1` mit Port 0; es wird kein
Internet gebraucht.

Diese Tests müssen bestehen:

- `ChatTests.SAGE_ohne_NAME_kommt_von_Gast_und_der_Server_endet`
- `ChatTests.NAME_setzt_den_Namen_fuer_die_folgenden_SAGE_Zeilen`
- `ChatTests.Name_und_Text_duerfen_Leerzeichen_enthalten`
- `ChatTests.Text_mit_Umlauten_und_Satzzeichen`
- `ChatTests.Unbekanntes_und_Unvollstaendiges_ergibt_FEHLER_und_der_Name_bleibt`
- `ChatTests.Ohne_Zeilen_verbindet_und_beendet_nur`
- `ChatTests.Der_Server_antwortet_sofort_und_schliesst_nach_ENDE`
- `ChatTests.Trennt_der_Klient_ohne_ENDE_endet_der_Server_ohne_Fehler`
