// sealed: Microsoft empfiehlt versiegelte Attributklassen, weil GetCustomAttributes dann
// keine abgeleiteten Klassen berücksichtigen muss (Buch 14.6, Seite 942).
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AutorAttribute : Attribute
{
    public AutorAttribute(string name)
    {
        Name = name;
    }

    // Positionaler Parameter: wird im Konstruktor übergeben.
    public string Name { get; }

    // Benannter Parameter: öffentlich und schreibbar, Standardwert 1.
    public int Version { get; set; } = 1;
}
