public class Verteiler
{
    private Meldung? ziele;

    // TODO: Methode an die Aufrufliste von ziele hängen (+=)
    public void Anmelden(Meldung m) => throw new NotImplementedException();

    // TODO: Methode aus der Aufrufliste entfernen (-=)
    public void Abmelden(Meldung m) => throw new NotImplementedException();

    // TODO: alle Ziele aufrufen; ohne Ziele (ziele ist null) darf nichts passieren
    public void Sende(string text) => throw new NotImplementedException();

    // TODO: Länge der Aufrufliste (GetInvocationList), ohne Ziele 0
    public int AnzahlZiele() => throw new NotImplementedException();
}

public static class Ketten
{
    // TODO: alle Schritte zu einem Delegaten kombinieren (+= oder Delegate.Combine); ohne Schritte null
    public static Schritt? Kette(params Schritt[] schritte) => throw new NotImplementedException();
}
