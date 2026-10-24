// Kennzeichnet eine Eigenschaft, die als Spalte "name" gespeichert werden soll.
// TODO 1: Ableiten von System.Attribute.
// TODO 2: Nur an Eigenschaften erlaubt (AttributeTargets.Property).
public class SpalteAttribute
{
    public SpalteAttribute(string name)
    {
        Name = name;
    }

    public string Name { get; }
}
