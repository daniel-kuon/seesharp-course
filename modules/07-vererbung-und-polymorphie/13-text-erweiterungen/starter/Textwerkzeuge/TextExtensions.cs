using System.Text;

public static class TextExtensions {
    // Erweiterungsblock für Instanzmitglieder von string; text ist der Empfänger.
    extension(string text) {
        // Vorwärts wie rückwärts gleich? Nur Buchstaben und Ziffern zählen, Groß/klein egal.
        public bool IstPalindrom {
            get {
                // TODO: char.IsLetterOrDigit, char.ToUpper
                throw new NotImplementedException();
            }
        }

        // Anzahl der durch Leerzeichen getrennten Wörter.
        public int AnzahlWoerter {
            get {
                // TODO: Split(' ', StringSplitOptions.RemoveEmptyEntries)
                throw new NotImplementedException();
            }
        }

        // Der Text rückwärts.
        public string Umgedreht() {
            // TODO: StringBuilder
            throw new NotImplementedException();
        }

        // Buchstaben am Anfang und nach einem Leerzeichen groß, alles andere unverändert.
        public string WortanfaengeGross() {
            // TODO: char.ToUpper
            throw new NotImplementedException();
        }
    }

    // Erweiterungsblock für statische Mitglieder von string (kein Empfänger).
    extension(string) {
        // text anzahl-mal hintereinander; anzahl <= 0 liefert "".
        public static string Wiederhole(string text, int anzahl) {
            // TODO
            throw new NotImplementedException();
        }

        // "ab" * 3 == "ababab"
        public static string operator *(string text, int anzahl) {
            // TODO: Wiederhole verwenden
            throw new NotImplementedException();
        }
    }

    // Klassische Erweiterungsmethode mit this-Parameter: Anzahl der Vorkommen von zeichen.
    public static int Zaehle(this string text, char zeichen) {
        // TODO
        throw new NotImplementedException();
    }
}
