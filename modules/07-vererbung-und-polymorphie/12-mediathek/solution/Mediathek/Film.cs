public sealed class Film : Medium {
    public int Minuten { get; }

    public Film(string titel, int minuten) : base(titel) {
        Minuten = minuten;
    }

    public override int Leihfrist => 7;

    // 2 € pro Tag Verspätung, höchstens 20 €.
    public override decimal Mahngebuehr(int tageZuSpaet) =>
        tageZuSpaet <= 0 ? 0m : Math.Min(2m * tageZuSpaet, 20m);

    public override string Info() => base.Info() + ", " + Minuten + " min";
}
