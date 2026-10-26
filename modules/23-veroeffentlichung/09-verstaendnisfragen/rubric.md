# Rubrik: Verständnisfragen Veröffentlichung (nur für die Betreuung)

Die Multiple-Choice-Fragen `mc-rid-mac` (richtig: Option 2), `mc-wpf-tfm` (Option 3) und `mc-web-start` (Option 1) wertet das
Programm selbst aus. Die Kommandos und Projektdateien wurden mit dem .NET-SDK 10 in einem Scratch-Projekt (`Hallo`, WPF-Vorlage, `webapp`-Vorlage) tatsächlich ausgeführt;
die Dateilisten und Größen unten stammen daraus. Größen hängen vom SDK ab, die Größenordnung zählt.

## debug-release

Wesentlich:
- Debug ist der Standard beim Entwickeln: gut zu testen und zu untersuchen, nicht auf Geschwindigkeit optimiert. Release optimiert; ausgeliefert wird Release.
- Eine Optimierung: zum Beispiel Inlining kurzer Methoden (der Aufruf wird durch den Rumpf ersetzt). Preis: Der Code im Debugger entspricht nicht mehr Zeile für Zeile dem Quelltext, Variablen sind „wegoptimiert", die Fehlersuche wird schwieriger.
- Schalter: `-c Release` (oder `--configuration Release`).

Typische Fehlvorstellungen: Release enthalte weniger Funktionen; Debug sei schneller; Debug-Builds dürfe man bedenkenlos ausliefern.

## code-framework-abhaengig

Wesentlich:
- Ergebnis im Ordner `bin/Release/net10.0/publish` unter dem Projektordner.
- Dateien (frameworkabhängig): `Hallo.dll` (das Programm als IL), `Hallo.exe` (der Starter für das Betriebssystem), `Hallo.deps.json` und `Hallo.runtimeconfig.json` (Konfiguration für die Laufzeit) und `Hallo.pdb` (Debuginformationen); zusammen rund 180 KB in dieser Prüfung (das Buch nennt unter 140 KB; kleine Abweichungen durch das SDK sind normal).
- Start: `dotnet Hallo.dll` oder `Hallo.exe` (der Starter ruft dieselbe DLL auf).
- Zielrechner: eine passende **.NET-Laufzeit** (hier .NET 10) muss installiert sein; ohne sie startet das Programm nicht.

Typische Fehlvorstellungen: Es entstehe eine einzelne `.exe` mit allem; die Laufzeit sei im Ergebnis enthalten (Ergebnis wäre dann ~70 MB); das Programm laufe auf jedem Windows ohne Installation.

## mc-rid-mac

(Nur zur Orientierung, wird automatisch gewertet.) Kernpunkt: RID = Betriebssystem plus Architektur (`osx-arm64`), `--self-contained` bringt die Laufzeit mit, `PublishSingleFile` fasst alles in eine Datei.

## zielframework

Wesentlich:
- `TargetFramework` (Target Framework Moniker, `net10.0`) legt fest, gegen welche APIs das Projekt gebaut wird und welche .NET-Version mindestens nötig ist.
- Braucht das Programm Betriebssystem-APIs, gehört das Betriebssystem in den Moniker: WPF läuft nur unter Windows, daher `net10.0-windows`.
- `TargetFrameworks` (Mehrzahl) baut das Projekt für mehrere Ziele (Zusatzwissen, steht nicht im Buch).
- Ein Runtime Identifier (`win-x64`, `linux-x64`) nennt Betriebssystem **und CPU-Architektur** des Zielrechners für die Veröffentlichung (eigenständig/ReadyToRun), das Zielframework dagegen die API-Basis beim Bauen: zwei verschiedene Einstellungen.

Typische Fehlvorstellungen: Zielframework und RID seien dasselbe; `net10.0` laufe auf jedem Betriebssystem mit jeder API (auch WPF); `TargetFramework` bestimme die Konfiguration Debug/Release.

## code-csproj-einzeldatei

Wesentlich:
- Die Eigenschaften in der Projektdatei ersetzen die Kommandozeilenoptionen (`-r win-x64 --self-contained -p:PublishSingleFile=true`): eigenständig, Einzeldatei, für Windows x64.
- Ergebnis: eine einzelne `Hallo.exe` von rund **70 MB** (hier 73,5 MB; das Buch nennt 71,2 MB in 191 Dateien vor dem Bündeln) plus die `.pdb`-Debugdatei, die nicht ausgeliefert werden muss.
- Läuft auf Windows-x64-Rechnern **ohne** installierte .NET-Laufzeit, weil sie mit in der Datei steckt. Nicht auf Linux oder Mac und nicht auf ARM (anderer RID).
- Preis: Größe; für Laufzeit-Updates muss neu veröffentlicht werden.

Typische Fehlvorstellungen: Die Datei sei klein (wenige KB); sie laufe auch auf Linux; es entstehe ein Ordner mit 191 Dateien (das war ohne `PublishSingleFile`).

## mc-wpf-tfm

(Nur zur Orientierung, wird automatisch gewertet.) Kernpunkt: `net10.0-windows` im Zielframework; ein RID ersetzt das nicht (Fehler NETSDK1136).

## frameworkabhaengig-vs-eigenstaendig

