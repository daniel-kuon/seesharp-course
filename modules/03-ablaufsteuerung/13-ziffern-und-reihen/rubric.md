# Rubrik — Zusatz: Ziffern und Reihen mit Schleifen (nur für die Betreuung)

Zusatzaufgabe zu Level 3, Fortsetzung von `sprachelemente-ziffern-und-uhrzeit`
(Level 2) mit Schleifen.

- `Einmaleins`: dasselbe Trennzeichen-Thema wie bei FizzBuzz.
- `Quersumme`: `while (n > 0)` — die 0 liefert dann ohne Sonderfall 0.
- `Umgedreht`: `ergebnis = ergebnis * 10 + n % 10; n /= 10;` ist das Muster.
  Fragen: Warum verschwindet bei 1230 die Null? (Führende Nullen gibt es bei
  Zahlen nicht.)
- `IstPalindrom`: Einzeiler über `Umgedreht`; wer die Logik dupliziert,
  darauf ansprechen.
- `Potenz`: `long ergebnis = 1;` — wer `int` nimmt, bekommt bei `Potenz(2, 40)`
  0 statt 1099511627776 (Überlauf, 4.6). Der Test ist absichtlich da.

Modellantwort:

```csharp
public static string Einmaleins(int zahl) {
    string reihe = "" + zahl;
    for (int i = 2; i <= 10; i++)
        reihe += " " + zahl * i;
    return reihe;
}

public static int Quersumme(long n) {
    int summe = 0;
    while (n > 0) {
        summe += (int)(n % 10);
        n /= 10;
    }
    return summe;
}

public static long Umgedreht(long n) {
    long ergebnis = 0;
    while (n > 0) {
        ergebnis = ergebnis * 10 + n % 10;
        n /= 10;
    }
    return ergebnis;
}

public static bool IstPalindrom(long n) => Umgedreht(n) == n;

public static long Potenz(int basis, int exponent) {
    long ergebnis = 1;
    for (int i = 0; i < exponent; i++)
        ergebnis *= basis;
    return ergebnis;
}
```
