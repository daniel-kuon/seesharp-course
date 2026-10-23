# Rubrik — Zusatz: Collatz-Folge (nur für die Betreuung)

Zusatzaufgabe zu Level 3 (kein Buchbezug; Collatz-Vermutung, Lothar Collatz
1937).

- `Schritte`: `while (n != 1)` mit Zähler. Wer `n > 1` schreibt, ist ebenso
  richtig. Nachfragen: Was passiert bei `Schritte(0)`? (Endlosschleife, 0 ist
  gerade und bleibt 0.) Vorbedingung besprechen.
- `Hoechstwert`: Startwert mitzählen — der Test mit 64 (Zweierpotenz) fängt
  das Vergessen.
- `LaengsterStartBis`: `>` statt `>=` beim Vergleich sorgt für den kleineren
  Startwert bei Gleichstand. Die Tests prüfen das nicht (bis 10 und bis 100
  ist das Maximum eindeutig); im Review fragen, was `>=` ändern würde.
- Warum `long`: Startwerte unter 1 Million erreichen Höchstwerte über
  `int.MaxValue`. Bezug zu Überlauf (4.6).

Modellantwort:

```csharp
public static int Schritte(long n) {
    int schritte = 0;
    while (n != 1) {
        if (n % 2 == 0)
            n /= 2;
        else
            n = 3 * n + 1;
        schritte++;
    }
    return schritte;
}

public static long Hoechstwert(long n) {
    long max = n;
    while (n != 1) {
        if (n % 2 == 0)
            n /= 2;
        else
            n = 3 * n + 1;
        if (n > max)
            max = n;
    }
    return max;
}

public static int LaengsterStartBis(int grenze) {
    int besterStart = 1;
    int meisteSchritte = 0;
    for (int start = 1; start <= grenze; start++) {
        int schritte = Schritte(start);
        if (schritte > meisteSchritte) {
            meisteSchritte = schritte;
            besterStart = start;
        }
    }
    return besterStart;
}
```
