namespace Nulloperatoren;

public class Adresse
{
    public string? Ort { get; set; }
}

public class Kunde
{
    public Adresse? Adresse { get; set; }
    public string? Name { get; set; }
    public int Alter { get; set; }
}

public class Zaehler
{
    public List<string>? Eintraege { get; private set; }

    public void Fuege(string eintrag)
    {
        Eintraege ??= new List<string>();
        Eintraege.Add(eintrag);
    }
}
