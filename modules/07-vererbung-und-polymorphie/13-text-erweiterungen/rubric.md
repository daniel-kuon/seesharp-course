# Rubrik — Zusatz Text-Erweiterungen (nur für die Betreuung)

- Instanzblock `extension(string text)` gegen statischen Block
  `extension(string)`: `string.Wiederhole(...)` und der Operator gehören in
  den statischen Block. Wer `Wiederhole` als Instanzmethode schreibt,
  bekommt einen Compilerfehler im Test (`string.Wiederhole` nicht gefunden).
- `IstPalindrom`: Lösungen mit zwei Indizes von außen nach innen sind
  besser als "säubern, umdrehen, vergleichen", beide sind in Ordnung.
  Nachfragen, warum `char.ToLower` statt `ToLower()` auf dem ganzen String
  (weniger Zwischenobjekte; `string` ist unveränderlich, Level 6).
- `Umgedreht()` per `StringBuilder` statt `+=` in der Schleife: Level 6
  wiederholen.
- Operator `*` für `string * int`: Das gibt es in C# nicht eingebaut,
  deshalb greift die Erweiterung. Wer `"ab" * 3` vorher ausprobiert, sieht
  den Compilerfehler.

Modellantwort: `solution/`.
