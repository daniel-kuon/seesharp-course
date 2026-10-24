# Rubrik — Konsolenanwendung veröffentlichen (nur für die Betreuung)

- Erwartete Dateien einer frameworkabhängigen Veröffentlichung (Name =
  Projektname): `<Name>.exe` (Starter), `<Name>.dll` (IL-Code),
  `<Name>.runtimeconfig.json` (welche Laufzeit), `<Name>.deps.json`
  (Abhängigkeiten) und `<Name>.pdb` (Debug-Symbole). Ausliefern: exe, dll,
  runtimeconfig.json, deps.json; die pdb nicht (23.2.2, Seite 1656 nennt sie
  verzichtbar). Zum Vergleich auf dem Rechner des Trainees nachsehen, ob die
  Angaben stimmen; Ordner und Kommandozeile prüfen lassen.
- Nachfrage: Was passiert, wenn die `.runtimeconfig.json` fehlt? (Der Host
  weiß nicht, welche Laufzeit gebraucht wird; der Start scheitert.)
- Nachfrage: Warum startet `dotnet <Name>.dll` auch ohne die exe? (Die dll
  ist das eigentliche Programm; die exe ist ein Starter.) Wo steht, dass es
  eine Laufzeit braucht?
- `dotnet publish` baut seit .NET 8 standardmäßig Release; `-c Release` zu
  nennen schadet nicht und macht die Absicht deutlich (23.2.1, Seite 1652).
- Auf Nicht-Windows-Rechnern gibt es keine `.exe`, sondern eine Datei ohne
  Endung.
