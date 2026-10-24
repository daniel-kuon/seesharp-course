// Kennzeichnet eine Eigenschaft, die als Spalte "name" gespeichert werden soll.
[AttributeUsage(AttributeTargets.Property)]
public sealed class SpalteAttribute : Attribute
{
    public SpalteAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
