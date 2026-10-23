using System.Text;

public static class Caesar {
    // Verschiebt jeden Buchstaben A-Z und a-z um schluessel Stellen im Alphabet (zyklisch).
    // Groß bleibt groß, klein bleibt klein; alle anderen Zeichen (Ziffern, Umlaute, Satzzeichen) bleiben unverändert.
    // Der Schlüssel darf negativ oder größer als 26 sein.
    public static string Verschluessele(string text, int schluessel) {
        // TODO: StringBuilder, Zeichen für Zeichen; Position im Alphabet (c - 'A'), verschieben, normieren, zurück zu char
        throw new NotImplementedException();
    }

    public static string Entschluessele(string geheim, int schluessel) {
        // TODO: Verschluessele wiederverwenden
        throw new NotImplementedException();
    }

    // Zählt, wie oft jeder Buchstabe vorkommt, ohne Rücksicht auf Groß-/Kleinschreibung.
    // Index 0 steht für A, Index 25 für Z.
    public static int[] Haeufigkeiten(string text) {
        // TODO
        throw new NotImplementedException();
    }

    // Errät den Schlüssel unter der Annahme, dass im Klartext E der häufigste Buchstabe ist.
    // Ergebnis im Bereich 0 bis 25.
    public static int Knacke(string geheim) {
        // TODO: häufigsten Buchstaben suchen; sein Abstand zu E ist der Schlüssel
        throw new NotImplementedException();
    }
}
