using System.Text;

public static class Wortspiele {
    // Palindrom: von vorn und hinten gleich gelesen, wenn man nur Buchstaben (char.IsLetter)
    // betrachtet und Groß-/Kleinschreibung ignoriert. "Lagerregal" und "Eine güldne, gute Tugend: Lüge nie!" sind Palindrome.
    public static bool IstPalindrom(string s) {
        int links = 0, rechts = s.Length - 1;
        while (links < rechts) {
            if (!char.IsLetter(s[links]))
                links++;
            else if (!char.IsLetter(s[rechts]))
                rechts--;
            else {
                if (char.ToLower(s[links]) != char.ToLower(s[rechts]))
                    return false;
                links++;
                rechts--;
            }
        }
        return true;
    }

    // Anagramm: beide Texte bestehen aus genau denselben Buchstaben (char.IsLetter, ohne Groß-/Kleinschreibung),
    // nur anders angeordnet. "Lampe" und "Palme" sind Anagramme.
    public static bool IstAnagramm(string a, string b) {
        return SortierteBuchstaben(a) == SortierteBuchstaben(b);
    }

    static string SortierteBuchstaben(string s) {
        var sb = new StringBuilder();
        foreach (char c in s)
            if (char.IsLetter(c))
                sb.Append(char.ToLower(c));
        char[] zeichen = sb.ToString().ToCharArray();
        Array.Sort(zeichen);
        return new string(zeichen);
    }

    // Lauflängenkodierung: "AAABCC" -> "3A1B2C". Leerer Text -> "".
    // Der Text enthält keine Ziffern.
    public static string Kodiere(string s) {
        var sb = new StringBuilder();
        int i = 0;
        while (i < s.Length) {
            char c = s[i];
            int lauf = 0;
            while (i < s.Length && s[i] == c) {
                lauf++;
                i++;
            }
            sb.Append(lauf).Append(c);
        }
        return sb.ToString();
    }

    // Umkehrung von Kodiere: "3A1B2C" -> "AAABCC", "12x" -> "xxxxxxxxxxxx".
    public static string Dekodiere(string code) {
        var sb = new StringBuilder();
        int zahl = 0;
        foreach (char c in code) {
            if (char.IsDigit(c))
                zahl = zahl * 10 + (c - '0');
            else {
                sb.Append(c, zahl);
                zahl = 0;
            }
        }
        return sb.ToString();
    }
}
