# Rubrik — Rekursion (nur für die Betreuung)

- Abbruchbedingung zuerst, dann der Selbstaufruf mit kleinerem Problem. Wer
  `return GgtRekursiv(a, b)` schreibt, bekommt den Stack overflow aus dem Buch
  (Seite 384) — im Review zeigen lassen.
- `Fibonacci(30)` braucht bereits rund 2,7 Millionen Aufrufe; `Fibonacci(45)`
  wäre im Test zu langsam. Fragen: Warum? (Jeder Aufruf erzeugt zwei weitere; exponentiell.)
  Ausblick auf die iterative Variante im Sample `Klassen und Objekte/Rekursion`.
- `Fakultaet(21)` läuft über — Bezug zu 4.6 (Überlauf), `checked` erwähnen.
- Bonus: Der Trainee kann `GgtRekursiv` neben die iterative Fassung aus
  Level 3 legen und beide mit dem Debugger vergleichen.

Modellantwort: `samples/Klassen und Objekte/Bruch/b6 Rekursion` im
Tool-Repository (dort als private Methode `GGTr`); Fakultät und Fibonacci:

```csharp
public static int GgtRekursiv(int a, int b) {
    int rest = a % b;
    if (rest == 0)
        return b;
    else
        return GgtRekursiv(b, rest);
}

public static long Fakultaet(int n) {
    if (n <= 1)
        return 1;
    return n * Fakultaet(n - 1);
}

public static long Fibonacci(int n) {
    if (n < 2)
        return n;
    return Fibonacci(n - 1) + Fibonacci(n - 2);
}
```
