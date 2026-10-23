# Zusatz: Generische Algorithmen für sortierte Arrays

Zusatzaufgabe: freiwillig, sie schaltet nichts frei. Zum Nachlesen:
**8.5 Generische Methoden** (Seite 602) und **8.2.2 Restringierte
Typformalparameter** (Seite 593).

Klassische Algorithmen hängen nicht vom Elementtyp ab, nur davon, dass sich
Elemente vergleichen lassen. Einmal generisch geschrieben, funktionieren sie
für `int`, `double`, `string` und jeden eigenen Typ mit `IComparable<T>`.
Öffne `Algorithmen.cs`. Die Methoden haben noch **keine** Einschränkung;
ergänze bei jeder `where T : IComparable<T>`, sobald du `CompareTo`
brauchst (ein Test prüft das):

1. `IstSortiert(werte)`: `true`, wenn jedes Element höchstens so groß ist
   wie sein Nachfolger. Leere und einelementige Arrays sind sortiert.
2. `BinaereSuche(sortiert, gesucht)`: Suche im sortierten Array durch
   Halbieren: Vergleiche mit dem mittleren Element und suche links oder
   rechts weiter. Liefert den Index oder -1. Nicht linear suchen: Der Test
   zählt mit, wie oft verglichen wird.
3. `Zusammenfuehren(a, b)`: zwei sortierte Arrays zu einem neuen
   sortierten Array verschmelzen. Laufe mit zwei Indizes gleichzeitig durch
   beide Arrays und nimm jeweils das kleinere Element (der Merge-Schritt aus
   Mergesort). Nicht einfach aneinanderhängen und sortieren.
4. `MinMax(params T[] werte)`: kleinstes und größtes Element als Tupel
   `(Min, Max)` in **einem** Durchlauf; eine leere Serie wirft
   `ArgumentException`.

Beim Aufruf schreibst du keine Typargumente: `Algorithmen.MinMax(3, 1, 2)`.

Diese Tests müssen bestehen:

- `AlgorithmenTests.Alle_Methoden_sind_auf_IComparable_eingeschraenkt`
- `AlgorithmenTests.IstSortiert_prueft_die_Reihenfolge`
- `AlgorithmenTests.BinaereSuche_findet_den_Index`
- `AlgorithmenTests.BinaereSuche_halbiert_den_Bereich`
- `AlgorithmenTests.Zusammenfuehren_verschmilzt_zwei_sortierte_Arrays`
- `AlgorithmenTests.MinMax_liefert_ein_Tupel`
