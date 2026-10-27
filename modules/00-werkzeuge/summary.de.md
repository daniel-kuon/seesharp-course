# Werkzeuge und erstes Projekt

Bevor eine Zeile C# entsteht, muss die Werkzeugkette stehen: das .NET SDK,
eine Entwicklungsumgebung und ein Gefühl dafür, was beim Bauen und Starten
eines Programms passiert. Das Buch beschreibt in Kapitel 3 (ab Seite 61) die
Kommandozeile, Visual Studio und VS Code. In diesem Kurs arbeiten wir mit
**JetBrains Rider**; die Konzepte sind dieselben, nur die Menüs heißen anders.
Lies deshalb vor allem Abschnitt 3.1 (.NET SDK, Seite 61) gründlich und die
IDE-Abschnitte 3.3 und 3.5 nur zur Orientierung.

## Das .NET SDK (3.1.1, Seite 61)

Das SDK enthält Compiler, Laufzeitumgebung und das Kommandozeilenwerkzeug
`dotnet`. Mit `dotnet --list-sdks` siehst du, welche Versionen installiert sind.
Liegen mehrere vor, nimmt `dotnet` das neueste, es sei denn, eine `global.json`
im Projektordner oder darüber legt eine bestimmte Version fest. Genau das tut
SeeSharp: Die `global.json` im Kursordner sorgt dafür, dass alle Übungen mit
demselben SDK gebaut werden.

## Projekt anlegen, bauen, starten (3.1.2 bis 3.1.5, Seite 65 bis 74)

`dotnet new console -n Hallo` erzeugt ein Konsolenprojekt: eine Projektdatei
`Hallo.csproj` und eine Quellcodedatei. Die Projektdatei beschreibt, was gebaut
wird (Zielframework, Ausgabetyp), die `.cs`-Dateien enthalten den Code. Eine
**Solution** (`.sln` oder `.slnx`) fasst mehrere Projekte zusammen; Rider öffnet
Solutions und Projekte gleichermaßen.

`dotnet build` übersetzt den Quellcode in IL-Code und legt das Ergebnis unter
`bin/` ab; `obj/` enthält nur Zwischenergebnisse und darf jederzeit gelöscht
werden. `dotnet run` baut und startet in einem Schritt. Unverzichtbar sind aus
`bin/` die `.dll` mit dem IL-Code und die `.runtimeconfig.json`, die der
Laufzeitumgebung sagt, welche .NET-Version das Programm braucht. Die `.exe` ist
nur eine bequeme Starthilfe für Windows; ohne sie startet `dotnet Hallo.dll` das
Programm (Seite 75). Die `.pdb`-Datei dient der Fehlersuche.

## Programmfehler lesen (3.1.6, Seite 76)

Das Buch unterscheidet zwei Fehlerarten: **Syntaxfehler** meldet der Compiler
mit Dateiname, Zeile, Spalte und einem Code wie `CS1002`; das Programm entsteht
gar nicht erst. **Logikfehler** (Semantikfehler) bemerkt der Compiler nicht:
Das Programm verhält sich anders als erwartet, liefert z. B. falsche Ergebnisse,
hängt in einer Endlosschleife oder stürzt mit einem **Laufzeitfehler** (einer
Ausnahme) ab. Logikfehler findet man nur mit Tests oder dem Debugger. Gewöhne dir an, bei
einem Compilerfehler zuerst die Zeile und dann den Fehlercode zu lesen; die
Meldung ist fast immer präziser, als sie auf den ersten Blick wirkt.

## Der Ablauf in SeeSharp

Jede Programmierübung in SeeSharp besteht aus einem **Starter-Projekt**, das du
in Rider öffnest und bearbeitest, und einem **Testprojekt**, das dein Ergebnis
prüft. Der Ablauf ist immer gleich:

1. Übung in SeeSharp öffnen, die Anleitung lesen, den genannten Buchabschnitt
   lesen.
2. „In Rider öffnen“ klicken; Rider springt in die Datei mit der Aufgabe.
3. Code schreiben, mit `Strg+F5` oder dem Run-Knopf starten und ausprobieren.
4. In SeeSharp „Abgeben“ klicken. SeeSharp kopiert deinen Code in ein sauberes
   Verzeichnis, lässt die Tests laufen und zeigt pro Test, ob er bestanden ist.
5. Rote Tests lesen: Der Testname sagt, was erwartet wurde, die Meldung zeigt
   den erwarteten und den tatsächlichen Wert. Korrigieren, erneut abgeben.

Die Tests im Starter-Ordner kannst du in Rider selbst ausführen (Rechtsklick
auf das Testprojekt, „Run Unit Tests“). Zur Bewertung zählt aber nur die Kopie,
die SeeSharp ausführt.

## Haltepunkte in Rider

Das Buch beschreibt den Debugger für Visual Studio (3.3.5.4, Seite 98, und
ausführlich 5.3.4, Seite 329). In Rider
setzt du einen Haltepunkt durch Klick links neben die Zeilennummer, startest mit
dem Käfer-Symbol (Debug) und siehst im Fenster „Variables“ die aktuellen Werte.
`F10` führt die nächste Zeile aus, `F11` springt in einen Methodenaufruf hinein.
Probiere das gleich in der ersten Übung aus: Haltepunkt in `Main()`, Debug
starten, Variablen ansehen.

## Was in diesem Level von dir erwartet wird

Zwei kleine Programmierübungen und ein Quiz. Die erste Übung prüft nur, ob die
Werkzeugkette steht: eine Methode, die eine Begrüßung zurückgibt. Die zweite
enthält ein absichtlich kaputtes Programm, das du anhand der Compilermeldungen
reparierst. Das Quiz fragt nach SDK-Auswahl, Projektaufbau und Ausgabedateien.
