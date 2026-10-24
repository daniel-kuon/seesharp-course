# Rubrik — Eine eigene IDisposable-Klasse (nur für die Betreuung)

- Kern: `IDisposable` ist das Protokoll, mit dem `using` arbeitet. Eine
  korrekte Implementierung ist idempotent und lässt nach der Freigabe keine
  Benutzung mehr zu (`ObjectDisposedException`). Die Tests prüfen genau das und
  dass `using` auch bei einer durchlaufenden Ausnahme freigibt (`Offene` zählt
  wieder herunter, die Datei ist frei).
- Der volle „Dispose-Pattern“ mit `Dispose(bool)` und Finalizer ist für
  Klassen gedacht, die rohe (unverwaltete) Ressourcen halten oder vererbt werden.
  Das Logbuch ist `sealed` und hält nur einen `StreamWriter`; darum reicht
  ein schlichtes `Dispose()`. Ein Finalizer wäre hier unnötig und bremst den GC.
  Nachfrage: Wann wäre er nötig? (Rohes Handle aus einer unverwalteten API; dann
  besser `SafeHandle` verwenden.)
- Falle: `Offene++` vor dem Öffnen der Datei: Scheitert das Öffnen, steht der
  Zähler falsch (`Scheitert_der_Konstruktor_wird_nichts_gezaehlt`).
- Falle: Zähler in `Dispose()` ohne Schutz: Ein zweiter Aufruf zählt doppelt.
- Das Quiz-Item ist die Frage aus der Planung: Ohne `Dispose()` bleibt die Datei
  gesperrt (der Test `Ohne_Dispose_bleibt_die_Datei_gesperrt` zeigt es), und
  ungeleerter Puffer des `StreamWriter` geht verloren, wenn der Prozess endet:
  Ein `StreamWriter` hat keinen Finalizer, der ihn leert.
- `Offene` ist statisch und daher nicht thread-sicher; für die Übung
  genügt das (keine Nebenläufigkeit in den Tests). Nachfrage nach `Interlocked`
  erst in Level 17.

Modellantwort: `solution/`.
