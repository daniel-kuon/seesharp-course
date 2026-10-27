# Weitere Typen: Strukturen, Arrays, Strings, Enums, Tupel, Records

Nach den Klassen lernst du in Kapitel 6 (ab Seite 431) die übrigen Bausteine
des Typsystems kennen. Der rote Faden ist die Frage **Wert oder Referenz**:
Wird beim Zuweisen kopiert oder nur ein Verweis weitergegeben? Davon hängt
ab, was eine Methode am Argument ändern kann und wann zwei Dinge "gleich"
sind.

## Strukturen und Boxing (6.1, Seite 431)

Eine `struct` sieht aus wie eine Klasse, ist aber ein **Werttyp**: `var p3 =
p1;` kopiert alle Felder, und eine Methode mit einem Strukturparameter
arbeitet auf einer Kopie (6.1.1, Seite 434). Strukturen eignen sich für
kleine, wertartige Dinge wie einen Punkt. Weist man eine Struktur einer
`object`-Variablen zu, wird sie **geboxt**, also in ein Heap-Objekt kopiert
(6.1.6, Seite 450); deshalb sind zwei geboxte `1` mit `==` ungleich, mit
`Equals` aber gleich.

## Arrays (6.2, Seite 455)

Ein Array hat eine feste Länge und einen Elementtyp; `new int[49]` liefert
lauter Nullen, `Length` und der Index von 0 bis `Length - 1` steuern die
Schleife. Arrays sind **Referenztypen**: `Mische(vektor, rnd)` kann das Array
des Aufrufers verändern, ohne etwas zurückzugeben. Die Klasse `Array` bringt
`IndexOf`, `Sort` und `BinarySearch` mit (6.2.6, Seite 463), dazu `Resize`
(6.2.2, Seite 458). Drei
Algorithmen aus den Übungen 6.10 solltest du von Hand können: das **Sieb des
Eratosthenes** über ein `bool[]`, **Fisher-Yates** zum Mischen und
**Selection Sort**. Mehrdimensionale Arrays (`float[,]`, 6.2.9, Seite 467)
sind rechteckig; der zweidimensionale Indexer `m[i, j]` macht eine Matrix
bequem. Ein `Random` mit festem Initialisierungswert (Seed) liefert immer dieselbe Folge, das macht
Zufall testbar (6.2.4, Seite 459).

## Zeichenfolgen (6.3, Seite 472)

`string` ist **unveränderlich**: `s.ToUpper()` ändert `s` nicht, sondern
liefert einen neuen String; `s += c` in einer Schleife kopiert jedes Mal den
ganzen Text. Für den Aufbau langer Texte gibt es `StringBuilder` mit `Append`
(6.3.2, Seite 479). Das Buch zeigt in 6.3.1.2 (Seite 473) u. a. `IndexOf`,
`Substring`, `Replace`, `StartsWith`, `ToUpper`/`ToLower` und `CompareTo`;
`Split` mit `StringSplitOptions.RemoveEmptyEntries` stellt der Tipp zu
Aufgabe 6 in 6.10 vor (Seite 542). Weitere String-Methoden siehe Deep Dive.
Mit `foreach (char c
in s)` läuft man über die Zeichen, und ein `char` rechnet direkt als `int`.

## Enumerationen (6.4, Seite 480)

Ein `enum` gibt einer Handvoll Ganzzahlen Namen. Der Cast `(Temperament)13`
gelingt immer, auch wenn es keinen solchen Wert gibt; `Enum.IsDefined` prüft
das, ein validierender Setter wehrt es ab. `(int)t` holt die Zahl. Den Weg
vom Namen zum Wert und zurück zeigt das Buch nicht (siehe Deep Dive).

## Tupel (6.6, Seite 486)

Ein Tupel `(string First, string Last, bool FirstPalin, bool LastPalin)` gibt
mehrere Werte aus einer Methode zurück, ohne eine Klasse zu deklarieren
(6.6.5, Seite 493). Beim Empfang **dekonstruiert** man es: `var (_, last, _,
pal) = AnalyzeName(...)` (6.6.4, Seite 491); `_` verwirft ein Element. Mit
einer eigenen `Deconstruct(out …)`-Methode lässt sich auch eine Klasse so
auseinandernehmen (6.6.6, Seite 494). Die Tupelzuweisung `(a, b) = (b, a)`
tauscht zwei Variablen ohne Hilfsvariable.

## Records (6.7, Seite 495)

`public record Artikel(string Name, int Menge)` erzeugt in einer Zeile einen
Konstruktor, `init`-Eigenschaften, `Deconstruct`, **Wertgleichheit** (`==`,
`Equals`, `GetHashCode`), ein lesbares `ToString()` und die Grundlage für
`with`-Ausdrücke (6.7.2 und 6.7.3, Seite 498 und 499): `this with { Menge =
5 }` liefert eine veränderte Kopie und lässt das Original in Ruhe. Records
sind Referenztypen, die sich wie Werte verhalten; `record struct` (6.7.5)
macht daraus echte Werttypen. Ihre Vererbung folgt in Level 7.

## Anonyme Klassen und using-Alias (6.5 und 6.8, Seite 483 und 504)

`new { Name = "Otto", Alter = 35 }` erzeugt ein Objekt einer anonymen Klasse,
deren Namen nur der Compiler vergibt (in C# nicht schreibbar), mit
Nur-Lese-Eigenschaften; die Variable muss `var` sein. Das ist für kurze
Zwischenergebnisse gedacht, in Level 13 (LINQ) wirst du es ständig sehen.
`using Koordinate = (double X, double Y);` gibt einem langen Typ einen
kurzen Namen für eine Datei, ohne einen neuen Typ zu erzeugen.

Vertiefung im Buch: 6.1 bis 6.8 (Seite 431 bis 505); 6.9 (RSS-Reader mit WPF)
ist nicht Teil des Kurses. Die Übungsaufgaben in 6.10 (Seite 537) sind die
Vorlage für Sieb, Lotto, Matrix, Glückszahl und Zeilenumbruch.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- **Enum-Werte als Text:** `ToString()` liefert den Namen eines Enum-Werts
  (bei einem undefinierten Wert wie `(Temperament)13` die Zahl).
  `Enum.Parse` und `Enum.TryParse` lesen einen Namen zurück, mit
  `ignoreCase: true` ohne Rücksicht auf Groß-/Kleinschreibung. `TryParse`
  akzeptiert auch Zahlen wie `"7"`; deshalb das Ergebnis zusätzlich mit
  `Enum.IsDefined` prüfen. Geübt im Deep-Dive-Teil von "Enumerationen und
  Tupel".
- **Weitere String-Methoden:** `Insert`, `Trim`/`TrimEnd`, `string.Join` und
  viele mehr beschreibt die BCL-Dokumentation zur Klasse `String`.
- **Weitere Array-Methoden:** `Array.Copy` kopiert einen Ausschnitt in ein
  anderes Array, eine Alternative zum Bereich `vektor[..6]`.
