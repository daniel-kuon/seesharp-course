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
        if (faktor >= 0.0)
            radius *= faktor;
    }

    public override double Inhalt => Math.PI * radius * radius;

    public override double Breite => radius * 2.0;
}
