# Rubrik — Span<T>, ReadOnlySpan<T> und ref-Rückgabe (nur für die Betreuung)

- Kern: Ein Span ist ein Fenster auf vorhandenen Speicher; Ausschnitte
  (`Slice`, `[a..b]`) kopieren nichts. Das Ergebnis prüfen die Tests, nicht
  die Allokation. Die Frage an den Trainee: Wo würde `Substring` oder `Split`
  Objekte erzeugen, die hier fehlen? Wer in `ZaehleWoerter` `Split` oder
  `ToString()` verwendet, hat das Lernziel verfehlt, auch wenn der Test grün ist.
- `ref`-Rückgabe: Der Aufrufer bekommt die Speicherstelle, nicht den Wert.
  `Hoechster(a)++` und `Hoechster(a) = 0` ändern das Array. Zur Sicherheit
  prüft der Compiler, dass der Verweis die Methode überlebt (Array-Element:
  ja; lokale Variable: nein, CS8168). Nachfragen: Warum darf `Hoechster` keinen
  Verweis auf eine lokale Variable zurückgeben?
- `ref readonly` vermeidet das Kopieren großer Strukturen bei Lesezugriff;
  `Messpunkt` ist darum `readonly struct`.
- C# 14: Der `extension`-Block auf `ReadOnlySpan<char>` kommt wegen der
  impliziten Konvertierungen ohne `.AsSpan()` aus. Vor C# 14 hätte
  `"anna".IstPalindrom()` nicht kompiliert. Die Aufgabe verlangt bewusst den
  `extension`-Block (Neuerung C# 14, Buch 15.4.3.3); eine klassische
  Erweiterungsmethode mit `this` ist nicht das Lernziel.
- Span-Grenzen (Quiz-Item): kein Feld in Klassen, kein `await`, keine
  Lambda-Erfassung.

Modellantwort: `solution/` bzw. `samples/C# für Fortgeschrittene/Span-Typen/…` und `…/ref-Rückgabe`.
