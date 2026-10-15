# Skill vocabulary — levels 0–9

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
| 7 | Vererbung und Polymorphie | 20 | inheritance, extensions, records |
| 8 | Typgenerisches Programmieren | 13 | generics, algo |
| 9 | Interfaces | 21 | interfaces, iterators, generics, oop |

206 skills (150 from the levels 0–6 draft, `oop.indexer-overload` and
`algo.vector-geometry` added for level 5, 54 for levels 7–9). Level 2 and 6
are above the 25 guideline because they each cover five to eight book
sections; split the levels rather than coarsening the skills if that bothers
you.

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

**Current state in `modules/`.** Levels 0–9 are authored. Levels 0–3 and the
level-4 Bruch chain b0, b1, b2, b5, b6, b7 (exercises 4.1, 4.2, 4.3, 4.6,
4.7, 4.8 plus the 4.0 terminology quiz) came first; b3/b4 (4.4, 4.5) are not
written, so the b7 starter still stubs `DuplWerte` and `Klone` and teaches
`oop.clone-method` and `oop.copy-values` itself. 4.7 (b6) exposes the
recursive ggT as a public static method and adds factorial and Fibonacci
(`algo.factorial`, `algo.fibonacci`). Level 2 teaches its
`types.*`/`operators.*` vocabulary across three coding exercises and two
quizzes; the `operators.*` quiz carries six skills.

Levels 5–9 follow the exercise plan in the tool repo's `MODULE-MAP.md`:

| Level | Exercises | Notes |
|---|---|---|
| 5 | 01 Aggregation (b8), 02 ToString (b9), 03 Indexer, 04 Geschachtelte Klassen, 05 R2Vek, 06 Bibliothek und Konsument (FractionLib) | 5.6 is the first two-project starter (library + console); its test project references both. |
| 6 | 01 Strukturen und Boxing, 02 Sieb, 03 Matrix, 04 Lotto, 05 Zeichenfolgen, 06 Enums und Tupel, 07 Records und anonyme Typen | 6.1/6.2 and 6.9/6.10 of the map were merged; `control.nested-loops` is taught by the sieve. |
| 7 | 01 Figurenhierarchie, 02 virtual/override, 03 Abstrakte Klassen, 04 Reparatur (7.16/1–2), 05 Ausblenden-Quiz, 06 Erweiterungsmitglieder, 07 Record-Figuren | The 04 starter does not compile by design (fix-the-error exercise). |
| 8 | 01 Generischer Stapel, 02 Sortierte Liste, 03 default und Nullable, 04 Generische Erweiterungen, 05 Max mit Serienparameter, 06 Generics-Quiz | `Listenwerte` (8.8/2) appears only as a quiz item. |
| 9 | 01 Interface implementieren, 02 Explizite Implementation, 03 Bruch IComparable/ICloneable (b10), 04 Enumeratoren (hand-written), 05 Iteratoren (yield), 06 Generische Mathematik (b11), 07 Interfaces-Quiz | b10/b11 give applied credit for the level 4–5 Bruch skills; `overflow.checked` is taught by 9.6 because level 3.6 was never authored. |

Skills in the vocabulary that no exercise teaches yet (left for the missing
exercises 0.2, 3.6, 4.4, 4.5, 4.9): `oop.reference-semantics`,
`oop.local-method`, `oop.required-member`, `oop.ref-readonly-param`,
`overflow.wraparound`, `overflow.min-max-value`, `types.long`, `types.float`,
`types.bit-pattern`, `strings.escape` and a few `tools.*` ids from level 0.
Requiring one of them is a validation error, so manifests avoid them.

## Skill graph, levels 0–9

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
  subgraph L7["Level 7 — Vererbung und Polymorphie"]
    inh["inheritance.derive-class<br/>inheritance.base-constructor<br/>inheritance.protected<br/>inheritance.base-reference<br/>inheritance.type-test"]
    poly["inheritance.virtual-override<br/>inheritance.base-call<br/>inheritance.sealed<br/>inheritance.abstract-*"]
    hiding["inheritance.hiding-new<br/>inheritance.overload-vs-override<br/>inheritance.static-no-override"]
    ext["extensions.*"]
    records7["records.inheritance<br/>records.positional-validation"]
  end
  subgraph L8["Level 8 — Typgenerisches Programmieren"]
    gen["generics.class-declare<br/>generics.array-of-t<br/>generics.constraint-*"]
    genm["generics.method<br/>generics.params<br/>generics.default<br/>generics.nullable-value<br/>generics.type-inference"]
    genext["generics.extension"]
    genq["generics.invariance<br/>generics.inheritance"]
  end
  subgraph L9["Level 9 — Interfaces"]
    ifc["interfaces.implement<br/>interfaces.as-type<br/>interfaces.explicit<br/>interfaces.multiple"]
    icmp["interfaces.icomparable<br/>interfaces.icloneable<br/>oop.memberwise-clone"]
    ienum["interfaces.ienumerable<br/>interfaces.ienumerator-manual<br/>iterators.*"]
    gmath["interfaces.generic-math<br/>interfaces.checked-operator<br/>interfaces.static-abstract"]
    variance["generics.covariance<br/>generics.contravariance<br/>interfaces.vs-abstract-class"]
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
  ctor --> inh --> poly --> hiding
  ops --> ext
  records --> records7
  inh --> records7
  poly --> gen --> genm --> genq
  ext --> genext
  genm --> genext
  poly --> ifc --> icmp
  refs --> icmp
  ifc --> ienum
  gen --> ienum
  ops --> gmath
  genm --> gmath
  genq --> variance
  ifc --> variance
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
  b10["b10 (Level 9)<br/>interfaces.icomparable<br/>interfaces.icloneable"]
  b11["b11 (Level 9)<br/>interfaces.generic-math<br/>interfaces.checked-operator"]
  b0 --> b1 --> b2 --> b3 --> b4 --> b7 --> b8
  b2 --> b5
  b0 --> b6
  b5 --> b9
  b9 --> b10 --> b11
```
