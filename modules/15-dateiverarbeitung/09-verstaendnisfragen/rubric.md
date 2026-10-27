# Rubrik — Verständnisfragen Level 15 (nur für die Betreuung und den KI-Tutor)

Die Code-Ausgaben wurden in einem Konsolenprojekt (net10.0) geprüft. Eine
Antwort besteht, wenn die genannten Kernpunkte sinngemäß vorkommen; Wortlaut
und Fachbegriffe müssen nicht exakt stimmen.

## using-warum

Kernpunkte:
- Der Garbage Collector räumt Speicher auf, aber **nicht zu einem bekannten Zeitpunkt**; eine Datei bleibt gesperrt (andere können sie nicht öffnen oder schreiben), und der Puffer eines `StreamWriter` wird womöglich nie geleert, sodass Daten fehlen. Freigabe muss man selbst auslösen: `Dispose()` oder `Close()`.
- `using (...) { ... }` ist Kurzschreibweise für `try { ... } finally { x.Dispose(); }`: Die Freigabe geschieht **auch bei einer Ausnahme**.
- Die `using`-Deklaration (`using var x = ...;`) gilt bis zum **Ende des umgebenden Blocks** (kein eigener Einrückungsblock nötig); beide geben in umgekehrter Reihenfolge der Anlage frei.

Typische Irrtümer: Der GC schließe die Datei sofort, wenn die Variable den Gültigkeitsbereich verlässt; `using` fange Ausnahmen ab (es gibt kein `catch`); die Deklaration gebe sofort nach der Zeile frei.

## stream-arten

Kernpunkte:
- `FileStream` (mit `BinaryWriter`/`BinaryReader`) arbeitet mit **Bytes bzw. Werten im Binärformat** (ein `int` sind 4, ein `double` 8 Bytes); kompakt, aber nicht menschenlesbar, und man muss beim Lesen Typ und Reihenfolge kennen.
- `StreamWriter`/`StreamReader` arbeiten mit **Text** (Zeilen, `WriteLine`, `ReadLine`); sie wandeln Zeichen in Bytes um und brauchen dafür eine **Zeichencodierung**.
- Codierung: Ohne Angabe gilt **UTF-8**; die Codierung steht **nicht in der Datei** (höchstens ein BOM verrät UTF-8/UTF-16), man muss sie kennen. Wird eine Datei mit falscher Codierung gelesen (z. B. Windows-1252 als UTF-8), erscheinen Ersatzzeichen statt Umlauten.

Typische Irrtümer: Der StreamReader erkenne jede Codierung von selbst (er erkennt nur ein BOM, Windows-1252 nicht); Binärdateien seien immer kleiner/besser; `StreamWriter` schreibe Bytes ohne Codierung.

## kultur

(Die Item-ID stammt aus einer früheren Frage zur Kultur; die Frage behandelt jetzt 16.4.)

Kernpunkte:
- Die `File`-Methoden eignen sich für **kleine Dateien**, die ganz in den Hauptspeicher passen: ein Aufruf statt Öffnen, Lesen bzw. Schreiben und Schließen (16.4, Seite 1041 f.).
- Sie öffnen und **schließen die Datei selbst**, auch wenn ein Fehler auftritt; kein `using`, kein `Close()` nötig. `WriteAllLines` überschreibt eine vorhandene Datei (`FileMode.Create`), `AppendAllLines` hängt an.
- Ungeeignet bei **großen Dateien** (alles liegt auf einmal im Speicher) und wenn man paketweise lesen, mit `Seek`/`Position` springen oder `FileMode`, `FileAccess` und `FileShare` selbst bestimmen will; dann nimmt man einen Datenstrom.

Typische Irrtümer: Die `File`-Methoden ließen die Datei offen; `WriteAllLines` hänge an; sie seien bei großen Dateien schneller.

Bonus (Deep Dive, nicht im Buch): Zahlen in Dateien mit `CultureInfo.InvariantCulture` lesen und schreiben, damit die Spracheinstellung des Rechners keine Rolle spielt.

