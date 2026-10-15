using de.bebagoe.fraction;

public static class Rechner {
    // Summe beliebig vieler Brüche; das Etikett der Summe ist "Summe".
    public static Bruch Summe(params Bruch[] brueche) {
        var summe = new Bruch(0, 1, "Summe");
        foreach (var b in brueche)
            summe += b;
        summe.Etikett = "Summe";
        return summe;
    }

    // Mittelwert der Brüche (Summe geteilt durch Anzahl), gekürzt, Etikett "Mittel".
    public static Bruch Mittel(params Bruch[] brueche) {
        var mittel = Summe(brueche);
        mittel.Nenner *= brueche.Length;
        mittel.Kuerze();
        mittel.Etikett = "Mittel";
        return mittel;
    }
}
