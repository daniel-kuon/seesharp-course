# Join, GroupJoin, and Zip

Read the section **“18.2.10 Combining Two Sequences”** (page 1224) and Exercise **18.6, Task 1** (page 1255) in the book on `Zip`.

Customers and orders are linked via `Bestellung.KundeId = Kunde.Id`. Open `Verknuepfungen.cs` (the records `Kunde(Id, Name)` and `Bestellung(Id, KundeId, Betrag)` are predefined):

1. `KundenMitBestellung(kunden, bestellungen)`: one (`(Name, Betrag)`) pair per order, in the order of the customers; customers without orders and orders without customers are not included (`Join`).
2. `BestellungenProKunde(kunden, bestellungen)`: for **each** customer `(Name, Anzahl, Summe)`, including customers with no orders `(name, 0, 0)`; order is the same as for the customers (`GroupJoin`).
3. `TopKunde(kunden, bestellungen)`: the customer with the highest total (in the event of a tie, the first one in the customer list); `null` if the customer list is empty.
4. `Paare(namen, zahlen)`: `"Name:Zahl"` for each pair; ends with the shorter sequence (`Zip`).

Tests: `KundenMitBestellung_ist_ein_innerer_Join`, `BestellungenProKunde_enthaelt_auch_Kunden_ohne_Bestellung`, `BestellungenProKunde_ohne_Bestellungen`, `TopKunde_hat_die_groesste_Summe`, `TopKunde_bei_Gleichstand_der_erste_Kunde`, `TopKunde_ohne_Kunden_ist_null`, `Paare_endet_mit_der_kuerzeren_Folge`.
