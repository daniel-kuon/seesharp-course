// TODO: Diese Klasse durch einen positionalen Record ersetzen:
//       public record Artikel(string Name, int Menge) { ... }
//       Deconstruct, Gleichheit, GetHashCode und ToString erzeugt der Compiler dann selbst.
public class Artikel {
    public string Name { get; init; }
    public int Menge { get; init; }

    public Artikel(string name, int menge) {
        Name = name;
        Menge = menge;
    }

    public void Deconstruct(out string name, out int menge) {
        name = Name;
        menge = Menge;
    }

    // Liefert eine Kopie mit anderer Menge; dieser Artikel bleibt unverändert.
    public Artikel MitMenge(int menge) {
        // TODO: with-Ausdruck
        throw new NotImplementedException();
    }

    // Liefert eine Kopie mit erhöhter Menge.
    public Artikel Plus(int zusatz) {
        // TODO: with-Ausdruck
        throw new NotImplementedException();
    }
}