## eigene-ressource

Kernpunkte:
- Eine Klasse implementiert `IDisposable`, wenn sie eine **Ressource hält**, die freigegeben werden muss (z. B. einen `StreamWriter`/Datei, Verbindung), damit Benutzer sie mit `using` verwenden können; `Dispose()` gibt die gehaltene Ressource frei.
- `Dispose()` soll **idempotent** sein: mehrfach aufrufbar ohne Fehler (z. B. mit einem `disposed`-Flag).
- Benutzung nach `Dispose()` soll eine **`ObjectDisposedException`** werfen.
- Einen Finalizer braucht nur, wer **unverwaltete Ressourcen direkt** hält; bei verwalteten Ressourcen (hier `StreamWriter`) genügt `Dispose()`.

Typische Irrtümer: Jede Klasse brauche einen Finalizer; `Dispose()` dürfe nur einmal aufgerufen werden; es genüge eine Methode namens `Close()` ohne `IDisposable`.

## code-using-reihenfolge

Ausgabe (sechs Zeilen): `auf A`, `auf B`, `Arbeit`, `zu B`, `zu A`, `danach`.
Kernpunkte:
- Beide Objekte werden in der Reihenfolge ihrer Anlage erzeugt.
- Freigabe in **umgekehrter Reihenfolge**: Die `using`-Deklaration `b` gilt bis zum Ende des inneren Blocks `{ ... }` (zu B), dann endet die `using`-Anweisung von `a` (zu A); beides geschieht, **bevor** „danach“ erscheint.

Typische Irrtümer: `zu A` vor `zu B`; `zu B` erscheine direkt nach `auf B`; `zu A` komme erst nach „danach“.

## code-schreiber

Ausgabe, drei Zeilen: `2`, `eins|zwei|drei`, `neu`.
Kernpunkte:
- Nach dem ersten `using` ist die Datei geschlossen und geleert; `ReadAllLines` liefert 2 Zeilen.
- `append: true` hängt an, ohne den Inhalt zu löschen → drei Zeilen.
- Der `StreamWriter` ohne `append` **überschreibt** die Datei (FileMode.Create): Nur `neu` bleibt übrig.

Typische Irrtümer: `eins|zwei|drei|neu` (Standard hänge an); die Datei sei nach dem ersten Block noch leer (ohne `using` stimmt das tatsächlich, mit `using` nicht).

## code-kultur

(Die Item-ID stammt aus einer früheren Frage zur Kultur; die Frage behandelt jetzt 16.4.)

Ausgabe, zwei Zeilen: `3` und `d,e,f`.
Kernpunkte:
- `WriteAllLines` **überschreibt** die Datei (16.4, Seite 1042: intern `FileMode.Create`): Nach dem zweiten `WriteAllLines` steht nur noch `d` darin; `a`, `b` und `c` sind weg.
- `AppendAllLines` **hängt an** (Seite 1043): danach `d`, `e`, `f`.
- `ReadAllLines` liefert ein Array mit einer Zeile je Element, also Länge 3.

Typische Irrtümer: `6` und `a,b,c,d,e,f` (`WriteAllLines` hänge an); `2` und `e,f` (`AppendAllLines` überschreibe); die Datei sei zwischen den Aufrufen noch gesperrt.

## code-binaer

Ausgabe, drei Zeilen: `12`, `42`, `7`.
Kernpunkte:
- `int` belegt 4 Bytes, `double` 8 Bytes, `BinaryWriter` schreibt sie ohne Trennzeichen oder Text: 4 + 8 = 12 Bytes.
- Gelesen wird in derselben Reihenfolge und mit denselben Typen (`ReadInt32`, dann `ReadDouble`): 42, und 3,5 · 2 = 7.

Typische Irrtümer: Dateigröße 8 (Text „42“ und „3.5“) oder 6; die Reihenfolge beim Lesen sei egal (falsche Reihenfolge liefert Unsinn oder `EndOfStreamException`).
