namespace Nullsicherheit;

public class Kunde
{
    public string Name { get; }
    public string? Spitzname { get; set; }

    public Kunde(string name)
    {
        Name = name;
    }

    public string Anzeige() =>
        Spitzname is null ? Name : $"{Name} ({Spitzname})";
}
