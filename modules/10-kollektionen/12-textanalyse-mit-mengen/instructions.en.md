# Extra: Text Analysis Using Sets

Read **11.5.2 Hash Tables and the HashSet<T> Class** (page 704) again.

Open `Textvergleich.cs`. Two texts are compared by comparing their sets of words.

1. `Woerter(text)` returns the **distinct** words as a `HashSet<string>`, in lowercase. Separators are spaces and `, . ; : ! ? -`.
2. `Gemeinsam(a, b)` returns the words that occur in both sets, sorted alphabetically as a `List<string>` (`Sort()`).
3. `NurInA(a, b)` returns the words that occur only in `a`, also sorted.
4. `Aehnlichkeit(a, b)` computes the Jaccard similarity: the number of common words divided by the number of all words (union), as a `double`. Two empty sets give 0.

The arguments `a` and `b` must not be changed. The tests use two short German sentences: `Woerter_liefert_verschiedene_Woerter_in_Kleinbuchstaben`, `Gemeinsam_liefert_die_gemeinsamen_Woerter_alphabetisch`, `NurInA_liefert_die_Woerter_die_in_b_fehlen`, `Aehnlichkeit_ist_Schnittmenge_durch_Vereinigung` and `Die_Eingabemengen_bleiben_unveraendert`.
