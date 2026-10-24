public class SichererZaehler : IZaehler
{
    readonly object _sperre = new();
    int _wert;

    public void Erhoehe()
    {
        lock (_sperre)
        {
            _wert++;
        }
    }

    public int Wert
    {
        get
        {
            lock (_sperre)
            {
                return _wert;
            }
        }
    }
}
