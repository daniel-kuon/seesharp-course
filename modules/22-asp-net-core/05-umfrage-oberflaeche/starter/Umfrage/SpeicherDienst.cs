// Speichert die Stimmen im Arbeitsspeicher (statt in einer Datenbank wie im Buchbeispiel).
public class SpeicherDienst : IUmfrageDienst
{
    private readonly List<Stimme> _stimmen = [];

    public IReadOnlyList<Stimme> Stimmen()
    {
        lock (_stimmen)
            return _stimmen.ToList();
    }

    public void Abgeben(Stimme stimme)
    {
        lock (_stimmen)
            _stimmen.Add(stimme);
    }
}
