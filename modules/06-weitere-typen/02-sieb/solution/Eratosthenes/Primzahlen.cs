public static class Primzahlen {
    // Liefert alle Primzahlen von 2 bis einschließlich grenze (aufsteigend) mit dem Sieb des Eratosthenes.
    public static int[] BisZu(int grenze) {
        if (grenze < 2)
            return [];
        bool[] prim = new bool[grenze + 1];
        for (int i = 2; i <= grenze; i++)
            prim[i] = true;

        int maxBasis = (int)Math.Sqrt(grenze);
        for (int basis = 2; basis <= maxBasis; basis++)
            if (prim[basis])
                for (int i = basis * basis; i <= grenze; i += basis)
                    prim[i] = false;

        int anzahl = 0;
        for (int i = 2; i <= grenze; i++)
            if (prim[i])
                anzahl++;
        int[] ergebnis = new int[anzahl];
        int k = 0;
        for (int i = 2; i <= grenze; i++)
            if (prim[i])
                ergebnis[k++] = i;
        return ergebnis;
    }

    // Anzahl der Primzahlen bis einschließlich grenze.
    public static int Anzahl(int grenze) => BisZu(grenze).Length;
}
