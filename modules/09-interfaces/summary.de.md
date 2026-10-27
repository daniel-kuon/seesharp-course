# Interfaces

Ein Interface ist eine Verpflichtungserklärung: Es zählt Methoden,
Eigenschaften, Indexer (und Ereignisse) auf, die ein Typ anbieten muss,
ohne sie selbst zu implementieren (Kapitel 9, Seite 609). Wer sich mit
`class Bruch : IComparable<Bruch>` zu einem Interface bekennt, muss liefern
und wird dafür überall akzeptiert, wo das Interface als Typ steht. Die BCL
ist voll davon: Der Definitionskopf von `String` nennt acht Interfaces, `Array.Sort`
verlangt `IComparable<T>`, `foreach` verlangt `IEnumerable<T>`.

## Definieren und implementieren (9.1 bis 9.3, Seite 614 bis 646)

Interface-Mitglieder ohne Rumpf sind implizit `public` und abstrakt;
Instanzfelder und Konstruktoren gibt es nicht. Eine Klasse oder **Struktur** implementiert beliebig viele
Interfaces, erbt aber nur von einer Basisklasse. Das ist die Antwort auf
die Buchfrage nach dem Unterschied zu abstrakten Klassen (9.6 Aufgabe 2):
Abstrakte Klassen geben Zustand und Code an eine Hierarchie weiter,
Interfaces beschreiben eine Fähigkeit quer durch alle Hierarchien. Als
Referenztyp erlaubt ein Interface gemischte Arrays (`IForm[]` mit Kreisen
und Quadraten); beim Zuweisen einer Struktur an eine Interface-Variable
wird sie **geboxt**: Änderungen über die Interface-Variable treffen nur die
geboxte Kopie, nicht das Original (9.3.2, Seite 645). Seit C# 8 dürfen Interfaces konkrete Mitglieder mit
Standardimplementierung enthalten (9.1.1.2, Seite 616).

## Explizite Implementierung (9.4, Seite 646)

Verlangen zwei Interfaces gleichnamige Mitglieder mit verschiedener
Bedeutung, oder soll ein Mitglied nicht in der öffentlichen Schnittstelle
der Klasse auftauchen, implementiert man es **explizit**: `int
IMesser.Wert() => 2;` ohne Zugriffsmodifikator. Der Aufruf geht dann nur über eine
Referenz vom Interface-Typ. Die BCL macht das ständig: Das nicht-generische
`IEnumerable.GetEnumerator()` ist meist explizit, damit nur die generische
Fassung sichtbar bleibt.

## IComparable<T> und ICloneable (9.2, Seite 640; 9.6 Aufgabe 1)

`CompareTo` liefert negativ, 0 oder positiv und macht `Array.Sort` und
`List<T>.Sort` möglich; `Bruch` vergleicht per Kreuzmultiplikation (in
`long`, damit nichts überläuft). Generische Schnittstellen sind den alten
nicht-generischen vorzuziehen: typsicher, ohne Cast, ohne Boxing bei
Strukturen (9.2.3, Seite 642). `ICloneable` ist so ein Altfall: Sein `object
Clone()` zwingt zum Cast, deshalb bleibt die eigene typsichere `Klone()`
daneben sinnvoll; `MemberwiseClone()` liefert die flache Kopie.

## IEnumerable<T>, IEnumerator<T> und yield (9.5, Seite 647)

`foreach` holt sich mit `GetEnumerator()` einen Enumerator und ruft
`MoveNext()` auf, bis es `false` liefert; `Current` ist das aktuelle
Element. Einen Enumerator von Hand zu schreiben (geschachtelte Klasse mit
Position, `MoveNext`, `Current`, `Reset`) zeigt das Protokoll; mit `yield
return` erzeugt der Compiler die Zustandsmaschine selbst (9.5.1, Seite 648).
Iteratoren können auch benannte Methoden oder Eigenschaften sein
(`RangeIt`, `DownIt`; 9.5.3, Seite 652; `RangeItUpDown` ist 9.6 Aufgabe 4), `yield break`
beendet sie vorzeitig. Wichtig: Iteratoren sind **faul**, ihr Rumpf läuft
erst beim Durchlaufen. LINQ in Level 13 baut vollständig darauf auf.

## Statische abstrakte Mitglieder und generische Mathematik (9.1.2, 9.1.3, Seite 622 bis 631)

Seit C# 11 kann ein Interface statische abstrakte Mitglieder und sogar
Operatoren verlangen (`static abstract TSelf operator +`). Die BCL nutzt das für
`IAdditionOperators<T, T, T>`, `INumber<T>` und Verwandte: Generischer
Code darf `a + b` schreiben, sobald `T` das Interface zusichert, und das
gilt für `int`, `double`, `decimal` und eigene Typen wie `Bruch`
gleichermaßen. Die `checked`-Variante eines Operators (`operator checked
+`) wird in `checked`-Kontexten gewählt und soll mit `checked(...)` bei
Überlauf `OverflowException` werfen; die Vorgabe im Interface tut das
nicht (9.6 Aufgabe 3).

## Ko- und Kontravarianz (9.1.5, Seite 634)

Generische Klassen sind invariant (Level 8). Generische Interfaces dürfen
Typformalparameter als `out` (nur Ausgabe) oder `in` (nur Eingabe)
markieren: `IEnumerable<out T>` ist **kovariant**, eine Folge von Kreisen
geht als Folge von Figuren durch (9.1.5.1); `IComparable<in T>` ist
**kontravariant**: `Kreis` erbt von `Figur` nur `IComparable<Figur>`, und
trotzdem sortiert `List<Kreis>.Sort()` die Kreise (9.1.5.2). Kommt `T` in beiden Positionen vor (`IList<T>`), bleibt nur
Invarianz.

Vertiefung im Buch: Kapitel 9 (Seite 609 bis 656); die Übungsaufgaben in
9.6 (Seite 655) liefern `IComparable`/`ICloneable`, `operator checked +`
und `RangeItUpDown` dieses Levels. Statische Polymorphie (9.1.2.3) und
das CRTP (9.1.3.3) sind Zusatzstoff.
