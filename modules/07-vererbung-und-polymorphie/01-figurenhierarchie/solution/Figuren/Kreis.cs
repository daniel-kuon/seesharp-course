public class Kreis : Figur {
    double radius = 75.0;

    public Kreis(double x, double y, double rad) : base(x, y) {
        if (rad >= 0.0)
            radius = rad;
    }
    public Kreis() { }

    public double Radius {
        get { return radius; }
        set { if (value >= 0.0) radius = value; }
    }

    // Untere rechte Ecke des umschließenden Quadrats.
    public (double X, double Y) UntenRechts {
        get {
            return (xpos + 2.0 * radius, ypos + 2.0 * radius);
        }
    }
}
