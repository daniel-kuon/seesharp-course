public class Rechteck : Figur {
    double breite = 50.0, hoehe = 50.0;

    public Rechteck(double x, double y, double b, double h) : base(x, y) {
        if (b >= 0.0 && h >= 0.0) {
            breite = b;
            hoehe = h;
        }
    }
    public Rechteck() { }

    public (double X, double Y) UntenRechts {
        get {
            return (xpos + breite, ypos + hoehe);
        }
    }
}
