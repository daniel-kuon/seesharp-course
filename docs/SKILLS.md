# Skill vocabulary — levels 0–6

Draft from task 3a. `skills.yaml` is the single source of truth; this file
explains it for review. Ids are permanent once a trainee database references
them, so review the ids more carefully than the labels.

## Counts per level (drafting order)

| Level | Topic | Skills | Categories |
|---|---|---:|---|
| 0 | Werkzeuge und erstes Projekt | 14 | tools, basics, methods |
| 1 | Konzepte | 12 | concepts |
| 2 | Elementare Sprachelemente | 31 | types, scope, strings, operators |
| 3 | Ablaufsteuerung | 22 | control, overflow, methods, algo |
| 4 | Klassen und Objekte | 29 | oop, statics, algo |
| 5 | Komposition, Indexer, Schutzstufen | 13 | oop, access |
| 6 | Weitere Typen | 29 | structs, arrays, algo, strings, enums, tuples, records, types |

150 skills. Level 2 and 6 are above the 25 guideline because they each cover
five to eight book sections; split the levels rather than coarsening the
skills if that bothers you.

A skill's level is **not** stored in `skills.yaml`. It is derived from the
exercises that teach it, so the table above only reflects the drafting order.

## `Klassen und Objekte/Bruch/b0`–`b9` → `teaches`

What the trainee would have to write if the sample became an exercise (the
sample is the model answer, the starter is the sample with those parts
removed). `requires` lists what the exercise builds on; entries in *italics*
come from levels 0–3 and only become valid once those levels are authored.

| Sample | Exercise | `teaches` | `requires` |
|---|---|---|---|
| b0 | 4.1 Felder, Eigenschaften, Validierung | `oop.field-private`, `oop.property-full`, `oop.property-validated`, `oop.property-backing-field`, `oop.method-instance`, `algo.gcd-modulo` | *types.int, control.if-else, control.do-while, operators.integer-division, methods.parameters* |
| b1 Methoden-Überladung | 4.2 | `oop.method-overload`, `methods.bool-predicate` | `oop.method-instance`, `oop.property-validated` |
| b2 Konstruktoren | 4.3 | `oop.constructor-explicit`, `oop.constructor-default`, `oop.constructor-validates`, `oop.object-initializer` | `oop.property-validated`, `oop.method-overload`, `algo.gcd-modulo` |
| b3 DuplWerte | 4.4 | `oop.reference-semantics`, `oop.copy-values` | `oop.constructor-explicit`, `oop.method-instance` |
| b4 Klone | 4.5 | `oop.clone-method` | `oop.copy-values`, `oop.constructor-explicit` |
| b5 Statische Member | 4.6 | `statics.property`, `statics.method`, `statics.constructor`, `oop.property-auto`, `oop.property-field-keyword` | `oop.constructor-explicit`, `oop.property-validated` |
| b6 Rekursion | 4.7 | `algo.recursion` | `algo.gcd-modulo`, *control.if-else* |
| b7 Operatoren-Überladung | 4.8 | `oop.operator-binary`, `oop.operator-compound` | `oop.clone-method`, `oop.method-instance`, *strings.interpolation* |
| b8 Aggregation | 5.1 | `oop.aggregation`, `oop.delegate-to-member`, `oop.method-chaining-objects` | `oop.operator-binary`, `oop.constructor-explicit` |
| b9 ToString-Überschreibung | 5.2 | `oop.tostring-override`, `oop.tostring-implicit` | `oop.property-auto`, *strings.interpolation* |

b10 and b11 (interfaces, generic math) live in level 9 and give `applied`
credit for the level 4–5 skills.

**Current state in `modules/`.** Levels 0–3 and the level-4 Bruch chain
b0, b1, b2, b5, b6, b7 are authored (exercises 4.1, 4.2, 4.3, 4.6, 4.7, 4.8
plus the 4.0 terminology quiz). b3/b4 (4.4, 4.5) are not yet written, so the
b7 starter still stubs `DuplWerte` and `Klone` and teaches `oop.clone-method`
and `oop.copy-values` itself. 4.7 (b6) exposes the recursive ggT as a public
static method and adds factorial and Fibonacci; the two skills
`algo.factorial` and `algo.fibonacci` were added for it (150 skills in total).
Level 2 teaches its `types.*`/`operators.*` vocabulary across three coding
exercises and two quizzes; the `operators.*` quiz carries six skills.

## Skill graph, levels 0–6

