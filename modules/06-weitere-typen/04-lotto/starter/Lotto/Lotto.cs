public static class Lotto {
    // Bringt das Array mit dem Fisher-Yates-Verfahren in eine zufällige Reihenfolge (in place).
    // Durchgang i (von Length - 1 abwärts bis 1): zufälligen Index k aus 0..i wählen, Elemente k und i tauschen.
    public static void Mische(int[] vektor, Random rnd) {
        // TODO
        throw new NotImplementedException();
    }

    // Sortiert das Array aufsteigend durch Auswahl (Selection Sort, in place).
    public static void SortiereAuswahl(int[] a) {
        // TODO
        throw new NotImplementedException();
    }

    // Zieht 6 verschiedene Zahlen aus 1..49 und liefert sie aufsteigend sortiert.
    // Gleicher Seed, gleiche Ziehung.
    public static int[] Ziehe(int seed) {
        // TODO: Array 1..49 füllen, mit new Random(seed) mischen, die ersten 6 kopieren (Array.Copy), sortieren
        throw new NotImplementedException();
    }
}
