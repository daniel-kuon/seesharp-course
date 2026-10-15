public class Figur {
    // protected: abgeleitete Klassen dürfen zugreifen, Fremde nicht.
    protected double xpos = 100.0, ypos = 100.0;

    public Figur(double x, double y) {
        if (x >= 0.0 && y >= 0.0) {
            xpos = x;
            ypos = y;
        }
    }
    public Figur() { }

    public (double X, double Y) Wo => (xpos, ypos);

    // Summe der Radien aller Kreise im Array (andere Figuren zählen nicht).
    public static double SummeRadien(Figur[] figuren) {
        // TODO: foreach über das Array, Typtest mit "is Kreis k"
        throw new NotImplementedException();
    }
}
