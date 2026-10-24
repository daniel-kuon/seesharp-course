public interface IRechnung
{
    int Berechne(int a, int b);
}

public class StandardRechnung : IRechnung
{
    public int Berechne(int a, int b) => a + b;
}

[Autor("Anna", Version = 2)]
[Autor("Ben")]
[Implementierung<StandardRechnung>]
public class Rechner
{
    [Autor("Ben", Version = 3)]
    public int Addiere(int a, int b) => a + b;

    public int Teile(int a, int b) => a / b;
}

public class Person
{
    [Spalte("name")]
    public string Name { get; set; } = "";

    [Spalte("alter")]
    public int Alter { get; set; }

    // Das Passwort wird nicht gespeichert: kein [Spalte].
    public string Passwort { get; set; } = "";
}
