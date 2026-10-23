using System.Text;

public static class TextExtensions {
    // Erweiterungsblock für Instanzmitglieder von string; text ist der Empfänger.
    extension(string text) {
        // Vorwärts wie rückwärts gleich? Nur Buchstaben und Ziffern zählen, Groß/klein egal.
        public bool IstPalindrom {
            get {
                int links = 0, rechts = text.Length - 1;
                while (links < rechts) {
                    if (!char.IsLetterOrDigit(text[links]))
                        links++;
                    else if (!char.IsLetterOrDigit(text[rechts]))
                        rechts--;
                    else if (char.ToLower(text[links++]) != char.ToLower(text[rechts--]))
                        return false;
                }
                return true;
            }
        }

        // Anzahl der durch Leerzeichen getrennten Wörter.
        public int AnzahlWoerter => text.Split(' ', StringSplitOptions.RemoveEmptyEntries).Length;

        // Der Text rückwärts.
        public string Umgedreht() {
            var sb = new StringBuilder(text.Length);
            for (int i = text.Length - 1; i >= 0; i--)
                sb.Append(text[i]);
            return sb.ToString();
        }

        // Buchstaben am Anfang und nach einem Leerzeichen groß, alles andere unverändert.
        public string WortanfaengeGross() {
            var sb = new StringBuilder(text.Length);
            for (int i = 0; i < text.Length; i++)
                sb.Append(i == 0 || text[i - 1] == ' ' ? char.ToUpper(text[i]) : text[i]);
            return sb.ToString();
        }
    }

    // Erweiterungsblock für statische Mitglieder von string (kein Empfänger).
    extension(string) {
        // text anzahl-mal hintereinander; anzahl <= 0 liefert "".
        public static string Wiederhole(string text, int anzahl) {
            var sb = new StringBuilder();
            for (int i = 0; i < anzahl; i++)
                sb.Append(text);
            return sb.ToString();
        }

        // "ab" * 3 == "ababab"
        public static string operator *(string text, int anzahl) => string.Wiederhole(text, anzahl);
    }

    // Klassische Erweiterungsmethode mit this-Parameter: Anzahl der Vorkommen von zeichen.
    public static int Zaehle(this string text, char zeichen) {
        int anzahl = 0;
        foreach (char c in text)
            if (c == zeichen)
                anzahl++;
        return anzahl;
    }
}
