# Extra exercise: A checking account with an overdraft line

This exercise is optional. It reviews properties with validation, constructors, and static members using a new example. For further reading: **5.5 Properties** (page 361), **5.4.3 Preparing for Use** (page 340), and **5.8 Static Members and Classes** (page 373).

Amounts of money are `decimal` (literals with `m`, such as `9.95m`), so that no rounding errors occur in calculations, as they do with `double` (Level 2).

Open `Konto.cs` and complete the `Konto` class:

1. The setter for `Inhaber` ignores empty names and names consisting solely of spaces (`string.IsNullOrWhiteSpace`). The setter for `Dispo` ignores negative values. Use `field` in each case.
2. Both constructors assign the next available account number from the static field `naechsteNummer` (then increment it by 1), increment `Anzahl`, and set the account holder **using the property**. A negative starting balance is set to 0.
3. The `Einzahlen(betrag)` function accepts only positive amounts and returns `true`; otherwise, it returns `false` without making any changes.
4. `Abheben(betrag)` only accepts positive amounts, and the account balance must not fall below the `-Dispo`. So, with a balance of 100 € and a 50 € Dispo, you can withdraw 150 €, but not a single cent more.
5. `Ueberweise(ziel, betrag)` withdraws funds here and deposits them into `ziel`, but only if the withdrawal is successful. A transfer to one's own account returns `false`.

The following tests must be passed:

- `KontoTests.Konstruktor_setzt_Inhaber_und_Startguthaben`
- `KontoTests.Negatives_Startguthaben_wird_zu_null`
- `KontoTests.Leerer_Inhaber_wird_ignoriert`
- `KontoTests.Negativer_Dispo_wird_ignoriert`
- `KontoTests.Nummern_sind_fortlaufend_und_Anzahl_zaehlt_beide_Konstruktoren`
- `KontoTests.Einzahlen_nur_positive_Betraege`
- `KontoTests.Abheben_bis_zum_Dispo`
- `KontoTests.Abheben_ohne_Dispo_und_mit_ungueltigem_Betrag`
- `KontoTests.Ueberweise_bucht_auf_beiden_Konten`
- `KontoTests.Ueberweise_scheitert_ohne_Deckung_und_an_sich_selbst`
