public static class Lohnliste {
    // Summe aller Gehälter.
    public static decimal Summe(Mitarbeiter[] alle) {
        decimal summe = 0m;
        foreach (Mitarbeiter m in alle)
            summe += m.Gehalt();
        return summe;
    }

    // Name des Mitarbeiters mit dem höchsten Gehalt (leeres Array: "").
    public static string Spitzenverdiener(Mitarbeiter[] alle) {
        if (alle.Length == 0)
            return "";
        Mitarbeiter bester = alle[0];
        foreach (Mitarbeiter m in alle)
            if (m.Gehalt() > bester.Gehalt())
                bester = m;
        return bester.Name;
    }

    // Summe der Stunden aller Freelancer (Typtest mit Musterdeklaration).
    public static int FreelancerStunden(Mitarbeiter[] alle) {
        int stunden = 0;
        foreach (Mitarbeiter m in alle)
            if (m is Freelancer f)
                stunden += f.Stunden;
        return stunden;
    }

    // Anzahl der Angestellten; Teamleiter sind auch Angestellte.
    public static int AnzahlAngestellte(Mitarbeiter[] alle) {
        int anzahl = 0;
        foreach (Mitarbeiter m in alle)
            if (m is Angestellter)
                anzahl++;
        return anzahl;
    }
}
