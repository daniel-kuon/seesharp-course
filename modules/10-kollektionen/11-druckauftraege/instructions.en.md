# Deep Dive: Print Jobs and Undo Stacks

> **Deep Dive (optional):** The book only mentions `Stack<T>` (stack, LIFO) and `Queue<T>` (queue, FIFO) in the introduction to **11.4 Managing a List** (page 697); their methods are not in the book. This exercise is a pointer to what to look into next. You need: `Stack<T>` with `Push()`, `Pop()` (removes the top element), `Count` and `Clear()`; `Queue<T>` with `Enqueue()`, `Dequeue()` (removes the oldest element) and `Count`. `Pop()` and `Dequeue()` throw an exception on an empty collection. You may already have done the Deep Dive part of exercise 3.

Open `Druckauftraege.cs`. It contains two classes.

1. `Texteditor` has `Tippe(string)`, `Rueckgaengig()` and `Wiederholen()`, implemented with two stacks that hold earlier text states. `Tippe` appends text, remembers the old state and clears the redo stack. `Rueckgaengig` and `Wiederholen` return `false` if there is nothing to do.
2. `Druckwarteschlange` prints jobs strictly in order of arrival, page by page. `Auftrag("Bericht", 3)` enqueues the pages `"Bericht 1/3"`, `"Bericht 2/3"` and `"Bericht 3/3"`; `NaechsteSeite()` returns the next one (or `null`); `Wartend` counts the pages still waiting. With fewer than one page, nothing is enqueued.

Tests (they call the methods one after another and check the results): `Rueckgaengig_nimmt_die_letzte_Aenderung_zurueck`, `Wiederholen_stellt_zurueckgenommene_Aenderungen_wieder_her`, `Neues_Tippen_loescht_den_Wiederholen_Stapel` and `Auftraege_werden_in_Ankunftsreihenfolge_Seite_fuer_Seite_gedruckt`.
