public abstract class Figur {
    protected double xpos = 100.0, ypos = 100.0;

    public Figur(double x, double y) {
        if (x >= 0.0 && y >= 0.0) {
            xpos = x;
            ypos = y;
        }
    }
    public Figur() { }

    public virtual string Wo() => $"Oben Links: ({xpos:0}; {ypos:0})";

    public abstract void Skaliere(double faktor);

    public abstract double Inhalt { get; }

    public abstract double Breite { get; }

    // Summe der Flächeninhalte aller Figuren.
    public static double Gesamtflaeche(Figur[] figuren) {
        double ges = 0.0;
        foreach (var f in figuren)
            ges += f.Inhalt;
        return ges;
    }
}
