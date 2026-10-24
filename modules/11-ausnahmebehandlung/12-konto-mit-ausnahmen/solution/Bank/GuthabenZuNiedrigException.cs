// Ein Konto hat nicht genug Guthaben: ein Fehler im Zustand des Objekts, kein falsches Argument.
public class GuthabenZuNiedrigException : InvalidOperationException
{
    // Der Betrag, der zur gewünschten Abhebung fehlt.
    public decimal Fehlbetrag { get; }

    public GuthabenZuNiedrigException(decimal fehlbetrag)
        : base($"Das Guthaben reicht nicht aus, es fehlen {fehlbetrag:F2}.")
    {
        Fehlbetrag = fehlbetrag;
    }
}
