// TODO: Klasse abstract machen; Skaliere, Inhalt und Breite werden abstrakt (ohne Rumpf).
public class Figur {
    protected double xpos = 100.0, ypos = 100.0;

    public Figur(double x, double y) {
        if (x >= 0.0 && y >= 0.0) {
            xpos = x;
            ypos = y;
        }
    }
    public Figur() { }

    public virtual string Wo() => $"Oben Links: ({xpos:0}; {ypos:0})";

    public virtual void Skaliere(double faktor) { }

    public virtual double Inhalt => 0.0;

    public virtual double Breite => 0.0;

    // Summe der Flächeninhalte aller Figuren.
    public static double Gesamtflaeche(Figur[] figuren) {
        // TODO
        throw new NotImplementedException();
    }
}