Nodes are skill groups (one per category and level); edges are the
dependencies the exercises above and the module map imply. The full
per-skill graph is what `seesharp validate` checks; drawing all 148 nodes is
not readable.

```mermaid
flowchart TB
  subgraph L0["Level 0 — Werkzeuge"]
    tools["tools.*"]
    basics0["basics.console-output<br/>basics.main-method<br/>basics.top-level-statements"]
    methods0["methods.declare-static<br/>methods.return-value"]
  end
  subgraph L1["Level 1 — Konzepte"]
    concepts["concepts.*"]
  end
  subgraph L2["Level 2 — Elementare Sprachelemente"]
    types["types.*"]
    strings2["strings.concat<br/>strings.interpolation<br/>strings.format-alignment"]
    operators["operators.*"]
    scope["scope.block"]
  end
  subgraph L3["Level 3 — Ablaufsteuerung"]
    control["control.*"]
    overflow["overflow.*"]
    methods3["methods.parameters<br/>methods.bool-predicate"]
    algo3["algo.gcd-subtraction<br/>algo.gcd-modulo<br/>algo.prime-test"]
  end
  subgraph L4["Level 4 — Klassen und Objekte"]
    props["oop.field-private<br/>oop.property-*"]
    methods4["oop.method-instance<br/>oop.method-overload"]
    ctor["oop.constructor-*<br/>oop.object-initializer"]
    refs["oop.reference-semantics<br/>oop.copy-values<br/>oop.clone-method"]
    statics["statics.*"]
    ops["oop.operator-binary<br/>oop.operator-compound"]
    recursion["algo.recursion"]
    modern4["oop.required-member<br/>oop.local-method<br/>oop.ref-readonly-param"]
  end
  subgraph L5["Level 5 — Komposition, Indexer, Schutzstufen"]
    aggregation["oop.aggregation<br/>oop.delegate-to-member<br/>oop.method-chaining-objects"]
    tostring["oop.tostring-override<br/>oop.tostring-implicit"]
    indexer["oop.indexer"]
    nested["oop.nested-class<br/>oop.nested-private-access"]
    access["access.*<br/>oop.library-consumer"]
    pure["oop.pure-method-returns-new<br/>oop.property-computed"]
  end
  subgraph L6["Level 6 — Weitere Typen"]
    structs["structs.*"]
    arrays["arrays.*"]
    algo6["algo.sieve<br/>algo.selection-sort<br/>algo.fisher-yates<br/>algo.matrix-transpose"]
    strings6["strings.immutability<br/>strings.methods<br/>strings.stringbuilder<br/>strings.char-iteration"]
    enums["enums.*"]
    tuples["tuples.*"]
    records["records.*"]
    types6["types.anonymous<br/>types.using-alias"]
  end

  tools --> basics0 --> methods0
  methods0 --> types
  concepts --> props
  types --> operators --> control
  types --> strings2
  scope --> control
  control --> methods3 --> algo3
  overflow --> algo3
  algo3 --> props
  methods3 --> methods4
  props --> methods4 --> ctor --> refs --> ops
  ctor --> statics
  control --> recursion
  props --> modern4
  ops --> aggregation
  strings2 --> tostring
  props --> tostring
  props --> indexer
  props --> nested
  tools --> access
  ctor --> pure
  ctor --> structs
  control --> arrays --> algo6
  strings2 --> strings6
  types --> enums
  methods3 --> tuples
  ctor --> records
  props --> types6
```

### Bruch chain in detail (levels 4–5)

```mermaid
flowchart LR
  b0["b0<br/>property-full<br/>property-validated<br/>method-instance<br/>gcd-modulo"]
  b1["b1<br/>method-overload<br/>bool-predicate"]
  b2["b2<br/>constructor-explicit<br/>constructor-validates<br/>object-initializer"]
  b3["b3<br/>reference-semantics<br/>copy-values"]
  b4["b4<br/>clone-method"]
  b5["b5<br/>statics.property<br/>statics.method<br/>statics.constructor<br/>property-field-keyword"]
  b6["b6<br/>recursion"]
  b7["b7<br/>operator-binary<br/>operator-compound"]
  b8["b8<br/>aggregation<br/>delegate-to-member"]
  b9["b9<br/>tostring-override"]
  b0 --> b1 --> b2 --> b3 --> b4 --> b7 --> b8
  b2 --> b5
  b0 --> b6
  b5 --> b9
```
