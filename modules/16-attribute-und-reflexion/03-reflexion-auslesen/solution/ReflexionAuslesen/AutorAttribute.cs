// Vorgegeben: das Attribut aus der vorigen Übung.
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public sealed class AutorAttribute : Attribute
{
    public AutorAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
