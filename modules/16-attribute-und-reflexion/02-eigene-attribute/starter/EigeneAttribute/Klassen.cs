public interface IRechnung
{
    int Berechne(int a, int b);
}

public class StandardRechnung : IRechnung
{
    public int Berechne(int a, int b) => a + b;
}

// TODO: Versieh die Klasse mit
//         - zwei [Autor]-Attributen: ("Anna", Version = 2) und ("Ben", ohne Version),
//         - [Implementierung<StandardRechnung>].
public class Rechner
{
    // TODO: [Autor("Ben", Version = 3)]
    public int Addiere(int a, int b) => a + b;

    public int Teile(int a, int b) => a / b;
}

public class Person
{
    // TODO: [Spalte("name")]
    public string Name { get; set; } = "";

    // TODO: [Spalte("alter")]
    public int Alter { get; set; }

    // Das Passwort wird nicht gespeichert: kein [Spalte].
    public string Passwort { get; set; } = "";
}
