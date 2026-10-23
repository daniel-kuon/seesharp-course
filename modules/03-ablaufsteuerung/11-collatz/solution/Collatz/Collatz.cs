using System;

public class Collatz {
    public static int Schritte(long n) {
        int schritte = 0;
        while (n != 1) {
            if (n % 2 == 0)
                n /= 2;
            else
                n = 3 * n + 1;
            schritte++;
        }
        return schritte;
    }

    public static long Hoechstwert(long n) {
        long max = n;
        while (n != 1) {
            if (n % 2 == 0)
                n /= 2;
            else
                n = 3 * n + 1;
            if (n > max)
                max = n;
        }
        return max;
    }

    public static int LaengsterStartBis(int grenze) {
        int besterStart = 1;
        int meisteSchritte = 0;
        for (int start = 1; start <= grenze; start++) {
            int schritte = Schritte(start);
            if (schritte > meisteSchritte) {
                meisteSchritte = schritte;
                besterStart = start;
            }
        }
        return besterStart;
    }
}
