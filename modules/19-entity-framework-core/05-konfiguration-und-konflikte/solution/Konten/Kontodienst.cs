using Microsoft.EntityFrameworkCore;

namespace Konten;

public class Kontodienst
{
    private readonly DbContextOptions<KontoContext> _optionen;

    public Kontodienst(DbContextOptions<KontoContext> optionen)
    {
        _optionen = optionen;
    }

    public int Anlegen(string inhaber, decimal saldo, Status status = Status.Aktiv)
    {
        using var kontext = new KontoContext(_optionen);
        kontext.Database.EnsureCreated();
        var konto = new Konto { Inhaber = inhaber, Saldo = saldo, Status = status, Version = 1 };
        kontext.Konten.Add(konto);
        kontext.SaveChanges();
        return konto.Id;
    }

    public void Ueberweisung(int von, int nach, decimal betrag)
    {
        using var kontext = new KontoContext(_optionen);
        using var transaktion = kontext.Database.BeginTransaction();
        try
        {
            var quelle = kontext.Konten.Find(von)
                ?? throw new InvalidOperationException($"Konto {von} gibt es nicht.");
            if (quelle.Saldo < betrag)
                throw new InvalidOperationException($"Auf Konto {von} fehlt Guthaben.");
            quelle.Saldo -= betrag;
            quelle.Version++;
            kontext.SaveChanges();

            var ziel = kontext.Konten.Find(nach)
                ?? throw new InvalidOperationException($"Konto {nach} gibt es nicht.");
            ziel.Saldo += betrag;
            ziel.Version++;
            kontext.SaveChanges();

            transaktion.Commit();
        }
        catch
        {
            transaktion.Rollback();
            throw;
        }
    }
}
