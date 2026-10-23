public record Artikel(string Name, decimal Preis, int Bestand);

public static class Lager {
    // Liefert eine Kopie mit erhöhtem Bestand. Eine Menge <= 0 ändert nichts (Rückgabe: a selbst).
    public static Artikel Einlagern(Artikel a, int menge) {
        // TODO: with-Ausdruck
        throw new NotImplementedException();
    }

    // Liefert eine Kopie mit um prozent Prozent gesenktem Preis, kaufmännisch auf Cent gerundet.
    public static Artikel Reduziere(Artikel a, int prozent) {
        // TODO: Math.Round(wert, 2, MidpointRounding.AwayFromZero)
        throw new NotImplementedException();
    }

    // Summe aus Preis mal Bestand über alle Artikel.
    public static decimal Gesamtwert(Artikel[] artikel) {
        // TODO
        throw new NotImplementedException();
    }

    // Kleinster Preis, größter Preis und Durchschnittspreis (auf Cent gerundet) als benanntes Tupel.
    // Leeres Array: (0, 0, 0).
    public static (decimal Min, decimal Max, decimal Schnitt) Preisstatistik(Artikel[] artikel) {
        // TODO
        throw new NotImplementedException();
    }

    // Liefert ein NEUES Array: Artikel mit Bestand unter mindestbestand werden auf mindestbestand
    // aufgefüllt, alle anderen unverändert übernommen. Das übergebene Array bleibt, wie es ist.
    public static Artikel[] Nachbestellen(Artikel[] artikel, int mindestbestand) {
        // TODO
        throw new NotImplementedException();
    }
}
