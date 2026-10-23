// Ein Punkt in der Ebene (fertig).
public class Punkt(double x, double y) {
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    public void Verschiebe(double dx, double dy) {
        X += dx;
        Y += dy;
    }

    public Punkt Klone() {
        return new Punkt(X, Y);
    }

    public override string ToString() {
        return $"({X}; {Y})";
    }
}
