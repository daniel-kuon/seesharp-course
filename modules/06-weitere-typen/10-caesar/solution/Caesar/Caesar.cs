using System.Text;

public static class Caesar {
    // Verschiebt jeden Buchstaben A-Z und a-z um schluessel Stellen im Alphabet (zyklisch).
    // Groß bleibt groß, klein bleibt klein; alle anderen Zeichen (Ziffern, Umlaute, Satzzeichen) bleiben unverändert.
    // Der Schlüssel darf negativ oder größer als 26 sein.
    public static string Verschluessele(string text, int schluessel) {
        int k = schluessel % 26;
        if (k < 0)
            k += 26;
        var sb = new StringBuilder(text.Length);
        foreach (char c in text) {
            if (c >= 'A' && c <= 'Z')
                sb.Append((char)('A' + (c - 'A' + k) % 26));
            else if (c >= 'a' && c <= 'z')
                sb.Append((char)('a' + (c - 'a' + k) % 26));
            else
                sb.Append(c);
        }
        return sb.ToString();
    }

    public static string Entschluessele(string geheim, int schluessel) {
        return Verschluessele(geheim, -schluessel);
    }

    // Zählt, wie oft jeder Buchstabe vorkommt, ohne Rücksicht auf Groß-/Kleinschreibung.
    // Index 0 steht für A, Index 25 für Z.
    public static int[] Haeufigkeiten(string text) {
        int[] anzahl = new int[26];
        foreach (char c in text) {
            if (c >= 'A' && c <= 'Z')
                anzahl[c - 'A']++;
            else if (c >= 'a' && c <= 'z')
                anzahl[c - 'a']++;
        }
        return anzahl;
    }

    // Errät den Schlüssel unter der Annahme, dass im Klartext E der häufigste Buchstabe ist.
    // Ergebnis im Bereich 0 bis 25.
    public static int Knacke(string geheim) {
        int[] anzahl = Haeufigkeiten(geheim);
        int maxIndex = 0;
        for (int i = 1; i < anzahl.Length; i++)
            if (anzahl[i] > anzahl[maxIndex])
                maxIndex = i;
        return (maxIndex - ('E' - 'A') + 26) % 26;
    }
}
