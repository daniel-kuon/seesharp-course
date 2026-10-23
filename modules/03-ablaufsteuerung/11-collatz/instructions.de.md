# Zusatz: Collatz-Folge

Zusatzaufgabe: freiwillig, sie blockiert nichts. Eine Folge mit einer
einfachen Regel, von der bis heute niemand beweisen konnte, dass sie immer
endet.

Die Regel: Beginne mit einer positiven Zahl `n`. Ist `n` gerade, wird daraus
`n / 2`, sonst `3 * n + 1`. Wiederhole, bis `n` gleich 1 ist. Von 6 aus:
6, 3, 10, 5, 16, 8, 4, 2, 1 — das sind **8 Schritte**.

Lies im Buch **4.7.3.3 Bedingungsabhängige Schleifen** (Seite 275).

Öffne `Collatz.cs`:

1. `Schritte(long n)` zählt die Schritte, bis die Folge bei 1 ankommt.
   `Schritte(1)` ist 0, `Schritte(6)` ist 8. Nimm eine `while`-Schleife mit
   `if`/`else` im Körper.
2. `Hoechstwert(long n)` liefert den größten Wert, den die Folge unterwegs
   erreicht (einschließlich `n` selbst). Von 6 aus ist das 16.
3. `LaengsterStartBis(int grenze)` sucht unter den Startwerten 1 bis
   `grenze` denjenigen mit den meisten Schritten. Bei Gleichstand gewinnt der
   kleinere Startwert. Rufe `Schritte()` in einer Schleife auf (`for`, wenn
   du sie aus 4.7.3.1 schon kennst, sonst `while`).

Warum `long`? Von 27 aus klettert die Folge auf über 9000, bei größeren
Startwerten wird es schnell mehr, als in ein `int` passt.

Diese Tests müssen bestehen:

- `CollatzTests.Von_1_aus_null_Schritte`
- `CollatzTests.Von_6_aus_acht_Schritte`
- `CollatzTests.Von_27_aus_111_Schritte`
- `CollatzTests.Hoechstwert_von_6_ist_16`
- `CollatzTests.Hoechstwert_von_27_ist_9232`
- `CollatzTests.Hoechstwert_einer_Zweierpotenz_ist_der_Start`
- `CollatzTests.Laengster_Start_bis_10_ist_9`
- `CollatzTests.Laengster_Start_bis_100_ist_97`
