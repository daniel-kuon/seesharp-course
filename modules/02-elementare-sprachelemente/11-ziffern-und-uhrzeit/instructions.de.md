# Zusatz: Ziffern und Uhrzeit

Zusatzaufgabe: freiwillig, sie blockiert nichts. Mit `/` und `%` zerlegst du
Zahlen in ihre Teile — ganz ohne Schleifen. Schleifen kommen in Level 3; dort
gibt es eine Fortsetzung dieser Aufgabe für beliebig lange Zahlen.

Lies im Buch **4.5.1 Arithmetische Operatoren** (Seite 216) zu Ganzzahldivision
und Modulo und **4.2.3 Formatierte Ausgabe** (Seite 176) zur Formatangabe `d`
mit Präzision (`{x:d2}` gibt mindestens zwei Ziffern aus, also `07`; was die
Präzision bei `d` bewirkt, steht nicht im Buch, hier vorgegeben).

Öffne `Ziffern.cs`:

1. `Quersumme(int n)` liefert die Summe der Ziffern einer Zahl von 0 bis 999.
   `Quersumme(472)` ist `13`. Tipp: `n % 10` ist die letzte Ziffer, `n / 10`
   schneidet sie ab.
2. `Umgedreht(int n)` dreht eine dreistellige Zahl um: `472` wird `274`,
   `120` wird `21`.
3. `IstGerade(int n)` liefert `true` für gerade Zahlen, auch negative.
4. `Uhrzeit(int sekunden)` macht aus Sekunden seit Mitternacht (0 bis 86399)
   den Text `hh:mm:ss`: `3725` wird `01:02:05`.

Diese Tests müssen bestehen:

- `ZiffernTests.Quersumme_dreistellig`
- `ZiffernTests.Quersumme_kleiner_Zahlen`
- `ZiffernTests.Umgedreht_dreistellig`
- `ZiffernTests.Umgedreht_mit_Null_am_Ende`
- `ZiffernTests.Gerade_und_ungerade`
- `ZiffernTests.Uhrzeit_mit_fuehrenden_Nullen`
- `ZiffernTests.Uhrzeit_Grenzen`
