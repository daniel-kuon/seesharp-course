// Festes Monatsgehalt.
public class Angestellter : Mitarbeiter {
    public decimal Monatsgehalt { get; }

    public Angestellter(string name, decimal monatsgehalt) : base(name) {
        Monatsgehalt = monatsgehalt >= 0m ? monatsgehalt : 0m;
    }

    public override decimal Gehalt() => Monatsgehalt;

    public override string Art => "Angestellt";
}

// Ein Angestellter mit monatlicher Leitungszulage.
public class Teamleiter : Angestellter {
    public decimal Zulage { get; }

    public Teamleiter(string name, decimal monatsgehalt, decimal zulage) : base(name, monatsgehalt) {
        Zulage = zulage >= 0m ? zulage : 0m;
    }

    public override decimal Gehalt() => base.Gehalt() + Zulage;

    public override string Art => "Teamleitung";
}
