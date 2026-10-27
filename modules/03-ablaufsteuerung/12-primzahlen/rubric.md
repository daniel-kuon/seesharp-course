# Rubrik — Zusatz: Primzahlen zählen und zerlegen (nur für die Betreuung)

Zusatzaufgabe zu Level 3. `IstPrim` ist die Modellantwort aus
`ablauf-primzahl-und-switch` (dort `long`, hier `int`); die Übung setzt sie
per `requires: algo.prime-test` als bestanden voraus.

- `AnzahlBis`: Wer bei 1 oder 0 beginnt, ist auch richtig, weil `IstPrim`
  diese Zahlen ablehnt. Gut, wenn der Trainee das bemerkt.
- `NaechsteNach`: `do { n++; } while (!IstPrim(n));` — hier ist `do` die
  natürliche Schleife, weil `n` selbst nicht in Frage kommt.
- `SindZwillinge`: Einzeiler mit `&&`. Wer `if (…) return true; else return
  false;` schreibt, darauf ansprechen.
- `Primfaktoren`: Das Trennzeichen-Problem wie bei FizzBuzz. Nachfragen,
  warum der Teiler nie eine zusammengesetzte Zahl sein kann, wenn er `n`
  teilt (deren Primfaktoren wurden vorher schon herausgeteilt) —
  deshalb braucht `Primfaktoren` `IstPrim` gar nicht.

Modellantwort:

```csharp
public static int AnzahlBis(int n) {
    int anzahl = 0;
    for (int i = 2; i <= n; i++)
        if (IstPrim(i))
            anzahl++;
    return anzahl;
}

public static int NaechsteNach(int n) {
    do {
        n++;
    } while (!IstPrim(n));
    return n;
}

public static bool SindZwillinge(int n) => IstPrim(n) && IstPrim(n + 2);

public static string Primfaktoren(int n) {
    string faktoren = "";
    int teiler = 2;
    while (n > 1) {
        if (n % teiler == 0) {
            faktoren += faktoren == "" ? "" + teiler : " * " + teiler;
            n /= teiler;
        } else
            teiler++;
    }
    return faktoren;
}
```
