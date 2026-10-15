# Vererbung und Polymorphie

Kapitel 7 (ab Seite 543) führt das zweite große Prinzip der
Objektorientierung ein: Eine Klasse kann von einer anderen **erben**, ihre
Mitglieder übernehmen, erweitern und verändern. Das Standardbeispiel ist eine
Figurenhierarchie mit `Figur`, `Kreis` und `Rechteck`; alle Übungen dieses
Levels arbeiten damit.

## Abgeleitete Klassen und Konstruktoren (7.3 bis 7.5, Seite 547 bis 554)

`class Kreis : Figur` macht `Kreis` zur Unterklasse: Jedes Kreis-Objekt
enthält alle Felder von `Figur` und kann überall verwendet werden, wo eine
`Figur` erwartet wird (7.2, das allgemeine Typsystem, Seite 545). Die
Basisklasse wird immer zuerst initialisiert; mit `: base(x, y)` wählst du,
welcher Basiskonstruktor läuft (7.4.1, Seite 549). Fehlt die Angabe, ruft der
Compiler den parameterlosen Basiskonstruktor; gibt es den nicht, scheitert
die Übersetzung (7.16 Aufgabe 1). Private Mitglieder werden vererbt, sind in
der Unterklasse aber nicht zugänglich; `protected` öffnet sie für Erben und
sonst niemanden (7.5, Seite 554).

## Basisklassenreferenzen und Typtests (7.7 und 7.8, Seite 561 und 563)

Eine Variable vom Typ `Figur` darf auf einen Kreis zeigen; damit lassen sich
gemischte Sammlungen wie `Figur[]` verwalten. Was das Objekt wirklich ist,
verrät `GetType()`; sicher darauf zugreifen kannst du mit dem Typtest
`if (f is Kreis k)`, der gleich eine passende Referenz liefert.

## Verdecken gegen Überschreiben (7.6 und 7.9, Seite 555 und 566)

Deklariert eine Unterklasse ein Mitglied mit gleicher Signatur, **verdeckt**
sie das Erbstück (`new`); das wirkt nur über Referenzen vom Typ der
Unterklasse, über eine `Figur`-Referenz läuft weiter die Basisfassung.
**Überschreiben** mit `virtual` in der Basis und `override` in der
Unterklasse ersetzt die Methode dagegen für das Objekt, egal über welche
Referenz es angesprochen wird: Entscheidend ist der dynamische Typ. Das ist
Polymorphie. `base.Wo()` ruft die Basisfassung aus der Überschreibung heraus.
`sealed` versiegelt eine überschriebene Methode oder eine ganze Klasse gegen
weitere Änderung (7.10, Seite 570). Überladen (gleicher Name, andere
Parameter) ist ein drittes, davon unabhängiges Konzept; statische Methoden
lassen sich überladen und verdecken, aber nicht überschreiben (7.16 Aufgabe
3).

## Abstrakte Klassen (7.13, Seite 577)

Eine `abstract` Klasse kann nicht instanziiert werden; abstrakte Mitglieder
haben keinen Rumpf und müssen in der ersten konkreten Unterklasse mit
`override` implementiert werden. So erzwingt die Basisklasse, dass jede
Figur einen Flächeninhalt liefert, statt eine nichtssagende 0 vorzugeben. Das
Liskovsche Substitutionsprinzip (7.14, Seite 579) formuliert die Pflicht der
Unterklassen: Wo eine `Figur` erwartet wird, muss sich jede Unterklasse wie
eine Figur verhalten.

## Record-Hierarchien (6.7.4, Seite 502; 7.16 Aufgabe 4)

Auch Records vererben. Ein positionaler Record reicht seine Parameter mit
`: Figur(X, Y)` an den primären Konstruktor der Basis weiter; fehlt die
Argumentliste, läuft der parameterlose Basiskonstruktor und die Werte gehen
verloren (Warnung CS8907). Die Wertgleichheit berücksichtigt den exakten Typ
(`EqualityContract`): Ein Kreis ist nie gleich einer Figur mit derselben
Position.

## Erweiterungsmitglieder (7.15, Seite 581)

Erweiterungsmitglieder rüsten fremde, auch versiegelte Typen nach, ohne sie
zu verändern: `pi.High(2)` ist in Wahrheit `DoubleExtensions.High(pi, 2)`.
Die klassische Form ist eine statische Methode mit `this`-Parameter (7.15.3,
Seite 585). Seit C# 14 bündelt ein **Erweiterungsblock** `extension(double
arg) { … }` Methoden und Eigenschaften, und `extension(double) { … }` ohne
Empfänger erlaubt sogar statische Mitglieder und Operatoren (7.15.2, Seite
583). Echte Mitglieder haben immer Vorrang vor Erweiterungen, und
Erweiterungen sehen nur die öffentliche Schnittstelle. Das Material ist neu;
das Buch ist hier die verlässlichere Quelle als das Netz.

Vertiefung im Buch: Kapitel 7, Abschnitte 7.1 bis 7.15 (Seite 543 bis 586);
die Übungsaufgaben in 7.16 (Seite 586) liefern Reparatur, Quiz und
Record-Übung dieses Levels.
