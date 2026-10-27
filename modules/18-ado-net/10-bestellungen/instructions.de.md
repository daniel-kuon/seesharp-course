# Zusatz: Bestellungen auswerten (SQL)

Lies im Buch **19.6.4 Abfragen per SELECT** (Seite 1302), besonders zu `JOIN`,
`GROUP BY` und den Aggregatfunktionen. Die Tests legen ein Schema mit drei Tabellen
an und füllen es:

- `Kunde(Id, Name)`
- `Bestellung(Id, KundeId, Datum)`
- `Position(Id, BestellungId, Produkt, Menge, Preis)`

Öffne `Auswertungen.cs` und schreibe die Abfragen (SQL-Texte in den
Konstanten; das Schema steht im Kommentar):

1. **`UmsatzProKunde`**: Spalten `Kunde` (Name) und `Umsatz` (Summe aus
   `Menge * Preis` über alle Positionen aller Bestellungen des Kunden), nur Kunden
   mit Bestellungen, höchster Umsatz zuerst.
2. **`Top3Produkte`**: Spalten `Produkt` und `Menge` (Summe der bestellten Menge) der
   drei meistbestellten Produkte; bei gleicher Menge nach Produktname. Die Zahl der
   Zeilen begrenzt in SQLite `LIMIT 3` am Ende der Abfrage (nicht im Buch, hier
   vorgegeben; der SQL Server schreibt `SELECT TOP 3 ...`).

Tests: `UmsatzProKunde_summiert_Menge_mal_Preis_und_sortiert_absteigend`,
`Top3Produkte_liefert_die_drei_meistbestellten_Produkte`.

> **Deep Dive (optional):** `LEFT JOIN` steht nicht im Buch. Anders als der `INNER JOIN`
> aus 19.6.4.3 behält ein `LEFT JOIN` jede Zeile der linken Tabelle; wo rechts nichts
> passt, sind die Spalten der rechten Tabelle NULL. Schreibe damit
> **`KundenOhneBestellung`**: Spalte `Name` der Kunden, die nie bestellt haben, nach Name
> sortiert (`LEFT JOIN` auf `Bestellung`, danach `WHERE ... IS NULL`). Die Tests
> `KundenOhneBestellung_findet_Carl_und_Dora` und
> `KundenOhneBestellung_aendert_sich_mit_neuen_Bestellungen` sind zusätzlich; die Aufgabe
> ist auch ohne sie bestanden.
