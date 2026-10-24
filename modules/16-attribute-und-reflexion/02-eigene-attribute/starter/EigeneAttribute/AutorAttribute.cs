// TODO 1: Mach aus der Klasse ein Attribut (Basisklasse System.Attribute).
// TODO 2: Beschränke mit [AttributeUsage] die Ziele auf Klassen und Methoden
//         (AttributeTargets.Class | AttributeTargets.Method) und erlaube,
//         dass das Attribut mehrfach am selben Ziel steht (AllowMultiple = true).
// TODO 3: 'Version' ist ein benannter Parameter ([Autor("Anna", Version = 2)])
//         und soll 1 sein, wenn er fehlt.
public class AutorAttribute
{
    public AutorAttribute(string name)
    {
        Name = name;
    }

    // Positionaler Parameter: wird im Konstruktor übergeben.
    public string Name { get; }

    // Benannter Parameter: öffentlich und schreibbar.
    public int Version { get; set; }
}
