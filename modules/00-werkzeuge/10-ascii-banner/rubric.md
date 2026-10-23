# Rubrik — Zusatz: ASCII-Banner (nur für die Betreuung)

Zusatzaufgabe zu Level 0. Ziel: noch einmal Methoden mit Rückgabewert
schreiben und erleben, dass Tests eine Spezifikation sind, keine
Musterlösung (die Tests prüfen Form, nicht Wortlaut).

- Hat der Trainee `Komplett()` aus `Rahmenlinie()` und `Titelzeile()`
  zusammengesetzt? Das ist die schönere Lösung: Eine Änderung der Linie wirkt
  dann überall. Wer ein Rohzeichenfolgenliteral schreibt, muss Linie und Titel
  doppelt pflegen — kurz darüber sprechen.
- Der Test vereinheitlicht Zeilenenden (`\r\n` / `\n`); ein Rohliteral in einer
  Datei mit Windows-Zeilenenden besteht deshalb auch.
- Nachfragen: Warum stehen in `Main()` keine Texte, sondern nur ein Aufruf?

Modellantwort:

```csharp
public static string Rahmenlinie() {
    return "+---------------------+";
}

public static string Titelzeile() {
    return "|  Hallo, SeeSharp!   |";
}

public static string Komplett() {
    return Rahmenlinie() + "\n" + Titelzeile() + "\n" + Rahmenlinie();
}
```
