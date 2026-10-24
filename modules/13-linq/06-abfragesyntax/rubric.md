# Rubrik — Abfragesyntax (nur für die Betreuung)

- Kernidee: Abfragesyntax und Methodensyntax sind austauschbar; der Compiler
  übersetzt `from`/`where`/`select` in `Where`/`Select` usw. Die Abfragesyntax
  gewinnt bei vielen Bereichsvariablen (`let`, mehrere `from`, `join`), die
  Methodensyntax bei einzelnen Operatoren und bei `Take`, `Count` usw.
- `let` führt eine Zwischenvariable ein, die nur einmal je Element berechnet
  wird; `into` beginnt eine Folgeabfrage, nach der die alten Bereichsvariablen
  nicht mehr sichtbar sind (nach `group ... into g` gibt es kein `p` mehr).
- `join ... on a equals b`: `equals` ist Pflicht, `==` geht nicht; die linke
  Seite gehört zur äußeren, die rechte zur inneren Sequenz.
- `join ... into bs` ist der `GroupJoin`; ohne `into` der innere `Join`.
- Die Tests vergleichen die Q-Variante mit der Methodenvariante und mit festen
  Werten. Typische Fehler: Reihenfolge der `orderby`-Schlüssel, `descending`
  hinter dem falschen Schlüssel, `let`-Wert doppelt berechnet.

Modellantwort: `solution/` bzw. `samples/LINQ-to-Objects/Abfragesyntax/*`.
