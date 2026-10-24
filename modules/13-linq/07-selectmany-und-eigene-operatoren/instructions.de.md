# SelectMany, Unterabfragen, OfType und eigene Operatoren

Lies im Buch **18.2.8.2 SelectMany()** (Seite 1220), **18.2.6.2 OfType()**
(Seite 1217) und **18.4 Unterabfragen** (Seite 1244); die Samples
`LINQ-to-Objects/{OfType, Unterabfrage}` und `Abfragesyntax/SelectMany per
Abfragesyntax` zeigen jeweils eine Lösung. Die Übungsaufgabe ist **18.6
Aufgabe 1** (Seite 1255); ihre fünf Aussagen sind die Quizfragen.

Öffne `Auswertung.cs` (Record `Mitarbeiter(Name, Gehalt)` ist vorgegeben):

1. `Woerter(saetze)`: alle Wörter aller Sätze, klein geschrieben, ohne
   Wiederholungen, in der Reihenfolge des ersten Auftretens (`SelectMany`,
   `Split` mit den vorgegebenen `Trenner`n, `Distinct`).
2. `Kombinationen(a, b)`: das kartesische Produkt als Texte, z. B.
   `"1x"`, mit **zwei `from`-Klauseln** (Abfragesyntax).
3. `UeberDemSchnitt(mitarbeiter)`: alle, die mehr als der Durchschnitt aller
   verdienen. Die Abfrage `where m.Gehalt > liste.Average(...)` würde den
   Durchschnitt für jedes Element neu berechnen. Berechne ihn **einmal**:
   Die Quelle darf höchstens zweimal aufgezählt werden (die Tests zählen).
4. `Spitzenverdiener(mitarbeiter)`: Namen aller mit dem höchsten Gehalt, mit
   einer **Unterabfrage** in Abfragesyntax:
   `where m.Gehalt == (from x in liste select x.Gehalt).Max()`.
5. `NurTexte(objekte)` und `NurGanzzahlen(objekte)`: mit `OfType<T>()`.
6. `MeineOperatoren` (Erweiterungsmethoden mit `yield return`):
   - `TakeEvery(n)`: das erste, dann jedes `n`-te Element
     (Positionen 0, n, 2n, ...); bei `n <= 0` `ArgumentOutOfRangeException`
     bei der Aufzählung. Muss mit einer **unendlichen** Quelle und `Take(5)`
     funktionieren.
   - `WhereNot(bedingung)`: die Elemente, die die Bedingung **nicht** erfüllen.
   - `Paarweise()`: aufeinanderfolgende Paare `(a, b)`; `[1,2,3]` ergibt
     `(1,2), (2,3)`; weniger als zwei Elemente ergeben nichts.

Tests: `Woerter_flacht_Saetze_ab_und_entfernt_Wiederholungen`,
`Kombinationen_ist_das_kartesische_Produkt`,
`UeberDemSchnitt_liefert_die_Besserverdiener`,
`UeberDemSchnitt_zaehlt_die_Quelle_hoechstens_zweimal`,
`Spitzenverdiener_nutzt_eine_Unterabfrage`,
`OfType_filtert_nach_Laufzeittyp`,
`TakeEvery_nimmt_das_erste_und_jedes_nte_Element`,
`TakeEvery_funktioniert_auf_unendlichen_Quellen`,
`TakeEvery_ist_zurueckgestellt`, `TakeEvery_mit_ungueltigem_n_wirft`,
`WhereNot_dreht_die_Bedingung_um`,
`Paarweise_liefert_aufeinanderfolgende_Paare`.
