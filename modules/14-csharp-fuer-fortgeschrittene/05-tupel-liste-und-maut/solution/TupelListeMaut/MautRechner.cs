namespace TupelListeMaut;

/// <summary>Mautrechner nach dem bekannten Microsoft-Beispiel: Grundgebühr plus Fahrzeug- und Zeitzuschlag.</summary>
public static class MautRechner
{
    public const decimal Grundgebuehr = 2.00m;

    public static Zeitband Band(DateTime zeit) => zeit.Hour switch
    {
        < 6 or >= 20 => Zeitband.Nacht,
        < 10 => Zeitband.Morgen,
        < 16 => Zeitband.Tag,
        _ => Zeitband.Abend
    };

    public static decimal FahrzeugZuschlag(Fahrzeug f) => f switch
    {
        Auto { Passagiere: 0 } => 0.50m,
        Auto { Passagiere: 1 } => 0m,
        Auto { Passagiere: 2 } => -0.50m,
        Auto { Passagiere: > 2 } => -1.00m,
        Taxi { Fahrgaeste: 0 } => 3.50m,
        Taxi { Fahrgaeste: 1 } => 1.00m,
        Taxi { Fahrgaeste: 2 } => 0m,
        Taxi { Fahrgaeste: > 2 } => -0.50m,
        Bus b when (double)b.Fahrgaeste / b.Kapazitaet < 0.50 => 2.00m,
        Bus b when (double)b.Fahrgaeste / b.Kapazitaet > 0.90 => -1.00m,
        Bus => 0m,
        Lieferwagen { Gewicht: > 5000 } => 10.00m,
        Lieferwagen { Gewicht: < 3000 } => -2.00m,
        Lieferwagen => 0m,
        null => throw new ArgumentNullException(nameof(f)),
        _ => throw new ArgumentException("Unbekanntes Fahrzeug oder ungültige Angabe.", nameof(f))
    };

    public static decimal ZeitZuschlag(DateTime zeit, bool einfahrt) => (zeit.DayOfWeek, Band(zeit), einfahrt) switch
    {
        (DayOfWeek.Saturday or DayOfWeek.Sunday, _, _) => 1.00m,
        (_, Zeitband.Morgen, true) => 2.00m,
        (_, Zeitband.Morgen, false) => 0.50m,
        (_, Zeitband.Tag, _) => 1.50m,
        (_, Zeitband.Abend, true) => 0.50m,
        (_, Zeitband.Abend, false) => 2.00m,
        (_, Zeitband.Nacht, _) => 0.75m
    };

    public static decimal Berechne(Fahrzeug f, DateTime zeit, bool einfahrt) =>
        Grundgebuehr + FahrzeugZuschlag(f) + ZeitZuschlag(zeit, einfahrt);
}
