using Microsoft.Data.Sqlite;

namespace Bankprotokoll;

/// <summary>
/// Überweisungen mit Protokoll. Tabellen (legen die Tests an):
///   Konto(Id INTEGER PRIMARY KEY, Inhaber TEXT, Saldo REAL)
///   Protokoll(Id INTEGER PRIMARY KEY, Von INTEGER, Nach INTEGER, Betrag REAL)
/// Die Verbindung gehört dem Aufrufer und ist offen.
/// </summary>
public static class Bank
{
    /// <summary>
    /// Bucht betrag von Konto von auf Konto nach um und schreibt eine Zeile in Protokoll (Von, Nach, Betrag).
    /// Reicht das Guthaben nicht oder fehlt ein Konto: InvalidOperationException. Scheitert irgendein
    /// Schritt (auch das Protokollieren), darf NICHTS davon übrig bleiben: weder Buchung noch Protokollzeile.
    /// Fehler werden nach dem Rollback mit "throw;" weitergereicht.
    /// </summary>
    public static void Ueberweise(SqliteConnection c, int von, int nach, decimal betrag)
    {
        // TODO: Bisher läuft alles ohne Transaktion: Scheitert das Gutschreiben, ist das Geld weg.
        //  1. Eine Transaktion beginnen und an alle Befehle hängen (siehe Aendere: der Parameter transaktion).
        //  2. Nach dem Gutschreiben die Zeile ins Protokoll einfügen (Parameter!), ebenfalls in der Transaktion.
        //  3. Commit(); bei einer Ausnahme Rollback() und mit "throw;" weiterreichen.
        if (Aendere(c, null, "UPDATE Konto SET Saldo = Saldo - @betrag WHERE Id = @id AND Saldo >= @betrag", von, betrag) == 0)
            throw new InvalidOperationException($"Konto {von} fehlt oder das Guthaben reicht nicht.");
        if (Aendere(c, null, "UPDATE Konto SET Saldo = Saldo + @betrag WHERE Id = @id", nach, betrag) == 0)
            throw new InvalidOperationException($"Zielkonto {nach} fehlt.");
    }

    /// <summary>Alle Protokollzeilen in der Reihenfolge ihrer Entstehung (nach Id).</summary>
    public static List<(int von, int nach, decimal betrag)> Protokoll(SqliteConnection c)
    {
        using var befehl = c.CreateCommand();
        befehl.CommandText = "SELECT Von, Nach, Betrag FROM Protokoll ORDER BY Id";
        using var leser = befehl.ExecuteReader();
        var zeilen = new List<(int, int, decimal)>();
        while (leser.Read())
            zeilen.Add((leser.GetInt32(0), leser.GetInt32(1), leser.GetDecimal(2)));
        return zeilen;
    }

    private static int Aendere(SqliteConnection c, SqliteTransaction? transaktion, string sql, int konto, decimal betrag)
    {
        using var befehl = c.CreateCommand();
        befehl.Transaction = transaktion;
        befehl.CommandText = sql;
        befehl.Parameters.AddWithValue("@id", konto);
        befehl.Parameters.AddWithValue("@betrag", betrag);
        return befehl.ExecuteNonQuery();
    }
}
