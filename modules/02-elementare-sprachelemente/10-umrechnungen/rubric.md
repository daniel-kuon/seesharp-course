# Rubrik — Zusatz: Umrechnungen (nur für die Betreuung)

Zusatzaufgabe zu Level 2. Aufgabe 6 aus 4.5.11 (DM+Pfennig → Euro, im Buch
eine WPF-Aufgabe, Sample `DmToEuroSep`) ohne Oberfläche, ergänzt um die
Temperaturumrechnung.

- `CelsiusInFahrenheit`: Wer `9 / 5 * celsius + 32` schreibt, bekommt
  `celsius + 32` (Ganzzahldivision ergibt 1). Der Test mit 37 °C fängt das.
  Richtig sind `celsius * 9 / 5 + 32` oder `9.0 / 5`.
- `DmInEuro`: `pfennig / 100` ist wieder Ganzzahldivision; `pfennig / 100m`
  oder `dm + pfennig / 100m` ist richtig. Ein `double` an dieser Stelle ist
  der eigentliche Fehler — Geld gehört in `decimal`.
- Die Konstante prüft ein Test per Reflexion (`const` + `decimal`). Fragen:
  Warum `const` und nicht einfach die Zahl zweimal hinschreiben?
- `Kassenbon`: `(int)(betrag * 100) % 100` — die Klammern um den Cast sind
  der Punkt.

Modellantwort:

```csharp
public const decimal DmProEuro = 1.95583m;

public static double CelsiusInFahrenheit(double celsius) => celsius * 9 / 5 + 32;
public static double FahrenheitInCelsius(double fahrenheit) => (fahrenheit - 32) * 5 / 9;
public static decimal EuroInDm(decimal euro) =>
    Math.Round(euro * DmProEuro, 2, MidpointRounding.AwayFromZero);
public static decimal DmInEuro(int dm, int pfennig) =>
    Math.Round((dm + pfennig / 100m) / DmProEuro, 2, MidpointRounding.AwayFromZero);
public static string Kassenbon(decimal betrag) =>
    $"{(int)betrag} Euro und {(int)(betrag * 100) % 100} Cent";
```
