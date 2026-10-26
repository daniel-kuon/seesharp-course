# Rubrik: Verständnisfragen, Weitere Typen (nur für die Betreuung)

Gilt für alle offenen Fragen. Eine Antwort besteht, wenn alle wesentlichen Punkte
sinngemäß vorkommen; der Wortlaut ist egal. Die Multiple-Choice-Fragen werten sich
selbst aus (Lösungen: `tausch` = `(a, b) = (b, a);`, `schleife` = `i < z.Length`,
`stringbuilder` = Append in der Schleife und `sb.ToString()`, `tupel-rueckgabe` = erste Option).

## wert-referenz

Wesentliche Punkte:
- Ein **Werttyp** (`struct`, `int`, `double`, `bool`, `char`, Tupel) enthält seine Daten selbst;
  `var b = a;` **kopiert** den Inhalt, danach sind `a` und `b` unabhängig.
- Ein **Referenztyp** (`class`, Array, `string`, Record) wird über einen Verweis erreicht;
  `var b = a;` kopiert nur den **Verweis**, beide zeigen auf **dasselbe** Objekt.
- Bei der Übergabe als Argument gilt dasselbe: Die Methode bekommt bei einer `struct` eine
  **Kopie** (Änderungen kommen beim Aufrufer nicht an), bei einem Array denselben Verweis
  (sie kann die Elemente des Aufrufers ändern, z. B. `Mische(vektor, rnd)`).
- Mindestens ein Beispieltyp je Art.

Typische Missverständnisse: "Arrays sind Werttypen, weil sie `int` enthalten" (der
Elementtyp ist unerheblich, das Array selbst ist ein Referenztyp); `string` für einen
Werttyp halten, weil er sich beim Zuweisen "wie ein Wert" verhält (er ist ein
unveränderlicher Referenztyp); Wert-/Referenztyp mit Stack/Heap gleichsetzen, ohne die
Kopiersemantik zu nennen (kein Punktabzug, aber die Kopiersemantik muss vorkommen).

## boxing

Wesentliche Punkte:
- **Boxing** = ein Wert (z. B. `int` oder eine `struct`) wird einer `object`-Variablen (oder
  einem Interface) zugewiesen und dabei in ein **neues Heap-Objekt kopiert**; Unboxing
  ist der Cast zurück.
- Es passiert **implizit**, etwa bei `object x = 1;`, beim Aufruf einer Methode mit
  `object`-Parameter oder beim alten `ArrayList`; es kostet Speicher und Zeit.
- Jedes Boxing erzeugt ein **eigenes** Objekt. `x == y` auf zwei `object`-Variablen vergleicht
  die **Verweise** (zwei verschiedene Boxen: `false`), `Equals` vergleicht den **Inhalt**
  (beide 1: `true`).

Typische Missverständnisse: `==` vergleiche immer den Wert (das gilt nur, wenn beide
Operanden statisch `int` sind); Boxing sei dasselbe wie Casten zwischen `int` und
`double`; Boxing sei ein Ausnahmefall und geschehe nie "aus Versehen".

## string-unveraenderlich

Wesentliche Punkte:
- `string` ist **unveränderlich**: Keine Methode ändert den vorhandenen String. `ToUpper()`
  liefert einen **neuen** String; `name.ToUpper();` verwirft ihn. Richtig:
  `name = name.ToUpper();`.
- Folge: `s += x` erzeugt in jedem Schritt einen neuen String und kopiert den ganzen
  bisherigen Text.
- `StringBuilder` nimmt man, wenn man in einer **Schleife** (oder sehr oft) Text anhängt:
  `Append` ändert denselben Puffer; am Ende `ToString()`.

Typische Missverständnisse: "ToUpper verändert den String nur, wenn man ihn zuweist"
(es verändert nie, man speichert das neue Ergebnis); `StringBuilder` für jede
Verkettung von zwei, drei Teilen empfehlen (für wenige Teile ist `+` oder
Interpolation in Ordnung).

## record-vs-klasse

