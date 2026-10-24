public static class Ablauf
{
    // Schreibt "start", führt den Schritt aus und schreibt IMMER "ende" (finally).
    // - Läuft der Schritt ohne Fehler durch: Ergebnis true.
    // - IOException, deren Meldung mit "temporär" beginnt: wird ignoriert, Zeile "ignoriert",
    //   Ergebnis false (Ausnahmefilter mit when).
    // - Jede andere IOException wird in eine InvalidOperationException mit der Meldung
    //   "Verarbeitung fehlgeschlagen" verpackt; die ursprüngliche ist deren InnerException.
    // - Alle anderen Ausnahmen laufen unverändert nach oben.
    public static bool Verarbeite(IArbeitsschritt schritt, Protokoll protokoll)
    {
        protokoll.Schreibe("start");
        try
        {
            schritt.Ausfuehren();
            return true;
        }
        catch (IOException ex) when (ex.Message.StartsWith("temporär", StringComparison.Ordinal))
        {
            protokoll.Schreibe("ignoriert");
            return false;
        }
        catch (IOException ex)
        {
            throw new InvalidOperationException("Verarbeitung fehlgeschlagen", ex);
        }
        finally
        {
            protokoll.Schreibe("ende");
        }
    }

    // Führt den Schritt aus. Scheitert er, steht im Protokoll "fehler: <Typname>"
    // und dieselbe Ausnahme wird mit throw; weitergereicht: Die Stapelüberwachung
    // zeigt weiterhin den Schritt, der den Fehler ausgelöst hat.
    public static void ProtokolliereUndWirfWeiter(IArbeitsschritt schritt, Protokoll protokoll)
    {
        try
        {
            schritt.Ausfuehren();
        }
        catch (Exception ex)
        {
            protokoll.Schreibe("fehler: " + ex.GetType().Name);
            throw;
        }
    }
}
