using Microsoft.Data.Sqlite;

namespace Bankprotokoll;

/// <summary>Überweisungen mit Protokoll: Buchung und Protokollzeile gehören zu einer Transaktion.</summary>
public static class Bank
{
    public static void Ueberweise(SqliteConnection c, int von, int nach, decimal betrag)
    {
        using var transaktion = c.BeginTransaction();
        try
        {
            if (Aendere(c, transaktion, "UPDATE Konto SET Saldo = Saldo - @betrag WHERE Id = @id AND Saldo >= @betrag", von, betrag) == 0)
                throw new InvalidOperationException($"Konto {von} fehlt oder das Guthaben reicht nicht.");
            if (Aendere(c, transaktion, "UPDATE Konto SET Saldo = Saldo + @betrag WHERE Id = @id", nach, betrag) == 0)
                throw new InvalidOperationException($"Zielkonto {nach} fehlt.");

            using var protokoll = c.CreateCommand();
            protokoll.Transaction = transaktion;
            protokoll.CommandText = "INSERT INTO Protokoll (Von, Nach, Betrag) VALUES (@von, @nach, @betrag)";
            protokoll.Parameters.AddWithValue("@von", von);
            protokoll.Parameters.AddWithValue("@nach", nach);
            protokoll.Parameters.AddWithValue("@betrag", betrag);
            protokoll.ExecuteNonQuery();

            transaktion.Commit();
        }
        catch
        {
            transaktion.Rollback();
            throw;
        }
    }

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
