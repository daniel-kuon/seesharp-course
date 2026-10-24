# Zusatz: Telefonbuch

Lies noch einmal **11.6 Verwaltung von (Schlüssel-Wert) - Paaren** (Seite 714).

Die Klasse `Telefonbuch` in `Telefonbuch.cs` verwaltet Namen und Nummern in
einem privaten `Dictionary<string,string>`. Implementiere:

1. `Setze(name, nummer)` legt einen Eintrag an oder überschreibt ihn.
2. `Suche(name)` liefert die Nummer oder `null`, wenn der Name unbekannt ist.
3. `Namen()` liefert alle Namen alphabetisch sortiert.
4. `MitVorwahl(vorwahl)` liefert alle Namen, deren Nummer mit der Vorwahl
   beginnt, alphabetisch sortiert (`foreach` über die `KeyValuePair`-Einträge).
5. `Entferne(name)` löscht den Eintrag und liefert `true`, wenn es ihn gab.

Die Tests decken den Normalfall und die Fälle mit fehlendem Schlüssel ab:
`Suche_liefert_null_fuer_unbekannte_Namen`, `Setze_ueberschreibt_vorhandene_Eintraege`,
`MitVorwahl_listet_passende_Namen_sortiert` und
`Entferne_meldet_ob_etwas_entfernt_wurde`.
