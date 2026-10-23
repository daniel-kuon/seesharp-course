// TODO: Von Film soll niemand mehr ableiten (sealed).
public class Film : Medium {
    public int Minuten { get; }

    public Film(string titel, int minuten) : base(titel) {
        // TODO
        throw new NotImplementedException();
    }

    // TODO: Leihfrist 7 Tage
    // TODO: Mahngebuehr 2 € pro Tag Verspätung, höchstens 20 €, ohne Verspätung 0
    // TODO: Info() hängt ", " + Minuten + " min" an
}
