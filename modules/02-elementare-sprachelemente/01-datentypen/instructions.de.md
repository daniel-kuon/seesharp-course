# Datentypen und Konvertierungen

Lies im Buch Abschnitt **4.3.4 Elementare Datentypen** (Seite 186) und
**4.5.7 Typumwandlung** (Seite 229); zur Ganzzahldivision **4.5.1** (Seite 216).

Öffne `Typen.cs` und vervollständige die fünf statischen Methoden:

1. `ZeichenCode(char c)` liefert den Unicode-Code des Zeichens als `int`
   (implizite Umwandlung, kein Cast nötig).
2. `Verschiebe(char c, int um)` liefert das Zeichen, das `um` Positionen
   hinter `c` liegt (`'a'` um 1 ist `'b'`). Hier ist ein Cast nötig.
3. `Abschneiden(double d)` liefert den ganzzahligen Anteil per Cast; `2.7`
   wird `2`, `-2.7` wird `-2` (kein Runden).
4. `Mittelwert(int a, int b)` liefert den Mittelwert als `double`; achte auf
   die Ganzzahldivision, `Mittelwert(1, 2)` muss `1.5` sein.
5. `Rest(int a, int b)` liefert den Rest der Ganzzahldivision.

`Program.cs` ruft die Methoden zum Ausprobieren auf.

Diese Tests müssen bestehen:

- `TypenTests.ZeichenCode_von_A_ist_65`
- `TypenTests.Verschiebe_a_um_1_ist_b`
- `TypenTests.Abschneiden_rundet_nicht`
- `TypenTests.Abschneiden_negativ_geht_Richtung_null`
- `TypenTests.Mittelwert_von_1_und_2_ist_1_5`
- `TypenTests.Rest_von_17_durch_5_ist_2`
