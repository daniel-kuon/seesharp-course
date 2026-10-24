namespace SqlGrundlagen;

/// <summary>
/// SQL-Skripte für SQLite. Jedes Mitglied ist ein Text, den die Tests gegen eine
/// frische Datenbank im Speicher ausführen. Rohtext-Literale ("""...""") erlauben
/// mehrzeiliges SQL ohne Escapen.
/// </summary>
public static class Skripte
{
    // TODO: Tabellen Kategorie und Artikel anlegen (siehe Aufgabenbeschreibung):
    // Primärschlüssel, UNIQUE, NOT NULL, CHECK und den Fremdschlüssel nicht vergessen.
    public const string Schema = "-- TODO";

    // TODO: die 4 Kategorien und 8 Artikel aus der Aufgabenbeschreibung einfügen
    // (mit den vorgegebenen Id-Werten).
    public const string Daten = "-- TODO";

    // TODO: Spalten Name, Preis; nur Artikel über 10; teuerste zuerst.
    public const string TeureArtikel = "-- TODO";

    // TODO: Spalten Kategorie (Name der Kategorie) und Name (des Artikels); JOIN;
    // sortiert nach Kategorie, dann nach Artikelname.
    public const string ArtikelMitKategorie = "-- TODO";

    // TODO: Spalten Kategorie und Anzahl; GROUP BY; HAVING COUNT(*) > 1;
    // sortiert nach Anzahl absteigend, dann nach Kategorie.
    public const string AnzahlProKategorie = "-- TODO";

    // TODO: UPDATE: alle Preise der Kategorie 'Garten' um 10 % erhöhen.
    public const string Preiserhoehung = "-- TODO";

    // TODO: DELETE: alle Kategorien ohne Artikel löschen (NOT EXISTS).
    public const string LoescheLeereKategorien = "-- TODO";
}
