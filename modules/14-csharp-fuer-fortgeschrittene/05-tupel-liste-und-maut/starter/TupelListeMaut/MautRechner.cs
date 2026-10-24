namespace TupelListeMaut;

/// <summary>Mautrechner nach dem bekannten Microsoft-Beispiel: Grundgebühr plus Fahrzeug- und Zeitzuschlag.</summary>
public static class MautRechner
{
    public const decimal Grundgebuehr = 2.00m;

    // TODO: switch-Ausdruck über zeit.Hour mit Relationsmustern und or:
    //       vor 6 Uhr und ab 20 Uhr Nacht; 6 bis 9 Morgen; 10 bis 15 Tag; 16 bis 19 Abend.
    public static Zeitband Band(DateTime zeit)
    {
        throw new NotImplementedException();
    }

    // TODO: switch-Ausdruck mit Typ- und Merkmalsmustern (Aufschlag in Euro):
    //       Auto:        0 Passagiere +0,50; 1: 0; 2: -0,50; mehr als 2: -1,00
    //       Taxi:        0 Fahrgäste +3,50; 1: +1,00; 2: 0; mehr als 2: -0,50
    //       Bus:         weniger als 50 % Auslastung (Fahrgaeste / Kapazitaet) +2,00;
    //                    mehr als 90 % -1,00; sonst 0   (when-Bedingung)
    //       Lieferwagen: Gewicht über 5000 +10,00; unter 3000 -2,00; sonst 0
    //       null wirft ArgumentNullException, alles andere ArgumentException.
    public static decimal FahrzeugZuschlag(Fahrzeug f)
    {
        throw new NotImplementedException();
    }

    // TODO: EIN switch-Ausdruck über das Tupel (zeit.DayOfWeek, Band(zeit), einfahrt):
    //       Samstag oder Sonntag: immer 1,00.
    //       Montag bis Freitag: Morgen einfahrend 2,00, ausfahrend 0,50;
    //                           Tag 1,50 (beide Richtungen);
    //                           Abend einfahrend 0,50, ausfahrend 2,00;
    //                           Nacht 0,75 (beide Richtungen).
    public static decimal ZeitZuschlag(DateTime zeit, bool einfahrt)
    {
        throw new NotImplementedException();
    }

    // Grundgebühr + FahrzeugZuschlag + ZeitZuschlag
    public static decimal Berechne(Fahrzeug f, DateTime zeit, bool einfahrt)
    {
        throw new NotImplementedException();
    }
}
