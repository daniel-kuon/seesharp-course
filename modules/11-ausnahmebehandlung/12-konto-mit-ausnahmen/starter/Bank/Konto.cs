public class Konto
{
    public decimal Kontostand { get; private set; }

    // TODO: Ein Startguthaben unter 0 ist ungültig: ArgumentOutOfRangeException (Parametername "startguthaben").
    public Konto(decimal startguthaben = 0m)
    {
        Kontostand = startguthaben;
    }

    // TODO: betrag <= 0: ArgumentOutOfRangeException (Parametername "betrag").
    public void Einzahlen(decimal betrag)
    {
        Kontostand += betrag;
    }

    // TODO: betrag <= 0: ArgumentOutOfRangeException (Parametername "betrag").
    // Reicht das Guthaben nicht aus: GuthabenZuNiedrigException mit dem Fehlbetrag
    // (betrag - Kontostand). Der Kontostand bleibt in beiden Fällen unverändert.
    public void Abheben(decimal betrag)
    {
        Kontostand -= betrag;
    }

    // Hebt betrag von diesem Konto ab und zahlt ihn auf ziel ein.
    // TODO: ziel == null: ArgumentNullException (Parametername "ziel", ArgumentNullException.ThrowIfNull).
    // Scheitert die Abhebung, darf sich kein Konto ändern: Prüfe also, bevor du etwas veränderst.
    public void Ueberweisen(Konto ziel, decimal betrag)
    {
        Abheben(betrag);
        ziel.Einzahlen(betrag);
    }
}
