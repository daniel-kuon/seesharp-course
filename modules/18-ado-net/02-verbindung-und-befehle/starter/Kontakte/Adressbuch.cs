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

    /// <summary>Legt die Tabelle an, falls es sie noch nicht gibt:
    /// Kontakt(Id INTEGER PRIMARY KEY, Name TEXT NOT NULL, Telefon TEXT).</summary>
    public void Erzeuge()
    {
        // TODO: Befehl erzeugen (using!), CREATE TABLE IF NOT EXISTS ... ausführen (ExecuteNonQuery).
        throw new NotImplementedException();
    }

    /// <summary>Fügt einen Kontakt ein. telefon darf null sein; dann wird NULL gespeichert.</summary>
    public void Hinzufuegen(string name, string? telefon)
    {
        // TODO: INSERT mit den Parametern @name und @telefon (niemals Text verketten).
        // Hinweis: Ein null in C# wird als DBNull.Value übergeben.
        throw new NotImplementedException();
    }

    /// <summary>Anzahl der Kontakte.</summary>
    public long Anzahl()
    {
        // TODO: SELECT COUNT(*) FROM Kontakt mit ExecuteScalar; das Ergebnis ist ein long (als object).
        throw new NotImplementedException();
    }

    /// <summary>Setzt bei allen Kontakten mit diesem Namen die Telefonnummer neu.
    /// Liefert die Zahl der geänderten Zeilen.</summary>
    public int Aendere(string name, string? neuesTelefon)
    {
        // TODO: UPDATE ... WHERE Name = @name; ExecuteNonQuery liefert die betroffenen Zeilen.
        throw new NotImplementedException();
    }

    /// <summary>Löscht alle Kontakte mit diesem Namen. Liefert die Zahl der gelöschten Zeilen.</summary>
    public int Entferne(string name)
    {
        // TODO: DELETE ... WHERE Name = @name
        throw new NotImplementedException();
    }

    /// <summary>Telefonnummer des (ersten) Kontakts mit diesem Namen; null, wenn es den Kontakt
    /// nicht gibt oder keine Nummer gespeichert ist.</summary>
    public string? Telefon(string name)
    {
        // TODO: ExecuteScalar liefert null (keine Zeile) oder DBNull.Value (Zeile, aber NULL).
        // Beides muss zu null werden, bevor du in string umwandelst.
        throw new NotImplementedException();
    }

    /// <summary>Zählt die Kontakte in einer Datenbankdatei. Öffnet dazu eine EIGENE Verbindung
    /// (Pfade können Leerzeichen, Umlaute und Kommas enthalten) und schließt sie wieder.</summary>
    public static int ZaehleInDatei(string dateipfad)
    {
        // TODO: new SqliteConnection($"Data Source={dateipfad}"), Open(), SELECT COUNT(*) FROM Kontakt.
        // Die Verbindung gehört in eine using-Anweisung.
        throw new NotImplementedException();
    }
}
