# Rubrik: Verständnisfragen Level 1 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, die Begriffe müssen aber stimmen. Level 1 ist Theorie: Streng nach Syntax wird hier nicht beurteilt, wohl aber, ob die Begriffe sauber getrennt werden. Die Auswahlfragen (`objekt-erzeugen`, `aufruf-schreibweise`, `using-direktive`, `framework-oder-net`) sind automatisch bewertet und haben hier keinen Eintrag.

## klasse-objekt

Kernpunkte:
- Die **Klasse** ist der Bauplan: Sie legt fest, welche Daten (Felder) ihre Objekte tragen und was man mit ihnen tun kann (Methoden). Sie steht im Quelltext.
- Ein **Objekt** ist ein konkretes Exemplar nach diesem Bauplan; es entsteht erst **zur Laufzeit** und belegt Speicher.
- `new` erzeugt ein neues Objekt der Klasse; von einer Klasse kann es beliebig viele Objekte geben, jedes mit eigenen Werten (zwei `Bruch`-Objekte, 1/2 und 3/4).
- Ein passendes Beispiel (Bauplan und Haus, Rezept und Kuchen, `Bruch` und `new Bruch()`).

Typische Irrtümer: Klasse und Objekt seien dasselbe; das Objekt sei der Bauplan; die Klasse existiere nur zur Laufzeit; es gebe pro Klasse nur ein Objekt.

## kapselung

Kernpunkte:
- Die **Felder sind vor direktem Zugriff von außen geschützt** (privat). Fremde Klassen kommen nur über öffentliche Methoden oder Eigenschaften an den Zustand.
- Diese Schnittstelle kann **Regeln durchsetzen**: Der Nenner-Setter kann den Wert 0 ablehnen, sodass kein Bruch mit Nenner 0 entsteht. Wären die Felder offen, könnte jeder 0 hineinschreiben.
- Nutzen: Das Objekt bleibt gültig, die innere Darstellung lässt sich ändern, ohne dass Aufrufer es merken.

Typische Irrtümer: Kapselung heiße „verschlüsseln“; alle Daten lägen in einer Klasse; eine Klasse dürfe keine Felder haben; Eigenschaften seien dasselbe wie öffentliche Felder (sie fühlen sich so an, können aber prüfen).

## nachricht-code

Kein Ausgabewert; die Zeilen erzeugen ein Objekt und lassen es etwas tun.

Kernpunkte:
- `Bruch` ist die **Klasse** (der Bauplan), `new Bruch()` erzeugt ein **Objekt** davon, und die Variable `b` verweist darauf (der Trainee darf auch einfach sagen: `b` bezeichnet das Objekt).
- `b.Kuerze()` ist eine **Nachricht** an das Objekt `b`: Der Aufrufer sagt, **was** passieren soll.
- **Empfänger** der Nachricht ist das Objekt `b`; **wie** gekürzt wird, entscheidet das Objekt beziehungsweise die Methode `Kuerze()` der Klasse `Bruch`, nicht der Aufrufer.

Typische Irrtümer: `Bruch` sei das Objekt; die Startklasse oder die Laufzeitumgebung empfange die Nachricht; der Aufrufer müsse die Felder selbst ändern.

## vererbung-polymorphie

Kernpunkte:
- **Vererbung:** `Kreis` übernimmt Felder und Methoden von `Figur` und kann eigene hinzufügen oder anpassen; gemeinsamer Code steht nur einmal in der Basisklasse.
- **Polymorphie:** Derselbe Methodenaufruf (zum Beispiel an eine `Figur`) tut je nach **tatsächlichem Objekttyp** etwas anderes (ein Kreis berechnet seine Fläche anders als ein Rechteck).
- Nutzen: weniger doppelter Code; Code, der mit `Figur` arbeitet, funktioniert auch mit neuen Unterklassen, ohne geändert zu werden.
- Details (`virtual`, `override`) kommen erst in Level 7 und werden hier nicht verlangt.

Typische Irrtümer: Die Basisklasse übernehme die Mitglieder der abgeleiteten; Kreis und Figur teilten sich denselben Speicher; Polymorphie sei dasselbe wie Vererbung; Polymorphie heiße, dass mehrere Methoden gleich heißen (das ist Überladung).

## namensraum-assembly

