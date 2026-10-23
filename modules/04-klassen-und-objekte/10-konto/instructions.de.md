# Zusatzaufgabe: Ein Girokonto mit Dispo

Diese Aufgabe ist freiwillig. Sie wiederholt Eigenschaften mit Validierung,
Konstruktoren und statische Member an einem neuen Beispiel. Zum Nachlesen:
**5.5 Eigenschaften** (Seite 361), **5.4.3 Einsatzvorbereitung** (Seite 340)
und **5.8 Statische Member und Klassen** (Seite 373).

Geldbeträge sind `decimal` (Literale mit `m`, etwa `9.95m`), damit beim
Rechnen keine Rundungsfehler wie bei `double` entstehen (Level 2).

Öffne `Konto.cs` und vervollständige die Klasse `Konto`:

1. Der Setter von `Inhaber` ignoriert leere Namen und Namen aus lauter
   Leerzeichen (`string.IsNullOrWhiteSpace`). Der Setter von `Dispo`
   ignoriert negative Werte. Verwende jeweils `field`.
2. Beide Konstruktoren vergeben die nächste freie Kontonummer aus dem
   statischen Feld `naechsteNummer` (danach um 1 erhöhen), zählen `Anzahl`
   hoch und setzen den Inhaber **über die Eigenschaft**. Ein negatives
   Startguthaben wird zu 0.
3. `Einzahlen(betrag)` akzeptiert nur positive Beträge und liefert dann
   `true`; sonst `false` ohne Änderung.
4. `Abheben(betrag)` akzeptiert nur positive Beträge, und der Kontostand darf
   danach nicht unter `-Dispo` liegen. Bei 100 € Guthaben und 50 € Dispo
   gehen also 150 €, aber kein Cent mehr.
5. `Ueberweise(ziel, betrag)` hebt hier ab und zahlt auf `ziel` ein, aber nur,
   wenn das Abheben gelingt. Eine Überweisung auf das eigene Konto liefert
   `false`.

Diese Tests müssen bestehen:

- `KontoTests.Konstruktor_setzt_Inhaber_und_Startguthaben`
- `KontoTests.Negatives_Startguthaben_wird_zu_null`
- `KontoTests.Leerer_Inhaber_wird_ignoriert`
- `KontoTests.Negativer_Dispo_wird_ignoriert`
- `KontoTests.Nummern_sind_fortlaufend_und_Anzahl_zaehlt_beide_Konstruktoren`
- `KontoTests.Einzahlen_nur_positive_Betraege`
- `KontoTests.Abheben_bis_zum_Dispo`
- `KontoTests.Abheben_ohne_Dispo_und_mit_ungueltigem_Betrag`
- `KontoTests.Ueberweise_bucht_auf_beiden_Konten`
- `KontoTests.Ueberweise_scheitert_ohne_Deckung_und_an_sich_selbst`
