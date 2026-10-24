namespace Merkmalsmuster;

public static class Muster
{
    // TODO: Merkmalsmuster mit or: mindestens 3 Passagiere oder ein Elektroauto.
    //       Für null muss false herauskommen (ein Merkmalsmuster passt nie auf null).
    public static bool Zugelassen(PKW? p)
    {
        throw new NotImplementedException();
    }

    // TODO: switch-Ausdruck mit verschachtelten Merkmalsmustern. Die Reihenfolge ist wichtig:
    //       1. Halter in "DE" und Elektro -> 0
    //       2. Halter in "DE" (erweitertes Merkmalsmuster { Halter.Land: "DE" }) und
    //          Fahrzeug älter als 20 Jahre (jahr - Baujahr > 20, when-Bedingung) -> 40
    //       3. Halter in "DE" -> 20
    //       4. alles andere, auch ohne Halter (null) -> 50
    public static int Gebuehr(Fahrzeug f, int jahr)
    {
        throw new NotImplementedException();
    }

    // TODO: Positionsmuster auf den Record Punkt:
    //       (0, 0) "Ursprung"; (> 0, > 0) "I"; (< 0, > 0) "II"; (< 0, < 0) "III";
    //       (> 0, < 0) "IV"; liegt der Punkt auf einer Achse, "Achse".
    public static string Quadrant(Punkt p)
    {
        throw new NotImplementedException();
    }

    // TODO: Positionsmuster mit var: (var x, var y) when x == y -> "Diagonale 3";
    //       sonst "(2|5)".
    public static string Beschreibe(Punkt p)
    {
        throw new NotImplementedException();
    }

    // TODO: Merkmalsmuster { X: 0 }; null ist nicht auf der Achse.
    public static bool AufYAchse(Punkt? p)
    {
        throw new NotImplementedException();
    }
}
