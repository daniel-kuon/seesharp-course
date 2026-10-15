public record Figur(double X, double Y) {
    // Die positionalen Eigenschaften werden ausdrücklich deklariert, um die Werte zu validieren.
    public double X { get; } = CheckGE0(X);
    public double Y { get; } = CheckGE0(Y);

    public Figur() : this(0.0, 0.0) { }

    static protected double CheckGE0(double arg) => arg >= 0
                       ? arg
                       : throw new ArgumentException("Der Wert muss >= 0 sein.");
}
