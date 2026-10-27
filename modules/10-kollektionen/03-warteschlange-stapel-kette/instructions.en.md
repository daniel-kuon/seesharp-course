# Queue, Stack, and Linked List

Read the introduction to **11.4 Managing a List** (page 697) in the book, where `Queue<T>` (queue, FIFO) and `Stack<T>` (stack, LIFO) are briefly mentioned, and **11.4.2 The LinkedList<T> Class with Doubly Linked Nodes** (page 700).

Open `Warteschlangen.cs`. It contains four classes. The signatures stay unchanged. The linked list is mandatory:

1. `ZuletztGeoeffnet` keeps the most recently opened names in a `LinkedList<string>`. `Oeffne()` puts the name at the front (an existing one is moved) and, when the list is full, drops the last entry. `Liste()` walks from the first node via `Next`, `ListeRueckwaerts()` from the last node via `Previous`.

The exercise is passed when these tests are green: `Zuletzt_geoeffnet_stellt_den_neuesten_Namen_nach_vorn`, `Zuletzt_geoeffnet_verschiebt_vorhandene_Namen`, `Zuletzt_geoeffnet_wirft_den_aeltesten_Namen_bei_voller_Liste_raus`, `Zuletzt_geoeffnet_erneutes_Oeffnen_bei_voller_Liste_wirft_nichts_raus` and `Zuletzt_geoeffnet_rueckwaerts_ist_die_umgekehrte_Reihenfolge`.

> **Deep Dive (optional):** The book only mentions `Queue<T>` and `Stack<T>` (you built a simple stack yourself in 8.2.1). The three other classes are an example of what to look into next. You need: `Queue<T>` with `Enqueue()`, `Dequeue()` (removes the oldest element), `Peek()` (only shows it) and `Count`; `Stack<T>` with `Push()`, `Pop()` (removes the top element), `Peek()`, `Count` and `Clear()`. `Dequeue()`, `Pop()` and `Peek()` throw an exception on an empty collection.
>
> - `Druckerwarteschlange` works on the FIFO principle with a `Queue<string>`. `Naechster()` and `Peek()` return `null` if nothing is waiting; `Dequeue()` on an empty queue would throw an exception, so check `Count` first. `Peek()` removes nothing.
> - `KlammernPruefer.IstAusgeglichen` uses a `Stack<char>` to check whether `()`, `[]` and `{}` are properly nested: `"([]{})"` yes, `"([)]"` and `"(("` no, the empty text yes. Other characters are ignored.
> - `Verlauf` is a browser history with two stacks. `Besuche()` shows a new page and clears the forward stack; `Zurueck()` and `Vor()` return the page that is shown afterwards, or `null` if there is none.
>
> Extra tests (they do not count for passing): `Warteschlange_liefert_in_Ankunftsreihenfolge`, `Warteschlange_leer_liefert_null_statt_Ausnahme`, `Peek_entnimmt_nichts`, `Warteschlange_kann_nach_dem_Leeren_weiterverwendet_werden`, `Klammern_werden_richtig_geprueft`, `Verlauf_vor_dem_ersten_Besuch_ist_leer`, `Verlauf_zurueck_und_vor` and `Neuer_Besuch_loescht_den_Vor_Stapel`.
