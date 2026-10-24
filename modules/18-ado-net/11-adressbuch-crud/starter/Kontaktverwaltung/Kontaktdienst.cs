using Microsoft.Data.Sqlite;

namespace Kontaktverwaltung;

/// <summary>Ein Kontakt; Telefon ist null, wenn keine Nummer gespeichert ist.</summary>
public record Kontakt(long Id, string Name, string? Telefon);

/// <summary>
/// Verwaltet die Tabelle Kontakt(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Telefon TEXT), die
/// es bereits gibt. Die offene Verbindung gehört dem Aufrufer. Alle Werte kommen als Parameter in
/// die Befehle; Befehle und Leser werden mit using freigegeben.
/// </summary>
public class Kontaktdienst
{
    private readonly SqliteConnection _verbindung;

    public Kontaktdienst(SqliteConnection verbindung)
    {
        _verbindung = verbindung;
    }

    /// <summary>Legt einen Kontakt an und liefert seine neue Id.</summary>
    public long Neu(string name, string? telefon)
    {
        // TODO: INSERT mit Parametern. Die neue Id liefert "SELECT last_insert_rowid()" (ExecuteScalar)
        // oder "INSERT ... RETURNING Id". Telefon null -> DBNull.Value.
        throw new NotImplementedException();
    }

    /// <summary>Ändert Name und Telefon des Kontakts. Liefert true, wenn es den Kontakt gab.</summary>
    public bool Aendern(long id, string name, string? telefon)
    {
        // TODO: UPDATE ... WHERE Id = @id; ExecuteNonQuery liefert die Zahl der Zeilen.
        throw new NotImplementedException();
    }

    /// <summary>Löscht den Kontakt. Liefert true, wenn es den Kontakt gab.</summary>
    public bool Loeschen(long id)
    {
        // TODO
        throw new NotImplementedException();
    }

    /// <summary>Alle Kontakte, deren Name den Text teil enthält, nach Name sortiert (Telefon kann null sein).</summary>
    public List<Kontakt> Suche(string teil)
    {
        // TODO: ... WHERE Name LIKE @muster ORDER BY Name, Id; @muster = "%" + teil + "%".
        // Beim Lesen erst IsDBNull fragen, bevor du GetString für Telefon aufrufst.
        throw new NotImplementedException();
    }
}
