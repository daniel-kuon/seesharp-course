public static class Lotto {
    // Bringt das Array mit dem Fisher-Yates-Verfahren in eine zufällige Reihenfolge (in place).
    // Durchgang i (von Length - 1 abwärts bis 1): zufälligen Index k aus 0..i wählen, Elemente k und i tauschen.
    public static void Mische(int[] vektor, Random rnd) {
        for (int i = vektor.Length - 1; i >= 1; i--) {
            int k = rnd.Next(i + 1);
            (vektor[k], vektor[i]) = (vektor[i], vektor[k]);
        }
    }

    // Sortiert das Array aufsteigend durch Auswahl (Selection Sort, in place).
    public static void SortiereAuswahl(int[] a) {
        for (int i = 0; i < a.Length - 1; i++)
            for (int j = i + 1; j < a.Length; j++)
                if (a[j] < a[i])
                    (a[i], a[j]) = (a[j], a[i]);
    }

    // Zieht 6 verschiedene Zahlen aus 1..49 und liefert sie aufsteigend sortiert.
    // Gleicher Seed, gleiche Ziehung.
    public static int[] Ziehe(int seed) {
        const int grenze = 49;
        int[] vektor = new int[grenze];
        for (int i = 0; i < grenze; i++)
            vektor[i] = i + 1;
        Mische(vektor, new Random(seed));
        int[] ziehung = new int[6];
        Array.Copy(vektor, ziehung, 6);
        SortiereAuswahl(ziehung);
        return ziehung;
    }
}
