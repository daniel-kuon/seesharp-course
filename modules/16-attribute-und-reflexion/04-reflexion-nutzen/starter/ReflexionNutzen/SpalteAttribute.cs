// Vorgegeben (aus Übung 2): kennzeichnet eine Eigenschaft als Spalte mit festem Namen.
[AttributeUsage(AttributeTargets.Property)]
public sealed class SpalteAttribute : Attribute
{
    public SpalteAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
