# Span<T>, ReadOnlySpan<T> und ref-Rückgabe

Lies im Buch **15.3 Methoden mit ref-Variablen und ref-Rückgabewerten**
(Seite 988) und **15.4 Span<T> und ReadOnlySpan<T>** (Seite 991) mit
**15.4.1 Extrahieren eines Speichersegments ohne Objektkreation und Kopie**
sowie **15.4.3 Premium-Sprachunterstützung für die Span-Typen seit C# 14**
(Seite 994).

Öffne `Spans.cs`; `Messpunkt.cs` ist eine bewusst große Struktur (vier
`double`-Werte). Die Signaturen sind vorgegeben, du schreibst die Rümpfe:

1. `Summe(ReadOnlySpan<int>)` summiert ohne Kopie. Der Test ruft sie mit
   einem Array, einem Ausschnitt (`a.AsSpan(2, 3)`) und einem
   `stackalloc`-Puffer auf: ein Parametertyp, viele Quellen. (`stackalloc`
   in einen `Span<T>` braucht keinen `unsafe`-Kontext, auch wenn das Buch
   in 15.5 anderes andeutet.)
2. `ZaehleWoerter(ReadOnlySpan<char>)` zählt Wörter, die durch Leerzeichen
   getrennt sind (mehrere Leerzeichen hintereinander zählen nicht doppelt).
   Zerlege den Text durch Ausschnitte (`TrimStart`, `IndexOf`, `text[ende..]`),
   nicht mit `Split` oder `Substring`.
3. `SpiegleInPlace(Span<int>)` kehrt die Elemente um. Bei einem Ausschnitt
   ändert sich nur dieser Teil des Arrays dahinter.
4. `Hoechster(int[])` liefert einen **Verweis** auf das größte Element
   (`ref int`; gibt es den Höchstwert mehrfach, auf das erste):
   `Hoechster(a) = 0;` setzt es im Array auf 0. Mit einer lokalen
   `ref`-Variable (`ref int m = ref a[0];`) merkst du dir die Fundstelle.
5. `Hellster(Messpunkt[])` liefert einen `ref readonly`-Verweis auf den
   Messpunkt mit der größten Helligkeit (bei Gleichstand den ersten), ohne
   die Struktur zu kopieren.
6. `SpanErweiterungen`: Der `extension`-Block (C# 14) macht
   `IstPalindrom()` zu einem Mitglied von `ReadOnlySpan<char>`.
   Groß-/Kleinschreibung zählt (`"Anna"` ist keins), der leere Text ist ein
   Palindrom. Weil Strings
   und `char`-Arrays implizit in Spans übergehen, ruft der Test sie auf
   `"anna"` und auf einem `char[]` auf.

Diese Tests müssen bestehen:

- `SpanUndRefTests.Summe_nimmt_Spans_entgegen`
- `SpanUndRefTests.Summe_ueber_Array_Ausschnitt_und_stackalloc`
- `SpanUndRefTests.ZaehleWoerter_zaehlt_Woerter`
- `SpanUndRefTests.ZaehleWoerter_arbeitet_auch_auf_einem_Ausschnitt`
- `SpanUndRefTests.SpiegleInPlace_aendert_das_Array`
- `SpanUndRefTests.SpiegleInPlace_wirkt_nur_auf_den_Ausschnitt`
- `SpanUndRefTests.Hoechster_gibt_einen_Verweis_zurueck`
- `SpanUndRefTests.Hoechster_kann_zugewiesen_werden`
- `SpanUndRefTests.Hellster_liefert_einen_schreibgeschuetzten_Verweis`
- `SpanUndRefTests.IstPalindrom_auf_String_und_Array`
