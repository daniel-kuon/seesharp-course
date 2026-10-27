# Statische Member

Lies im Buch Abschnitt **5.8 Statische Member und Klassen** (Seite 373) bis
5.8.4 (Statische Konstruktoren, Seite 377) und zum Schlüsselwort `field`
**5.5.2.2 Validierender set-Block ohne explizite Felddeklaration** (Seite 365)
sowie **5.6 Automatisch implementierte Eigenschaften statt expliziter Felder**
(Seite 367).

Öffne `Bruch.cs`. Die Klasse verwendet jetzt automatisch implementierte
Eigenschaften ohne eigene Felder. Vervollständige:

1. `Nenner` und `Etikett`: Ergänze die Validierung im Setter (Nenner 0
   ignorieren, Etikett auf 40 Zeichen kürzen). Verwende dazu das Schlüsselwort
   `field` statt eines expliziten Feldes.
2. `Anzahl` zählt die erzeugten Objekte: Erhöhe die statische Eigenschaft in
   **beiden** Konstruktoren. Ihr Setter bleibt `private`.
3. Schreibe einen **statischen Konstruktor** `static Bruch()`, der
   `ZaehlerVoreinst` auf eine Zufallszahl von 1 bis 6 und `NennerVoreinst` auf
   eine Zufallszahl von `ZaehlerVoreinst` bis 8 setzt (`Random.Next(min, max)`,
   `max` ist ausgeschlossen). Der parameterlose Konstruktor verwendet diese
   Voreinstellungen bereits.
4. `BenDef(string e)` ist eine statische Fabrikmethode: Sie erzeugt einen
   Bruch 0/1 mit Etikett `e`, lässt ihn per `Frage()` vom Benutzer füllen,
   kürzt ihn und liefert ihn zurück. Scheitert `Frage()`, liefert sie `null`.
   Das Fragezeichen im vorgegebenen Rückgabetyp `Bruch?` sagt dem Compiler,
   dass `null` erlaubt ist (Buch Seite 338, Fußnote; ausführlich kommt das in
   Kapitel 15.1.1). Das Buchbeispiel auf Seite 377 schreibt nur `Bruch`; du
   musst am Kopf nichts ändern.

Diese Tests müssen bestehen:

- `BruchTests.Nenner_ignoriert_null`
- `BruchTests.Etikett_wird_gekuerzt`
- `BruchTests.Anzahl_zaehlt_beide_Konstruktoren`
- `BruchTests.Standardkonstruktor_nutzt_Voreinstellungen_aus_statischem_Konstruktor`
- `BruchTests.BenDef_liefert_gekuerzten_Bruch_mit_Etikett`
- `BruchTests.BenDef_liefert_null_bei_ungueltiger_Eingabe`
