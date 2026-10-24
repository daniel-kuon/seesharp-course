using Microsoft.Data.Sqlite;

namespace Kontakte;

/// <summary>
/// Ein Adressbuch in der SQLite-Tabelle Kontakt. Die Verbindung gehört dem Aufrufer
/// (die Tests übergeben eine offene Verbindung): Adressbuch öffnet und schließt sie nicht,
/// sondern erzeugt pro Aufruf nur einen eigenen Befehl.
/// </summary>
public class Adressbuch
{
    private readonly SqliteConnection _verbindung;

    public Adressbuch(SqliteConnection verbindung)
    {
        _verbindung = verbindung;
    }

    /// <summary>Legt die Tabelle an, falls es sie noch nicht gibt.</summary>
    public void Erzeuge()
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "CREATE TABLE IF NOT EXISTS Kontakt(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Telefon TEXT)";
        befehl.ExecuteNonQuery();
    }

    /// <summary>Fügt einen Kontakt ein. telefon darf null sein; dann wird NULL gespeichert.</summary>
    public void Hinzufuegen(string name, string? telefon)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "INSERT INTO Kontakt (Name, Telefon) VALUES (@name, @telefon)";
        befehl.Parameters.AddWithValue("@name", name);
        befehl.Parameters.AddWithValue("@telefon", (object?)telefon ?? DBNull.Value);
        befehl.ExecuteNonQuery();
    }

    /// <summary>Anzahl der Kontakte.</summary>
    public long Anzahl()
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "SELECT COUNT(*) FROM Kontakt";
        return (long)befehl.ExecuteScalar()!;
    }

    /// <summary>Setzt bei allen Kontakten mit diesem Namen die Telefonnummer neu.</summary>
    public int Aendere(string name, string? neuesTelefon)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "UPDATE Kontakt SET Telefon = @telefon WHERE Name = @name";
        befehl.Parameters.AddWithValue("@name", name);
        befehl.Parameters.AddWithValue("@telefon", (object?)neuesTelefon ?? DBNull.Value);
        return befehl.ExecuteNonQuery();
    }

    /// <summary>Löscht alle Kontakte mit diesem Namen.</summary>
    public int Entferne(string name)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "DELETE FROM Kontakt WHERE Name = @name";
        befehl.Parameters.AddWithValue("@name", name);
        return befehl.ExecuteNonQuery();
    }

    /// <summary>Telefonnummer des (ersten) Kontakts mit diesem Namen; null, wenn es den Kontakt
    /// nicht gibt oder keine Nummer gespeichert ist.</summary>
    public string? Telefon(string name)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "SELECT Telefon FROM Kontakt WHERE Name = @name ORDER BY Id LIMIT 1";
        befehl.Parameters.AddWithValue("@name", name);
        object? ergebnis = befehl.ExecuteScalar();
        return ergebnis is null or DBNull ? null : (string)ergebnis;
    }

    /// <summary>Zählt die Kontakte in einer Datenbankdatei mit einer eigenen Verbindung.</summary>
    public static int ZaehleInDatei(string dateipfad)
    {
        using var verbindung = new SqliteConnection($"Data Source={dateipfad}");
        verbindung.Open();
        using var befehl = verbindung.CreateCommand();
        befehl.CommandText = "SELECT COUNT(*) FROM Kontakt";
        return Convert.ToInt32(befehl.ExecuteScalar());
    }
}
