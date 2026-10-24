public class Konto
{
    public decimal Kontostand { get; private set; }

    // Ein Startguthaben unter 0 ist ungültig: ArgumentOutOfRangeException (Parametername "startguthaben").
    public Konto(decimal startguthaben = 0m)
    {
        if (startguthaben < 0)
            throw new ArgumentOutOfRangeException(nameof(startguthaben), startguthaben, "Das Startguthaben darf nicht negativ sein.");
        Kontostand = startguthaben;
    }

    // betrag <= 0: ArgumentOutOfRangeException (Parametername "betrag").
    public void Einzahlen(decimal betrag)
    {
        if (betrag <= 0)
            throw new ArgumentOutOfRangeException(nameof(betrag), betrag, "Der Betrag muss größer als 0 sein.");
        Kontostand += betrag;
    }

    // betrag <= 0: ArgumentOutOfRangeException. Reicht das Guthaben nicht aus:
    // GuthabenZuNiedrigException mit dem Fehlbetrag. Der Kontostand bleibt in beiden Fällen unverändert.
    public void Abheben(decimal betrag)
    {
        if (betrag <= 0)
            throw new ArgumentOutOfRangeException(nameof(betrag), betrag, "Der Betrag muss größer als 0 sein.");
        if (betrag > Kontostand)
            throw new GuthabenZuNiedrigException(betrag - Kontostand);
        Kontostand -= betrag;
    }

    // Hebt betrag von diesem Konto ab und zahlt ihn auf ziel ein.
    // ziel == null: ArgumentNullException (Parametername "ziel"). Scheitert die Abhebung, ändert sich kein Konto.
    public void Ueberweisen(Konto ziel, decimal betrag)
    {
        ArgumentNullException.ThrowIfNull(ziel);
        Abheben(betrag);
        ziel.Einzahlen(betrag);
    }
}
