public class Rechteck : Figur {
    double breite = 50.0, hoehe = 50.0;

    public Rechteck(double x, double y, double b, double h) : base(x, y) {
        if (b >= 0.0 && h >= 0.0) {
            breite = b;
            hoehe = h;
        }
    }
    public Rechteck() { }

    public override string Name => "Rechteck";

    public sealed override string Wo() {
        return base.Wo() + $"\nUnten Rechts: ({xpos + breite:0}; {ypos + hoehe:0})";
    }

    public override void Skaliere(double faktor) {
        if (faktor >= 0.0) {
            breite *= faktor;
            hoehe *= faktor;
        }
    }
}
