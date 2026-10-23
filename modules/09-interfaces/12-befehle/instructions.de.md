# Zusatz: Befehle mit Rückgängig und Wiederholen

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**9.2 Interfaces implementieren** (Seite 640) und **9.3 Interfaces als
Referenzdatentypen** (Seite 644).

Jeder Editor kann "Rückgängig" und "Wiederholen". Ein bewährter Weg dahin:
Jede Aktion ist ein Objekt, das sich selbst ausführen **und** zurücknehmen
kann. Das Interface `IBefehl` beschreibt diese Fähigkeit; der `Rechner`
kennt nur das Interface und nie die konkreten Befehle. Neue Befehle lassen
sich so ergänzen, ohne den Rechner anzufassen. Öffne `Befehle.cs`;
`Addiere` ist als Beispiel fertig:

1. `Multipliziere(faktor)`: `Name` ist z. B. `"Multipliziere 3"`. Ein
   Faktor 0 ließe sich nicht zurücknehmen und wirft deshalb im Konstruktor
   `ArgumentOutOfRangeException`. Rückgängig teilt durch den Faktor.
2. `Negiere`: `Name` ist `"Negiere"`; Ausführen und Rückgängig drehen das
   Vorzeichen.
3. `Makro(params IBefehl[] befehle)` fasst mehrere Befehle zu einem
   zusammen und ist selbst ein `IBefehl` (also kann ein Makro auch Makros
   enthalten). Ausführen wendet die Befehle der Reihe nach an,
   Rückgängig nimmt sie in **umgekehrter** Reihenfolge zurück. `Name`:
   `"Makro(Addiere 2, Multipliziere 3)"`.
4. `Rechner`: `Ausfuehren(befehl)` wendet den Befehl auf `Wert` an und legt
   ihn im Verlauf ab (`verlauf` ist ein Array mit Zähler, wie ein Stapel).
   `Rueckgaengig()` nimmt den zuletzt ausgeführten Befehl zurück und legt
   ihn auf den Stapel `zurueckgenommen`; `Wiederholen()` führt den zuletzt
   zurückgenommenen Befehl erneut aus. Beide liefern `false`, wenn es
   nichts zu tun gibt. Ein neuer Befehl über `Ausfuehren` leert den Stapel
   `zurueckgenommen`. `Protokoll()` liefert die Namen im Verlauf, mit
   `", "` verbunden (`string.Join`).

Diese Tests müssen bestehen:

- `BefehleTests.Alle_Befehle_sind_IBefehle`
- `BefehleTests.Ausfuehren_und_Rueckgaengig_heben_sich_auf`
- `BefehleTests.Multipliziere_mit_0_wirft`
- `BefehleTests.Makro_fuehrt_der_Reihe_nach_aus_und_rueckwaerts_zurueck`
- `BefehleTests.Rechner_fuehrt_aus_und_protokolliert`
- `BefehleTests.Rueckgaengig_nimmt_den_letzten_Befehl_zurueck`
- `BefehleTests.Wiederholen_nach_Rueckgaengig`
