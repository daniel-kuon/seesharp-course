# Extra: Account with Exceptions

Reread Section **13.5, “Exception Classes in the BCL”** (page 911), and **Section 13.7**, **“Defining Exceptions”** (page 916). You are familiar with accounts from Level 4.

The `Konto` class in `Konto.cs` doesn't perform any checks yet: You can deposit negative amounts and withdraw more than is available. Report each error with the appropriate exception:

1. `Einzahlen(betrag)` and `Abheben(betrag)` throw an `ArgumentOutOfRangeException` (parameter name `"betrag"`) when `betrag <= 0`.
2. If the balance is insufficient when `Abheben`, the method throws its **own** exception, `GuthabenZuNiedrigException`, with the shortfall (`betrag - Kontostand`). It is defined in `GuthabenZuNiedrigException.cs` and should inherit from `InvalidOperationException`: The argument is not incorrect; the account simply does not have enough at the moment. You pass the message to the base constructor.
3. `Ueberweisen(ziel, betrag)` throws an `ArgumentNullException` (parameter name `"ziel"`) if `ziel == null`. If the withdrawal fails, **no** account should be affected.
4. The constructor rejects a negative starting balance with an `ArgumentOutOfRangeException` (parameter name `"startguthaben"`).

The tests verify the exception type and properties, and ensure that a failed call does not change the account balances: `Abheben_ueber_das_Guthaben_wirft_GuthabenZuNiedrigException_mit_Fehlbetrag`, `GuthabenZuNiedrigException_ist_eine_InvalidOperationException_mit_Fehlbetrag`, `Ueberweisen_an_null_wirft_ArgumentNullException_und_aendert_nichts`, and `Ueberweisen_ohne_Deckung_laesst_beide_Konten_unveraendert`.
