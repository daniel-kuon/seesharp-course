# Rubrik: Rückgabecode, Ausnahme oder Try-Muster (nur für die Betreuung)

- **Kernidee:** Es gibt drei Wege, einen Fehler zu melden, und die Wahl hängt
  davon ab, **wie wahrscheinlich** er ist: Häufige Fehler (Tippfehler, Dateiende)
  meldet man per Rückgabewert oder Try-Muster, seltene (fehlende Konfiguration,
  Dienstausfall) per Ausnahme. Das Try-Muster `bool TryXyz(…, out T)` verbindet
  beides: Der Aufrufer fragt das `bool`, das Ergebnis kommt über `out`, und es
  wird nie geworfen.
- `TryParse`: Prüfen, dass die Methode **nie** wirft. Häufig vergessen:
  `null` (die Signatur hat `string?`), Zahlen jenseits von `int` (hier
  `int.TryParse` statt `int.Parse`) und der Nenner 0, den der `Bruch`-Konstruktor
  mit einer Ausnahme quittieren würde. Ein `try`/`catch` **in** `TryParse` ist
  eine Notlösung, die man erkennen und ablehnen darf: Sie verfehlt den Zweck
  (keine Ausnahmekosten).
- Bei `ergebnis` auf allen `false`-Pfaden `null` setzen (`out` verlangt eine
  Zuweisung auf jedem Pfad).
- `ParseAlleMit…`: Der 2000er-Test erzeugt 1500 Ausnahmeobjekte in der einen
  Variante, keine in der anderen. Gespräch: Warum ist das für eine Datei mit
  vielen fehlerhaften Zeilen wichtig? (Ausnahmen sind langsam: Stapelüberwachung
  aufbauen, Stapel abbauen.) Gemessen wird nichts.
- Quiz: Lösungen sind Try-Muster, Ausnahme, Rückgabewert, Ausnahme, Try-Muster;
  `ArgumentNullException`, `InvalidOperationException`, `NotSupportedException`,
  `KeyNotFoundException`, `IndexOutOfRangeException`. Bei der offenen Frage
  zum Syntaxdiagramm: `try`-Block, dann entweder ein oder mehrere
  `catch`-Blöcke (optional mit `when`), optional `finally`, **oder** nur `finally`.
  Ein `try` ohne `catch` und `finally` ist ungültig.
- Modellantwort: `solution/`; Vorlage `samples/Ausnahmebehandlung/RcVsException`.
