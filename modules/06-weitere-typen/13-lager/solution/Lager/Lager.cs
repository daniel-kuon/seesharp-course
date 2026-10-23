public record Artikel(string Name, decimal Preis, int Bestand);

public static class Lager {
    // Liefert eine Kopie mit erhöhtem Bestand. Eine Menge <= 0 ändert nichts (Rückgabe: a selbst).
    public static Artikel Einlagern(Artikel a, int menge) {
        if (menge <= 0)
            return a;
        return a with { Bestand = a.Bestand + menge };
    }

    // Liefert eine Kopie mit um prozent Prozent gesenktem Preis, kaufmännisch auf Cent gerundet.
    public static Artikel Reduziere(Artikel a, int prozent) {
        decimal neu = a.Preis * (100 - prozent) / 100;
        return a with { Preis = Math.Round(neu, 2, MidpointRounding.AwayFromZero) };
    }

    // Summe aus Preis mal Bestand über alle Artikel.
    public static decimal Gesamtwert(Artikel[] artikel) {
        decimal summe = 0;
        foreach (Artikel a in artikel)
            summe += a.Preis * a.Bestand;
        return summe;
    }

    // Kleinster Preis, größter Preis und Durchschnittspreis (auf Cent gerundet) als benanntes Tupel.
    // Leeres Array: (0, 0, 0).
    public static (decimal Min, decimal Max, decimal Schnitt) Preisstatistik(Artikel[] artikel) {
        if (artikel.Length == 0)
            return (0, 0, 0);
        decimal min = artikel[0].Preis, max = artikel[0].Preis, summe = 0;
        foreach (Artikel a in artikel) {
            if (a.Preis < min)
                min = a.Preis;
            if (a.Preis > max)
                max = a.Preis;
            summe += a.Preis;
        }
        return (min, max, Math.Round(summe / artikel.Length, 2, MidpointRounding.AwayFromZero));
    }

    // Liefert ein NEUES Array: Artikel mit Bestand unter mindestbestand werden auf mindestbestand
    // aufgefüllt, alle anderen unverändert übernommen. Das übergebene Array bleibt, wie es ist.
    public static Artikel[] Nachbestellen(Artikel[] artikel, int mindestbestand) {
        var ergebnis = new Artikel[artikel.Length];
        for (int i = 0; i < artikel.Length; i++) {
            Artikel a = artikel[i];
            ergebnis[i] = a.Bestand < mindestbestand ? a with { Bestand = mindestbestand } : a;
        }
        return ergebnis;
    }
}
