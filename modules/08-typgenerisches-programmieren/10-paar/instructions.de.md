# Zusatz: Ein generisches Paar mit zwei Typformalparametern

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**8.2.1 Generische Klassen: Definition** (Seite 591) und **8.5 Generische
Methoden** (Seite 602).

Eine generische Klasse darf mehrere Typformalparameter haben:
`Paar<T1, T2>` hält zwei Werte beliebiger, auch verschiedener Typen, etwa
`Paar<int, string>`. Öffne `Paar.cs`:

1. Der Konstruktor übernimmt `Erstes` und `Zweites`; `ToString()` liefert
   `"(erstes, zweites)"`, z. B. `"(1, eins)"`.
2. `Getauscht()` liefert ein **neues** Paar mit vertauschten Werten. Dabei
   tauschen auch die Typen: Aus `Paar<int, string>` wird
   `Paar<string, int>`.
3. `MitErstem<TNeu>(TNeu neu)` ist eine generische Methode in einer
   generischen Klasse: Sie hat ihren eigenen Typformalparameter `TNeu` und
   liefert ein neues Paar, dessen erster Wert ersetzt ist, auch durch einen
   Wert eines anderen Typs. Das ursprüngliche Paar bleibt unverändert.
4. Die nicht generische statische Klasse `Paar` (gleicher Name, aber ohne
   Typformalparameter, das ist erlaubt) bietet Fabrikmethoden:
   `Paar.Von(1, "eins")` liefert ein `Paar<int, string>`, ohne dass du die
   Typargumente hinschreibst (Typinferenz).
   `Paar.Geordnet(a, b)` liefert ein Paar zweier gleichartiger Werte, das
   kleinere zuerst; dazu braucht `T` die Einschränkung
   `where T : IComparable<T>`.

Diese Tests müssen bestehen:

- `PaareTests.Paar_haelt_zwei_Werte_verschiedener_Typen`
- `PaareTests.ToString_zeigt_beide_Werte`
- `PaareTests.Getauscht_tauscht_Werte_und_Typen`
- `PaareTests.MitErstem_kann_den_Typ_wechseln`
- `PaareTests.Von_leitet_die_Typargumente_ab`
- `PaareTests.Geordnet_legt_den_kleineren_Wert_nach_vorn`
