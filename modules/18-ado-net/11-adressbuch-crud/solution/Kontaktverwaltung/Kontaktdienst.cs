using Microsoft.Data.Sqlite;

namespace Kontaktverwaltung;

/// <summary>Ein Kontakt; Telefon ist null, wenn keine Nummer gespeichert ist.</summary>
public record Kontakt(long Id, string Name, string? Telefon);

/// <summary>Verwaltet die Tabelle Kontakt(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Telefon TEXT).</summary>
public class Kontaktdienst
{
    private readonly SqliteConnection _verbindung;

    public Kontaktdienst(SqliteConnection verbindung)
    {
        _verbindung = verbindung;
    }

    public long Neu(string name, string? telefon)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "INSERT INTO Kontakt (Name, Telefon) VALUES (@name, @telefon) RETURNING Id";
        befehl.Parameters.AddWithValue("@name", name);
        befehl.Parameters.AddWithValue("@telefon", (object?)telefon ?? DBNull.Value);
        return (long)befehl.ExecuteScalar()!;
    }

    public bool Aendern(long id, string name, string? telefon)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "UPDATE Kontakt SET Name = @name, Telefon = @telefon WHERE Id = @id";
        befehl.Parameters.AddWithValue("@id", id);
        befehl.Parameters.AddWithValue("@name", name);
        befehl.Parameters.AddWithValue("@telefon", (object?)telefon ?? DBNull.Value);
        return befehl.ExecuteNonQuery() > 0;
    }

    public bool Loeschen(long id)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "DELETE FROM Kontakt WHERE Id = @id";
        befehl.Parameters.AddWithValue("@id", id);
        return befehl.ExecuteNonQuery() > 0;
    }

    public List<Kontakt> Suche(string teil)
    {
        using var befehl = _verbindung.CreateCommand();
        befehl.CommandText = "SELECT Id, Name, Telefon FROM Kontakt WHERE Name LIKE @muster ORDER BY Name, Id";
        befehl.Parameters.AddWithValue("@muster", "%" + teil + "%");
        var ergebnis = new List<Kontakt>();
        using var leser = befehl.ExecuteReader();
        while (leser.Read())
        {
            ergebnis.Add(new Kontakt(
                leser.GetInt64(0),
                leser.GetString(1),
                leser.IsDBNull(2) ? null : leser.GetString(2)));
        }
        return ergebnis;
    }
}
