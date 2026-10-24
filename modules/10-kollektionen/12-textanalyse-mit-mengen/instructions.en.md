# Extra: Text Analysis Using Sets

Reread **11.5.2 "Hash Tables" and the HashSet<T> class** (page 704).

Open `Textvergleich.cs`. Two texts are compared by comparing their sets of words.

1. `Woerter(text)` returns the **various** words as a `HashSet<string>`, all in lowercase. Delimiters are spaces and `, . ; : ! ? -`.
2. `Gemeinsam(a, b)` returns the words that appear in both sets, sorted alphabetically as a `List<string>` (`Sort()`).
3. `NurInA(a, b)` returns the words that appear only in `a`, also sorted.
4. `Aehnlichkeit(a, b)` calculates the Jaccard similarity: the number of common words divided by the total number of words (union), returned as a `double`. Two empty sets result in 0.

Arguments `a` and `b` must not be modified. The tests use two short German sentences: `Woerter_liefert_verschiedene_Woerter_in_Kleinbuchstaben`, `Gemeinsam_liefert_die_gemeinsamen_Woerter_alphabetisch`, `NurInA_liefert_die_Woerter_die_in_b_fehlen`, `Aehnlichkeit_ist_Schnittmenge_durch_Vereinigung`, and `Die_Eingabemengen_bleiben_unveraendert`.
