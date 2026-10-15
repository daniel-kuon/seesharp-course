# Felder, Eigenschaften, Validierung

Lies im Buch Abschnitt **5.2 Instanzvariablen (Felder)** (Seite 300),
**5.3.1 Methodendefinition** (Seite 309) und **5.5 Eigenschaften** (Seite 361).
Die Aufgaben 1 bis 3 in **5.15** (Seite 424) passen dazu.

Öffne `Bruch.cs`. Die Felder `zaehler`, `nenner` und `etikett` sind
vorhanden. Vervollständige:

1. Die Eigenschaft `Zaehler` liest und schreibt das Feld `zaehler`.
2. Der Setter von `Nenner` ignoriert den Wert 0 (der Nenner bleibt dann
   unverändert).
3. Der Setter von `Etikett` übernimmt höchstens 40 Zeichen (`Substring`).
4. `Kuerze()` kürzt den Bruch mit dem ggT (Euklid, Modulo-Variante aus
   Level 3, mit `Math.Abs` für negative Werte). Ein Bruch mit Zähler 0 wird zu
   0/1.
5. `Addiere(Bruch b)` addiert `b` zu diesem Bruch und kürzt anschließend.

Beantworte danach die Frage zum rekursiven Getter.

Diese Tests müssen bestehen:

- `BruchTests.Zaehler_liest_und_schreibt_das_Feld`
- `BruchTests.Nenner_ignoriert_null`
- `BruchTests.Nenner_uebernimmt_gueltige_Werte`
- `BruchTests.Etikett_wird_auf_40_Zeichen_gekuerzt`
- `BruchTests.Kuerze_teilt_durch_den_ggT`
- `BruchTests.Kuerze_macht_aus_null_Zaehler_null_durch_eins`
- `BruchTests.Kuerze_mit_negativem_Zaehler`
- `BruchTests.Addiere_addiert_und_kuerzt`
