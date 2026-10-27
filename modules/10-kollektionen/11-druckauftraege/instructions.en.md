# Extra: Print Jobs and Undo Stacks

Read the introduction to **11.4 Managing a List** (page 697) again, where `Stack<T>` and `Queue<T>` are briefly mentioned; you know their methods from exercise 3.

Open `Druckauftraege.cs`. It contains two classes.

1. `Texteditor` has `Tippe(string)`, `Rueckgaengig()` and `Wiederholen()`, implemented with two stacks that hold earlier text states. `Tippe` appends text, remembers the old state and clears the redo stack. `Rueckgaengig` and `Wiederholen` return `false` if there is nothing to do.
2. `Druckwarteschlange` prints jobs strictly in order of arrival, page by page. `Auftrag("Bericht", 3)` enqueues the pages `"Bericht 1/3"`, `"Bericht 2/3"` and `"Bericht 3/3"`; `NaechsteSeite()` returns the next one (or `null`); `Wartend` counts the pages still waiting. With fewer than one page, nothing is enqueued.

Tests (they call the methods one after another and check the results): `Rueckgaengig_nimmt_die_letzte_Aenderung_zurueck`, `Wiederholen_stellt_zurueckgenommene_Aenderungen_wieder_her`, `Neues_Tippen_loescht_den_Wiederholen_Stapel` and `Auftraege_werden_in_Ankunftsreihenfolge_Seite_fuer_Seite_gedruckt`.
