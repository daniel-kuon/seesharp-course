public class Formatierung {
    // Soll "3 + 2 = 5" liefern. Warum kommt "3 + 2 = 32" heraus? Mit Klammern beheben.
    public static string SummeText() {
        return "3 + 2 = " + 3 + 2;
    }

    // "zaehler/nenner" per Interpolation, z. B. "3/4"
    public static string Bruchzeile(int zaehler, int nenner) {
        throw new NotImplementedException();
    }

    // Rechts- und linksbündige Ausgabe in Breite 4, siehe Anleitung
    public static string Ausgerichtet(int i, int j, int k, int m) {
        throw new NotImplementedException();
    }
}
