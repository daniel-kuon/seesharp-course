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

    // TODO: Zwei Reparaturen sind möglich: die Felder in Figur protected machen, oder (besser)
    //       die Validierung der Position dem Basiskonstruktor überlassen (: base(x, y)).
    public Kreis(double x, double y, double rad) {
        if (x >= 0.0 && y >= 0.0 && rad >= 0.0) {
            xpos = x;
            ypos = y;
            radius = rad;
        }
    }
    public Kreis() { }

    public double Radius => radius;
}
