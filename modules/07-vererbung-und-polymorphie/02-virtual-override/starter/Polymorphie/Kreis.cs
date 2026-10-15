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

    // TODO: override statt new, sonst greift der Ersatz nur bei Kreis-Referenzen
    public new string Name => "Kreis";

    // TODO: override; base.Wo() liefert die erste Zeile
    public new string Wo() {
        return base.Wo() + $"\nUnten Rechts: ({xpos + 2.0 * radius:0}; {ypos + 2.0 * radius:0})";
    }

    // TODO: override
    public new void Skaliere(double faktor) {
        if (faktor >= 0.0)
            radius *= faktor;
    }
}
