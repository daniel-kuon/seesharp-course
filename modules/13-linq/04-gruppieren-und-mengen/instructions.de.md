# Gruppieren, Zählen und Mengenoperatoren

Lies im Buch **18.2.9 GroupBy()** (Seite 1222) und die Übungsaufgabe
**18.6 Aufgabe 2** (Seite 1255, Dublettensuche). Das Dateisystem wird hier
durch Einträge im Speicher ersetzt; das echte Programm findest du im
Sample `LINQ-to-Objects/FindDuplicate`. `CountBy` und `AggregateBy` (ab .NET
9) stehen nicht im Buch: `CountBy(schluessel)` liefert Paare (Schlüssel,
Anzahl), `AggregateBy(schluessel, startwert, funktion)` verdichtet pro
Schlüssel zu einem Wert.

Öffne `Auswertung.cs` (Record `Dateieintrag(Pfad, Groesse, Hash)`):

1. `Duplikate(eintraege)`: Gruppen von Einträgen mit gleicher `(Groesse, Hash)`,
   in denen mehr als ein Eintrag steht, als `List<List<string>>` der
   **sortierten** Pfade (`StringComparer.Ordinal`); die Gruppen sind nach
   ihrem ersten Pfad geordnet (`GroupBy`, `Where`, `Select`, `OrderBy`).
2. `SpeicherProEndung(eintraege)`: je Dateiendung (`Path.GetExtension(pfad)`
   liefert sie samt Punkt, z. B. `".PNG"`; klein geschrieben; die Klasse `Path`
   behandelt Level 15 ausführlich) die Summe der Größen, größte Summe zuerst, bei Gleichstand
   nach Endung (`Ordinal`).
3. `Haeufigkeiten(werte)`: `Dictionary<string, int>` mit `CountBy`.
4. `GroesseProEndung(eintraege)`: `Dictionary<string, long>` Endung (wie in 2.)
   -> Summe der Größen, mit `AggregateBy`.
5. `NeueTags(alt, neu)`: Tags aus `neu`, die in `alt` fehlen (`Except`);
   `AlleTags(a, b)` (`Union`); `GemeinsameTags(a, b)` (`Intersect`). Alle drei
   liefern eine **sortierte** Liste ohne Wiederholungen (`Order`).

Tests: `Duplikate_findet_gleiche_Groesse_und_Hash`,
`Duplikate_ohne_Treffer_ist_leer`,
`SpeicherProEndung_summiert_und_sortiert`,
`SpeicherProEndung_bricht_Gleichstand_nach_Endung`,
`Haeufigkeiten_zaehlen_je_Wert`,
`GroesseProEndung_verdichtet_je_Schluessel`, `Mengenoperatoren_auf_Tags`.
