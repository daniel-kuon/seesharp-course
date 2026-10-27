# Queue, Stack, and Linked List

Read the introduction to **11.4 Managing a List** (page 697) in the book, where `Queue<T>` and `Stack<T>` are briefly mentioned, and **11.4.2 The LinkedList<T> Class with Doubly Linked Nodes** (page 700). The book does not cover `Queue<T>` and `Stack<T>` any further (you built a simple stack yourself in 8.2.1). You need: `Queue<T>` with `Enqueue()`, `Dequeue()` (removes the oldest element), `Peek()` (only shows it) and `Count`; `Stack<T>` with `Push()`, `Pop()` (removes the top element), `Peek()`, `Count` and `Clear()`. `Dequeue()`, `Pop()` and `Peek()` throw an exception on an empty collection.

Open `Warteschlangen.cs`. It contains four classes. The signatures stay unchanged.

1. `Druckerwarteschlange` works on the FIFO principle with a `Queue<string>`. `Naechster()` and `Peek()` return `null` if nothing is waiting; `Dequeue()` on an empty queue would throw an exception, so check `Count` first. `Peek()` removes nothing.
2. `KlammernPruefer.IstAusgeglichen` uses a `Stack<char>` to check whether `()`, `[]` and `{}` are properly nested: `"([]{})"` yes, `"([)]"` and `"(("` no, the empty text yes. Other characters are ignored.
3. `Verlauf` is a browser history with two stacks. `Besuche()` shows a new page and clears the forward stack; `Zurueck()` and `Vor()` return the page that is shown afterwards, or `null` if there is none.
4. `ZuletztGeoeffnet` keeps the most recently opened names in a `LinkedList<string>`. `Oeffne()` puts the name at the front (an existing one is moved) and, when the list is full, drops the last entry. `Liste()` walks from the first node via `Next`, `ListeRueckwaerts()` from the last node via `Previous`.

The tests only check content and order. Important tests: `Warteschlange_liefert_in_Ankunftsreihenfolge`, `Peek_entnimmt_nichts`, `Klammern_werden_richtig_geprueft`, `Verlauf_zurueck_und_vor`, `Neuer_Besuch_loescht_den_Vor_Stapel`, `Zuletzt_geoeffnet_verschiebt_vorhandene_Namen` and `Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge`.
