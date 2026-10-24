# Rubrik: Initialisierer und Kollektionsausdrücke (nur für die Betreuung)

- **Kernidee:** Ein Kollektionsausdruck `[...]` hat keinen eigenen Typ; der
  Zieltyp kommt aus Zuweisung, Parameter oder Rückgabetyp. Darum scheitert
  `var x = [];` und `var x = [1, 2];` (CS9176). Der Initialisierer
  `new List<string> { ... }` ruft dagegen für jedes Element `Add()`; er
  braucht eine Klasse mit `Add()` und `IEnumerable`.
- `NeuesLager`: `Artikel = { ... }` weist **keine** neue Liste zu, es ruft
  `Add()` auf der vorhandenen Liste auf. Ohne Standardwert in `Lager`
  (`= new()`) gäbe es eine `NullReferenceException`. Gut zum Nachfragen.
- `FuelleAuf` und `Zaehle`: Wer `List<int>` als Parametertyp wählt, besteht
  den HashSet-Test nicht; das Interface macht den Code allgemein
  (`collections.icollection-members`).
- `Gesamt`: Warum geht `folge.Count` hier nicht? (`IEnumerable<T>` kennt nur
  die Aufzählung; `Count()` aus LINQ folgt in Level 13.) Die
  Testhilfsfunktion mit `yield return` zeigt eine Folge ohne `Count`.
- Modellantwort: `solution/`. Kein Beispielprojekt aus `samples/`.
