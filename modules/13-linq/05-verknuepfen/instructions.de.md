# Join, GroupJoin und Zip

Lies im Buch **18.2.10 Verknüpfen von zwei Sequenzen** (Seite 1224) und
die Übungsaufgabe **18.6 Aufgabe 1** (Seite 1255) zu `Zip`.

Kunden und Bestellungen hängen über `Bestellung.KundeId = Kunde.Id`
zusammen. Öffne `Verknuepfungen.cs` (die Records `Kunde(Id, Name)` und
`Bestellung(Id, KundeId, Betrag)` sind vorgegeben):

1. `KundenMitBestellung(kunden, bestellungen)`: je Bestellung ein Paar
   `(Name, Betrag)`, in der Reihenfolge der Kunden; Kunden ohne
   Bestellung und Bestellungen ohne Kunde erscheinen nicht (`Join`).
2. `BestellungenProKunde(kunden, bestellungen)`: für **jeden** Kunden
   `(Name, Anzahl, Summe)`, auch für Kunden ohne Bestellung
   (`(name, 0, 0)`); Reihenfolge wie bei den Kunden (`GroupJoin`).
3. `TopKunde(kunden, bestellungen)`: der Kunde mit der größten Summe
   (bei Gleichstand der erste in der Kundenliste), bei leerer Kundenliste `null`.
4. `Paare(namen, zahlen)`: `"Name:Zahl"` für jedes Paar; endet mit der
   kürzeren Sequenz (`Zip`).

Tests: `KundenMitBestellung_ist_ein_innerer_Join`,
`BestellungenProKunde_enthaelt_auch_Kunden_ohne_Bestellung`,
`BestellungenProKunde_ohne_Bestellungen`, `TopKunde_hat_die_groesste_Summe`,
`TopKunde_bei_Gleichstand_der_erste_Kunde`, `TopKunde_ohne_Kunden_ist_null`,
`Paare_endet_mit_der_kuerzeren_Folge`.
