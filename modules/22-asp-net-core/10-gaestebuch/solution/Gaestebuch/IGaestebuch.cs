// Die Abhängigkeit des PageModels. Alle() liefert die Einträge in der Reihenfolge des Eintragens (älteste zuerst).
public interface IGaestebuch
{
    void Hinzufuegen(Eintrag eintrag);
    IReadOnlyList<Eintrag> Alle();
}

public class SpeicherGaestebuch : IGaestebuch
{
    private readonly List<Eintrag> _eintraege = [];

    public void Hinzufuegen(Eintrag eintrag)
    {
        lock (_eintraege)
            _eintraege.Add(eintrag);
    }

    public IReadOnlyList<Eintrag> Alle()
    {
        lock (_eintraege)
            return _eintraege.ToList();
    }
}
