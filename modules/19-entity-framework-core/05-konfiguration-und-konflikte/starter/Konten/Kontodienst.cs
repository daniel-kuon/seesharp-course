using Microsoft.EntityFrameworkCore;

namespace Konten;

public class Kontodienst
{
    private readonly DbContextOptions<KontoContext> _optionen;

    public Kontodienst(DbContextOptions<KontoContext> optionen)
    {
        _optionen = optionen;
    }

    /// <summary>Vorgegeben: legt ein Konto an (Version 1) und liefert seine Id.</summary>
    public int Anlegen(string inhaber, decimal saldo, Status status = Status.Aktiv)
    {
        using var kontext = new KontoContext(_optionen);
        kontext.Database.EnsureCreated();
        var konto = new Konto { Inhaber = inhaber, Saldo = saldo, Status = status, Version = 1 };
        kontext.Konten.Add(konto);
        kontext.SaveChanges();
        return konto.Id;
    }

    /// <summary>
    /// Bucht betrag vom Konto von auf das Konto nach um, in einer expliziten Transaktion
    /// (kontext.Database.BeginTransaction()). Erst wird abgebucht und mit SaveChanges gespeichert, dann
    /// gutgeschrieben und noch einmal gespeichert; danach Commit. Fehlt ein Konto oder reicht der Saldo
    /// des Quellkontos nicht: InvalidOperationException. Bei JEDER Ausnahme Rollback und "throw;": Es bleibt
    /// keine halbe Überweisung zurück. Bei jeder Änderung die Version hochzählen.
    /// </summary>
    public void Ueberweisung(int von, int nach, decimal betrag)
    {
        // TODO: using var kontext...; using var transaktion = kontext.Database.BeginTransaction();
        //       try { ... transaktion.Commit(); } catch { transaktion.Rollback(); throw; }
        throw new NotImplementedException();
    }
}
