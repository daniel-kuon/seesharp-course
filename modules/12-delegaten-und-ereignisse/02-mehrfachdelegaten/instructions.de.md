# Mehrfachdelegaten

Lies im Buch **10.1.3 Delegatenobjekte kombinieren** (Seite 663 bis 664).

Ein Delegatenobjekt kann mehrere Methoden aufrufen (Aufrufliste). `+=` hängt
eine Methode an, `-=` entfernt sie; ist die Liste leer, ist die Variable
`null`. Öffne `Verteiler.cs`:

1. `Verteiler`: `Anmelden` und `Abmelden` ändern die Aufrufliste von `ziele`
   mit `+=` und `-=`. `Sende(text)` ruft alle Ziele in Anmeldereihenfolge auf
   und darf ohne Ziele nicht abstürzen (`?.Invoke`). `AnzahlZiele()` zählt
   die Einträge der Aufrufliste (`GetInvocationList()`), ohne Ziele 0.
2. `Ketten.Kette(params Schritt[] schritte)` fasst die Schritte zu einem
   Delegaten zusammen (ohne Schritte: `null`). Beobachte: Der Aufruf liefert
   nur das Ergebnis des **letzten** Schritts, alle Schritte laufen aber, und
   jeder bekommt dasselbe Argument.

Tests: `Kette_liefert_das_Ergebnis_des_letzten_Schritts`,
`Kette_fuehrt_alle_Schritte_aus`, `Kette_ohne_Schritte_ist_null`,
`Kette_mit_einem_Schritt_ist_dieser_Schritt`, `Ohne_Ziele_passiert_nichts`,
`Sende_ruft_in_Anmeldereihenfolge_auf`,
`Zweimal_angemeldet_wird_zweimal_aufgerufen`,
`Abmelden_entfernt_nur_einen_Eintrag`,
`Abmelden_ohne_Anmeldung_aendert_nichts`,
`Letztes_Ziel_abmelden_leert_die_Liste`.
