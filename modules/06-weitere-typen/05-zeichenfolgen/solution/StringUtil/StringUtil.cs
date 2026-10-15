using System.Text;

public static class StringUtil {
    const int nColDef = 72;

    // Bricht den Text in Zeilen von höchstens ncol Zeichen um (an Leerzeichen; längere Wörter werden hart geteilt).
    // Mit hypSep == true darf ein Wort zusätzlich hinter einem Bindestrich getrennt werden.
    public static string[] WrapLine(string text, int ncol = nColDef, bool hypSep = false) {
        if (ncol < 1)
            ncol = 1;
        // Ein Bindestrich zwischen zwei Nicht-Leerzeichen wird als optionale Trennstelle markiert.
        if (hypSep)
            for (int j = 1; j < text.Length - 1; j++)
                if (text[j] == '-' && text[j - 1] != ' ' && text[j + 1] != ' ')
                    text = text.Insert(j + 1, "{opt} ");

        string[] tokens = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        var zeilen = new List<string>();
        var zeile = new StringBuilder();
        int i = 0;
        while (i < tokens.Length) {
            string s = tokens[i];
            bool optSep = s.EndsWith("{opt}");
            if (optSep)
                s = s.Substring(0, s.Length - 5);
            while (true) {
                if (zeile.Length + s.Length <= ncol) {
                    zeile.Append(s);
                    if (zeile.Length < ncol && !optSep)
                        zeile.Append(' ');
                    i++;
                    break;
                } else if (zeile.Length > 0) {
                    zeilen.Add(zeile.ToString().TrimEnd());
                    zeile.Clear();
                } else {
                    zeilen.Add(s.Substring(0, ncol));
                    s = s.Substring(ncol);
                }
            }
        }
        zeilen.Add(zeile.ToString().TrimEnd());
        return zeilen.ToArray();
    }

    // Glückszahl von 1 bis 100 aus Vor- und Nachname: Seed ist der Code des ersten Buchstabens des Vornamens
    // plus der Code des letzten Buchstabens des Nachnamens (beide als Großbuchstaben).
    public static int Glueckszahl(string vorname, string nachname) {
        int az = vorname.ToUpper()[0];
        int ez = nachname.ToUpper()[nachname.Length - 1];
        var zzg = new Random(az + ez);
        return zzg.Next(100) + 1;
    }

    // Zählt die Vokale (a, e, i, o, u, auch groß) in s.
    public static int ZaehleVokale(string s) {
        int n = 0;
        foreach (char c in s.ToLower())
            if ("aeiou".Contains(c))
                n++;
        return n;
    }

    // Kehrt die Zeichenfolge um, z. B. "Otto" -> "ottO" (mit StringBuilder).
    public static string Umkehren(string s) {
        var sb = new StringBuilder(s.Length);
        for (int i = s.Length - 1; i >= 0; i--)
            sb.Append(s[i]);
        return sb.ToString();
    }
}
