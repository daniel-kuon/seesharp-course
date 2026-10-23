using System;

public class Primzahlen {
    // Fertig vorgegeben (aus der Übung "Primzahltest, switch-Ausdruck, foreach"). Nicht ändern.
    public static bool IstPrim(int n) {
        if (n < 2)
            return false;
        bool teilerGefunden = false;
        for (int tk = 2; tk * tk <= n && !teilerGefunden; tk++)
            if (n % tk == 0)
                teilerGefunden = true;
        return !teilerGefunden;
    }

    // Anzahl der Primzahlen von 2 bis einschließlich n (for)
    public static int AnzahlBis(int n) {
        throw new NotImplementedException();
    }

    // kleinste Primzahl größer als n (do ... while)
    public static int NaechsteNach(int n) {
        throw new NotImplementedException();
    }

    // true, wenn n und n + 2 beide prim sind
    public static bool SindZwillinge(int n) {
        throw new NotImplementedException();
    }

    // n >= 2 in Primfaktoren zerlegen: 12 -> "2 * 2 * 3", 13 -> "13"
    public static string Primfaktoren(int n) {
        throw new NotImplementedException();
    }
}
