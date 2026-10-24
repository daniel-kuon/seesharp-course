# Mengen mit HashSet<T>

Lies im Buch **11.5 Mengen** (Seite 704) und darin besonders
**11.5.2 Hashtabellen und die Klasse HashSet<T>** (Seite 704).

Die Aufgabe hat zwei Dateien.

**`Mengenwerkzeuge.cs`**

1. `Duplikate` liefert die Werte, die mehr als einmal vorkommen, jeden nur
   einmal. `Add()` liefert `false`, wenn das Element schon da war.
2. `GemeinsameFreunde`, `NurLinks` und `Alle` bilden Schnittmenge,
   Differenz und Vereinigung als **neue** Menge mit `IntersectWith`,
   `ExceptWith` und `UnionWith`. Die Argumente dürfen sich nicht ändern; die
   Tests prüfen sie nach. `IstTeilmenge` nutzt `IsSubsetOf`.
3. `ContainsAllListe` und `ContainsAllMenge` beantworten dieselbe Frage
   ("kommt jede gesuchte Zahl in der Liste vor?"), die erste mit
   `List<int>.Contains`, die zweite über ein `HashSet<int>`. Beide müssen
   immer dasselbe Ergebnis liefern. Zeit wird nicht gemessen.

**`Punkt.cs`**

4. Überschreibe in `Punkt` die Methoden `Equals(object?)` und
   `GetHashCode()` (mit `HashCode.Combine`). Danach muss ein `HashSet<Punkt>`,
   in das dreimal (1, 2) eingefügt wird, genau ein Element haben und
   `Contains(new Punkt(1, 2))` wahr liefern. `Equals(null)` und
   `Equals("x")` sind falsch.

Wichtige Tests: `Duplikate_meldet_jeden_doppelten_Wert_einmal`,
`Mengenoperationen_veraendern_die_Argumente_nicht`,
`HashSet_von_Punkten_erkennt_gleiche_Punkte`,
`Gleiche_Punkte_haben_gleiche_Hashwerte`,
`Equals_ist_bei_null_und_fremden_Typen_false` und
`ContainsAll_Liste_und_Menge_stimmen_ueberein`.
