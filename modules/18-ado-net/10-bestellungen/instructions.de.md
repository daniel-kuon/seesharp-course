# Zusatz: Bestellungen auswerten (SQL)

Lies im Buch **19.6.4 Abfragen per SELECT** (Seite 1302), besonders zu `JOIN`,
`GROUP BY` und den Aggregatfunktionen. Die Tests legen ein Schema mit drei Tabellen
an und füllen es:

- `Kunde(Id, Name)`
- `Bestellung(Id, KundeId, Datum)`
- `Position(Id, BestellungId, Produkt, Menge, Preis)`

Öffne `Auswertungen.cs` und schreibe drei Abfragen (SQL-Texte in den
Konstanten; das Schema steht im Kommentar):

1. **`UmsatzProKunde`**: Spalten `Kunde` (Name) und `Umsatz` (Summe aus
   `Menge * Preis` über alle Positionen aller Bestellungen des Kunden), nur Kunden
   mit Bestellungen, höchster Umsatz zuerst.
2. **`KundenOhneBestellung`**: Spalte `Name` der Kunden, die nie bestellt haben, nach
   Name sortiert. Tipp: `LEFT JOIN` auf `Bestellung` und danach `WHERE ... IS NULL`.
3. **`Top3Produkte`**: Spalten `Produkt` und `Menge` (Summe der bestellten Menge) der
   drei meistbestellten Produkte; bei gleicher Menge nach Produktname.
   SQLite kennt `LIMIT 3` statt `TOP 3`.

Tests: `UmsatzProKunde_summiert_Menge_mal_Preis_und_sortiert_absteigend`,
`KundenOhneBestellung_findet_Carl_und_Dora`,
`KundenOhneBestellung_aendert_sich_mit_neuen_Bestellungen`,
`Top3Produkte_liefert_die_drei_meistbestellten_Produkte`.
