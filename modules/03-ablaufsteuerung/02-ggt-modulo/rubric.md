# Rubrik — ggT mit Modulo (nur für die Betreuung)

- Die Schleife soll `do … while (rest > 0)` sein; eine `while`-Variante ist
  nicht falsch, aber fragen, warum `do` hier natürlich ist (der Rest muss
  erst einmal berechnet werden).
- `Kgv`: `a / ggt * b` statt `a * b / ggt` — Überlauf vermeiden; Bezug zu 4.6.
- Was passiert bei `GgtModulo(5, 0)`? (Division durch null.) Vorbedingung
  besprechen.
- Diese Methode wandert in Level 4 fast wörtlich in `Bruch.Kuerze()`.

Modellantwort (angelehnt an `Elementare Sprachelemente/GGT.Mod` im
Tool-Repository):

```csharp
public static int GgtModulo(int a, int b) {
    int rest;
    do {
        rest = a % b;
        a = b;
        b = rest;
    } while (rest > 0);
    return a;
}

public static int Kgv(int a, int b) => a / GgtModulo(a, b) * b;
```
