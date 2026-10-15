# Rubrik — ggT per Subtraktion (nur für die Betreuung)

- Schleifenbedingung `a != b` statt eines Flags? Beides korrekt; die
  Flag-Variante aus `GGT.Diff` im Sample-Ordner (`ggt == 0`) kurz vergleichen.
- Was passiert bei `GgtDifferenz(0, 5)`? (Endlosschleife.) Nicht getestet,
  aber eine gute Frage zu Vorbedingungen.
- `GroessterExponent`: Hat der Trainee verstanden, warum die Antwort 52 ist
  (52 Mantissenbits)? Rückbezug auf Level 2.
- Mit `Stopwatch` einmal `GgtDifferenz(1, 1_000_000_000)` messen lassen —
  Motivation für die nächste Übung.

Modellantwort (angelehnt an `Elementare Sprachelemente/GGT.Diff` und `FloP`
im Tool-Repository):

```csharp
public static int GgtDifferenz(int a, int b) {
    while (a != b) {
        if (a > b)
            a -= b;
        else
            b -= a;
    }
    return a;
}

public static int GroessterExponent() {
    double eps = 1.0;
    int i = 0;
    while (1.0 + eps / 2.0 > 1.0) {
        eps /= 2.0;
        i++;
    }
    return i;
}
```
