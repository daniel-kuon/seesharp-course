# Veröffentlichung von Anwendungen

Ein Programm, das beim Entwickeln läuft, ist noch nicht ausgeliefert.
Kapitel 23 (Seite 1637) beschreibt, welche Entscheidungen bei der
Veröffentlichung anstehen. Die Aufgaben dieses Levels sind Quiz- und
Review-Aufgaben: Dateilisten und Größen hängen von Rechner und SDK ab, deshalb
prüft kein automatischer Test sie. Die Betreuung vergleicht deine Ergebnisse
mit der echten Ausgabe.

## Konfiguration und Zielframework (23.1.1 und 23.1.2, Seite 1637)

Der Compiler kennt zwei Konfigurationen. **Debug** ist der Standard beim
Entwickeln: gut testbar, aber nicht leistungsoptimiert. **Release** optimiert
(zum Beispiel durch Inlining kurzer Methoden) und erschwert dafür die
Fehlersuche; ausgeliefert wird Release. Das `TargetFramework` in der
Projektdatei (der Target Framework Moniker, etwa `net10.0`) legt fest, gegen
welche APIs das Projekt gebaut wird und welche .NET-Version mindestens nötig
ist. Braucht das Programm Betriebssystem-APIs, gehört das Betriebssystem in den
Moniker: `net10.0-windows` für eine WPF-Anwendung. Mit `TargetFrameworks`
(Mehrzahl) kann ein Projekt für mehrere Ziele gebaut werden; das ist
Zusatzwissen und steht nicht im Buch.

## Zielruntime und Bereitstellungsmodus (23.1.4 und 23.1.5, Seite 1643 bis 1646)

Der **Runtime Identifier** (RID) nennt Betriebssystem und CPU-Architektur des
Zielrechners: `win-x64`, `linux-x64`, `linux-arm64`, `osx-arm64`. Bei einer
frameworkabhängigen Veröffentlichung beeinflusst er nur den mitgelieferten
Starter, bei eigenständigen und vorübersetzten Programmen ist er
entscheidend. **Frameworkabhängig** heißt: Auf dem Zielrechner muss eine
passende .NET-Laufzeit installiert sein; die Auslieferung besteht aus
`.dll`, Starter und Konfigurationsdateien und ist klein (im Buch
unter 140 KB). **Eigenständig** (self-contained) bringt die Laufzeit mit; das
Beispiel im Buch wächst von wenigen KB auf 130 MB. Dafür läuft es ohne
Installation auf dem Zielrechner, muss aber für Laufzeit-Updates neu
veröffentlicht werden.

## Einzeldatei und ReadyToRun (23.1.6 und 23.1.7, Seite 1646 bis 1649)

Die eigenständige Veröffentlichung im Buch umfasst 191 Dateien mit 71,2 MB.
`PublishSingleFile` fasst sie in eine Datei zusammen; `PublishTrimmed` entfernt
ungenutzten Code und verkleinert sie erheblich (bei WPF nicht verfügbar,
Fehler NETSDK1168). **ReadyToRun** (R2R) übersetzt den IL-Code vorab in
Maschinencode für eine feste Zielruntime: Das Programm startet schneller, die
Datei wird größer, und sie ist nicht portabel.

## Beispiele (23.2, Seite 1649 bis 1662)

Das Buch veröffentlicht ein Konsolenprogramm als getrimmte Einzeldatei und als
R2R-Einzeldatei für `win-x86`, `linux-x64` und `osx-x64`; das Kommando für die getrimmte Einzeldatei ist
`dotnet publish -r win-x86 -p:PublishSingleFile=true -p:PublishTrimmed=true` (23.2.1, Seite 1652). Die Visual-Studio-
Veröffentlichungsprofile (23.1.3, Seite 1639) ersetzen wir durch
`dotnet publish` im Terminal oder in Rider. Eine Webanwendung wird lokal als
Ordner veröffentlicht und startet mit dem eingebauten Webserver Kestrel
(Standardport 5000, nur HTTP); `launchSettings.json` fehlt im
Veröffentlichungsordner. Für den Betrieb im Netz stellt man meist einen
**Reverse Proxy** (IIS, Nginx, Apache) vor Kestrel (23.2.3.3, Seite 1662).
Hosting-Optionen von IIS und die Umgebungsvariablen `ASPNETCORE_URLS` und
`ASPNETCORE_ENVIRONMENT` sind Zusatzstoff aus der Microsoft-Dokumentation.
