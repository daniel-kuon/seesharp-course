// Festes Monatsgehalt.
public class Angestellter : Mitarbeiter {
    public decimal Monatsgehalt { get; }

    public Angestellter(string name, decimal monatsgehalt) : base(name) {
        // TODO: negatives Monatsgehalt als 0 übernehmen
        throw new NotImplementedException();
    }

    // TODO: Gehalt() liefert das Monatsgehalt; Art ist "Angestellt".
}

// Ein Angestellter mit monatlicher Leitungszulage.
public class Teamleiter : Angestellter {
    public decimal Zulage { get; }

    public Teamleiter(string name, decimal monatsgehalt, decimal zulage) : base(name, monatsgehalt) {
        // TODO: negative Zulage als 0 übernehmen
        throw new NotImplementedException();
    }

    // TODO: Gehalt() = Gehalt des Angestellten (base.Gehalt()) + Zulage; Art ist "Teamleitung".
}
