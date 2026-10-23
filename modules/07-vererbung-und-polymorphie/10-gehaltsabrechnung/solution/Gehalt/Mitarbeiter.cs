// Basisklasse aller Mitarbeiter. Ein "Mitarbeiter an sich" hat kein Gehalt.
public abstract class Mitarbeiter {
    public string Name { get; }

    protected Mitarbeiter(string name) {
        Name = name;
    }

    // Monatliches Gehalt in Euro.
    public abstract decimal Gehalt();

    // Art der Beschäftigung, z. B. "Angestellt".
    public virtual string Art => "Mitarbeiter";

    // Nicht virtuell: nutzt die virtuellen Mitglieder.
    public string Beschreibung() => $"{Name} ({Art})";
}
