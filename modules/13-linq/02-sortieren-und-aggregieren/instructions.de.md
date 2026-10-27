# Sortieren, Aggregate und Teilfolgen

Lies im Buch **18.2.7 Sortieren** (Seite 1218) und **18.2.11 Weitere
LINQ-Operatoren** (Seite 1228; `Chunk` auf Seite 1234).

Der Record `Produkt` kennst du aus der vorigen Aufgabe. Öffne
`Statistik.cs`; alle Methoden bekommen eine `IEnumerable<Produkt>` und
lassen die Quelle unverändert:

1. `Teuerste(produkte, n)`: die `n` teuersten Produkte, teuerstes zuerst,
   bei gleichem Preis in der Reihenfolge der Quelle (`OrderByDescending`, `Take`;
   die Quellreihenfolge bei Gleichstand ergibt sich von selbst, warum, steht
   im Deep Dive der Zusammenfassung).
2. `NachKategorieDannPreis(produkte)`: nach Kategorie aufsteigend, innerhalb
   der Kategorie nach Preis absteigend (`OrderBy`, `ThenByDescending`).
3. `Seite(produkte, seite, groesse)`: eine Seite der Liste in der gegebenen
   Reihenfolge; die Zählung der Seiten beginnt bei 0 (`Skip`, `Take`).
4. `Preisspanne(produkte)`: `(min, max, mittel)` der Preise
   (`Min`, `Max`, `Average`); bei einer **leeren** Sequenz `(0, 0, 0)`
   (sonst wirft `Average` eine Ausnahme).
5. `Lagerwert(produkte)`: Summe von `Preis * Lager` (`Sum`).
6. `AnzahlTeurerAls(produkte, grenze)`: Anzahl der Produkte mit
   `Preis > grenze` (`Count` mit Bedingung).
7. `Pakete(produkte, n)`: die Produkte in Gruppen zu je höchstens `n`
   (`Chunk`).
8. `BisZumErstenLeeren(produkte)`: die Produkte vom Anfang an, solange
   `Lager > 0` (`TakeWhile`).

Tests:
`Teuerste_sortiert_absteigend_und_behaelt_bei_Gleichstand_die_Quellreihenfolge`,
`NachKategorieDannPreis_sortiert_zweistufig`,
`Seite_liefert_die_gewuenschte_Seite`,
`Preisspanne_liefert_Minimum_Maximum_und_Mittel`,
`Preisspanne_einer_leeren_Quelle_ist_null`,
`Lagerwert_summiert_Preis_mal_Lager`,
`AnzahlTeurerAls_zaehlt_strikt_groesser`, `Pakete_teilt_in_Gruppen`,
`BisZumErstenLeeren_endet_beim_ersten_Produkt_ohne_Lager`,
`Die_Quelle_bleibt_unveraendert`.
