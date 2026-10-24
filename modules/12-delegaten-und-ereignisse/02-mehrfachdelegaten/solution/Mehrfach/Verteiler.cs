public class Verteiler
{
    private Meldung? ziele;

    public void Anmelden(Meldung m) => ziele += m;

    public void Abmelden(Meldung m) => ziele -= m;

    public void Sende(string text) => ziele?.Invoke(text);

    public int AnzahlZiele() => ziele?.GetInvocationList().Length ?? 0;
}

public static class Ketten
{
    public static Schritt? Kette(params Schritt[] schritte)
    {
        Schritt? kette = null;
        foreach (Schritt s in schritte)
            kette += s;
        return kette;
    }
}
