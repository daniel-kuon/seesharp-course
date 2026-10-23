# Rubrik — Zusatz: FizzBuzz (nur für die Betreuung)

Zusatzaufgabe zu Level 3. Abweichung von der Vorlage „FizzBuzz als
string-Array“: Arrays kommen erst in Level 6, deshalb liefert `Folge()` eine
Zeichenkette.

- `Wort`: Der Fall „durch 15 teilbar“ muss zuerst geprüft werden, sonst
  greift `Fizz` vorher. Wer `zahl % 3 == 0 && zahl % 5 == 0` schreibt statt
  `zahl % 15 == 0`, ist ebenso richtig.
- `Folge`: Das Leerzeichen-Problem (Trenner nur zwischen den Wörtern) gibt es
  in vielen Varianten: erstes Wort vor der Schleife, `if (i > 1)` in der
  Schleife oder am Ende `Trim()`. Alle gelten; nach dem Warum fragen.
- Ausblick: In Level 6 wird daraus `string.Join(" ", …)` bzw. ein
  `StringBuilder`.

Modellantwort:

```csharp
public static string Wort(int zahl) {
    if (zahl % 15 == 0)
        return "FizzBuzz";
    else if (zahl % 3 == 0)
        return "Fizz";
    else if (zahl % 5 == 0)
        return "Buzz";
    else
        return "" + zahl;
}

public static string Folge(int bis) {
    string folge = Wort(1);
    for (int i = 2; i <= bis; i++)
        folge += " " + Wort(i);
    return folge;
}
```
