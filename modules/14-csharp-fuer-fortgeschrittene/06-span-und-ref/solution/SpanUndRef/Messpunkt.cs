namespace SpanUndRef;

/// <summary>Bewusst große Struktur: Kopieren kostet, ein Verweis nicht.</summary>
public readonly struct Messpunkt(double x, double y, double z, double helligkeit)
{
    public double X { get; } = x;
    public double Y { get; } = y;
    public double Z { get; } = z;
    public double Helligkeit { get; } = helligkeit;
}
