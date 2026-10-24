# Einzeldatei und ReadyToRun

Lies im Buch **23.1.6 Zusammenfassung in einer einzelnen Datei** (Seite
1646), **23.1.7 ReadyToRun-Übersetzung** (Seite 1648) und die Beispiele
**23.2.1 Einzeldateianwendung** (Seite 1649) und **23.2.2
ReadyToRun-Einzeldateianwendung** (Seite 1652). Das Buch veröffentlicht mit dem
Assistenten und zusätzlich mit `PublishTrimmed`; du nutzt das
Kommandozeilenkommando `dotnet publish` mit den Optionen aus dem Manifest
(ohne Trimmen).

Veröffentliche das Konsolenprogramm aus der vorigen Aufgabe in drei
Varianten und vergleiche sie:

| Variante | Optionen |
|---|---|
| frameworkabhängig | `-c Release` |
| eigenständig, Einzeldatei | `-r win-x64 --self-contained -p:PublishSingleFile=true` |
| eigenständig, Einzeldatei, ReadyToRun | zusätzlich `-p:PublishReadyToRun=true` |

Läuft dein Rechner nicht unter Windows x64, wähle den passenden
Runtime Identifier (`linux-x64`, `osx-arm64`, ...). Die erste Veröffentlichung
mit einer neuen Zielruntime kann Pakete aus dem Internet laden.

Trage Dateianzahl und Größe in eine Tabelle ein und erkläre die
Unterschiede. Es gibt keine Tests; die Zahlen hängen vom SDK ab. Die
Betreuung vergleicht sie mit den Größenordnungen aus 23.2.1 und 23.2.2.
