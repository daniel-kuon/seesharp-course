// Kreis ist eine Figur: die Basisklasse steht hinter dem Doppelpunkt.
public class Kreis : Figur {
    double radius = 75.0;

    // TODO: x und y an den Basiskonstruktor weiterreichen (: base(x, y))
    public Kreis(double x, double y, double rad) {
        // TODO: rad nur übernehmen, wenn >= 0
    }
    public Kreis() { }

    public double Radius {
        get { return radius; }
        set { if (value >= 0.0) radius = value; }
    }

    // Untere rechte Ecke des umschließenden Quadrats.
    public (double X, double Y) UntenRechts {
        get {
            // TODO: (xpos + 2 * radius, ypos + 2 * radius)
            throw new NotImplementedException();
        }
    }
}