Wesentliche Punkte:
- Geschenkt bekommt man: Konstruktor, Eigenschaften (`init`), `Deconstruct`,
  **Wertgleichheit** (`==`, `Equals`, `GetHashCode`), ein lesbares `ToString()` und die
  Grundlage für `with`. Mindestens zwei davon nennen, Wertgleichheit muss dabei sein.
- `==` bei Records vergleicht die **Werte** der Eigenschaften (gleiche Inhalte: `true`),
  bei Klassen ohne eigene Überladung die **Verweise** (zwei getrennt erzeugte Objekte:
  `false`).
- `with` erzeugt eine **veränderte Kopie** (`a with { Menge = 5 }`); das Original bleibt
  unverändert. Das passt zu unveränderlichen Datenobjekten.

Typische Missverständnisse: Records seien Werttypen (es sind Referenztypen, die sich wie
Werte vergleichen; erst `record struct` ist ein Werttyp); `with` ändere das Original.

## code-struct

Ausgabe: `1 2`
- `Punkt` ist eine `struct`: `Punkt b = a;` **kopiert**, die Zuweisung `b.X = 2` ändert nur `b`.
- `Setze(a)` bekommt eine **Kopie** von `a` und setzt deren `X` auf 99; `a.X` bleibt `1`.
  `b.X` ist `2`.
- Beide Zahlen müssen begründet sein. Wäre `Punkt` eine `class`, käme `99 99` heraus.

Typische Fehler: `99 2` (Kopie beim Aufruf übersehen), `2 2` oder `99 99` (`struct` wie
`class` behandelt).

## code-array-string

Ausgabe: `1,2,3 abc`
- `b = a` kopiert nur den Verweis; `Array.Sort(b)` sortiert **dasselbe** Array, also ist
  `a` sortiert: `1,2,3`.
- `string` ist unveränderlich: `s += "d"` erzeugt einen **neuen** String und lässt `s` darauf
  zeigen; `t` zeigt weiter auf den alten `"abc"`.
- Gegensatz: Das Array ist ein veränderliches Referenzobjekt (beide Variablen sehen die
  Änderung), der String ist ein unveränderliches (eine "Änderung" ist ein neues Objekt).

Typische Fehler: `3,1,2 abc` (Array wie eine Kopie behandelt) oder `1,2,3 abcd`.

## code-record

Ausgabe, drei Zeilen: `True`, `False`, `Artikel { Name = Stift, Menge = 5 }`
- `a == c`: Records vergleichen Werte, Name und Menge sind gleich: `True`.
- `ReferenceEquals(a, c)`: Es sind zwei getrennt erzeugte Objekte: `False`.
- `b` ist eine Kopie von `a` mit `Menge = 5`; das erzeugte `ToString()` zeigt
  den Typnamen und die Eigenschaften. Die Form der Ausgabe muss nicht wörtlich stimmen,
  aber "Name = Stift, Menge = 5" ist zu erwarten, nicht `Artikel`
  oder `System.Object`.

Typische Fehler: `False` für die erste Zeile (Records wie Klassen vergleichen),
`True` für die zweite.

## code-enum

Ausgabe, drei Zeilen: `7`, `1`, `False`
- Ein `enum` ist im Kern eine Ganzzahl (hier `int`) mit Namen für einige Werte. Der Cast
  `(Ampel)7` gelingt immer, auch wenn kein Name zu 7 gehört; deshalb keine Ausnahme.
- `Console.WriteLine(a)` kann keinen Namen finden und gibt die Zahl `7` aus.
- `(int)Ampel.Gelb` ist `1`, weil die Werte bei 0 beginnen (Rot 0, Gelb 1, Gruen 2).
- `Enum.IsDefined(a)` prüft, ob es einen Namen zum Wert gibt: `False`. Wer gültige Werte
  braucht, prüft damit oder lässt einen validierenden Setter ablehnen.

Typische Fehler: Es werde eine `InvalidCastException` oder `ArgumentException` erwartet;
`2` für `(int)Ampel.Gelb` (Zählung bei 1).
