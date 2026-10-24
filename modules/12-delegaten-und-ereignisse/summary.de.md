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
Ziel. Wer alle Ergebnisse braucht, durchläuft `GetInvocationList()`. Ist die
Liste leer, ist die Variable `null`; sicher aufruft man deshalb mit
`aktion?.Invoke(...)`. Ob man einen Delegaten oder ein Interface als
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
`Action<...>` ohne, `Predicate<T>` für Bedingungen. `List<T>` nutzt sie
(10.3 Aufgabe 2, Seite 688): `FindAll(Predicate<T>)`, `Exists`, `Find`,
`RemoveAll`, `ForEach(Action<T>)` und `Sort(Comparison<T>)`.

Ein Lambda darf Variablen der umgebenden Methode benutzen. Es **fängt die
Variable ein**, nicht ihren Wert, und hält sie so lange am Leben wie das
Delegatenobjekt (**Closure**). Jeder Aufruf der Fabrikmethode erzeugt eine
eigene Variable und damit einen eigenen Zustand (`Zaehler()`). Aufpassen
musst du bei Schleifen: Fängt ein Lambda die Variable einer
`for`-Schleife ein, teilen sich alle Lambdas sie; eine Kopie je Durchlauf
oder `foreach` löst das.

## Ko- und Kontravarianz (10.1.6, Seite 675)

Wie bei Interfaces (Level 9) gilt für generische Delegaten: `Func<out T>` ist
kovariant (`Func<string>` passt als `Func<object>`), `Action<in T>` und
`Comparison<in T>` sind kontravariant (`Action<object>` passt als
`Action<string>`).

## Ereignisse (10.2, Seite 678 bis 686)

Ein **Ereignis** (`event`) ist ein Delegat mit Zugriffsschutz: Hinter ihm
steht eine private Delegatenvariable, nach außen gibt es nur `+=` und `-=`
(10.2.1). Fremde Klassen können sich also an- und abmelden, das Ereignis
aber weder auslösen noch überschreiben. Ein öffentliches Delegatenfeld
erlaubt beides, ist also kein Ersatz. Das Standardmuster:
`EventHandler<TEventArgs>` als Typ, eine eigene `EventArgs`-Ableitung für
Nutzdaten und eine `protected virtual void OnXyz(...)`-Methode, die mit
`Xyz?.Invoke(this, e)` auslöst; Erben überschreiben sie, um die Auslösung zu
steuern (10.2.3, Seite 684). Eine Behandlungsmethode hat die Parameter
`(object? sender, TEventArgs e)` (10.2.2, Seite 681); `sender` ist der
Auslöser und lässt sich zurückcasten, wenn mehrere Objekte dieselbe Methode
nutzen. Wer sich anmeldet, sollte sich wieder abmelden: Über die Aufrufliste
hält der Anbieter den Abonnenten am Leben. Ein Lambda lässt sich nur
abmelden, wenn man dasselbe Delegatenobjekt aufbewahrt hat.

Vertiefung im Buch: Kapitel 10 (Seite 657 bis 689); die Übungsaufgaben
in 10.3 (Seite 688) liefern die Quizfragen und `ListLE(k)` dieses Levels.
