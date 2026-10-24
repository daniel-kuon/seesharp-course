# DataReader und Objektabbildung

Lies im Buch **19.7.15 DbDataReader** (Seite 1363). Ein Leser liefert das Ergebnis
einer Abfrage Zeile für Zeile: `Read()` geht zur nächsten Zeile und meldet `false`,
wenn es keine mehr gibt. Die Spalten liest man mit `GetOrdinal` (Spaltennummer zum
Namen) und typisierten Methoden wie `GetInt32`, `GetString`, `GetDecimal`;
`IsDBNull` fragt, ob die Spalte NULL enthält.

Öffne `ArtikelRepository.cs`. Das `record Artikel` ist vorgegeben (`Kategorie` ist
`string?`). Du bildest Datenbankzeilen auf diese Objekte ab. Die Verbindung gehört
dem Aufrufer; Leser und Befehle gibst du jeweils mit `using` frei.

1. `Alle()`: alle Artikel, sortiert nach `Id`. Die vorgegebene Abfrage `Auswahl`
   verbindet per `LEFT JOIN` die Kategorie; Artikel ohne Kategorie haben dort NULL
   und müssen in C# `null` bleiben.
2. `Suche(teil)`: Artikel, deren Name `teil` enthält, nach Name sortiert. Der
   Suchtext kommt als **Parameter** in einen `LIKE`-Ausdruck. Die Prozentzeichen
   hängst du an den **Parameterwert** an (`"%" + teil + "%"`), nicht an den SQL-Text.
3. `NachKategorie()`: ein `Dictionary<string, List<Artikel>>` mit dem Kategorienamen
   als Schlüssel; Artikel ohne Kategorie stehen unter `"(ohne)"`.
4. `LagerwertPerSql()` und `LagerwertPerCsharp()`: die Summe aus `Preis * Bestand`
   einmal von der Datenbank berechnen lassen (`SUM`, `ExecuteScalar`) und einmal in
   C# über die Artikel aus `Alle()`. Beide müssen dasselbe liefern, auch bei einer
   leeren Tabelle (`SUM` ergibt dort NULL, also `DBNull`; das Ergebnis soll 0 sein).

Alle Methoden müssen die Verbindung freigeben: Die Tests prüfen nach jedem Aufruf,
dass kein Leser mehr offen ist.

Beantworte danach die Quizfrage.

Tests: `Alle_liefert_alle_Artikel_nach_Id`, `Alle_laesst_fehlende_Kategorie_null`,
`Alle_auf_leerer_Tabelle_liefert_leere_Liste`,
`Suche_findet_Teiltext_ohne_Beachtung_der_Gross_Kleinschreibung_und_sortiert_nach_Name`,
`Suche_mit_leerem_Text_liefert_alle`, `Suche_ist_gegen_SQL_Injection_sicher`,
`NachKategorie_gruppiert_und_sammelt_Artikel_ohne_Kategorie_unter_ohne`,
`Lagerwert_per_SQL_und_per_Csharp_stimmen_ueberein`, `Lagerwert_einer_leeren_Tabelle_ist_null`,
`Leser_werden_freigegeben_Alle`, `Leser_werden_freigegeben_Suche`,
`Leser_werden_freigegeben_NachKategorie`.
