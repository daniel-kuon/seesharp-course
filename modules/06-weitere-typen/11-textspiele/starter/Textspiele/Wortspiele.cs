using System.Text;

public static class Wortspiele {
    // Palindrom: von vorn und hinten gleich gelesen, wenn man nur Buchstaben (char.IsLetter)
    // betrachtet und Groß-/Kleinschreibung ignoriert. "Lagerregal" und "Eine güldne, gute Tugend: Lüge nie!" sind Palindrome.
    public static bool IstPalindrom(string s) {
        // TODO: zwei Indizes von beiden Enden aufeinander zu bewegen, Nicht-Buchstaben überspringen
        throw new NotImplementedException();
    }

    // Anagramm: beide Texte bestehen aus genau denselben Buchstaben (char.IsLetter, ohne Groß-/Kleinschreibung),
    // nur anders angeordnet. "Lampe" und "Palme" sind Anagramme.
    public static bool IstAnagramm(string a, string b) {
        // TODO: Buchstaben klein in ein char[] übernehmen, mit Array.Sort sortieren, vergleichen
        throw new NotImplementedException();
    }

    // Lauflängenkodierung: "AAABCC" -> "3A1B2C". Leerer Text -> "".
    // Der Text enthält keine Ziffern.
    public static string Kodiere(string s) {
        // TODO: StringBuilder; Läufe gleicher Zeichen zählen
        throw new NotImplementedException();
    }

    // Umkehrung von Kodiere: "3A1B2C" -> "AAABCC", "12x" -> "xxxxxxxxxxxx".
    public static string Dekodiere(string code) {
        // TODO: Ziffern zu einer Zahl sammeln (char.IsDigit), beim Buchstaben so oft anhängen
        throw new NotImplementedException();
    }
}
