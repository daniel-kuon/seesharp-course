// Kennzeichnet eine ganzzahlige Eigenschaft, deren Wert zwischen Min und Max (beide einschließlich) liegen muss.
// TODO: Mit [AttributeUsage] nur an Eigenschaften erlauben, nicht mehrfach.
public sealed class BereichAttribute : Attribute
{
    public BereichAttribute(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public int Min { get; }
    public int Max { get; }
}
