# Rubrik: Verständnisfragen Level 0 (nur für die Betreuung und den KI-Tutor)

Offene Antworten bestehen, wenn die genannten Kernpunkte sinngemäß vorkommen. Die Wortwahl ist egal, Fachbegriffe sollen aber stimmen. Die Auswahlfragen (`gueltiges-programm`, `gruss-methode`, `projekt-anlegen`, `variable-deklarieren`, `debugger-schritt`) sind automatisch bewertet und haben hier keinen Eintrag.

## global-json

Kernpunkte:
- Die `global.json` legt fest, **welche SDK-Version** `dotnet` benutzt, und gilt für den Ordner, in dem sie liegt, und alle Ordner darunter.
- Ohne sie nimmt `dotnet` das **neueste installierte SDK**; das kann je nach Rechner ein anderes sein.
- SeeSharp liefert eine mit, damit **alle Übungen (und die Bewertung) mit demselben SDK** gebaut werden und dasselbe Ergebnis liefern, unabhängig davon, was sonst auf dem Rechner installiert ist.

Typische Irrtümer: Die `global.json` lege das Zielframework oder den Ausgabetyp fest (das macht die `.csproj`); sie installiere das SDK (sie wählt nur aus, was installiert ist); sie gelte nur für ein Projekt.

## reihenfolge

Exakte Ausgabe (vier Zeilen):

```
Start
in Name
SeeSharp
Ende
```

Kernpunkte:
- Die Anweisungen in `Main()` laufen von oben nach unten.
- Um `Console.WriteLine(Name())` auszuführen, muss zuerst das Argument berechnet werden, also `Name()` aufgerufen werden. Dabei wird `in Name` ausgegeben; erst danach gibt `Main()` den zurückgegebenen Text `SeeSharp` aus.
- `Name()` gibt also selbst etwas aus **und** liefert etwas zurück; das sind zwei verschiedene Dinge.

Typischer Irrtum: `in Name` erscheine nach `SeeSharp` oder gar nicht, oder der Rückgabewert werde automatisch ausgegeben.

## fehlerarten

Kernpunkte:
- **Syntaxfehler:** verstößt gegen die Sprachregeln (fehlendes Semikolon, Tippfehler im Namen). Der Compiler meldet ihn mit Datei, Zeile, Spalte und Code (`CSxxxx`); es entsteht kein Programm.
- **Laufzeitfehler:** Das Programm baut und startet, bricht aber beim Ausführen mit einer Ausnahme ab (Beispiel: Division durch 0, Zugriff außerhalb eines Arrays, Datei fehlt).
- **Logikfehler:** Das Programm läuft ohne Absturz durch, liefert aber ein falsches Ergebnis (Beispiel: falsche Formel, `<` statt `<=`, falscher Text). Man findet ihn nur durch Testen, Vergleichen mit dem erwarteten Ergebnis oder im Debugger.
- Der Trainee sagt, wie man jede Art bemerkt: Compiler-Fehlerliste, Absturzmeldung, falsche Ausgabe oder roter Test.

Typische Irrtümer: Warnungen und Fehler verwechseln; einen Absturz „Syntaxfehler“ nennen; behaupten, der Compiler finde Logikfehler.

## rueckgabe-ohne-ausgabe

Exaktes Verhalten: Das Programm baut ohne Fehler und gibt **nichts** aus.

Kernpunkte:
- `Main()` ruft `Gruss()` auf; die Methode liefert `"Hallo"` zurück, aber der Rückgabewert wird einfach verworfen.
- Ein Rückgabewert ist keine Ausgabe. Etwas erscheint auf der Konsole nur, wenn `Console.WriteLine` aufgerufen wird.
- Änderung: in `Main()` `Console.WriteLine(Gruss());` schreiben, wie in der Übung `Hallo`. Auch richtig: `Gruss()` selbst ausgeben lassen und dann `void` verwenden.

Typischer Irrtum: Es erscheine `Hallo`, weil die Methode „etwas zurückgibt“; oder der Aufruf `Gruss();` sei ein Fehler (er ist erlaubt, der Wert wird ignoriert).

## ausgabedateien

Kernpunkte:
- Mindestens nötig: die **`.dll`** (enthält den IL-Code und die Metadaten, also das eigentliche Programm), die **`.exe`** (Starthilfe für Windows, die die Laufzeit lädt) und die **`.runtimeconfig.json`** (sagt der Laufzeitumgebung, welche .NET-Version das Programm braucht).
- Weglassen kann man die **`.pdb`**: Sie enthält Debug-Informationen und wird nur vom Debugger gebraucht.
- Der Zielrechner braucht die passende .NET-Laufzeit; der Ordner `obj/` gehört nicht dazu (Zwischenergebnisse).

Typische Irrtümer: Die `.exe` allein genüge; die `.pdb` enthalte das Programm; `obj/` müsse mitgeliefert werden; in der `.exe` stehe Maschinencode.

## semikolon

Kernpunkte:
- Der Compiler meldet einen **Syntaxfehler** in Zeile 5: **CS1002** (`;` erwartet). Die Meldung nennt Datei, Zeile, Spalte und Fehlercode.
- Weil der Build fehlschlägt, entsteht kein Programm; `dotnet run` startet **nichts** und zeigt nur die Fehlerliste.
- Behebung: ein Semikolon hinter `Console.WriteLine("Hallo")`.
- Gut: Der Trainee erwähnt, dass man die Zeile in der Meldung liest (manchmal zeigt der Compiler die Zeile **nach** der fehlenden Stelle, hier aber Zeile 5).

Typische Irrtümer: Das Programm laufe trotzdem und gebe `Hallo` aus; es sei ein Laufzeitfehler.

## bewertung

Kernpunkte:
- Beim Abgeben **kopiert** SeeSharp den Code des Trainees in ein sauberes Verzeichnis, kopiert die **eigenen Tests der Übung** dazu und führt sie dort aus; pro Test wird angezeigt, ob er bestanden ist.
- Es zählt nur diese Kopie, weil der Testordner des Trainees verändert sein könnte (absichtlich oder aus Versehen); die Bewertung vertraut nur den Originaltests.
- Rote Tests lesen: Der **Testname** sagt, was geprüft wurde, die **Meldung** zeigt erwarteten und tatsächlichen Wert. Dann korrigieren und erneut abgeben.

Typische Irrtümer: SeeSharp führe den Code des Trainees einfach im Arbeitsordner aus; die Tests in Rider seien maßgeblich; ein roter Test bedeute, dass das Projekt nicht gebaut werden konnte.
