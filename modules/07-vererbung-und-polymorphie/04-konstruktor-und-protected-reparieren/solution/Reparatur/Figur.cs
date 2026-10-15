// Aufgabe 2 aus 7.16: Kreis kommt nicht an seine geerbten Felder heran.
public class Figur {
    double xpos = 100.0;
    double ypos = 100.0;

    public Figur(double x, double y) {
        if (x >= 0.0 && y >= 0.0) {
            xpos = x;
            ypos = y;
        }
    }
    public Figur() { }

    public (double, double) Wo => (xpos, ypos);
}

public class Kreis : Figur {
    double radius = 75.0;

    // Private Mitglieder werden zwar vererbt (jedes Kreis-Objekt hat xpos und ypos),
    // sind in der abgeleiteten Klasse aber nicht zugänglich (CS0122). Die saubere Lösung:
    // die Position dem Basiskonstruktor überlassen, der sie ohnehin validiert.
    public Kreis(double x, double y, double rad) : base(x, y) {
        if (rad >= 0.0)
            radius = rad;
    }
    public Kreis() { }

    public double Radius => radius;
}
