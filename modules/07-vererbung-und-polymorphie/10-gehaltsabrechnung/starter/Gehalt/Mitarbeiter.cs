// Basisklasse aller Mitarbeiter.
// TODO: Ein "Mitarbeiter an sich" hat kein Gehalt. Mache die Klasse abstrakt und Gehalt()
//       zu einer abstrakten Methode ohne Rumpf (der Konstruktor darf dann protected sein).
public class Mitarbeiter {
    public string Name { get; }

    public Mitarbeiter(string name) {
        Name = name;
    }

    // Monatliches Gehalt in Euro.
    public virtual decimal Gehalt() => 0m;

    // Art der Beschäftigung, z. B. "Angestellt".
    public virtual string Art => "Mitarbeiter";

    // Nicht virtuell: nutzt die virtuellen Mitglieder.
    public string Beschreibung() => $"{Name} ({Art})";
}
