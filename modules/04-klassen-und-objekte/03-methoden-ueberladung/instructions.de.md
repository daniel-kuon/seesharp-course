# Methoden überladen

Lies im Buch Abschnitt **5.3.5 Methoden überladen** (Seite 334) und zur
Erinnerung **5.3.2 Methodenaufruf und Aktualparameter** (Seite 324).

Öffne `Bruch.cs`. Eigenschaften und `Kuerze()` sind fertig. Vervollständige
die beiden gleichnamigen Methoden:

1. `Addiere(Bruch b)` addiert `b` zu diesem Bruch und kürzt anschließend (wie
   in der vorigen Übung).
2. `Addiere(int zpar, int npar, bool autokurz)` addiert den Bruch
   `zpar/npar`. Ist `npar` gleich 0, passiert nichts und die Methode liefert
   `false`; sonst liefert sie `true` und kürzt nur, wenn `autokurz` gesetzt
   ist.

Der Compiler wählt anhand der Argumente, welche Überladung aufgerufen wird.
Probiere in `Bruchrechnung.cs` beide Aufrufe aus.

Diese Tests müssen bestehen:

- `BruchTests.Addiere_Bruch_addiert_und_kuerzt`
- `BruchTests.Addiere_Zahlen_mit_autokurz`
- `BruchTests.Addiere_Zahlen_ohne_autokurz_kuerzt_nicht`
- `BruchTests.Addiere_mit_Nenner_null_liefert_false_und_aendert_nichts`
- `BruchTests.Beide_Ueberladungen_sind_aufrufbar`
