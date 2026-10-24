[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
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
