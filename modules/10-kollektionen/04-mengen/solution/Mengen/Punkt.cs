public class Punkt(int x, int y)
{
    public int X { get; } = x;
    public int Y { get; } = y;

    public override string ToString() => $"({X}, {Y})";

    // Zwei Punkte sind gleich, wenn X und Y übereinstimmen.
    public override bool Equals(object? obj)
    {
        return obj is Punkt p && p.X == X && p.Y == Y;
    }

    // Gleiche Punkte müssen denselben Hashwert liefern.
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }
}
