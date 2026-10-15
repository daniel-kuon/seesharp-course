# Rubrik — Datentypen und Konvertierungen (nur für die Betreuung)

- `ZeichenCode`: `return c;` genügt. Hat der Trainee unnötig `(int)c`
  geschrieben? Nicht falsch, aber fragen, warum es ohne geht.
- `Verschiebe`: `(char)(c + um)` — die Klammern sind der Punkt. `(char)c + um`
  ergibt `int` und kompiliert nicht als Rückgabe.
- `Mittelwert`: `(a + b) / 2.0` oder `(double)(a + b) / 2`. Wer `(double)(a + b
  / 2)` schreibt, bekommt 1.0 — Lehrmoment für die Rangfolge.
- `Abschneiden`: Cast schneidet ab, `Math.Round` rundet; beides kurz zeigen.

Modellantwort (kein Sample im Tool-Repository):

```csharp
public static int ZeichenCode(char c) => c;
public static char Verschiebe(char c, int um) => (char)(c + um);
public static int Abschneiden(double d) => (int)d;
public static double Mittelwert(int a, int b) => (a + b) / 2.0;
public static int Rest(int a, int b) => a % b;
```
