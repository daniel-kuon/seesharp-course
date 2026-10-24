# SelectMany, subqueries, OfType, and custom operators

Read sections **18.2.8.2 SelectMany()** (page 1220), **18.2.6.2 OfType()** (page 1217), and **18.4 Subqueries** (page 1244) in the book; the samples `LINQ-to-Objects/{OfType, Unterabfrage}` and `Abfragesyntax/SelectMany per Abfragesyntax` each demonstrate a solution. The exercise is **18.6 Exercise 1** (page 1255); its five statements are the quiz questions.

Open `Auswertung.cs` (the `Mitarbeiter(Name, Gehalt)` record is predefined):

1. `Woerter(saetze)`: all words of all sentences, in lowercase, without repetitions, in order of first occurrence (`SelectMany`, `Split` with the given `Trenner` separators, `Distinct`).
2. `Kombinationen(a, b)`: the Cartesian product as text, e.g., `"1x"`, with **two `from` clauses** (query syntax).
3. `UeberDemSchnitt(mitarbeiter)`: everyone who earns more than the average of all employees. The query `where m.Gehalt > liste.Average(...)` would recalculate the average for each element. Calculate it **once**: The source may be included at most twice (the tests count).
4. `Spitzenverdiener(mitarbeiter)`: Names of all employees with the highest salaries, using a **subquery** in the query syntax: `where m.Gehalt == (from x in liste select x.Gehalt).Max()`
5. `NurTexte(objekte)` and `NurGanzzahlen(objekte)`: using `OfType<T>()`.
6. `MeineOperatoren` (Extension methods with `yield return`):
   - `TakeEvery(n)`: the first element, then every `n`-th element (positions 0, n, 2n, ...); for `n <= 0`, an `ArgumentOutOfRangeException` during enumeration. Must work with an **infinite** source and `Take(5)`.
   - `WhereNot(bedingung)`: the elements that **do not** satisfy the condition.
   - `Paarweise()` returns consecutive pairs `(a, b)`; `[1,2,3]` returns `(1,2), (2,3)`; if there are fewer than two elements, nothing is returned.

Tests: `Woerter_flacht_Saetze_ab_und_entfernt_Wiederholungen`, `Kombinationen_ist_das_kartesische_Produkt`, `UeberDemSchnitt_liefert_die_Besserverdiener`, `UeberDemSchnitt_zaehlt_die_Quelle_hoechstens_zweimal`, `Spitzenverdiener_nutzt_eine_Unterabfrage`, `OfType_filtert_nach_Laufzeittyp`, `TakeEvery_nimmt_das_erste_und_jedes_nte_Element`, `TakeEvery_funktioniert_auf_unendlichen_Quellen`, `TakeEvery_ist_zurueckgestellt`, `TakeEvery_mit_ungueltigem_n_wirft`, `WhereNot_dreht_die_Bedingung_um`, `Paarweise_liefert_aufeinanderfolgende_Paare`.
