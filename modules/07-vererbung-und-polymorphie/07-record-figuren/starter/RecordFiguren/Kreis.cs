// TODO: Beim Erzeugen eines Kreises kommen X und Y nicht in der Basisklasse an (Ausgabe: dx=0, dy=0).
//       Finde die Ursache in der Basisklassenangabe und behebe sie.
public record Kreis(double X, double Y, double Radius) : Figur {
    public double Radius { get; } = CheckGE0(Radius);
    public Kreis() : this(0.0, 0.0, 0.0) { }
}
