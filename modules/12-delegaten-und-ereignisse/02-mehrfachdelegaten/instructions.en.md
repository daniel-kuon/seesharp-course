# Multiple delegates

Read section **10.1.3, “Combining Delegate Objects,”** in the book (pages 663–664).

A delegate object can call multiple methods (call list). `+=` adds a method to the list, `-=` removes it; if the list is empty, the variable is `null`. Open `Verteiler.cs`:

1. `Verteiler`: `Anmelden` and `Abmelden` modify the invocation list of `ziele` using `+=` and `-=`. `Sende(text)` calls all targets in the order they were registered and must not crash if no targets are specified (`?.Invoke`). `AnzahlZiele()` counts the entries in the invocation list (`GetInvocationList()`); returns 0 if no targets are present.
2. `Ketten.Kette(params Schritt[] schritte)` combines the steps into a delegate (`null` if no steps are provided). Note: The call returns only the result of the **last** step, but all steps are executed, and each receives the same argument.

Tests: `Kette_liefert_das_Ergebnis_des_letzten_Schritts`, `Kette_fuehrt_alle_Schritte_aus`, `Kette_ohne_Schritte_ist_null`, `Kette_mit_einem_Schritt_ist_dieser_Schritt`, `Ohne_Ziele_passiert_nichts`, `Sende_ruft_in_Anmeldereihenfolge_auf`, `Zweimal_angemeldet_wird_zweimal_aufgerufen`, `Abmelden_entfernt_nur_einen_Eintrag`, `Abmelden_ohne_Anmeldung_aendert_nichts`, `Letztes_Ziel_abmelden_leert_die_Liste`.
