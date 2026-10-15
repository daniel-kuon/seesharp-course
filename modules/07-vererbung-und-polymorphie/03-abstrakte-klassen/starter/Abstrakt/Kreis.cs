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

    public override string Wo() {
        return base.Wo() + $"\nUnten Rechts: ({xpos + 2.0 * radius:0}; {ypos + 2.0 * radius:0})";
    }

    public override void Skaliere(double faktor) {
        // TODO: Radius mit dem Faktor multiplizieren (nur bei faktor >= 0)
        throw new NotImplementedException();
    }

    public override double Inhalt {
        get {
            // TODO: Kreisfläche
            throw new NotImplementedException();
        }
    }

    public override double Breite {
        get {
            // TODO: Durchmesser
            throw new NotImplementedException();
        }
    }
}
