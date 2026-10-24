namespace SqlGrundlagen;

/// <summary>
/// SQL-Skripte für SQLite. Jedes Mitglied ist ein Text, den die Tests gegen eine
/// frische Datenbank im Speicher ausführen.
/// </summary>
public static class Skripte
{
    public const string Schema = """
        CREATE TABLE Kategorie (
            Id   INTEGER PRIMARY KEY,
            Name TEXT NOT NULL UNIQUE
        );
        CREATE TABLE Artikel (
            Id          INTEGER PRIMARY KEY,
            Name        TEXT NOT NULL,
            Preis       REAL CHECK (Preis >= 0),
            KategorieId INTEGER REFERENCES Kategorie (Id)
        );
        """;

    public const string Daten = """
        INSERT INTO Kategorie (Id, Name) VALUES
            (1, 'Werkzeug'), (2, 'Garten'), (3, 'Buero'), (4, 'Reserve');
        INSERT INTO Artikel (Id, Name, Preis, KategorieId) VALUES
            (1, 'Hammer',      12.50, 1),
            (2, 'Zange',        9.90, 1),
            (3, 'Saege',       18.00, 1),
            (4, 'Spaten',      24.90, 2),
            (5, 'Harke',       11.00, 2),
            (6, 'Giesskanne',   7.50, 2),
            (7, 'Handschuhe',   5.90, 2),
            (8, 'Locher',       4.20, 3);
        """;

    public const string TeureArtikel =
        "SELECT Name, Preis FROM Artikel WHERE Preis > 10 ORDER BY Preis DESC";

    public const string ArtikelMitKategorie = """
        SELECT k.Name AS Kategorie, a.Name
        FROM Artikel a
        JOIN Kategorie k ON k.Id = a.KategorieId
        ORDER BY k.Name, a.Name
        """;

    public const string AnzahlProKategorie = """
        SELECT k.Name AS Kategorie, COUNT(*) AS Anzahl
        FROM Artikel a
        JOIN Kategorie k ON k.Id = a.KategorieId
        GROUP BY k.Id, k.Name
        HAVING COUNT(*) > 1
        ORDER BY Anzahl DESC, Kategorie
        """;

    public const string Preiserhoehung = """
        UPDATE Artikel
        SET Preis = Preis * 1.10
        WHERE KategorieId = (SELECT Id FROM Kategorie WHERE Name = 'Garten')
        """;

    public const string LoescheLeereKategorien = """
        DELETE FROM Kategorie
        WHERE NOT EXISTS (SELECT 1 FROM Artikel WHERE Artikel.KategorieId = Kategorie.Id)
        """;
}
