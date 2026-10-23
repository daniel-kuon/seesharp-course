using System;

public class Primzahlen {
    public static bool IstPrim(int n) {
        if (n < 2)
            return false;
        bool teilerGefunden = false;
        for (int tk = 2; tk * tk <= n && !teilerGefunden; tk++)
            if (n % tk == 0)
                teilerGefunden = true;
        return !teilerGefunden;
    }

    public static int AnzahlBis(int n) {
        int anzahl = 0;
        for (int i = 2; i <= n; i++)
            if (IstPrim(i))
                anzahl++;
        return anzahl;
    }

    public static int NaechsteNach(int n) {
        do {
            n++;
        } while (!IstPrim(n));
        return n;
    }

    public static bool SindZwillinge(int n) => IstPrim(n) && IstPrim(n + 2);

    public static string Primfaktoren(int n) {
        string faktoren = "";
        int teiler = 2;
        while (n > 1) {
            if (n % teiler == 0) {
                faktoren += faktoren == "" ? "" + teiler : " * " + teiler;
                n /= teiler;
            } else
                teiler++;
        }
        return faktoren;
    }
}
