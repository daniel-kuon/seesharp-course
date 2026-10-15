public class Schleifen {
    public static bool IstPrim(long n) {
        if (n < 2)
            return false;
        bool teilerGefunden = false;
        for (long tk = 2; tk * tk <= n && !teilerGefunden; tk++)
            if (n % tk == 0)
                teilerGefunden = true;
        return !teilerGefunden;
    }

    public static string Wochentag(int tag) => tag switch {
        1 => "Montag", 2 => "Dienstag", 3 => "Mittwoch", 4 => "Donnerstag",
        5 => "Freitag", 6 => "Samstag", 7 => "Sonntag", _ => "ungültig"
    };

    public static int AnzahlVokale(string text) {
        int anzahl = 0;
        foreach (char c in text)
            if ("aeiou".Contains(char.ToLower(c)))
                anzahl++;
        return anzahl;
    }
}
