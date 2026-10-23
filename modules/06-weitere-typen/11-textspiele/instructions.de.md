# Zusatzaufgabe: Palindrome, Anagramme, Lauflängen

Diese Aufgabe ist freiwillig. Sie übt den Umgang mit einzelnen Zeichen,
`StringBuilder` und die Klasse `Array`. Zum Nachlesen: **6.3 Klassen für
Zeichenfolgen** (Seite 472) und **6.2.6 Suchen und Sortieren** (Seite 463).

Öffne `Wortspiele.cs` und implementiere die vier statischen Methoden:

1. `IstPalindrom(s)`: Ein Text ist ein Palindrom, wenn er vorwärts und
   rückwärts gleich lautet. Dabei zählen nur Buchstaben (`char.IsLetter`),
   und Groß-/Kleinschreibung ist egal (`char.ToLower`). So ist auch
   `"Eine güldne, gute Tugend: Lüge nie!"` ein Palindrom. Lauf mit zwei
   Indizes von beiden Enden aufeinander zu und überspringe
   Nicht-Buchstaben. Ein leerer Text ist ein Palindrom.
2. `IstAnagramm(a, b)`: Zwei Texte sind Anagramme, wenn sie aus genau
   denselben Buchstaben bestehen (wieder nur Buchstaben, ohne
   Groß-/Kleinschreibung). Tipp: Die Buchstaben klein in ein `char[]`
   sammeln, mit `Array.Sort` sortieren und mit `new string(...)` vergleichen.
3. `Kodiere(s)`: Lauflängenkodierung. Jeder Lauf gleicher Zeichen wird zu
   Anzahl und Zeichen: `"AAABCC"` wird `"3A1B2C"`. Der Text enthält keine
   Ziffern.
4. `Dekodiere(code)`: die Umkehrung. Die Anzahl kann mehrstellig sein
   (`"12x"`); sammle die Ziffern (`char.IsDigit`, `c - '0'`) zu einer Zahl,
   bis ein Nicht-Ziffer-Zeichen kommt. `StringBuilder.Append(c, anzahl)`
   hängt ein Zeichen mehrfach an.

Diese Tests müssen bestehen:

- `WortspieleTests.Einfache_Palindrome`
- `WortspieleTests.Palindrom_ignoriert_Satzzeichen_Leerzeichen_und_Grossschreibung`
- `WortspieleTests.Anagramme_werden_erkannt`
- `WortspieleTests.Anagramm_ignoriert_Grossschreibung_und_Nicht_Buchstaben`
- `WortspieleTests.Keine_Anagramme`
- `WortspieleTests.Kodiere_zaehlt_Laeufe`
- `WortspieleTests.Dekodiere_mit_mehrstelligen_Zahlen`
- `WortspieleTests.Dekodiere_hebt_Kodiere_auf`