Wesentlich:
- Frameworkabhängig: nur `.dll`, Starter und Konfigurationsdateien, **klein** (Größenordnung 100 KB bis wenige MB); auf dem Zielrechner muss eine passende .NET-Laufzeit installiert sein.
- Eigenständig: bringt die Laufzeit mit, **groß** (Größenordnung 70 MB und mehr; im Buch wächst das Beispiel auf 130 MB); läuft ohne Installation.
- Fälle: frameworkabhängig, wenn die Laufzeit überall vorhanden ist (Firmenrechner, Server, viele kleine Auslieferungen) und Platz oder Download zählen; eigenständig, wenn der Zielrechner nichts installiert hat oder nicht verändert werden darf (Kiosk-PC, Kunde ohne Admin-Rechte).
- Updates: Bei frameworkabhängig aktualisiert der Betreiber die Laufzeit auf dem Rechner, bei eigenständig muss der **Entwickler neu veröffentlichen und ausliefern**.

Typische Fehlvorstellungen: Eigenständig sei kleiner, weil „alles in einer Datei"; frameworkabhängig laufe auf jedem Rechner; Sicherheitsupdates der Laufzeit kämen bei eigenständig von allein.

## code-wpf-trimmen

Wesentlich:
- Der Befehl scheitert mit dem Fehler **NETSDK1168**: WPF wird nicht unterstützt oder empfohlen, wenn das Kürzen (Trimming) aktiviert ist; es entsteht kein Ergebnis.
- Abhilfe: ohne `-p:PublishTrimmed=true` veröffentlichen, also eigenständig (`-r win-x64 --self-contained`), nach Wunsch mit `-p:PublishSingleFile=true`, oder frameworkabhängig. Die Anwendung wird größer (hier rund 130 MB; einige native WPF-DLLs liegen auch bei der Einzeldatei daneben).
- Hintergrund: Trimming entfernt scheinbar ungenutzten Code; WPF lädt vieles über Reflexion und XAML und würde dabei Teile verlieren.

Typische Fehlvorstellungen: Der Befehl gelingt und liefert eine kleine Datei; Trimming sei bei jedem Projekttyp möglich; der Fehler liege am Windows-RID.

## einzeldatei-trimmen-r2r

Wesentlich:
- `PublishSingleFile` bündelt die Dateien einer eigenständigen Veröffentlichung in eine Datei (Preis: Die Größe bleibt hoch; hier gemessen 73,5 MB für ein Hallo-Welt-Programm).
- `PublishTrimmed` entfernt ungenutzten Code und verkleinert die Datei erheblich; Preis: Risiko für Code, der über Reflexion arbeitet, und bei WPF gar nicht verfügbar.
- `PublishReadyToRun` (R2R) übersetzt den IL-Code vorab in Maschinencode: schnellerer Start, aber **größere Datei** (hier 83,3 MB statt 73,5 MB) und **nicht portabel**.
- R2R braucht einen RID, weil der Maschinencode für ein festes Betriebssystem und eine feste CPU erzeugt wird; ein Ergebnis für `win-x64` enthält x64-Code für Windows und läuft nicht auf Linux (oder auf ARM). Für jede Zielruntime wird einzeln veröffentlicht.

Typische Fehlvorstellungen: R2R mache die Datei kleiner; R2R sei portabel wie IL; Trimmen sei ohne Risiko; Einzeldatei bedeute „klein".

## code-web-start

Wesentlich:
- Erster Befehl: Kestrel lauscht auf `http://localhost:5000` (Standardport, nur HTTP). Zweiter Befehl: `--urls` überschreibt die Adresse, die Anwendung antwortet auf `http://localhost:5123` (Port 5000 ist dann nicht belegt).
- `launchSettings.json` gilt nur für Starts aus der Entwicklungsumgebung (`dotnet run`, Rider) und wird nicht mit veröffentlicht; die Ports aus der Datei (im Beispiel der Vorlage ebenfalls 5000, bei anderen Projekten ein anderer Wert) gelten im Veröffentlichungsordner nicht mehr. Ohne Einstellung benutzt Kestrel Port 5000.
- Zusatz (nicht verlangt, nicht im Buch): Die Konsole meldet in diesem Fall „Hosting environment: Production".

Typische Fehlvorstellungen: Die Anwendung benutze den Port aus `launchSettings.json` weiter; ohne `--urls` sei kein Start möglich; Port 5000 gelte auch bei `--urls`.

## mc-web-start

(Nur zur Orientierung, wird automatisch gewertet.) Kernpunkt: Im Veröffentlichungsordner startet man die Assembly mit `dotnet MeineWeb.dll` (nicht `dotnet run`, keine Projektdatei).

## kestrel-und-proxy

Wesentlich:
- Kestrel ist der in ASP.NET Core eingebaute Webserver; er führt die Anwendung aus und lauscht auf einem Port (Standard 5000, HTTP).
- Im Netz steht meist ein Reverse Proxy (IIS, Nginx, Apache) davor: Er nimmt die Anforderungen aus dem Netz an und reicht sie an Kestrel weiter.
- Aufgaben des Proxys (mindestens zwei, etwa aus der Dokumentation): TLS/HTTPS-Zertifikat an einer Stelle, mehrere Anwendungen hinter Port 443, statische Dateien, Lastverteilung, Absicherung, Neustart einer Anwendung, ohne die anderen zu stören.
- Die Anwendung behält ihre Aufgabe: Anforderungen verarbeiten und HTML/Daten liefern.

Typische Fehlvorstellungen: Der Proxy führe den C#-Code aus; Kestrel könne kein HTTP; ohne Proxy sei kein Betrieb möglich (zum Entwickeln und für interne Zwecke genügt Kestrel).
