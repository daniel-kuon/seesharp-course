public class AtomarerZaehler : IZaehler
{
    int _wert;

    public void Erhoehe() => Interlocked.Increment(ref _wert);

    public int Wert => Volatile.Read(ref _wert);
}
