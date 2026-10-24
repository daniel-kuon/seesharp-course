using Microsoft.Data.Sqlite;

namespace Bankgeschaefte;

/// <summary>
/// Überweisungen zwischen Konten der Tabelle Konto(Id INTEGER PRIMARY KEY, Inhaber TEXT, Saldo REAL).
/// Eine Überweisung besteht aus zwei UPDATE-Befehlen (abbuchen, gutschreiben). Beide müssen
/// zusammen gelingen oder zusammen scheitern: dafür sind Transaktionen da.
/// </summary>
public static class Bank
{
    public static void Ueberweise(SqliteConnection c, int von, int nach, decimal betrag, Action? nachAbbuchung = null)
    {
        using var transaktion = c.BeginTransaction();
        try
        {
            Abbuchen(c, transaktion, von, betrag);
            nachAbbuchung?.Invoke();
            Gutschreiben(c, transaktion, nach, betrag);
            transaktion.Commit();
        }
        catch
        {
            transaktion.Rollback();
            throw;
        }
    }

    public static void Mehrfach(SqliteConnection c, IEnumerable<(int von, int nach, decimal betrag)> ueberweisungen)
    {
        using var transaktion = c.BeginTransaction();
        try
        {
            foreach (var (von, nach, betrag) in ueberweisungen)
            {
                Abbuchen(c, transaktion, von, betrag);
                Gutschreiben(c, transaktion, nach, betrag);
            }
            transaktion.Commit();
        }
        catch
        {
            transaktion.Rollback();
            throw;
        }
    }

    private static void Abbuchen(SqliteConnection c, SqliteTransaction transaktion, int konto, decimal betrag)
    {
        if (Aendere(c, transaktion, "UPDATE Konto SET Saldo = Saldo - @betrag WHERE Id = @id AND Saldo >= @betrag", konto, betrag) == 0)
            throw new InvalidOperationException($"Konto {konto} fehlt oder das Guthaben reicht nicht für {betrag}.");
    }

    private static void Gutschreiben(SqliteConnection c, SqliteTransaction transaktion, int konto, decimal betrag)
    {
        if (Aendere(c, transaktion, "UPDATE Konto SET Saldo = Saldo + @betrag WHERE Id = @id", konto, betrag) == 0)
            throw new InvalidOperationException($"Zielkonto {konto} fehlt.");
    }

    private static int Aendere(SqliteConnection c, SqliteTransaction transaktion, string sql, int konto, decimal betrag)
    {
        using var befehl = c.CreateCommand();
        befehl.Transaction = transaktion;
        befehl.CommandText = sql;
        befehl.Parameters.AddWithValue("@id", konto);
        befehl.Parameters.AddWithValue("@betrag", betrag);
        return befehl.ExecuteNonQuery();
    }
}
