// Ein Konto hat nicht genug Guthaben: ein Fehler im Zustand des Objekts, kein falsches Argument.
//
// TODO: Die Klasse soll von InvalidOperationException erben (nicht von Exception) und die Meldung
//       an den Basiskonstruktor weitergeben, z. B. "Das Guthaben reicht nicht aus, es fehlen 5,00."
//       (mit $"...{fehlbetrag:F2}..."). Der Konstruktor speichert außerdem den Fehlbetrag.
public class GuthabenZuNiedrigException : Exception
{
    // Der Betrag, der zur gewünschten Abhebung fehlt.
    public decimal Fehlbetrag { get; }

    public GuthabenZuNiedrigException(decimal fehlbetrag)
    {
    }
}
