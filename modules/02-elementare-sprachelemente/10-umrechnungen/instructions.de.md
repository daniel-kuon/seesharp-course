# Zusatz: Umrechnungen

Zusatzaufgabe: freiwillig, sie blockiert nichts. Rechnen mit `double` und
`decimal`, Konstanten und Runden — und zwei Fallen, die in der Praxis jeden
einmal erwischen.

Lies im Buch **4.3.9 Konstanten** (Seite 200), **4.3.4 Elementare
Datentypen** (Seite 186) zu `decimal` und Aufgabe 6 in **4.5.11**
(Seite 242): Dort rechnet ein Programm DM und Pfennig in Euro und Cent um.
Der amtliche Kurs ist 1 Euro = 1,95583 DM.

Öffne `Umrechner.cs`:

1. `CelsiusInFahrenheit(double celsius)` rechnet `celsius * 9 / 5 + 32`.
   Achtung: `9 / 5` allein ist eine Ganzzahldivision.
2. `FahrenheitInCelsius(double fahrenheit)` rechnet `(fahrenheit - 32) * 5 / 9`.
3. Lege in der Klasse eine öffentliche Konstante `DmProEuro` vom Typ
   `decimal` mit dem Wert 1,95583 an (Suffix `m`) und verwende sie in den
   beiden DM-Methoden.
4. `EuroInDm(decimal euro)` liefert den DM-Betrag, kaufmännisch auf zwei
   Nachkommastellen gerundet (`Math.Round` mit
   `MidpointRounding.AwayFromZero`).
5. `DmInEuro(int dm, int pfennig)` rechnet einen Betrag aus Mark und Pfennig
   (100 Pfennig = 1 DM) in Euro um, ebenso auf Cent gerundet. 0 DM und 99
   Pfennig sind 0,51 Euro, nicht 0.
6. `Kassenbon(decimal betrag)` liefert für `12.34m` den Text
   `12 Euro und 34 Cent`. Die Euro bekommst du per Cast nach `int`, die Cent
   mit `* 100` und `%`. Der Betrag ist nie negativ und hat höchstens zwei
   Nachkommastellen.

Diese Tests müssen bestehen:

- `UmrechnerTests.Koerpertemperatur_in_Fahrenheit`
- `UmrechnerTests.Gefrierpunkt_und_Siedepunkt`
- `UmrechnerTests.Minus_40_Grad_sind_gleich`
- `UmrechnerTests.Kurs_ist_eine_decimal_Konstante`
- `UmrechnerTests.Euro_in_DM`
- `UmrechnerTests.Mark_und_Pfennig_in_Euro`
- `UmrechnerTests.Pfennige_gehen_nicht_verloren`
- `UmrechnerTests.Kassenbon_trennt_Euro_und_Cent`
