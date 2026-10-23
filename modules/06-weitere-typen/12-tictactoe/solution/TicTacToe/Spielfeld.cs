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
        get { return felder[z, s]; }
    }

    // Wer ist am Zug? X, solange gleich viele X und O stehen, sonst O.
    public Feld AmZug {
        get {
            int x = 0, o = 0;
            for (int z = 0; z < 3; z++)
                for (int s = 0; s < 3; s++) {
                    if (felder[z, s] == Feld.X)
                        x++;
                    else if (felder[z, s] == Feld.O)
                        o++;
                }
            return x == o ? Feld.X : Feld.O;
        }
    }

    // Setzt das Zeichen des Spielers, der am Zug ist. false, wenn (z, s) außerhalb liegt,
    // das Feld belegt ist oder das Spiel schon vorbei ist.
    public bool Setze(int z, int s) {
        if (z < 0 || z >= felder.GetLength(0) || s < 0 || s >= felder.GetLength(1))
            return false;
        if (felder[z, s] != Feld.Leer || Spielstand() != Status.Laeuft)
            return false;
        felder[z, s] = AmZug;
        return true;
    }

    // X oder O, wenn eine Zeile, Spalte oder Diagonale ganz diesem Spieler gehört; sonst Feld.Leer.
    public Feld Gewinner() {
        for (int i = 0; i < 3; i++) {
            if (felder[i, 0] != Feld.Leer && felder[i, 0] == felder[i, 1] && felder[i, 1] == felder[i, 2])
                return felder[i, 0];
            if (felder[0, i] != Feld.Leer && felder[0, i] == felder[1, i] && felder[1, i] == felder[2, i])
                return felder[0, i];
        }
        if (felder[1, 1] != Feld.Leer
            && ((felder[0, 0] == felder[1, 1] && felder[1, 1] == felder[2, 2])
                || (felder[0, 2] == felder[1, 1] && felder[1, 1] == felder[2, 0])))
            return felder[1, 1];
        return Feld.Leer;
    }

    public Status Spielstand() {
        Status st = Gewinner() switch {
            Feld.X => Status.GewonnenX,
            Feld.O => Status.GewonnenO,
            _ => Status.Laeuft
        };
        if (st != Status.Laeuft)
            return st;
        foreach (Feld f in felder)
            if (f == Feld.Leer)
                return Status.Laeuft;
        return Status.Unentschieden;
    }
}
