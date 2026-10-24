// Vorgegeben, nicht ändern: eine Verbindung, die geöffnet, benutzt und wieder geschlossen werden muss.
public interface IVerbindung
{
    void Oeffnen();
    void Senden(string nachricht);
    void Schliessen();
}

public class Sender
{
    // Wie viele Sendeversuche gescheitert sind.
    public int Fehlschlaege { get; private set; }

    // Öffnet die Verbindung, sendet alle Nachrichten der Reihe nach und schließt die Verbindung.
    // Schliessen() wird in JEDEM Fall genau einmal aufgerufen: nach Erfolg, nach einem Fehler beim
    // Öffnen und nach einem Fehler beim Senden.
    // - Scheitert Oeffnen(): Die Ausnahme wird in eine InvalidOperationException mit der Meldung
    //   "Verbindung konnte nicht geöffnet werden" verpackt; die ursprüngliche ist InnerException.
    // - Scheitert Senden(): Fehlschlaege wird erhöht und DIESELBE Ausnahme mit throw; weitergereicht.
    public void SendeAlle(IVerbindung verbindung, string[] nachrichten)
    {
        try
        {
            try
            {
                verbindung.Oeffnen();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Verbindung konnte nicht geöffnet werden", ex);
            }

            try
            {
                foreach (string nachricht in nachrichten)
                    verbindung.Senden(nachricht);
            }
            catch (Exception)
            {
                Fehlschlaege++;
                throw;
            }
        }
        finally
        {
            verbindung.Schliessen();
        }
    }
}
