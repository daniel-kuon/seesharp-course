using Microsoft.EntityFrameworkCore;

namespace Konten;

public static class Konfliktloeser
{
    public static int Speichere(KontoContext kontext, Konto konto, Action<Konto> aenderung)
    {
        aenderung(konto);
        konto.Version++;
        try
        {
            kontext.SaveChanges();
            return 1;
        }
        catch (DbUpdateConcurrencyException)
        {
            kontext.Entry(konto).Reload();   // frischer Stand aus der Datenbank, inklusive neuer Version
            aenderung(konto);
            konto.Version++;
            kontext.SaveChanges();           // scheitert es erneut, erfährt es der Aufrufer
            return 2;
        }
    }
}
