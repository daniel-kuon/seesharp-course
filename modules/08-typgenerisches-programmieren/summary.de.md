# Typgenerisches Programmieren

C# prüft Typen beim Übersetzen. Ein Stapel, der "irgendetwas" aufnehmen
soll, stand damit lange vor der Wahl zwischen einem Elementtyp `object` (mit
Casts, Boxing und Laufzeitfehlern) oder einer Kopie der Klasse pro Elementtyp.
Generische Typen lösen das (8.1, Seite 589): Die Klasse bekommt einen
**Typformalparameter**, der erst beim Verwenden durch einen konkreten Typ
ersetzt wird.

## Generische Klassen (8.2, Seite 591)

`class SimpleStack<T>` deklariert `T` als Platzhalter; im Rumpf steht er für
Felder (`T[] data`), Parameter (`Push(T element)`) und Rückgabetypen
(`T Pop()`). `new SimpleStack<double>(10)` **konkretisiert** die Klasse;
`SimpleStack<double>` und `SimpleStack<string>` sind danach zwei verschiedene
Typen, auch zur Laufzeit (8.4, Seite 601). Werttypen als Typargumente sind
ausdrücklich erlaubt und werden nicht geboxt; daher ist `List<int>` dem alten
`ArrayList` haushoch überlegen (8.8 Aufgabe 2).

## Einschränkungen (8.2.2, Seite 593)

Ohne Zusatz weiß der Compiler über `T` nur, was jedes `object` kann. Mit
`where T : IComparable<T>` darf die Klasse `element.CompareTo(other)`
aufrufen und schließt zugleich Typen aus, die das nicht können. Weitere
Arten: eine Basisklasse, `class`, `struct`, `new()` (für `new T()`),
`notnull`, `unmanaged`; mehrere werden mit Komma kombiniert, `struct` oder
`class` zuerst, `new()` zuletzt. Die sortierte Liste des Levels zeigt den
typischen Fall: Einfügen an der richtigen Stelle braucht einen Vergleich.

Generische Klassen können von anderen Klassen erben und beerbt werden (8.2.3,
Seite 596); eine offene generische Basis braucht in der abgeleiteten Klasse
einen eigenen Typformalparameter. Was nicht geht: `List<object> lo = new
List<string>()`. Generische Klassen sind **invariant**; sonst könnte man über
`lo` ein `int` in eine String-Liste schreiben. Varianz gibt es nur bei
Interfaces und Delegaten (Level 9 und 12).

## Nullable<T> (8.3, Seite 598)

`int?` ist die Kurzform der generischen Struktur `Nullable<int>`: ein Wert
plus das Flag `HasValue`. `wert ?? ersatz` liefert den Wert oder den Ersatz
(8.3.2, Seite 600); `??=` weist nur zu, wenn die Variable null ist. Nicht
verwechseln mit `string?`, der Nullable-Annotation für Referenztypen aus
Level 14.

## Generische Methoden und Typinferenz (8.5, Seite 602)

Auch eine einzelne Methode kann einen eigenen Typformalparameter haben:
`static T Max<T>(params T[] werte) where T : IComparable<T>`. Beim Aufruf
`Serie.Max(3, 9, 4)` leitet der Compiler `T = int` aus den Argumenten ab;
nur bei leerer Argumentliste (`Serie.Max<int>()`) musst du ihn nennen. Eine
Methode, die bloß das `T` ihrer Klasse benutzt (`T Pop()`), ist dagegen
nicht generisch (8.8 Aufgabe 1). Serienparameter (`params T[]`) nehmen
beliebig viele Werte oder ein Array entgegen.

## Generische Erweiterungsmitglieder (8.6, Seite 604)

Der Erweiterungsblock aus Level 7 wird generisch: `extension<T>(T[] arr)
where T : IComparable<T>` rüstet alle Arrays vergleichbarer Elemente mit
Eigenschaften wie `MinFirst` nach. Die klassische Form ist eine generische
Methode mit `this`-Parameter: `static bool? LeadingMin<T>(this T[] arr)`.
Der Empfänger zählt bei der Typinferenz als erstes Argument.

## default (8.7, Seite 605)

`default(T)` oder kurz `default` liefert den Standardwert eines Typs: 0,
`false`, `null` für Referenztypen und für `Nullable<T>`. Das braucht
generischer Code, der ein `T` initialisieren muss, ohne den Typ zu kennen;
ein Objekt erzeugt nur `new T()` mit der Einschränkung `new()`.

Vertiefung im Buch: Kapitel 8 (Seite 589 bis 608); die Übungsaufgaben in
8.8 (Seite 607) liefern das Quiz und `Max<T>()` dieses Levels. `Listenwerte`
im Beispielordner misst den Boxing-Aufwand von `ArrayList`.
