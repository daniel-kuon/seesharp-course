using System.Text;

public static class StringUtil {
    const int nColDef = 72;

    // Bricht den Text in Zeilen von höchstens ncol Zeichen um (an Leerzeichen; längere Wörter werden hart geteilt).
    // Mit hypSep == true darf ein Wort zusätzlich hinter einem Bindestrich getrennt werden.
    public static string[] WrapLine(string text, int ncol = nColDef, bool hypSep = false) {
        // TODO
        throw new NotImplementedException();
    }

    // Glückszahl von 1 bis 100 aus Vor- und Nachname: Seed ist der Code des ersten Buchstabens des Vornamens
    // plus der Code des letzten Buchstabens des Nachnamens (beide als Großbuchstaben).
    public static int Glueckszahl(string vorname, string nachname) {
        // TODO
        throw new NotImplementedException();
    }

    // Zählt die Vokale (a, e, i, o, u, auch groß) in s.
    public static int ZaehleVokale(string s) {
        // TODO: Zeichen für Zeichen durchlaufen
        throw new NotImplementedException();
    }

    // Kehrt die Zeichenfolge um, z. B. "Otto" -> "ottO" (mit StringBuilder).
    public static string Umkehren(string s) {
        // TODO
        throw new NotImplementedException();
    }
}
