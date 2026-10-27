# Quantoren, Elementoperatoren und verzögerte Ausführung

Lies im Buch **18.2.4 Zurückgestellte oder sofortige Ausführung** (Seite
1215) bis **18.2.6** (Seite 1217) sowie aus **18.2.11** die Abschnitte
**18.2.11.2 Extraktion einzelner Elemente** (Seite 1230) und **18.2.11.5
Existenz oder Bedingung prüfen** (Seite 1232).

Eine Abfrage wie `quelle.Where(...)` läuft erst, wenn jemand sie aufzählt.
Das ist praktisch, aber tückisch. Öffne `Ausfuehrung.cs`:

1. `Pruefungen`: `AlleVolljaehrig` (`All`, Alter >= 18), `HatNegativenWert`
   (`Any` mit Bedingung) und `Enthaelt(texte, text)` mit
   `StringComparer.OrdinalIgnoreCase` (`Contains` mit Vergleicher).
2. `Zugriff`: `ErstesOderStandard` (`werte.FirstOrDefault(standard)`; die
   Überladung mit eigenem Standardwert ist nicht im Buch, hier vorgegeben),
   `EindeutigerTreffer` (`Single`; wirft bei keinem und bei mehreren
   Treffern `InvalidOperationException`), `EindeutigerTrefferText` (fängt
   diese Ausnahme und liefert `"Treffer: N"` bzw. `"kein eindeutiger
   Treffer"`), `Dritte` (`ElementAt`) und `Letzte` (`Last`).
3. `Ausfuehrung`: `Quelle(log)` ist ein Iterator und vorgegeben; er schreibt
   `liefere N` ins Protokoll. `GeradeZahlen(log)` baut `Quelle(log).Where(...)`
   und gibt die **nicht ausgeführte** Abfrage zurück. `GrosseWerte(liste)`
   gibt ebenfalls eine Abfrage zurück (Werte über 10), `GrosseWerteJetzt(liste)`
   einen **Schnappschuss** (`ToList`). `ZweimalNutzen(log)` ist vorgegeben,
   zählt aber jedes Element doppelt: Die Abfrage wird zweimal aufgezählt.
   Behebe das mit `ToList()`.

Tests: `Abfrage_laeuft_erst_bei_der_Aufzaehlung`,
`Jede_Aufzaehlung_fuehrt_die_Abfrage_neu_aus`,
`ZweimalNutzen_zaehlt_die_Quelle_nur_einmal`,
`Abfrage_sieht_spaetere_Aenderungen_der_Quelle`,
`Schnappschuss_sieht_spaetere_Aenderungen_nicht`, `All_Any_Contains`,
`ErstesOderStandard_liefert_Erstes_oder_Standard`,
`EindeutigerTreffer_wirft_bei_keinem_und_bei_mehreren`,
`EindeutigerTrefferText_faengt_die_Ausnahme`, `Dritte_und_Letzte`.
