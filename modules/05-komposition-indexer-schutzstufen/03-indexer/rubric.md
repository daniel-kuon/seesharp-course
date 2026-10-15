# Rubrik — Indexer (nur für die Betreuung)

- Ein Indexer ist eine Eigenschaft mit Parametern: `this[...]`, `get`, `set`,
  `value`. Wer `Get(int)`/`Set(int, Person)` schreibt, hat die Syntax
  umgangen; das Testprojekt kompiliert dann nicht.
- Die Fehlerbehandlung (werfen beim Lesen, schweigen beim Schreiben) ist aus
  dem Buch übernommen; im Gespräch hinterfragen, ob das konsistent ist.
- `FindElement` ist O(n); die Liste ist absichtlich einfach. Wer `Count`
  nicht pflegt, fällt beim ersten Test durch.
- Nachfrage: Warum ist `Element` geschachtelt und privat?

Modellantwort: `solution/` bzw. `samples/Klassen und Objekte/Indexer`.
