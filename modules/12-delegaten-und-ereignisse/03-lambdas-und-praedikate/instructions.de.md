# Lambda-Ausdrücke und Prädikate

Lies im Buch **10.1.5.2 Lambda-Ausdrücke** (Seite 667) und die Übungsaufgabe
**10.3 Aufgabe 2** (Seite 688) zu `Predicate<T>` und `FindAll`.

Die Methoden `FindAll`, `Exists`, `Find`, `RemoveAll`, `Sort` und `ForEach`
von `List<T>` erwarten Delegaten; Lambda-Ausdrücke liefern sie an Ort und
Stelle. Öffne `Filter.cs`:

1. `LangeWoerter`: Wörter mit mehr als 5 Zeichen (`FindAll`, Ausdruckslambda).
2. `OhneLeere`: Einträge, die `null`, leer oder nur Leerraum sind, mit
   `RemoveAll` aus der Liste selbst löschen; Rückgabe: Anzahl der gelöschten
   Einträge.
3. `Existiert`: ist der Wert in der Liste (`Exists`)?
4. `ErstesMit`: erstes Wort, das mit dem Zeichen beginnt (`Find`), sonst `null`.
5. `SortiereNachLaenge`: sortiert die Liste mit `Sort` und einem **Lambda mit
   Anweisungsblock**: erst nach Länge, bei gleicher Länge mit
   `string.CompareOrdinal`.
6. `Summe`: addiert alle Werte mit `ForEach` und einer lokalen Variablen, die
   das Lambda verändert.

Beantworte danach die Fragen zu den Delegatentypen der Lambdas.

Tests: `LangeWoerter_filtert_nach_Laenge`,
`LangeWoerter_aendert_die_Quelle_nicht`,
`OhneLeere_entfernt_in_der_Liste_selbst`, `OhneLeere_ohne_Treffer`,
`Existiert_findet_Werte`, `ErstesMit_findet_das_erste_Wort`,
`ErstesMit_ohne_Treffer_ist_null`, `Sortiere_nach_Laenge_dann_alphabetisch`,
`Summe_addiert_alle_Werte`.
