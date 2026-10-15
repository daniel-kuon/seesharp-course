# Klassen und Objekte

Eine **Klasse** beschreibt, welche Daten ihre Objekte tragen (Felder) und was man
mit ihnen tun kann (Methoden, Eigenschaften). Ein **Objekt** ist eine konkrete
Instanz, erzeugt mit `new`. In diesem Level bauen wir eine Klasse `Bruch` Schritt
für Schritt aus, genau wie das Buch in Kapitel 5 (ab Seite 286): erst Felder und
Eigenschaften mit Validierung, dann überladene Methoden, Konstruktoren, statische
Mitglieder, Rekursion und zuletzt überladene Operatoren. Jede Übung baut auf dem
Stand der vorigen auf; der Sample-Ordner `Bruch/b0` bis `b7` des Buchs ist die
Vorlage.

## Begriffe (5.1, Seite 286; 5.15 Aufgabe 7, Seite 424)

Bevor du schreibst, solltest du im Quelltext benennen können, was du siehst:
Instanzvariable (Feld), Klassenvariable (statisches Feld), Konstruktor,
Instanz- und Klassenmethode, Instanz- und statische Eigenschaft, lokale
Variable, Methodenaufruf, Objekterzeugung, Operatorüberladung. Das erste Quiz
dieses Levels fragt genau das ab.

## Felder und Eigenschaften (5.2 und 5.5, Seite 300 und 361)

Felder sind privat und werden beim Erzeugen automatisch initialisiert (`int`
auf 0, Referenzen auf `null`); ein Initialisierer wie `nenner = 1` setzt einen
anderen Startwert. Nach außen zeigt die Klasse **Eigenschaften** mit `get` und
`set`. Im Setter wird validiert (`Nenner` darf nie 0 werden, `Etikett` wird auf
40 Zeichen gekürzt); der Getter darf nicht auf die Eigenschaft selbst
zugreifen, sonst ruft er sich endlos auf, bis der Stack überläuft (5.15
Aufgabe 3, Seite 425). Automatisch implementierte Eigenschaften (`{ get; set; }`)
ersparen das Feld; seit C# 14 erlaubt das Schlüsselwort `field` auch in ihnen
einen Setter mit Prüfung (5.6, Seite 367).

## Methoden und Überladung (5.3, Seite 308; 5.3.5, Seite 334)

Eine **Instanzmethode** arbeitet mit dem Zustand des Objekts: `Kuerze()`
verändert Zähler und Nenner, `Addiere(Bruch b)` verrechnet ein zweites Objekt.
Mehrere Methoden dürfen denselben Namen tragen, wenn sich ihre Parameterlisten
unterscheiden (**Überladung**); der Rückgabetyp zählt nicht zur Signatur.
`Addiere(int, int, bool)` ist die zweite Überladung, die über `bool` meldet,
ob die Operation gültig war.

## Konstruktoren (5.4.3, Seite 340)

Ein Konstruktor trägt den Klassennamen und initialisiert das Objekt. Mehrere
Konstruktoren mit unterschiedlichen Parameterlisten sind erlaubt; wer einen
expliziten Konstruktor schreibt, verliert den automatischen Standardkonstruktor
und muss ihn bei Bedarf selbst deklarieren. Im Konstruktor über die
Eigenschaften zuweisen, nicht über die Felder, damit die Validierung greift.
Objektinitialisierer (`new Bruch { Zaehler = 3, Nenner = 7 }`) setzen
Eigenschaften direkt nach dem Konstruktoraufruf.

## Referenzen, Kopien, statische Mitglieder (5.4.4, 5.8, Seite 352 und 373)

Eine Variable vom Klassentyp enthält eine **Referenz**. Zwei Variablen können
auf dasselbe Objekt zeigen; eine echte Kopie braucht eine Methode wie `Klone()`.
Statische Mitglieder gehören der Klasse, nicht dem Objekt: ein Instanzzähler
`Anzahl`, eine Fabrikmethode `BenDef()` oder ein **statischer Konstruktor**, der
einmalig beim ersten Zugriff auf die Klasse läuft und Voreinstellungen setzt.

## Rekursion (5.9.2, Seite 382)

Eine Methode darf sich selbst aufrufen. Das funktioniert, wenn jeder Aufruf das
Problem verkleinert und ein direkt lösbarer Fall (die Abbruchbedingung) die
Kette beendet: Der ggT von `a` und `b` ist der ggT von `b` und `a % b`, bis der
Rest 0 ist. Fehlt die Abbruchbedingung, läuft der Stack über. Fakultät und
Fibonacci-Zahlen sind die klassischen Beispiele; die rekursive Fibonacci-Variante
zeigt auch, dass Rekursion teuer werden kann.

## Operatoren überladen (5.9.3, Seite 385)

`operator +` ist eine statische Methode, die ein neues Objekt liefert und ihre
Operanden unverändert lässt. Seit C# 14 kann `+=` getrennt als Instanzoperator
überladen werden, der das vorhandene Objekt verändert und keine neue Instanz
anlegt.

Vertiefung im Buch: Kapitel 5, Abschnitte 5.1 bis 5.9 (Seite 286 bis 388);
die Übungsaufgaben in 5.15 (Seite 424) sind die Vorlage für Quiz und
Rekursionsübung.
