# Abfragesyntax mit let, into und join

Lies im Buch **18.3 Abfragesyntax** (Seite 1235 bis 1244) und schau dir
die Samples `LINQ-to-Objects/Abfragesyntax/{Einstieg, let, into, Join}` an.

Das Projekt enthält zwei Klassen. `Methodensyntax` (in `Methodensyntax.cs`)
ist fertig und von den Tests abgedeckt; sie zeigt dieselben Abfragen in
Methodensyntax. In `Abfragesyntax` (in `Abfragesyntax.cs`) formulierst du jede Abfrage **in Abfragesyntax** neu;
das Ergebnis muss dasselbe sein:

1. `TeuerQ(produkte, grenze)`: `from ... where ... orderby ... select`; die
   Namen der Produkte über der Grenze, alphabetisch.
2. `MitMehrwertsteuerQ(produkte)`: mit `let brutto = p.Preis * 1.19m`, das in
   `where` und `select` benutzt wird; `(Name, Brutto)` aller Produkte mit
   Brutto über 20.
3. `GroessteKategorienQ(produkte)`: `group p by p.Kategorie into g`, dann
   `where g.Count() > 1` (Folgeabfrage mit `into`); `(Kategorie, Anzahl)`,
   größte Anzahl zuerst, bei Gleichstand nach Kategorie.
4. `KundenMitBestellungQ(kunden, bestellungen)`: `join ... on ... equals ...`;
   `(Name, Betrag)` je Bestellung.
5. `KundenSummenQ(kunden, bestellungen)`: `join ... on ... equals ... into bs`
   (Gruppenverknüpfung); `(Name, Summe)` für jeden Kunden, auch ohne
   Bestellung (Summe 0).

Ein Ausdruck in Abfragesyntax steht meist in Klammern, damit man `.ToList()`
anhängen kann.

Tests: `Methodensyntax_Teuer`, `Methodensyntax_MitMehrwertsteuer`,
`Methodensyntax_GroessteKategorien`, `Methodensyntax_Kunden`,
`TeuerQ_wie_Methodensyntax`, `MitMehrwertsteuerQ_wie_Methodensyntax`,
`GroessteKategorienQ_wie_Methodensyntax`,
`KundenMitBestellungQ_wie_Methodensyntax`,
`KundenSummenQ_enthaelt_auch_Kunden_ohne_Bestellung`.
