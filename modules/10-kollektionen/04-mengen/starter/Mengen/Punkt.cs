public class Punkt(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public override string ToString() => $"({X}, {Y})";

    // TODO: Überschreibe Equals(object?): Zwei Punkte sind gleich, wenn X und Y
    // übereinstimmen (null und fremde Typen sind nie gleich).

    // TODO: Überschreibe GetHashCode() passend dazu: HashCode.Combine(X, Y).
    // Gleiche Punkte müssen denselben Hashwert liefern, sonst findet ein
    // HashSet<Punkt> sie nicht.
}
