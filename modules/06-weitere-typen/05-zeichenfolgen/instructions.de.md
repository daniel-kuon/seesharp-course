# Zeichenfolgen: Zeilenumbruch, Glückszahl, StringBuilder

Lies im Buch Abschnitt **6.3 Klassen für Zeichenfolgen** (Seite 472):
6.3.1 `String` (Seite 472) mit seinen Methoden (6.3.1.2, Seite 473) und
6.3.2 `StringBuilder` (Seite 479). Die Aufgaben 5 und 6 in **6.10** (Seite 541) beschreiben
Glückszahl und Zeilenumbruch.

Öffne `StringUtil.cs` und implementiere die vier statischen Methoden:

1. `WrapLine(text, ncol = 72, hypSep = false)` zerlegt den Text an
   Leerzeichen (`text.Split(' ', StringSplitOptions.RemoveEmptyEntries)`,
   aus dem Tipp zu Aufgabe 6 in 6.10, Seite 542: liefert die Wörter ohne leere
   Einträge) und füllt Zeilen von
   höchstens `ncol` Zeichen: Passt das nächste Wort noch (mit dem trennenden
   Leerzeichen), kommt es in die Zeile, sonst beginnt eine neue. Ein Wort,
   das länger als `ncol` ist, wird hart geteilt. Die Zeilen kommen ohne
   Leerzeichen am Ende als `string[]` zurück. Mit `hypSep == true` darf
   zusätzlich hinter einem Bindestrich getrennt werden, der zwischen zwei
   Nicht-Leerzeichen steht (`Schmal-Zeile` → `Schmal-` / `Zeile`); hinter
   so einer Trennstelle steht kein Leerzeichen. Tipp (aus der Beispiellösung zum Buch): Markiere
   solche Bindestriche vor dem `Split` mit einem Platzhalter wie `{opt}`
   und einem Leerzeichen.
2. `Glueckszahl(vorname, nachname)`: Seed = Code des ersten Buchstabens des
   Vornamens + Code des letzten Buchstabens des Nachnamens, beide in
   Großschrift (`char` lässt sich direkt als `int` verwenden); Ergebnis
   `new Random(seed).Next(100) + 1`.
3. `ZaehleVokale(s)`: Zeichen für Zeichen durchlaufen (`foreach` über den
   String) und a, e, i, o, u in beiden Schreibweisen zählen.
4. `Umkehren(s)`: mit einem `StringBuilder` von hinten nach vorn aufbauen.

Denk daran: Strings sind unveränderlich. `text.Replace(...)` oder `ToUpper()`
liefern neue Strings, das Original bleibt, wie es war.
