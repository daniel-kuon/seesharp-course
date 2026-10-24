# Queue, Stack, and Linked List

Read **section 11.4.1** (page 697) in the book about `Queue<T>` and `Stack<T>`, and **section 11.4.2, “The LinkedList<T> Class with Doubly Linked Nodes”** (page 700).

Open `Warteschlangen.cs`. There are four classes there. The signatures remain unchanged.

1. The `Druckerwarteschlange` operates according to the FIFO principle using a `Queue<string>`. `Naechster()` and `Peek()` return `null` if nothing is waiting; `Dequeue()` on an empty queue would throw an exception, so check `Count` first. `Peek()` does not remove anything.
2. `KlammernPruefer.IstAusgeglichen` uses a `Stack<char>` to check whether `()`, `[]`, and `{}` are properly nested: `"([]{})"` yes, `"([)]"` and `"(("` no, empty text yes. Other characters are ignored.
3. `Verlauf` is a browser history with two stacks. `Besuche()` displays a new page and clears the "previous" stack; `Zurueck()` and `Vor()` return the page that is displayed next, or `null` if there isn't one.
4. `ZuletztGeoeffnet` stores the most recently opened names in a `LinkedList<string>`. `Oeffne()` moves the name to the front (shifting any existing entry) and, if the list is full, removes the last entry. `Liste()` traverses the list from the first node using `Next`, while `ListeRueckwaerts()` traverses it from the last node using `Previous`.

The tests only check content and order. Important tests: `Warteschlange_liefert_in_Ankunftsreihenfolge`, `Peek_entnimmt_nichts`, `Klammern_werden_richtig_geprueft`, `Verlauf_zurueck_und_vor`, `Neuer_Besuch_loescht_den_Vor_Stapel`, `Zuletzt_geoeffnet_verschiebt_vorhandene_Namen`, and `Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge`.
