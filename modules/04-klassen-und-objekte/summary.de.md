# Klassen und Objekte

Eine **Klasse** beschreibt, welche Daten ihre Objekte tragen (Felder) und was man
mit ihnen tun kann (Methoden, Eigenschaften). Ein **Objekt** ist eine konkrete
Instanz, erzeugt mit `new`. In diesem Level bauen wir eine Klasse `Bruch` Schritt
für Schritt aus: erst Felder und Eigenschaften mit Validierung, dann
Konstruktoren, Kopien, statische Mitglieder und zuletzt überladene Operatoren.

## Felder und Eigenschaften (5.2, 5.3)

Felder sind privat. Nach außen zeigt die Klasse **Eigenschaften** mit `get` und
`set`. Im Setter wird validiert (`Nenner` darf nie 0 werden); der Getter darf
nicht auf die Eigenschaft selbst zugreifen, sonst ruft er sich endlos auf. Seit
C# 14 ersetzt das Schlüsselwort `field` ein eigenes Backing-Feld.

## Konstruktoren (5.4.3, Seite 340)

Ein Konstruktor trägt den Klassennamen und initialisiert das Objekt. Mehrere
Konstruktoren mit unterschiedlichen Parameterlisten sind erlaubt; wer einen
expliziten Konstruktor schreibt, verliert den automatischen Standardkonstruktor
und muss ihn bei Bedarf selbst deklarieren. Im Konstruktor über die
Eigenschaften zuweisen, nicht über die Felder, damit die Validierung greift.
Objektinitialisierer (`new Bruch { Zaehler = 3, Nenner = 7 }`) setzen
Eigenschaften direkt nach dem Konstruktoraufruf.

## Referenzen, Kopien, statische Mitglieder (5.4.4, 5.8)

Eine Variable vom Klassentyp enthält eine **Referenz**. Zwei Variablen können
auf dasselbe Objekt zeigen; eine echte Kopie braucht eine Methode wie `Klone()`.
Statische Mitglieder gehören der Klasse, nicht dem Objekt: ein Instanzzähler
`Anzahl` oder eine Fabrikmethode `BenDef()`.

## Operatoren überladen (5.9.3, Seite 385)

`operator +` ist eine statische Methode, die ein neues Objekt liefert und ihre
Operanden unverändert lässt. Seit C# 14 kann `+=` getrennt als Instanzoperator
überladen werden, der das vorhandene Objekt verändert und keine neue Instanz
anlegt.

Vertiefung im Buch: Kapitel 5, ab Seite 286.
