# Komposition, Indexer, Schutzstufen

Level 4 hat die Klasse `Bruch` von innen aufgebaut. Dieses Level schaut auf
das Zusammenspiel **mehrerer** Klassen: Objekte, die andere Objekte besitzen,
Klassen, die in Klassen stecken, Klassen, die sich wie Arrays anfühlen, und
die Frage, was eine Klasse nach außen zeigt und was sie für sich behält. Die
Buchabschnitte 5.10 bis 5.13 (Seite 388 bis 400) sind das Lesepensum; dazu
kommen zwei Übungsaufgaben aus 5.15 und 7.16.

## Aggregation und Komposition (5.10, Seite 388)

Ein Objekt kann andere Objekte als Felder halten. Die Klasse `Aufgabe` besitzt
drei `Bruch`-Objekte: zwei Argumente und die Lösung. Sie rechnet nicht selbst,
sondern **delegiert**: `lsg.Addiere(b2)`. Das Buch unterscheidet lose
Aggregation (das Teil könnte auch ohne das Ganze leben) und enge Komposition
(das Teil entsteht und vergeht mit dem Ganzen); in C# sieht beides gleich aus,
nämlich als Feld mit Klassentyp. Ein `readonly`-Feld fixiert dabei nur die
Referenz, nicht das Objekt dahinter: `NeueWerte()` darf die Brüche verändern,
aber keine neuen anlegen.

## ToString überschreiben (7.16 Aufgabe 5, Seite 588)

Jede Klasse erbt `ToString()` von `Object`; die geerbte Fassung liefert nur
den Typnamen. Mit `public override string ToString()` ersetzt du sie, und
`Console.WriteLine(b)`, `$"{b}"` und `"x" + b` benutzen die neue Fassung
automatisch. Das ist der erste Kontakt mit `virtual`/`override`; Level 7
erklärt den Mechanismus vollständig.

## Geschachtelte Klassen (5.11, Seite 391)

Eine Klasse darf innerhalb einer anderen deklariert werden. Die innere Klasse
sieht alle Mitglieder der äußeren, auch private, braucht für Instanzmitglieder
aber eine Referenz auf ein Objekt der äußeren Klasse (`f.name`). Ohne
Modifizierer ist eine geschachtelte Klasse privat und von außen unsichtbar;
mit `public` wird sie als `Familie.Sohn` ansprechbar. Primärkonstruktoren
(`class Sohn(Familie f, string name, int alter)`) sparen Boilerplate; die
Parameter werden in `readonly`-Felder übernommen.

## Indexer (5.12, Seite 393)

Ein Indexer ist eine Eigenschaft mit Parametern: `public Person this[int i]
{ get … set … }`. Damit lässt sich eine eigene Kollektion wie ein Array
ansprechen (`pl[1]`, `pl[1] = …`). Das Buch zeigt ihn an einer einfach
verketteten Liste, deren Knoten eine private geschachtelte Klasse `Element`
sind. Indexer dürfen überladen werden (5.12.2, Seite 397): `pl["Ilse"]`
sucht nach dem Vornamen. Auch mehrere Parameter sind erlaubt (5.12.3): die
Matrix in Level 6 nutzt `this[int zeile, int spalte]`.

## Schutzstufen (5.13, Seite 398)

Für nicht geschachtelte Klassen gibt es nur `public` und `internal`; ohne
Angabe gilt `internal` (5.13.1). Für Mitglieder kommen `private` (Standard),
`protected` und Kombinationen hinzu (5.13.2, Seite 399). `internal` heißt
**assembly-intern**: Ein anderes Projekt sieht das Mitglied nicht, auch wenn
es die Bibliothek referenziert. Genau das übst du mit `FractionLib`: Die
Klasse `Bruch` wandert in eine Klassenbibliothek (Projekttyp Library, keine
`Main`-Methode), ein Konsolenprojekt setzt einen Projektverweis und holt den
Namensraum `de.bebagoe.fraction` per `using` herein. Eine Hilfsmethode wie
`Ggt` wird `internal`, damit die Schnittstelle der Bibliothek klein bleibt.

## Berechnete Eigenschaften und reine Methoden (5.15 Aufgabe 4, Seite 425)

Die Vektorklasse `R2Vek` wiederholt Level 4 an einem neuen Gegenstand und
bringt zwei Muster, die ständig wiederkehren: Eine **berechnete Eigenschaft**
wie `Laenge` hat kein Feld, sondern rechnet bei jedem Lesen neu; so kann sie
nie veralten. Und der Unterschied zwischen einer Methode, die das Objekt
verändert (`Addiere`), und einer, die ein neues Objekt liefert und die
Operanden in Ruhe lässt (`Plus`). Letzteres ist auch das Verhalten von
`operator +` aus Level 4 und von Records in Level 6.

Vertiefung im Buch: 5.10 bis 5.13 (Seite 388 bis 400); 5.14 (WPF-Oberfläche
für die Bruchrechnung, Seite 400) ist in diesem Kurs nicht Pflicht.
