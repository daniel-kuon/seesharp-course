# Rubrik — Die Gleitkomma-Falle (nur für die Betreuung)

- Kernfrage im Review: Warum ist `0.1 + 0.2 != 0.3` bei `double`, aber nicht bei
  `decimal`? (Binäre Darstellung, 0,1 ist periodisch.) Wann nimmt man welchen
  Typ? (Geld: `decimal`; Physik, Grafik: `double`.)
- `EinsPlusZweiHochMinus(53) == 1.0`: Die Mantisse hat 52 Bit; 2^-53 ist die
  halbe Auflösung bei 1,0 und wird weggerundet. Nicht jeder Trainee muss das
  bis ins Bit verstehen, aber die Größenordnung „etwa 16 Dezimalstellen“ schon.
- `IstUngefaehrGleich`: `<` oder `<=`? Beides besteht die Tests; kurz
  besprechen. Das Buch (4.5.4, Seite 223 f.) rät von der absoluten Differenz
  ab, weil die passende Schwelle von der Größenordnung abhängt, und empfiehlt
  `|d1 - d2| / |d1| < 1e-14` (absolute Schwelle nur beim Vergleich mit 0).
- Hat der Trainee `Math.Round(betrag, 2)` ohne `AwayFromZero` probiert und den
  Unterschied gesehen (Banker's Rounding)?

Modellantwort (kein Sample im Tool-Repository; `FloP` im Sample-Ordner ist
die Schleifenvariante):

```csharp
public static double SummeDouble() => 0.1 + 0.2;
public static decimal SummeDecimal() => 0.1m + 0.2m;
public static double EinsPlusZweiHochMinus(int i) => 1.0 + Math.Pow(2, -i);
public static bool IstUngefaehrGleich(double a, double b, double toleranz) => Math.Abs(a - b) < toleranz;
public static decimal RundeKaufmaennisch(decimal betrag) => Math.Round(betrag, 2, MidpointRounding.AwayFromZero);
```
