# Konzepte: Was ist OOP, was ist .NET?

Dieses Level enthält keine Programmierübung. Die Kapitel 1 und 2 des Buchs
(Seite 1 bis 60) erklären die Begriffe, mit denen alle späteren Kapitel
arbeiten. Wer sie jetzt sauber sortiert, muss später beim Programmieren nicht
raten, was ein Assembly oder ein Namensraum ist. Drei kurze Quizze prüfen, ob
die Begriffe sitzen.

## Klassen, Objekte, Nachrichten (1.3, Seite 9)

Ein **Programm** ist in der objektorientierten Sicht eine Menge von Objekten,
die miteinander kommunizieren. Eine **Klasse** ist der Bauplan: Sie legt fest,
welche Daten ihre Objekte tragen (**Felder**) und was man mit ihnen tun kann
(**Methoden**). Ein **Objekt** ist ein konkretes Exemplar, das zur Laufzeit mit
`new` entsteht. Das Buch führt das am Beispiel der Klasse `Bruch` ein, die
Zähler und Nenner speichert und sich selbst kürzen kann.

**Kapselung** bedeutet, dass die Felder vor direktem Zugriff von außen
geschützt sind. Andere Klassen reden mit dem Objekt über öffentliche Methoden
oder über **Eigenschaften**: ein Paar aus Lese- und Schreibzugriff, das sich im
Quelltext wie ein Feld anfühlt, aber Regeln durchsetzen kann (ein Nenner darf
nie 0 werden). Ein Methodenaufruf wie `b.Kuerze()` ist eine **Nachricht** an das
Objekt `b`: Der Aufrufer sagt, was passieren soll, das Objekt entscheidet, wie.

**Vererbung** lässt eine Klasse Felder und Methoden einer Basisklasse
übernehmen und erweitern; **Polymorphie** erlaubt, dass derselbe Methodenaufruf
je nach tatsächlichem Objekttyp Verschiedenes tut. Beide Themen kommen in
Kapitel 7 ausführlich; hier reicht es, die Begriffe zuordnen zu können.

## Startklasse und Main (1.5, Seite 12)

Jedes Programm braucht genau einen Einstiegspunkt: die statische Methode
`Main()` einer Startklasse. Von dort aus werden Objekte erzeugt und Methoden
aufgerufen. Seit C# 9 kann der Compiler diese Klasse aus Anweisungen auf
oberster Ebene selbst erzeugen; das Prinzip bleibt gleich.

## Compiler, IL und Assemblies (2.3 und 2.4, Seite 25 und 30)

Der C#-Compiler erzeugt keinen Maschinencode, sondern **IL-Code**
(Intermediate Language), eine prozessorunabhängige Zwischensprache. Der
IL-Code landet zusammen mit **Metadaten** in einer Datei, dem **Assembly**
(`.dll` oder `.exe`). Die Metadaten beschreiben die enthaltenen Typen, die
Version, die Kultur und die Abhängigkeiten von anderen Assemblies. Ein
Assembly ist also die Einheit, die gebaut, ausgeliefert und versioniert wird.

Ein **Namensraum** ist etwas anderes: ein logisches Präfix für Typnamen, das
Namenskollisionen vermeidet (`System.Console`). Ein Assembly kann Typen aus
vielen Namensräumen enthalten, und ein Namensraum kann sich über viele
Assemblies erstrecken. Die `using`-Direktive importiert einen Namensraum, nicht
ein Assembly; Assemblies werden über Projektverweise eingebunden.

## CLR, JIT und AOT (2.5, Seite 42)

Die **Common Language Runtime** führt IL-Code aus. Ihr **JIT-Compiler**
(Just-In-Time) übersetzt jede Methode beim ersten Aufruf in Maschinencode für
die lokale CPU. Außerdem kümmert sich die CLR um die automatische
Speicherfreigabe (**Garbage Collection**), Ausnahmebehandlung, Typsicherheit
und Multithreading; wegen dieser Betreuung heißt IL-Code auch **verwalteter
Code** (managed code). Alternativ kann man schon beim Veröffentlichen in
Maschinencode übersetzen (**AOT**, Ahead-Of-Time): schnellerer Start, dafür
plattformgebunden und mit Einschränkungen.

## BCL (2.6, Seite 47)

Die **Base Class Library** ist die mitgelieferte Sammlung von Assemblies mit
Grundtypen wie `String`, `Console` oder `Math`. Sie ist Teil der Laufzeitumgebung
und plattformunabhängig; GUI-Bibliotheken wie WPF sind Erweiterungen, die nur
unter Windows laufen. Die BCL ist überwiegend selbst in C# geschrieben, und
weil alle .NET-Sprachen denselben IL-Code erzeugen, lassen sich C#-Bibliotheken
auch aus VB.NET oder F# nutzen.

## .NET-Implementationen (2.2, Seite 21)

Das klassische **.NET Framework** ist Windows-gebunden und wird nicht mehr
weiterentwickelt. Das heutige **.NET** (ohne Zusatz, Version 10 in diesem Kurs)
ist plattformübergreifend und die richtige Wahl für neue Projekte, auch wenn
sie nur unter Windows laufen sollen.

Vertiefung: Kapitel 1 (ab Seite 1) und Kapitel 2 (ab Seite 19), die
Zusammenfassungen in 1.7 und 2.7 eignen sich gut zum Wiederholen.
