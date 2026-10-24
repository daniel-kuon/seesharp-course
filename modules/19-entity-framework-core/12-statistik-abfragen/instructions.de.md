# Zusatz: Umsatzstatistik

Lies noch einmal **20.9.4 Statistische Auswertungsmethoden (Aggregatoperatoren)**
(Seite 1454). `Verkauf` (`Id`, `Produkt`, `Menge`, `Preis`, `Datum`), `VerkaufContext` und
das `record ProduktUmsatz(Produkt, Umsatz)` sind vorgegeben. Alle Berechnungen soll die
**Datenbank** ausführen, nicht dein C#-Code.

1. `GesamtUmsatz()`: Summe aus `Menge * Preis` über alle Verkäufe (`Sum`); ohne Verkäufe `0`.
2. `ProProduktAbfrage(kontext)`: Umsatz je Produkt, höchster zuerst: `GroupBy`, `OrderByDescending` nach der Summe, dann `Select` auf
   `ProduktUmsatz` mit `Sum`. Liefert die noch nicht ausgeführte
   `IQueryable`; der Test prüft mit `ToQueryString()`, dass `SUM`, `GROUP BY` und `ORDER BY` im
   SQL stehen. `ProProdukt()` führt sie aus (vorgegeben).
3. `TopProdukte(n)`: die `n` umsatzstärksten Produkte (`Take` auf die sortierte Abfrage).

Tests: `GesamtUmsatz_summiert_Menge_mal_Preis`, `GesamtUmsatz_ohne_Verkaeufe_ist_null`,
`ProProdukt_gruppiert_summiert_und_sortiert_absteigend`,
`ProProduktAbfrage_wird_vom_Server_berechnet`, `TopProdukte_liefert_die_umsatzstaerksten`.
