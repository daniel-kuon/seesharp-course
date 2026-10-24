# Where, Select und Verkettung

Lies im Buch **18.2.1 Beispiel** (Seite 1211) und **18.2.3 Fluent-API**
(Seite 1213) sowie **18.2.6.1 Where()** (Seite 1217).

LINQ besteht aus Erweiterungsmethoden auf `IEnumerable<T>`; die
Lambda-Ausdrücke liefern die Bedingungen und Umformungen. Öffne
`Abfragen.cs` (der Record `Produkt` und die Hilfsmethode `Euro` sind
vorgegeben):

1. `Guenstige(produkte, max)`: alle Produkte mit `Preis <= max` (`Where`).
2. `Namen(produkte)`: die Namen (`Select`).
3. `Etiketten(produkte)`: eine Liste von Tupeln `(Name, Preis)`, der Preis
   als Text mit `Euro`, z. B. `"12,50 EUR"` (`Select` mit Tupel,
   `ToList()`).
4. `VorraetigeGuenstige(produkte, max)`: Namen der Produkte mit `Lager > 0`
   und `Preis <= max`; zwei `Where`-Aufrufe und ein `Select` hintereinander.
5. `Preisliste(produkte)`: `Dictionary<string, decimal>` Name -> Preis
   (`ToDictionary`).
6. `Schnappschuss(produkte)`: ein Array mit den Produkten (`ToArray`).

Die Quellliste darf nie verändert werden. Beantworte danach die beiden
Fragen zu Typen.

Tests: `Guenstige_filtert_nach_Preis`,
`Namen_liefert_alle_Namen_in_Reihenfolge`,
`Etiketten_formatieren_den_Preis`,
`VorraetigeGuenstige_verkettet_Where_und_Select`,
`Preisliste_ist_ein_Woerterbuch`,
`Schnappschuss_ist_ein_Array_und_entkoppelt_von_der_Quelle`,
`Die_Quellliste_bleibt_unveraendert`.
