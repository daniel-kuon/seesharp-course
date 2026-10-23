// Wird nach Stunden bezahlt.
public class Freelancer : Mitarbeiter {
    public decimal Stundensatz { get; }
    public int Stunden { get; }

    public Freelancer(string name, decimal stundensatz, int stunden) : base(name) {
        // TODO: negative Werte als 0 übernehmen
        throw new NotImplementedException();
    }

    // TODO: Gehalt() = Stundensatz * Stunden; Art ist "Freelancer".
}
