public enum Feld { Leer, X, O }

public enum Status { Laeuft, GewonnenX, GewonnenO, Unentschieden }

// Ein 3 x 3-Spielfeld für Tic-Tac-Toe. X beginnt, dann wird abgewechselt.
public class Spielfeld {
    readonly Feld[,] felder = new Feld[3, 3];

    // Fertig: baut ein Spielfeld aus drei Zeilen wie "XO.", ".X.", "..X" ('.' = leer).
    public static Spielfeld AusText(string zeile0, string zeile1, string zeile2) {
        var sf = new Spielfeld();
        string[] zeilen = [zeile0, zeile1, zeile2];
        for (int z = 0; z < 3; z++)
            for (int s = 0; s < 3; s++)
                sf.felder[z, s] = zeilen[z][s] switch {
                    'X' => Feld.X,
                    'O' => Feld.O,
                    _ => Feld.Leer
                };
        return sf;
    }

    // Nur lesender Indexer: Zeile z, Spalte s.
    public Feld this[int z, int s] {
        get {
            // TODO
            throw new NotImplementedException();
        }
    }

    // Wer ist am Zug? X, solange gleich viele X und O stehen, sonst O.
    public Feld AmZug {
        get {
            // TODO: X und O zählen (verschachtelte Schleifen)
            throw new NotImplementedException();
        }
    }

    // Setzt das Zeichen des Spielers, der am Zug ist. false, wenn (z, s) außerhalb liegt,
    // das Feld belegt ist oder das Spiel schon vorbei ist.
    public bool Setze(int z, int s) {
        // TODO
        throw new NotImplementedException();
    }

    // X oder O, wenn eine Zeile, Spalte oder Diagonale ganz diesem Spieler gehört; sonst Feld.Leer.
    public Feld Gewinner() {
        // TODO
        throw new NotImplementedException();
    }

    public Status Spielstand() {
        // TODO: Gewinner per switch-Ausdruck auf Status abbilden; ohne Gewinner: voll -> Unentschieden, sonst Laeuft
        throw new NotImplementedException();
    }
}
