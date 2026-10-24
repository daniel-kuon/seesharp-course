# Zusatz: Zeichenstatistik ohne Kopien

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**15.4 Span<T> und ReadOnlySpan<T>** (Seite 991) mit **15.4.1 Extrahieren
eines Speichersegments ohne Objektkreation und Kopie**.

Die Klasse `Statistik` in `Zeichenstatistik.cs` nimmt ihre Daten als Spans
entgegen, damit Strings, Arrays und Ausschnitte davon gleichermaßen
funktionieren, und erzeugt dabei keine Teilstrings.

1. `ZaehleVokale(ReadOnlySpan<char>)`: zählt `a`, `e`, `i`, `o`, `u`, `ä`,
   `ö`, `ü`, groß und klein.
2. `ErstesWort(ReadOnlySpan<char>)`: liefert das erste Wort als **Ausschnitt**
   des Eingabetexts (führende Leerzeichen überspringen). Der Test prüft,
   dass der Rückgabe-Span auf denselben Speicher zeigt.
3. `Teilsumme(ReadOnlySpan<int>, int von, int bis)`: Summe der Werte von
   Index `von` (einschließlich) bis `bis` (ausschließlich). Ungültige
   Grenzen werfen `ArgumentOutOfRangeException`.

Diese Tests müssen bestehen:

- `StatistikTests.ZaehleVokale_in_String_Array_und_Ausschnitt`
- `StatistikTests.ErstesWort_liefert_den_Ausschnitt`
- `StatistikTests.ErstesWort_kopiert_nichts`
- `StatistikTests.Teilsumme_ueber_Array_und_Ausschnitt`
- `StatistikTests.Teilsumme_lehnt_ungueltige_Grenzen_ab`
