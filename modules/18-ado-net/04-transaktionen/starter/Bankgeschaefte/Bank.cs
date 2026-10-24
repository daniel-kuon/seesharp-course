using Microsoft.Data.Sqlite;

namespace Bankgeschaefte;

/// <summary>
/// Überweisungen zwischen Konten der Tabelle Konto(Id INTEGER PRIMARY KEY, Inhaber TEXT, Saldo REAL).
/// Eine Überweisung besteht aus zwei UPDATE-Befehlen (abbuchen, gutschreiben). Beide müssen
/// zusammen gelingen oder zusammen scheitern: dafür sind Transaktionen da.
/// Die Verbindung gehört dem Aufrufer und ist offen.
/// </summary>
public static class Bank
{
    /// <summary>
    /// Bucht betrag von Konto von auf Konto nach um. Fehlt eines der Konten oder reicht das Guthaben
    /// des Quellkontos nicht (der Saldo darf nicht negativ werden), wird ALLES zurückgenommen und
    /// eine InvalidOperationException geworfen. Jede andere Ausnahme, die in der Transaktion auftritt,
    /// führt ebenfalls zum Rollback und wird mit "throw;" unverändert weitergereicht.
    /// </summary>
    /// <param name="nachAbbuchung">Wird (falls nicht null) nach dem Abbuchen und vor dem Gutschreiben
    /// aufgerufen. Die Tests lösen damit mitten in der Transaktion einen Fehler aus.</param>
    public static void Ueberweise(SqliteConnection c, int von, int nach, decimal betrag, Action? nachAbbuchung = null)
    {
        // TODO: 1. Transaktion beginnen: c.BeginTransaction() (der Befehl muss ihr zugeordnet sein: befehl.Transaction = tx).
        //       2. try: abbuchen ("... SET Saldo = Saldo - @betrag WHERE Id = @id AND Saldo >= @betrag");
        //          0 betroffene Zeilen = Konto fehlt oder zu wenig Guthaben -> InvalidOperationException.
        //       3. nachAbbuchung?.Invoke(); dann gutschreiben (0 Zeilen = Zielkonto fehlt -> InvalidOperationException).
        //       4. Commit(). catch: Rollback() und die Ausnahme mit "throw;" weiterreichen.
        throw new NotImplementedException();
    }

    /// <summary>
    /// Führt alle Überweisungen in EINER Transaktion aus: Entweder werden alle gebucht oder keine.
    /// Scheitert eine (Konto fehlt, Guthaben reicht nicht), wird alles zurückgenommen und
    /// eine InvalidOperationException geworfen.
    /// </summary>
    public static void Mehrfach(SqliteConnection c, IEnumerable<(int von, int nach, decimal betrag)> ueberweisungen)
    {
        // TODO: Eine Transaktion um die ganze Schleife. Beachte: SQLite kennt keine verschachtelten
        // Transaktionen, du kannst hier also nicht einfach Ueberweise() mit seiner eigenen Transaktion aufrufen.
        // Lege die beiden UPDATEs in eine private Hilfsmethode, die eine bestehende Transaktion benutzt.
        throw new NotImplementedException();
    }
}
