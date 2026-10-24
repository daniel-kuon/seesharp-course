# Extra: Print Jobs and Undo Stacks

Reread sections **11.4.1** (page 697) and **11.4.2** (page 700) on `Stack<T>` and `Queue<T>`.

Open `Druckauftraege.cs`. There are two classes there.

1. The `Texteditor` has `Tippe(string)`, `Rueckgaengig()`, and `Wiederholen()` functions, implemented using two stacks that contain previous text states. `Tippe` appends text, saves the previous state, and clears the repeat stack. `Rueckgaengig` and `Wiederholen` return `false` if there is nothing to do.
2. The `Druckwarteschlange` prints jobs strictly in the order they arrive, page by page. `Auftrag("Bericht", 3)` inserts the pages `"Bericht 1/3"`, `"Bericht 2/3"`, and `"Bericht 3/3"`; `NaechsteSeite()` returns the next page (or `null`); and `Wartend` counts the open pages.

Tests (they call the methods one after another and check the results): `Rueckgaengig_nimmt_die_letzte_Aenderung_zurueck`, `Wiederholen_stellt_zurueckgenommene_Aenderungen_wieder_her`, `Neues_Tippen_loescht_den_Wiederholen_Stapel`, and `Auftraege_werden_in_Ankunftsreihenfolge_Seite_fuer_Seite_gedruckt`.
