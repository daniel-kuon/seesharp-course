# Quantifiers, Element Operators, and Deferred Execution

Read **18.2.4 Deferred or Immediate Execution** in the book (page
1215) through **18.2.6** (page 1217), and from **18.2.11** the sections **18.2.11.2 Extracting Single Elements** (page 1230) and **18.2.11.5 Checking Existence or a Condition** (page 1232).

A query like `quelle.Where(...)` doesn't run until someone enumerates it. That's convenient, but tricky. Open `Ausfuehrung.cs`:

1. `Pruefungen`: `AlleVolljaehrig` (`All`, age >= 18), `HatNegativenWert` (`Any` with condition), and `Enthaelt(texte, text)` with `StringComparer.OrdinalIgnoreCase` (`Contains` with a comparer).
2. `Zugriff`: `ErstesOderStandard` (`FirstOrDefault` with default value), `EindeutigerTreffer` (`Single`; throws an `InvalidOperationException` if there are no matches or multiple matches), `EindeutigerTrefferText` (catches this exception and returns `"Treffer: N"` or `"kein eindeutiger Treffer"`), `Dritte` (`ElementAt`), and `Letzte` (`Last`).
3. `Ausfuehrung`: `Quelle(log)` is an iterator and is provided; it writes `liefere N` to the log. `GeradeZahlen(log)` constructs `Quelle(log).Where(...)` and returns the **unexecuted** query. `GrosseWerte(liste)` also returns a query (values greater than 10), while `GrosseWerteJetzt(liste)` returns a **snapshot** (`ToList`). `ZweimalNutzen(log)` is given, but it counts each element twice: the query is enumerated twice. Fix this using `ToList()`.

Tests: `Abfrage_laeuft_erst_bei_der_Aufzaehlung`, `Jede_Aufzaehlung_fuehrt_die_Abfrage_neu_aus`, `ZweimalNutzen_zaehlt_die_Quelle_nur_einmal`, `Abfrage_sieht_spaetere_Aenderungen_der_Quelle`, `Schnappschuss_sieht_spaetere_Aenderungen_nicht`, `All_Any_Contains`, `ErstesOderStandard_liefert_Erstes_oder_Standard`, `EindeutigerTreffer_wirft_bei_keinem_und_bei_mehreren`, `EindeutigerTrefferText_faengt_die_Ausnahme`, `Dritte_und_Letzte`.
