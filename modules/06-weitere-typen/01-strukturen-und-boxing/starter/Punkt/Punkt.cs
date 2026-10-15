// TODO: Aus der Klasse eine Struktur machen (Wertsemantik).
public class Punkt(double x, double y) {
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
        // TODO: p ist bei einer Struktur bereits eine Kopie; verschieben und zurückgeben
        throw new NotImplementedException();
    }

    public string Pos() => $"({X}; {Y})";
}
