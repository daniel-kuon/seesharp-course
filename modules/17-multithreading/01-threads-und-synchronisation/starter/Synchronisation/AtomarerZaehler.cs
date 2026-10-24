public class AtomarerZaehler : IZaehler
{
    int _wert;

    // TODO: Mit Interlocked.Increment(ref _wert) atomar erhöhen, ohne lock.
    public void Erhoehe()
    {
        throw new NotImplementedException();
    }

    // Hinweis: Volatile.Read(ref _wert) liest den aktuellen Wert.
    public int Wert => throw new NotImplementedException();
}
