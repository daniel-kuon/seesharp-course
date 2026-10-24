# Extra: Arithmetic Expressions as Trees

Extra exercise: optional; it unlocks nothing. For further reading: **7.9 Polymorphism** (page 566) and **7.10 Sealed Methods and Classes** (page 570).

The expression `(2 + 3) * 4` can be stored as a tree: a `Mal` node with a `Plus` node on the left and the `Zahl` 4 on the right. Each node is an `Ausdruck`; when evaluating the tree, you simply call `Auswerten()` on the root, and each node handles its own part (polymorphism plus recursion). Open `Ausdruck.cs`:

1. `Zahl`: `Auswerten()` returns the value, `Knoten` is 1, and `ToString()` returns the value as text (`"4"`).
2. `BinaererAusdruck` is the common base for all operators with two operands. `Auswerten()` evaluates `Links` and `Rechts` and passes both results to `Verknuepfe`; `Knoten` is 1 plus the nodes on both sides; `ToString()` returns `"(links symbol rechts)"`, e.g., `"((2 + 3) * 4)"`. `Auswerten()` and `Knoten` should **no** longer be overridable in the operators: `sealed override`.
3. `Plus`, `Minus`, `Mal`, and `Geteilt` now only return their `Symbol` (`"+"`, `"-"`, `"*"`, `"/"`) and their `Verknuepfe` calculation.
4. `Vereinfache()`: In `Ausdruck`, the method returns the expression itself. `BinaererAusdruck` overrides it: If both sides are `Zahl` instances, the node is replaced by a new `Zahl` holding the result; otherwise it stays as it is. `Mal` can do more: If one side is the number 0, the result is `new Zahl(0)`; if one side is the number 1, the result is the **other** side (the same object). In all other cases, `Mal` calls the base version with `base.Vereinfache()`.

The following tests must be passed:

- `AusdrueckeTests.Zahl_wertet_zu_sich_selbst_aus`
- `AusdrueckeTests.Baum_wird_rekursiv_ausgewertet`
- `AusdrueckeTests.ToString_setzt_Klammern`
- `AusdrueckeTests.Knoten_zaehlt_alle_Knoten`
- `AusdrueckeTests.Auswerten_und_Knoten_sind_in_BinaererAusdruck_versiegelt`
- `AusdrueckeTests.Vereinfache_faltet_Konstanten`
- `AusdrueckeTests.Mal_vereinfacht_mit_0_und_1`
