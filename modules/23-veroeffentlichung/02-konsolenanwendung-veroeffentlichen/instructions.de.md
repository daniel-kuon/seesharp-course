# Eine Konsolenanwendung veröffentlichen

Lies im Buch **23.2.1 Einzeldateianwendung** (Seite 1649) und
**23.1.5 Bereitstellungsmodus** (Seite 1644, nur den Teil
*frameworkabhängig*). Das Buch zeigt dort den Visual-Studio-Assistenten; in
dieser Aufgabe benutzt du stattdessen das Kommando, das der Assistent im
Hintergrund ausführt: `dotnet publish`. Die Buchaufgabe 4 in **3.7** (Seite 159)
fragt, welche Dateien aus dem Ausgabeordner einer Projekterstellung
(`bin/Release/net10.0`) man ausliefern muss; hier stellst du dieselbe Frage für den
Veröffentlichungsordner.

1. Wähle ein Konsolenprogramm aus einem früheren Level (oder lege mit
   `dotnet new console` ein neues an).
2. Veröffentliche es im Projektordner mit `dotnet publish -c Release`. Das
   Ergebnis liegt in `bin/Release/net10.0/publish`.
3. Starte es von dort aus mit `dotnet <Name>.dll` und als `<Name>.exe`.
   Schau dir vorher mit `dir` an, was der Ordner enthält.
4. Beantworte die offene Frage mit der Dateiliste und deiner Einschätzung,
   was ein Kunde bekommen muss.

Es gibt keine Tests: Die Dateien und Größen hängen vom SDK und vom Rechner ab.
Die Betreuung vergleicht deine Angaben mit der echten Ausgabe.
