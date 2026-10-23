# Zusatz: Primzahlen zählen und zerlegen

Zusatzaufgabe: freiwillig, sie blockiert nichts. Den Primzahltest hast du in
der Übung „Primzahltest, switch-Ausdruck, foreach“ geschrieben; hier ist er
fertig vorgegeben, und du baust darauf auf.

Lies im Buch **4.7.3.1 Zählergesteuerte Schleife (for)** (Seite 271) und
**4.7.3.3 Bedingungsabhängige Schleifen** (Seite 275) zur `do`-Schleife.

Öffne `Primzahlen.cs`. `IstPrim(int n)` ist fertig, ändere es nicht.
Vervollständige:

1. `AnzahlBis(int n)` zählt die Primzahlen von 2 bis einschließlich `n`
   (`for`-Schleife). Bis 10 sind es 4 (2, 3, 5, 7), bis 100 sind es 25.
2. `NaechsteNach(int n)` liefert die kleinste Primzahl, die **größer** als
   `n` ist: nach 13 kommt 17, nach 1 kommt 2. Nimm eine `do … while`-Schleife:
   Erst eins weiterzählen, dann prüfen.
3. `SindZwillinge(int n)` liefert `true`, wenn `n` und `n + 2` beide prim
   sind (11 und 13 ja, 7 und 9 nein).
4. `Primfaktoren(int n)` zerlegt eine Zahl ab 2 in ihre Primfaktoren,
   aufsteigend und durch ` * ` getrennt: `12` ergibt `2 * 2 * 3`, `13` ergibt
   `13`. Idee: Beginne mit dem Teiler 2. Solange `n` größer als 1 ist: Teilt
   der Teiler `n`, notiere ihn und teile `n` durch ihn; sonst erhöhe den
   Teiler um 1. Dafür reicht eine einzige `while`-Schleife.

Diese Tests müssen bestehen:

- `PrimzahlenTests.Anzahl_bis_10_ist_4`
- `PrimzahlenTests.Anzahl_bis_100_ist_25`
- `PrimzahlenTests.Anzahl_unter_2_ist_0`
- `PrimzahlenTests.Naechste_Primzahl`
- `PrimzahlenTests.Primzahlzwillinge`
- `PrimzahlenTests.Keine_Zwillinge`
- `PrimzahlenTests.Primfaktoren_zusammengesetzter_Zahlen`
- `PrimzahlenTests.Primfaktoren_einer_Primzahl`
