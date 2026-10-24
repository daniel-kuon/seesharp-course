# Abfragen mit LINQ-to-Entities

Lies im Buch **20.9 Abfragen** ab **20.9.2 Mehrere Entitäten abrufen** (Seite 1452)
bis einschließlich **20.9.6** zur server- und klientenseitigen Auswertung. Du kennst
LINQ von Sammlungen im Speicher; auf einem `DbSet<T>` übersetzt EF Core denselben
Ausdruck in **SQL**, das die Datenbank ausführt. Die Abfrage läuft erst bei `ToList()`,
`Count()`, `FirstOrDefault()` und ähnlichen Aufrufen.

Der Kontext `BeitragContext` mit der Entität `Beitrag` (`Id`, `Titel`, `Inhalt`,
`Datum`) ist vorgegeben. Öffne `BlogAbfragen.cs`:

1. `MitTitel(teil)`: Beiträge, deren Titel `teil` enthält (`Where` und `Contains`), nach Id.
2. `Neueste(n)`: die `n` neuesten Beiträge, neuester zuerst (`OrderByDescending`, `Take`).
3. `Finde(id)` mit `Find`; `ErsterMit(teil)` mit `FirstOrDefault` (kleinste Id,
   `null`, wenn es keinen Treffer gibt).
4. `TitellisteAbfrage(kontext)`: projiziert mit `Select` auf den Titel und liefert eine
   noch nicht ausgeführte `IQueryable<string>`; der Test sieht sich mit
   `ToQueryString()` das SQL an und verlangt, dass nur die Spalte `Titel` abgerufen wird, nicht der
   `Inhalt`.
5. `StatistikAbfrage(kontext)`: Anzahl und durchschnittliche Länge des Inhalts in **einer
   serverseitigen** Abfrage: `GroupBy(b => 1)` fasst alle Zeilen zu einer Gruppe zusammen,
   `Select` berechnet `Count()` und `Average()`. Der Test verlangt `COUNT` und `AVG` im SQL.
   `Statistik()` liefert das Ergebnis; bei einer leeren Tabelle `(0, 0)`.
6. `ClientAuswertung()`: dasselbe Ergebnis, aber absichtlich **clientseitig**: erst
   `AsEnumerable()` (alle Beiträge samt Inhalt werden geladen), dann rechnet C#. Das ist der
   Gegensatz, den das Buch in 20.9.6 beschreibt.

Beantworte danach die Quizfrage.

Tests: `MitTitel_filtert_mit_Where_und_Contains`, `Neueste_liefert_die_n_neuesten_Beitraege_absteigend`,
`Finde_liefert_den_Beitrag_oder_null`, `ErsterMit_liefert_den_ersten_Treffer_oder_null`,
`Titelliste_liefert_alle_Titel_nach_Id`, `TitellisteAbfrage_waehlt_nur_die_Spalte_Titel_aus`,
`Statistik_berechnet_Anzahl_und_Durchschnitt`, `StatistikAbfrage_rechnet_auf_dem_Server_mit_COUNT_und_AVG`,
`Statistik_einer_leeren_Tabelle_ist_null_null`, `ClientAuswertung_liefert_dasselbe_Ergebnis_wie_die_Serverabfrage`.
