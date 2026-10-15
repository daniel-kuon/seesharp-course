public record Artikel(string Name, int Menge) {
    // Liefert eine Kopie mit anderer Menge; dieser Artikel bleibt unverändert.
    public Artikel MitMenge(int menge) => this with { Menge = menge };

    // Liefert eine Kopie mit erhöhter Menge.
    public Artikel Plus(int zusatz) => this with { Menge = Menge + zusatz };
}
