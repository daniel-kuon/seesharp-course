# Rubrik — Zusatz: Bedingungen als Ausdrücke (nur für die Betreuung)

Zusatzaufgabe zu Level 2, die Gegenstücke zu den Fragen aus 4.5.11/3 und /5
als Code.

- `IstSchaltjahr`: Klammern setzen, auch wo `&&` vor `||` sie unnötig macht.
  Fragen: Was liefert der Ausdruck ohne Klammern? (Dasselbe — aber wer muss
  das beim Lesen nachschlagen?)
- `AusserhalbBereich` ohne `!`: `x < min || x > max`. Die Tests merken ein
  `!ImBereich(...)` nicht; im Review ansehen, ob De Morgan angewendet wurde.
- `Vorzeichen`, `Maximum`: verschachtelte `?:` sind lesbar, solange sie
  zeilenweise eingerückt sind. In Level 3 kommt `if`; dann vergleichen, was
  lesbarer ist.
- `Maximum` ohne `Math.Max`, nur zur Übung — im echten Code ist
  `Math.Max(a, Math.Max(b, c))` richtig.

Modellantwort:

```csharp
public static bool IstSchaltjahr(int jahr) =>
    (jahr % 4 == 0 && jahr % 100 != 0) || jahr % 400 == 0;
public static bool ImBereich(int x, int min, int max) => min <= x && x <= max;
public static bool AusserhalbBereich(int x, int min, int max) => x < min || x > max;
public static int Vorzeichen(int x) => x < 0 ? -1 : x > 0 ? 1 : 0;
public static int Maximum(int a, int b, int c) =>
    a >= b ? (a >= c ? a : c)
           : (b >= c ? b : c);
```
