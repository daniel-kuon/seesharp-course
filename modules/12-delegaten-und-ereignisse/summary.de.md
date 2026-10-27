# Delegaten, Lambda-Ausdrücke und Ereignisse

Ein **Delegat** ist ein Typ für Methodenreferenzen (Kapitel 10, Seite 657):
Er beschreibt eine Signatur, und ein Objekt dieses Typs zeigt auf eine
Methode mit genau dieser Signatur. Damit lässt sich Verhalten wie ein Wert
weitergeben, speichern und später aufrufen. In diesem Level lernst du
Delegaten, die kurze Schreibweise mit Lambda-Ausdrücken und darauf aufbauend
Ereignisse.

## Delegaten (10.1.1 und 10.1.2, Seite 659 bis 663)

`delegate double Operation(double a, double b);` deklariert einen
Delegatentyp. Für die Verträglichkeit zählen Parameterliste und Rückgabetyp,
nicht die Namen. Ein Delegatenobjekt entsteht aus einer **Methodengruppe**
(`Operation op = Rechner.Addiere;`, ohne Klammern) und wird wie eine Methode
aufgerufen (`op(2, 3)`, gleichwertig `op.Invoke(2, 3)`). Zeigt es auf eine
Instanzmethode, merkt es sich das Zielobjekt mit; Delegatenobjekte sind
unveränderlich. Weil ein Delegat ein ganz normaler Parameter ist, kann eine
Methode wie `Reduziere(Operation op, double[] werte)` ihr Verhalten von außen
erhalten.

## Mehrfachdelegaten (10.1.3 und 10.1.4, Seite 663 bis 665)

Mit `+=` und `-=` wächst oder schrumpft die **Aufrufliste** eines
Delegaten; jede Änderung erzeugt ein neues Objekt. Der Aufruf startet alle
Ziele in Anmeldereihenfolge; bei einem Rückgabewert zählt nur das **letzte**
Ziel. Wer alle Ergebnisse braucht, muss die Ziele einzeln aufrufen (siehe
Deep Dive). Ist die
Liste leer, ist die Variable `null`; vor dem Aufruf steht deshalb ein
null-Test (Seite 664) oder kürzer `aktion?.Invoke(...)` (null-bedingter
Operator, Vorgriff auf 15.1.5.2, Seite 971). Ob man einen Delegaten oder ein Interface als
Rückrufmechanismus wählt, ist eine Entwurfsfrage (10.1.4): Ein Delegat
schreibt genau eine Methode vor, der Methodenname ist egal, und ein Lambda
erledigt die Aufgabe an Ort und Stelle. Ein Interface kann mehrere
zusammengehörige Fähigkeiten verlangen.

## Anonyme Funktionen, Lambdas und Closures (10.1.5, Seite 665 bis 675)

Statt eine benannte Methode zu schreiben, erzeugt man den Delegaten inline:
als **anonyme Methode** (`delegate (int x) { ... }`, älter) oder als
**Lambda-Ausdruck**: `x => x * 2` (Ausdruckskörper) oder
`(a, b) => { ...; return ...; }` (Anweisungsblock). Welcher Delegatentyp
entsteht, entscheidet der Zieltyp. Die vordefinierten generischen
Delegaten decken fast alles ab: `Func<..., TResult>` mit Rückgabewert,
`Action<...>` ohne, `Predicate<T>` für Bedingungen. `List<T>` nutzt sie:
`FindAll(Predicate<T>)` (Seite 670 und 10.3 Aufgabe 2, Seite 688) und
`Sort(Comparison<T>)` (10.1.4, Seite 664); weitere Listenmethoden siehe Deep Dive.

Ein Lambda darf Variablen der umgebenden Methode benutzen. Es **fängt die
Variable ein**, nicht ihren Wert, und hält sie so lange am Leben wie das
Delegatenobjekt (**Closure**). Jeder Aufruf der Fabrikmethode erzeugt eine
eigene Variable und damit einen eigenen Zustand (`Zaehler()`). Aufpassen
musst du bei Schleifen: Fängt ein Lambda die Variable einer
`for`-Schleife ein, teilen sich alle Lambdas sie; eine Kopie je Durchlauf
oder `foreach` löst das.

## Ko- und Kontravarianz (10.1.6, Seite 675 bis 677)

Wie bei Interfaces (Level 9) gilt für generische Delegaten: `Func<out T>` ist
kovariant (`Func<string>` passt als `Func<object>`), `Action<in T>` und
`Comparison<in T>` sind kontravariant (`Action<object>` passt als
`Action<string>`).

## Ereignisse (10.2, Seite 678 bis 688)

Ein **Ereignis** (`event`) ist ein Klassenmitglied, das einen Delegaten schützt: Hinter ihm
steht eine private Delegatenvariable, nach außen gibt es nur `+=` und `-=`
(10.2.1). Fremde Klassen können sich also an- und abmelden, das Ereignis
aber weder auslösen noch per Zuweisung (`=`) ersetzen. Ein öffentliches Delegatenfeld
erlaubt beides, ist also kein Ersatz. Das Standardmuster:
`EventHandler<TEventArgs>` als Typ, eine eigene `EventArgs`-Ableitung für
Nutzdaten und eine `protected virtual void OnXyz(...)`-Methode, die mit
`Xyz?.Invoke(this, e)` auslöst; abgeleitete Klassen überschreiben sie, um die
Auslösung zu steuern (10.2.3, Seite 687 f.). Eine Behandlungsmethode hat die Parameter
`(object? sender, TEventArgs e)` (10.2.2, Seite 682); `sender` ist die
Ereignisquelle und lässt sich zurückcasten, wenn mehrere Objekte dieselbe Methode
nutzen. Wer sich anmeldet, sollte sich wieder abmelden: Über die Aufrufliste
hält der Anbieter den Abonnenten am Leben. Ein Lambda lässt sich nur
abmelden, wenn man dasselbe Delegatenobjekt aufbewahrt hat.

Vertiefung im Buch: Kapitel 10 (Seite 657 bis 689); die Übungsaufgaben
in 10.3 (Seite 688 f.) liefern die Quizfragen und `ListLE(k)` dieses Levels.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- `GetInvocationList()` liefert die Aufrufliste eines Delegaten als Array.
  Damit erreicht man jedes Ziel einzeln, etwa um die Ziele zu zählen
  (Aufgabe 02) oder alle Rückgabewerte einzusammeln.
- Weitere Methoden von `List<T>`, die Delegaten erwarten (Aufgaben 03 und 11):
  `Exists(Predicate<T>)`, `Find(Predicate<T>)` (erstes passendes Element oder
  `default`), `RemoveAll(Predicate<T>)` (löscht in der Liste selbst und liefert
  die Anzahl) und `ForEach(Action<T>)`.
- `string.CompareOrdinal(a, b)` vergleicht Strings Zeichen für Zeichen nach
  ihren Zahlencodes, unabhängig von Sprache und Kultur.
- `EventArgs.Empty` ist ein fertiges leeres `EventArgs`-Objekt für Ereignisse
  ohne Nutzdaten.
