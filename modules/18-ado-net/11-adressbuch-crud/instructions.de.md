# Zusatz: Adressbuch mit Suche

Lies noch einmal **19.7.5 DbCommand** (Seite 1323) und **19.7.15 DbDataReader**
(Seite 1363). In `Kontaktdienst.cs` verwaltest du die Tabelle
`Kontakt(Id, Name, Telefon)` über eine offene Verbindung, die dem Aufrufer gehört.
Das `record Kontakt` ist vorgegeben; `Telefon` ist `string?`.

1. `Neu(name, telefon)`: Kontakt einfügen und die **neue Id** zurückgeben
   (nicht im Buch, hier vorgegeben: nach dem `INSERT` liefert
   `SELECT last_insert_rowid()` per `ExecuteScalar` die Id als `long`).
2. `Aendern(id, name, telefon)`: `UPDATE`; `true`, wenn es den Kontakt gab.
3. `Loeschen(id)`: `DELETE`; `true`, wenn es den Kontakt gab.
4. `Suche(teil)`: alle Kontakte, deren Name `teil` enthält, nach Name sortiert,
   auch solche ohne Telefonnummer (`null`).

Alle Werte gehören als Parameter in den Befehl, nie in den SQL-Text. `null` für das
Telefon wird zu `DBNull.Value`, ein NULL in der Datenbank beim Lesen wieder zu `null`.

Tests: `Neu_liefert_die_neue_Id_und_speichert_den_Kontakt`, `Neu_ohne_Telefon_speichert_NULL`,
`Neu_vertraegt_Hochkommas_und_SQL_Zeichen_im_Namen`,
`Aendern_aendert_Name_und_Telefon_und_meldet_ob_es_den_Kontakt_gab`,
`Aendern_kann_das_Telefon_auf_NULL_setzen`, `Loeschen_entfernt_nur_den_einen_Kontakt`,
`Suche_findet_Teiltext_und_sortiert_nach_Name`, `Suche_liefert_auch_Kontakte_ohne_Telefon`,
`Suche_ohne_Treffer_und_mit_SQL_Zeichen_liefert_leere_Liste`,
`Suche_mit_leerem_Text_liefert_alle_sortiert`.
