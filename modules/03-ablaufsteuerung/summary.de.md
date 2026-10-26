# Ablaufsteuerung

Bis hierher liefen Programme von oben nach unten. Abschnitt 4.7 des Buchs
(ab Seite 252) führt die Anweisungen ein, mit denen ein Programm entscheidet
und wiederholt: `if`, `switch`, `while`, `do`, `for`, `foreach`. Abschnitt 4.6
(Seite 244) davor behandelt Über- und Unterlauf; lies ihn mit, auch wenn er in
diesem Level nur am Rand vorkommt. Vier Übungen: zwei Varianten des
Euklidischen Algorithmus, eine Fehlersuche und ein Primzahltest.

## Verzweigungen (4.7.2, Seite 253)

`if (bedingung) anweisung else anweisung` verzweigt; mehrere Fälle reiht man
als `else if`-Kette. Die Bedingung muss ein `bool` sein, deshalb ist
`if (b = false)` kein Vergleich, sondern eine Zuweisung, die `false` liefert
und `b` nebenbei überschreibt; der Compiler warnt nur. Das **dangling else**
ist die zweite klassische Falle: Ein `else` gehört immer zum nächstgelegenen
`if` ohne `else`, egal wie der Code eingerückt ist. Geschweifte Klammern
machen die Absicht eindeutig.

`switch` vergleicht einen Wert mit mehreren Konstanten; jeder Zweig endet mit
`break` oder `return`. Der **switch-Ausdruck** (ab C# 8) liefert direkt einen
Wert: `tag switch { 1 => "Montag", …, _ => "ungültig" }`. Für Zuordnungen wie
Wochentage oder Kategorien ist er kürzer und lesbarer als eine `if`-Kette.

## Schleifen (4.7.3, Seite 270)

`for` (4.7.3.1, Seite 271) ist die zählergesteuerte Schleife: Initialisierung,
Bedingung, Fortschaltung in einer Zeile. `foreach` (4.7.3.2, Seite 273) läuft
über alle Elemente einer Kollektion, etwa die Zeichen eines Strings, ohne
Index. `while` (4.7.3.3, Seite 275) prüft die Bedingung vor jedem Durchlauf,
`do … while` erst danach, läuft also mindestens einmal. Eine Schleife, deren
Bedingung nie falsch wird, ist eine Endlosschleife; die häufigste Ursache ist
ein Semikolon direkt hinter dem Schleifenkopf, `while (i < 100);`, das als
leere Anweisung den gesamten Schleifenkörper ersetzt.

`break` verlässt die Schleife sofort, `continue` springt zum nächsten
Durchlauf (4.7.3.6, Seite 278). Beide sind erlaubt, aber oft lässt sich eine
Schleife ohne sie klarer schreiben: mit einer Bedingung, die den Abbruch
ausdrückt, oder mit `return` aus einer Methode.

## Methoden mit Parametern

Alle Übungen dieses Levels lagern die Logik in statische Methoden mit
Parametern aus, etwa `GgtModulo(int a, int b)`. Das ist mehr, als das Buch an
dieser Stelle tut (die Beispiele dort arbeiten direkt in `Main` mit
Konsoleneingabe), hat aber einen Grund: Nur eine Methode, die Werte entgegennimmt
und ein Ergebnis zurückgibt, lässt sich testen. Eine Methode mit `bool`-Rückgabe,
die eine Frage beantwortet (`IstPrim`), nennt man Prädikat.

## Euklids Algorithmus, zweimal (4.7.4, Aufgabe 6, Seite 282)

Der größte gemeinsame Teiler zweier Zahlen lässt sich durch wiederholtes
Subtrahieren bestimmen: Solange die Zahlen verschieden sind, zieht man die
kleinere von der größeren ab; am Ende sind beide gleich dem ggT. Das ist die
Variante aus Kapitel 1. Die Modulo-Variante ersetzt die vielen Subtraktionen
durch den Rest der Division: Der ggT von `a` und `b` ist der ggT von `b` und
`a % b`; wird der Rest 0, ist der letzte Divisor das Ergebnis. Bei stark
unterschiedlichen Zahlen ist das um Größenordnungen schneller. Beide Varianten
brauchst du später in der Klasse `Bruch`.

## Überlauf (4.6, Seite 244)

Ganzzahltypen haben einen festen Wertebereich. Steht `int.MaxValue + 1` als
konstanter Ausdruck im Code, meldet schon der Compiler einen Fehler (CS0220). Mit
Variablen zur Laufzeit (`x = x + 1` bei `x == int.MaxValue`) gibt es dagegen keinen
Fehler: Der Wert springt still auf den negativen Rand. Wer Zwischenergebnisse
nicht abschätzen kann, nimmt `long` oder lässt mit `checked` eine Ausnahme
auslösen. In diesem Level gibt es dazu keine eigene Übung; behalte das Thema
im Hinterkopf, wenn in Level 4 Fakultäten berechnet werden.

Vertiefung: Abschnitte 4.6 und 4.7 (Seite 244 bis 285), die Übungsaufgaben in
4.7.4 (Seite 281) sind die Vorlage für dieses Level.
