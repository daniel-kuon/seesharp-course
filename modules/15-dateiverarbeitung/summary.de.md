# Dateiverarbeitung und JSON

Kapitel 16 (Seite 1013) zeigt, wie ein Programm Daten dauerhaft speichert:
in Dateien, als Bytes, als Text und als JSON. Zusammengehalten wird alles
vom Konzept des **Datenstroms** und von der Pflicht, externe Ressourcen
freizugeben.

## Datenströme aus Bytes (16.1, Seite 1013 bis 1026)

Ein `Stream` ist eine Folge von Bytes mit einer Position. Die Basisklasse
bietet `Read`, `Write`, `Seek` und `Flush`; ein `FileStream` (16.1.4,
Seite 1018) bindet sie an eine Datei. Beim Öffnen gibt `FileMode` an, was mit
der Datei geschieht (`Create`, `CreateNew`, `Open`, `OpenOrCreate`, `Append`,
`Truncate`), `FileAccess`, was das Objekt darf, und `FileShare`, was andere
dürfen. `Read` liefert die Zahl der tatsächlich gelesenen Bytes (0 am Ende):
Wer immer den ganzen Puffer verwendet, schreibt Müll.

## Ressourcen freigeben (16.2, Seite 1026; 5.4.5, Seite 355)

Der Garbage Collector räumt Speicher auf, aber nicht zu einem bekannten
Zeitpunkt; eine Datei bleibt gesperrt, bis jemand `Dispose()` (oder `Close()`)
aufruft oder irgendwann der Garbage Collector aufräumt. Die **using-Anweisung** (16.2.3, Seite 1027) ist Kurzschreibweise für
`try/finally` mit `Dispose()`, die **using-Deklaration** (16.2.4, Seite 1030)
gilt bis zum Ende des umgebenden Blocks. Geschachtelte Ressourcen werden in
umgekehrter Reihenfolge freigegeben. Eigene Klassen, die eine Ressource halten,
implementieren `IDisposable`: `Dispose()` ist idempotent, danach wirft jede
Benutzung `ObjectDisposedException`. Einen Finalizer braucht nur, wer
unverwaltete Ressourcen direkt hält.

## Binär und Text (16.3, Seite 1032 bis 1041)

`BinaryWriter` und `BinaryReader` (16.3.1, Seite 1032) schreiben und lesen
Werte elementarer Typen in ihrem Binärformat (ein `int` sind 4, ein `double`
8 Bytes). `StreamWriter` und `StreamReader` (16.3.2, Seite 1036) arbeiten mit
Text und einer Zeichencodierung: Ohne Angabe gilt UTF-8, die Codierung steht
nicht in der Datei (zum BOM siehe Deep Dive). Windows-1252
liefert erst der `CodePagesEncodingProvider` (16.3.3, Seite 1040): nach
`Encoding.RegisterProvider(CodePagesEncodingProvider.Instance)` mit
`Encoding.GetEncoding(1252)`. `ReadLine()` liefert `null` am Dateiende. Ein `StreamWriter`
puffert; `Flush()` leert den Puffer, `AutoFlush = true` tut das nach jedem
Schreiben (sicher, aber bei Massendaten langsam; Übung 16.7/2, Seite 1060).

## Kleine Dateien (16.4, Seite 1041)

`File.ReadAllBytes`, `WriteAllBytes`, `ReadAllLines`, `WriteAllLines` und
`AppendAllLines` erledigen Öffnen, Lesen oder Schreiben und Schließen in einem
Aufruf; `WriteAll…` überschreibt eine vorhandene Datei, `AppendAllLines` hängt
an. Weitere Methoden dieser Art und Zahlen in Dateien siehe Deep Dive.

## JSON (16.5, Seite 1043 bis 1051)

`JsonSerializer.Serialize` und `Deserialize<T>` (System.Text.Json, Teil des
Frameworks) wandeln öffentliche Eigenschaften in JSON und zurück.
`JsonSerializerOptions` steuern Einrückung und camelCase;
`[JsonPropertyName]` und `[JsonIgnore]` steuern einzelne Eigenschaften.
Unbekannte JSON-Felder werden beim Einlesen ignoriert. Zirkuläre Referenzen
brechen die Serialisierung ab, solange man nicht `ReferenceHandler.Preserve`
(16.5.5, Seite 1050) einstellt.

## Dateien und Ordner (16.6, Seite 1052 bis 1058)

`File`, `Directory` und `Path` verwalten das Dateisystem: Kopieren,
Verschieben, Löschen, Ordner anlegen und auflisten. Pfade setzt man mit
`Path.Combine` zusammen (ein absoluter Teil verwirft alles davor) und zerlegt
sie mit `GetExtension`. Spezielle Ordner liefert
`Environment.GetFolderPath(…)`; `DriveInfo` und `FileSystemWatcher`
(16.6.5, 16.6.6) sind nur Vorführstoff. In den Aufgaben arbeitet jeder Test in
einem eigenen Temp-Ordner, dessen Name Leerzeichen, Komma und Umlaut enthält.

Vertiefung im Buch: Kapitel 16 (Seite 1013 bis 1060); die Übungsaufgaben in
16.7 (Seite 1060) liefern die Spaltenmittelwerte und die AutoFlush-Frage dieses Levels.

## Deep Dive (optional)

> Nicht im Buch. Diese Themen sind optional – Beispiele dafür, was du dir als Nächstes ansehen kannst.

- **Zahlen und Kultur:** Ohne Angabe parst und formatiert .NET Zahlen nach der
  Spracheinstellung des Rechners: `"1.5"` ergibt unter `de-DE` 15, weil der
  Punkt dort Tausendertrenner ist. Für Dateien mit festem Format nimmt man
  `CultureInfo.InvariantCulture` (Namensraum `System.Globalization`), beim
  Parsen mit `NumberStyles.Float`, damit ein Komma keine Tausendertrennung
  wird. Der Fehler fällt auf dem eigenen Rechner oft nicht auf und wirft
  meist keine Ausnahme.
- **BOM:** Am Dateianfang verrät höchstens eine Byte-Order-Mark (`EF BB BF`)
  UTF-8 oder UTF-16. `Encoding.UTF8` schreibt sie, `new UTF8Encoding(false)`
  nicht.
- **Weitere `File`-Methoden:** `ReadAllText`, `WriteAllText` und
  `AppendAllText` arbeiten mit einem ganzen String statt mit Zeilen;
  `File.Move(von, nach, overwrite: true)` überschreibt ein vorhandenes Ziel.
- **Weitere Pfad- und Ordnermethoden:** `Path.GetFileName`,
  `GetFileNameWithoutExtension`, `GetDirectoryName`, `ChangeExtension`,
  `GetRelativePath`, `GetTempPath` und `GetRandomFileName`;
  `Directory.EnumerateFiles(ordner, muster, SearchOption.AllDirectories)` listet
  auch Unterordner auf.
- **JSON:** `JsonStringEnumConverter` schreibt Enums als Text;
  `ReferenceHandler.IgnoreCycles` ersetzt Rückverweise durch `null`.
- `ObjectDisposedException.ThrowIf(bedingung, this)` wirft die Ausnahme in
  einer Zeile.
