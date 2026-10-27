# Extra: Statistics for all number types using INumber<T>

Extra exercise: optional; it unlocks nothing. For further reading: **9.1.3 Generic Math** (page 625) and **9.1.3.2 Example of Using Numeric Interfaces** (page 626).

In Exercise 6, you only specified the plus operator using `IAdditionOperators<T, T, T>`. `INumber<T>` encompasses everything a number can do: the operators `+ - * /`, comparisons with `<` and `>`, and **static** members such as `T.Zero`, `T.One`, and `T.CreateChecked(...)`. Static members are accessed via the type parameter (`T.Zero`); this is only possible because the interface requires them as `static abstract` (or `static virtual`), and `int`, `double`, `decimal`, etc., implement them. Open `Statistik.cs`:

1. For each method, add the constraint `where T : INumber<T>` (`using System.Numerics;` is already there). A test checks this.
2. The `Summe` starts at `T.Zero`, the `Produkt` at `T.One`; for an empty series, these are also the results.
3. `SummeGeprueft` adds in a `checked` expression: `summe = checked(summe + w);`. Then the compiler selects the `operator checked +` of `T`, and an overflow throws an `OverflowException` instead of silently rolling over as it does with `Summe`.
4. The `Mittelwert` divides the sum by the count. The count is an `int`; `T.CreateChecked(werte.Length)` converts it to a `T`. For integer types, the division is performed as an integer division.
5. `Minimum` and `Maximum` compare using `<` and `>`, respectively; `Spannweite` is `Maximum - Minimum`.
6. The `Mittelwert`, `Minimum`, `Maximum`, and `Spannweite` methods throw an `ArgumentException` for an empty series.

The following tests must pass:

- `StatistikTests.Alle_Methoden_sind_auf_INumber_eingeschraenkt`
- `StatistikTests.Summe_fuer_verschiedene_Zahltypen`
- `StatistikTests.SummeGeprueft_erkennt_Ueberlauf`
- `StatistikTests.Produkt_beginnt_bei_Eins`
- `StatistikTests.Mittelwert_teilt_im_Zahltyp`
- `StatistikTests.Minimum_Maximum_und_Spannweite`
- `StatistikTests.Leere_Serie_wirft_wo_es_kein_Ergebnis_gibt`
