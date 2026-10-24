namespace Merkmalsmuster;

public static class Muster
{
    /// <summary>Zugelassen sind PKW mit mindestens 3 Passagieren oder Elektroautos; null nie.</summary>
    public static bool Zugelassen(PKW? p) => p is { Passagiere: >= 3 } or { Elektro: true };

    /// <summary>Gebühr nach Halterland, Antrieb und Alter (jahr ist das aktuelle Jahr).</summary>
    public static int Gebuehr(Fahrzeug f, int jahr) => f switch
    {
        { Halter: { Land: "DE" }, Elektro: true } => 0,
        { Halter.Land: "DE" } when jahr - f.Baujahr > 20 => 40,
        { Halter.Land: "DE" } => 20,
        _ => 50
    };

    public static string Quadrant(Punkt p) => p switch
    {
        (0, 0) => "Ursprung",
        (> 0, > 0) => "I",
        (< 0, > 0) => "II",
        (< 0, < 0) => "III",
        (> 0, < 0) => "IV",
        _ => "Achse"
    };

    public static string Beschreibe(Punkt p) => p switch
    {
        (var x, var y) when x == y => $"Diagonale {x}",
        (var x, var y) => $"({x}|{y})"
    };

    public static bool AufYAchse(Punkt? p) => p is { X: 0 };
}
