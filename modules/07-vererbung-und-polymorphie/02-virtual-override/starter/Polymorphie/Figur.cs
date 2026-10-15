public class Figur {
    protected double xpos = 100.0, ypos = 100.0;

    public Figur(double x, double y) {
        if (x >= 0.0 && y >= 0.0) {
            xpos = x;
            ypos = y;
        }
    }
    public Figur() { }

    // TODO: virtual, damit abgeleitete Klassen überschreiben können
    public string Name => "Figur";

    // TODO: virtual
    public string Wo() => $"Oben Links: ({xpos:0}; {ypos:0})";

    // TODO: virtual; eine allgemeine Figur hat nichts zu skalieren
    public void Skaliere(double faktor) { }

    // Nicht virtuell: nutzt die virtuellen Mitglieder und bekommt so automatisch das richtige Verhalten.
    public string Beschreibe() => $"{Name}: {Wo()}";
}
