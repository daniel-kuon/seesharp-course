# throw Expressions and Validation in SimpleStack

Read **13.6 Throwing Exceptions (throw)** (page 913) in the book, with the `throw` expression, and then the exercise **13.8 No. 4** (page 920). You know the generic `SimpleStack<T>` from Level 8 (book 8.2.1).

The stack in `SimpleStack.cs` has a fixed capacity but reacts to errors in an unpredictable way: A full `Push` throws an `IndexOutOfRangeException`, and an empty `Pop` corrupts `Count`. Explain each error using an exception that fits the situation:

1. **Constructor:** A capacity of `<= 0` triggers an `ArgumentOutOfRangeException` with the parameter name `"kapazitaet"` (instead of silently using a default value).
2. **`Push`** on a full stack and **`Pop`** on an empty one: an `InvalidOperationException` with a message in German. The object is then in the wrong state for this operation (not an invalid argument). The stack must not be corrupted after the error.
3. **`Peek()`** should be a body of an expression: `=> anzahl > 0 ? items[anzahl - 1] : throw new InvalidOperationException(…);`
4. **`Name`:** The setter throws a `ArgumentNullException` (parameter name `"value"`) when the value is `null`, written as a throw expression `value ?? throw new …`. The name then remains unchanged.
5. **`Fuelle(IEnumerable<T> quelle)`** adds all elements to the stack one after another. If `null`, `ArgumentNullException.ThrowIfNull(quelle)` throws the exception (parameter name `"quelle"`).

The tests check the exception type, `ParamName` and that the state is correct after the error: `Konstruktor_wirft_bei_nicht_positiver_Kapazitaet`, `Push_auf_vollem_Stapel_wirft_InvalidOperationException`, `Pop_auf_leerem_Stapel_wirft_InvalidOperationException_und_ueberlebt`, `Peek_auf_leerem_Stapel_wirft_InvalidOperationException`, `Name_null_wirft_ArgumentNullException_und_laesst_den_Namen_unveraendert`, and `Fuelle_mit_null_wirft_ArgumentNullException_mit_Parametername`.
