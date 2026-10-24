# Ausnahmen und Abbruch bei Aufgaben

Lies im Buch **17.5.6 Unbehandelte Ausnahmen bei der Aufgabenbearbeitung**
(Seite 1129) mit **17.5.6.1 Erneutes Werfen auf höherer Ebene** und dem
Abschnitt zu `Flatten()` sowie **17.5.10 Aufgaben abbrechen** (Seite 1145).

Zwei Regeln sind neu gegenüber normalem Code:

- Eine Ausnahme in einer Aufgabe fliegt nicht dort, wo sie passiert,
  sondern wird in der Aufgabe aufgehoben. Wer auf die Aufgabe wartet
  (`Wait`, `WaitAll`, `Result`), bekommt sie als `AggregateException`, die
  **alle** Fehler enthält. Mehrere Aufgaben, mehrere Fehler. Verschachtelte
  Gruppen löst `Flatten()` auf, die einzelnen Ausnahmen stehen in
  `InnerExceptions`.
- Eine Aufgabe lässt sich nicht von außen stoppen. Sie wird **kooperativ**
  abgebrochen: Der Aufrufer ruft `Cancel()` auf einer
  `CancellationTokenSource` auf, die Aufgabe fragt regelmäßig über das
  `CancellationToken` nach und beendet sich selbst. Der Normalfall ist
  `token.ThrowIfCancellationRequested()`. Die so entstehende
  `OperationCanceledException` ist kein Fehler: Die Aufgabe endet im
  Zustand "abgebrochen" (`IsCanceled`), nicht "fehlgeschlagen" (`IsFaulted`).

**Die Tests sind deterministisch:** keine Zeitmessung, kein `Thread.Sleep`.
Der Abbruchtest wartet mit einem `ManualResetEventSlim`, bis die Aufgabe
wirklich läuft, und bricht dann erst ab. Wartezeiten sind nur Hängerschutz.

Ergänze:

1. `Fehler.Sammle(params Func<int>[] aufgaben)` (`Fehler.cs`): jede
   Funktion mit `Task.Run`, dann `Task.WaitAll` in `try/catch
   (AggregateException)`. Liefere die sortierten Meldungen aller Ausnahmen
   (mit `Flatten()`), bei Erfolg eine leere Liste.
2. `Fehler.ErsteMeldung(Task t)`: die Meldung der ersten Ausnahme einer
   fehlgeschlagenen Aufgabe, sonst `null`.
3. `Zaehler.ZaehleHoch` (`Zaehler.cs`): zählt ohne Ende, setzt bei 1000
   das Signal und prüft bei jedem Durchlauf mit `ThrowIfCancellationRequested`.
4. `Suche.ErstenTreffer` (`Suche.cs`): sucht das erste passende Element und
   prüft vor jedem Element, ob abgebrochen wurde. Ist das Token schon beim Aufruf
   abgebrochen, darf das Prädikat nicht ein einziges Mal laufen.

Diese Tests müssen bestehen:

- `FehlerAbbruchTests.Sammle_liefert_die_Meldungen_aller_Fehler_sortiert`
- `FehlerAbbruchTests.Sammle_ohne_Fehler_oder_ohne_Aufgaben_ist_leer`
- `FehlerAbbruchTests.Sammle_loest_verschachtelte_AggregateExceptions_auf`
- `FehlerAbbruchTests.Sammle_wartet_auf_alle_Aufgaben_auch_wenn_eine_frueh_scheitert`
- `FehlerAbbruchTests.ErsteMeldung_liefert_die_Meldung_der_Ausnahme`
- `FehlerAbbruchTests.ErsteMeldung_ist_null_wenn_nichts_fehlgeschlagen_ist`
- `FehlerAbbruchTests.ZaehleHoch_meldet_1000_und_endet_beim_Abbruch_als_abgebrochen`
- `FehlerAbbruchTests.ZaehleHoch_zaehlt_nichts_wenn_das_Token_schon_abgebrochen_ist`
- `FehlerAbbruchTests.ErstenTreffer_findet_das_erste_passende_Element_oder_null`
- `FehlerAbbruchTests.ErstenTreffer_ruft_das_Praedikat_bei_abgebrochenem_Token_nie_auf`
- `FehlerAbbruchTests.ErstenTreffer_bemerkt_einen_Abbruch_mitten_in_der_Suche`
