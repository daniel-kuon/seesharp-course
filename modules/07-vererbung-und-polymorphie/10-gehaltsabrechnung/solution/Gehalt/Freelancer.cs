// Wird nach Stunden bezahlt.
public class Freelancer : Mitarbeiter {
    public decimal Stundensatz { get; }
    public int Stunden { get; }

    public Freelancer(string name, decimal stundensatz, int stunden) : base(name) {
        Stundensatz = stundensatz >= 0m ? stundensatz : 0m;
        Stunden = stunden >= 0 ? stunden : 0;
    }

    public override decimal Gehalt() => Stundensatz * Stunden;

    public override string Art => "Freelancer";
}
