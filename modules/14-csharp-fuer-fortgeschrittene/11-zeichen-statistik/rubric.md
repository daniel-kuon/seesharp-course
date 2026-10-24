# Rubrik — Zusatz: Zeichenstatistik ohne Kopien (nur für die Betreuung)

- Kern: Spans als Parametertyp (`ReadOnlySpan<char>`, `ReadOnlySpan<int>`) und
  Ausschnitte (`text[..ende]`, `werte[von..bis]`) statt `Substring`/`Array.Copy`.
  `ErstesWort` darf ein Span zurückgeben, weil er auf den Speicher des
  Aufrufers zeigt; ein Span auf einen lokalen `stackalloc`-Puffer wäre dagegen ein
  Fehler (CS8352).
- `ErstesWort_kopiert_nichts` prüft mit `Unsafe.AreSame`, dass der Rückgabe-Span
  im Eingabe-Array liegt; `.ToString()` in der Lösung würde das nicht bestehen.
- Nachfrage: Warum kann `ZaehleVokale` einen String, ein `char[]` und einen
  Ausschnitt annehmen, ohne drei Überladungen?

Modellantwort: `solution/`.
