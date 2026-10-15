public class Rechteck : Figur {
    double breite = 50.0, hoehe = 50.0;

    public Rechteck(double x, double y, double b, double h) : base(x, y) {
        if (b >= 0.0 && h >= 0.0) {
            breite = b;
            hoehe = h;
        }
    }
    public Rechteck() { }

    // TODO: Name ("Rechteck"), Wo() (zweite Zeile "Unten Rechts: (x + breite; y + hoehe)")
    //       und Skaliere (Breite und Höhe mit dem Faktor multiplizieren) überschreiben.
    //       Wo() soll außerdem versiegelt werden (sealed override), damit Unterklassen von Rechteck
    //       es nicht mehr ändern können.
}
