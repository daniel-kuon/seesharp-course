public struct Punkt(double x, double y) {
    public double X { get; set; } = x;
    public double Y { get; set; } = y;

    // Konstruktorverkettung: der parameterlose Konstruktor delegiert an den anderen.
    public Punkt() : this(0, 0) { }

    // Verändert diese Instanz.
    public void Bewegen(double hor, double vert) {
        X += hor;
        Y += vert;
    }

    // Liefert eine verschobene Kopie; der übergebene Punkt bleibt unverändert.
    public static Punkt Verschoben(Punkt p, double hor, double vert) {
        p.Bewegen(hor, vert); // p ist eine Kopie des Arguments
        return p;
    }

    public string Pos() => $"({X}; {Y})";
}
