# Rubrik — Textdateien mit StreamWriter und StreamReader (nur für die Betreuung)

- Kern: Ein `StreamWriter`/`StreamReader` hält eine Datei offen und puffert;
  erst `Close()` (bzw. `Dispose()`) gibt sie frei und schreibt den Rest. Hier mit
  `try/finally`, damit der Trainee in Aufgabe 4 den Gewinn der `using`-Anweisung
  selbst spürt. `Schreibe_schliesst_die_Datei_auch_bei_einer_Ausnahme` prüft
  das mit einer Quelle, die mitten im Schreiben wirft (`PruefeDateiFrei` öffnet
  die Datei ohne Mitbenutzung).
- Lesen bis `null`: `ReadLine()` liefert `null` erst am Dateiende, eine leere
  Zeile ist `""`. Wer `while (!r.EndOfStream)` nimmt, löst ebenfalls richtig.
- Codierung: Die Codierung steht nicht in der Datei. Ohne Angabe nimmt
  .NET UTF-8; `Encoding.UTF8` als Argument schreibt dagegen ein BOM, während
  `new StreamWriter(pfad)` und `new UTF8Encoding(false)` es nicht tun. Diese
  Falle trifft viele; `SchreibeUtf8_schreibt_ohne_BOM` fängt sie.
- `catch` nur auf die erwarteten Typen, kein `catch (Exception)`: Rechte-
  und Sperrfehler sollen sichtbar bleiben. Nachfrage: Warum wäre
  `catch (IOException)` hier zu breit? (`FileNotFoundException` und
  `DirectoryNotFoundException` sind Geschwister unter `IOException`; der
  Basistyp finge auch gesperrte Dateien und volle Datenträger.)
- Testumgebung: Der Temp-Ordner enthält Leerzeichen, Komma und Umlaut; wer
  Pfade selbst zusammenbaut oder zerlegt, fällt hier auf.

Modellantwort: `solution/` bzw. `samples/Ein- und Ausgabe über Datenströme/{Einstieg,StreamWrtRd,Ansi-Text Lesen}`.
