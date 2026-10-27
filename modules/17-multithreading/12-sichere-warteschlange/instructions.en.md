# Extra: A Thread-Safe Queue

Extra exercise: optional; it unlocks nothing. For further reading: **17.2.1.1 Producer-Consumer Example** (page 1065), **17.2.4.1 Exclusive Access,** and **17.2.4.1.1 The lock Statement** (page 1073).

The collections in the class library (`List<T>`, `Queue<T>`, `Dictionary<K,V>`) are **not** designed for concurrent access. Two threads calling `Enqueue` simultaneously may lose elements, corrupt the data structure, or throw an exception. The solution is to use a `lock` around every access to the shared collection.

`SichereWarteschlange<T>` wraps a `Queue<T>` (the book only names it; given here: `Enqueue(x)` appends at the end, `Dequeue()` removes the front element, `Count` counts):

- `Einreihen(element)` appends at the back,
- `TryNaechster(out element)` retrieves the first element or returns `false` (with `default` as the value) if there is nothing there,
- `Anzahl` returns the number of elements in the queue.

All three members use the same private lock object. In `TryNaechster`, the check `Count > 0` and the `Dequeue` belong **together** under a single `lock`: Otherwise, another thread could remove the last element between these two steps.

The large-scale test starts four producers (2,500 elements each) and four consumers simultaneously. It uses `Join()` and verifies that each element has been consumed **exactly once**. It never sleeps and does not measure time; the consumers stop as soon as all producers are finished and the queue is empty.

The following tests must be passed:

- `SichereWarteschlangeTests.Elemente_kommen_in_der_Reihenfolge_des_Einreihens_heraus`
- `SichereWarteschlangeTests.Eine_leere_Warteschlange_liefert_false_und_den_Standardwert`
- `SichereWarteschlangeTests.Vier_Erzeuger_und_vier_Verbraucher_jedes_Element_genau_einmal`
