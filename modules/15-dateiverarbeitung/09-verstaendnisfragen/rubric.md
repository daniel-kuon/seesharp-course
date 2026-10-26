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
- Codierung: Ohne Angabe gilt **UTF-8**; die Codierung steht **nicht in der Datei**, man muss sie kennen. Wird eine Datei mit falscher Codierung gelesen (z. B. Windows-1252 als UTF-8), erscheinen Ersatzzeichen statt Umlauten.

Typische Irrtümer: Der StreamReader erkenne die Codierung von selbst; Binärdateien seien immer kleiner/besser; `StreamWriter` schreibe Bytes ohne Codierung.

## kultur

Kernpunkte:
- Ohne Angabe gilt die **Spracheinstellung des Rechners**: Dezimaltrenner, Tausendertrenner und Datumsformat unterscheiden sich (`"1.5"` ergibt unter `de-DE` 15, weil der Punkt dort Tausendertrenner ist; `1,5` unter `en-US`).
- Dateien mit festem Format müssen auf jedem Rechner gleich gelesen und geschrieben werden: deshalb `CultureInfo.InvariantCulture` beim Parsen **und** beim Formatieren.
- Der Fehler fällt auf dem eigenen Rechner nicht auf, weil dort Lese- und Schreibkultur übereinstimmen; er tritt erst auf einem Rechner mit anderer Spracheinstellung auf (oder Datei von dort), und oft **ohne Ausnahme** mit falschen Werten.

Typische Irrtümer: Es gebe immer eine `FormatException`; die Kultur spiele nur bei der Ausgabe auf dem Bildschirm eine Rolle.

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

Ausgabe, vier Zeilen: `15`, `1.5`, `1.5`, `15`.
Kernpunkte:
- Unter `de-DE` ist der Punkt der Tausendertrenner und das Komma das Dezimalzeichen: `"1.5"` → 15, `"1,5"` → 1,5 (ausgegeben mit Punkt: `1.5`).
- Unter der invarianten Kultur ist der Punkt das Dezimalzeichen: `"1.5"` → 1,5. Das Komma wird dort als Tausendertrenner akzeptiert, also `"1,5"` → 15 (keine Ausnahme!).
- Das Beispiel zeigt: Dieselbe Zeichenkette ergibt je nach Kultur andere Werte, meist ohne Fehlermeldung.

Typische Irrtümer: `"1.5"` unter `de-DE` ergebe 1,5 oder eine `FormatException`; die vierte Zeile werfe eine Ausnahme (dort ist das Komma Tausendertrenner).

## code-binaer

Ausgabe, drei Zeilen: `12`, `42`, `7`.
Kernpunkte:
- `int` belegt 4 Bytes, `double` 8 Bytes, `BinaryWriter` schreibt sie ohne Trennzeichen oder Text: 4 + 8 = 12 Bytes.
- Gelesen wird in derselben Reihenfolge und mit denselben Typen (`ReadInt32`, dann `ReadDouble`): 42, und 3,5 · 2 = 7.

Typische Irrtümer: Dateigröße 8 (Text „42“ und „3.5“) oder 6; die Reihenfolge beim Lesen sei egal (falsche Reihenfolge liefert Unsinn oder `EndOfStreamException`).
