// Basisklasse aller ausleihbaren Medien. Diese Klasse ist fertig, bis auf eine Kleinigkeit:
// TODO: Bestseller braucht den Ausleihzähler. Mache ihn protected (nicht public).
public class Medium {
    // Wie oft das Medium ausgeliehen wurde.
    private int ausleihen;

    public string Titel { get; }

    public Medium(string titel) {
        Titel = titel;
    }

    public void Ausleihen() {
        ausleihen++;
    }

    // Leihfrist in Tagen.
    public virtual int Leihfrist => 28;

    // 0,50 € pro Tag Verspätung, höchstens 10 €; ohne Verspätung nichts.
    public virtual decimal Mahngebuehr(int tageZuSpaet) =>
        tageZuSpaet <= 0 ? 0m : Math.Min(0.50m * tageZuSpaet, 10m);

    public virtual string Info() => $"{Titel} ({Leihfrist} Tage)";
}