Kernpunkte:
- Ein **Namensraum** ist ein **logisches Präfix** für Typnamen, das Namenskollisionen vermeidet (`System.Console`).
- Ein **Assembly** ist die **physische Datei** (`.dll` oder `.exe`) mit IL-Code und Metadaten (Typen, Version, Abhängigkeiten); die Einheit, die gebaut, ausgeliefert und versioniert wird.
- Beziehung: Ein Assembly kann Typen aus **vielen** Namensräumen enthalten, und ein Namensraum kann sich über **mehrere** Assemblies erstrecken.
- `using` importiert einen **Namensraum**, **kein** Assembly. Assemblies bindet man über Projekt- oder Paketverweise ein.

Typische Irrtümer: Namensraum und Assembly seien dasselbe; jedes Assembly habe genau einen Namensraum gleichen Namens; `using` binde die Datei ein.

## namensraum-im-code

Exaktes Verhalten: Das Programm baut und gibt `Hallo` aus.

Kernpunkte:
- Es braucht kein `using`, weil der Typ **voll qualifiziert** angesprochen wird: `System` ist der **Namensraum**, `Console` die **Klasse**, `WriteLine` die **Methode**. `using System;` spart nur das Tippen des Präfixes.
- Der Code von `WriteLine` liegt **nicht im eigenen Programm**, sondern in einem Assembly der **BCL** (Base Class Library), die zur .NET-Laufzeitumgebung gehört. Das eigene Programm verweist darauf.

Typische Irrtümer: Ohne `using` könne man keine Klasse aus `System` benutzen; `Console` sei der Namensraum; `System` sei ein Assembly in der Projektmappe des Trainees.

## il-jit-aot

Kernpunkte:
- **IL** (Intermediate Language) ist eine **prozessorunabhängige Zwischensprache**. Der Compiler legt sie zusammen mit Metadaten im Assembly ab.
- Maschinencode entsteht **zur Laufzeit**: Der **JIT-Compiler** der CLR übersetzt jede Methode beim ersten Aufruf für die lokale CPU.
- **AOT** übersetzt schon beim Veröffentlichen in Maschinencode. Vorteil: schnellerer Start (kein JIT). Nachteil: das Ergebnis ist plattformgebunden, und es gelten Einschränkungen.
- Gut: Der Trainee nennt als Grund für IL, dass dasselbe Assembly auf verschiedenen Plattformen laufen kann und alle .NET-Sprachen denselben IL-Code erzeugen.

Typische Irrtümer: Der Compiler erzeuge direkt Maschinencode; die CLR interpretiere IL zeilenweise wie ein Skript; IL und Quelltext seien dasselbe; AOT sei plattformunabhängig.

## startklasse

Exakte Ausgabe (zwei Zeilen):

```
Start
aus Hilfe
```

Kernpunkte:
- **`Start`** ist die Startklasse, weil sie die statische Methode **`Main()`** hat. Die Ausführung beginnt in `Main()`; es gibt genau einen Einstiegspunkt.
- `Hilfe` hat kein `Main`; die Klasse läuft nicht von selbst, sondern wird nur von `Main()` aus benutzt.
- Reihenfolge: erst `Start`, dann (beim Berechnen des Arguments) `Hilfe.Text()`, danach die Ausgabe `aus Hilfe`.

Typische Irrtümer: Die erste Klasse in der Datei starte zuerst; `Hilfe` werde automatisch ausgeführt; die Ausgabe erfolge in umgekehrter Reihenfolge.

## clr-bcl-gc

Kernpunkte:
- **CLR** (Common Language Runtime) führt IL-Code aus: JIT-Übersetzung, Garbage Collection, Ausnahmebehandlung, Typsicherheit, Multithreading. Sie ist die Laufzeitumgebung.
- **BCL** (Base Class Library) ist die mitgelieferte **Sammlung von Assemblies mit Grundtypen** (`String`, `Console`, `Math`); sie ist Bibliothek, keine Ausführungsmaschine. Beide gehören zur Laufzeitumgebung. GUI-Bibliotheken wie WPF sind Erweiterungen.
- **Verwalteter Code**, weil die CLR die Ausführung **betreut** (Speicher, Typprüfung, Ausnahmen).
- Die **GC** gibt den Speicher frei, wenn **keine Referenz** im Programm mehr auf das Objekt zeigt; **den Zeitpunkt bestimmt die CLR**.

Typische Irrtümer: Die BCL sei der Compiler oder ein Werkzeug zum Projektanlegen; die GC gebe Speicher sofort beim Ende der Methode frei; man müsse `delete` aufrufen; der Speicher werde erst beim Programmende freigegeben; „verwaltet“ meine, dass ein Projektmanager den Code freigibt.
