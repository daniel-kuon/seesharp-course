// Ohne Argumente hinter Figur ruft der Record den parameterlosen Basiskonstruktor auf,
// und die positionalen Parameter X und Y von Kreis bleiben ungenutzt (Warnung CS8907).
// Die Lösung: die Parameter an den primären Konstruktor der Basis weiterreichen.
public record Kreis(double X, double Y, double Radius) : Figur(X, Y) {
    public double Radius { get; } = CheckGE0(Radius);
    public Kreis() : this(0.0, 0.0, 0.0) { }
}
