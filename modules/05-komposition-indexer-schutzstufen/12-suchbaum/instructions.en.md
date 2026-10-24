# Extra exercise: A binary search tree with a nested node

This exercise is optional and is the most challenging one in this level. It combines nested classes (**5.11**, page 391) with recursion (**5.9.2**, page 382).

A **binary search tree** stores numbers in nodes. Each node has at most two children: the left subtree contains only smaller values, and the right subtree contains only larger ones. When searching for a value, you compare it at each node and branch off to the left or right, rather than traversing the entire tree.

```
        8
      /   \
     3     10
    / \      \
   1   6      14
      / \    /
     4   7  13
```

The `Knoten` is a private nested class; from the outside, you can only see `int` values. Open `Suchbaum.cs` and complete the following:

1. `Einfuegen(wert)`: If the tree is empty, the value becomes the root. Otherwise, traverse the tree downward from the root (left for smaller values, right for larger values) until the appropriate slot is `null`, and insert a new node there. If the value is already in the tree, the method returns `false`.
2. `Enthaelt(wert)`: descend in exactly the same way; reaching `null` means "not there."
3. `Anzahl` using a **recursive** private helper method `static int Zaehle(Knoten? k)`: an empty subtree has 0 nodes; otherwise, 1 plus the nodes on the left plus the nodes on the right.
4. `Hoehe` is also recursive: 0 if empty, otherwise 1 plus the greater of the two subtree heights (`Math.Max`).
5. `ToString()` returns all values in ascending order, separated by a space: recursively, first the left subtree, then the node, then the right subtree (in-order). Be sure to include spaces for empty subtrees.

The following tests must be passed:

- `SuchbaumTests.Leerer_Baum`
- `SuchbaumTests.Einfuegen_lehnt_Duplikate_ab`
- `SuchbaumTests.Enthaelt_findet_eingefuegte_Werte`
- `SuchbaumTests.Anzahl_zaehlt_alle_Knoten`
- `SuchbaumTests.Hoehe_des_Beispielbaums`
- `SuchbaumTests.Sortiert_eingefuegt_entsteht_eine_Kette`
- `SuchbaumTests.ToString_liefert_die_Werte_aufsteigend`
- `SuchbaumTests.Negative_Werte_funktionieren`
