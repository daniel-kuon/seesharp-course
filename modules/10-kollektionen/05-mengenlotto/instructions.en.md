# Lotto with SortedSet<T>

Read Section **11.5.3, “Balanced Binary Trees and the SortedSet<T> Class”** (page 711), and then Exercise **11.8, No. 2** (page 723): You’re familiar with the lottery draw from Level 6 using arrays; with the right collection, the code becomes very short.

Open `Lotto.cs` and implement four methods:

1. `Ziehe(Random rnd)` returns a `SortedSet<int>` containing six different numbers from 1 to 49. Call `rnd.Next(1, 50)` repeatedly and add the number until the set contains six elements. The order of the calls is fixed: The test with `new Random(42)` knows the exact result.
2. `Treffer(tipp, ziehung)` counts the numbers they have in common. Neither set may be modified: Copy one of them and apply `IntersectWith` to it.
3. `NaechsteZahl(s, x)` returns the smallest number in `s` that is greater than `x`, or `-1`. Use `GetViewBetween` (not in the book: `s.GetViewBetween(lower, upper)` returns a view of all elements from `lower` to `upper`, both inclusive).
4. `Spanne(s)` returns `Max - Min` (0 if the set is empty).

Tests: `Ziehe_mit_festem_Startwert_liefert_das_Ergebnis_der_Musterloesung`, `Ziehe_liefert_sechs_verschiedene_Zahlen_von_1_bis_49_aufsteigend`, `Doppelte_Zahl_aendert_die_Menge_nicht`, `Treffer_zaehlt_gemeinsame_Zahlen`, `Treffer_veraendert_keine_der_Mengen`, `NaechsteZahl_liefert_die_kleinste_groessere_Zahl`, and `Spanne_ist_Maximum_minus_Minimum`.
