public static class Ablauf
{
    // Schreibt "start", führt den Schritt aus und schreibt IMMER "ende".
    // - Läuft der Schritt ohne Fehler durch: Ergebnis true.
    // - IOException, deren Meldung mit "temporär" beginnt: wird ignoriert, Zeile "ignoriert"
    //   im Protokoll, Ergebnis false. Das gelingt mit einem Ausnahmefilter: catch (...) when (...)
    // - Jede andere IOException wird in eine InvalidOperationException mit der Meldung
    //   "Verarbeitung fehlgeschlagen" verpackt; die ursprüngliche ist deren InnerException.
    // - Alle anderen Ausnahmen laufen unverändert nach oben (im Protokoll steht trotzdem "ende").
    // Das "ende" gehört in einen finally-Block. Genau ein "ende" pro Aufruf, auch bei return im try.
    public static bool Verarbeite(IArbeitsschritt schritt, Protokoll protokoll)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Führt den Schritt aus. Scheitert er, steht im Protokoll "fehler: <Typname>"
    // (ex.GetType().Name) und dieselbe Ausnahme wird weitergereicht. Nimm throw; und nicht
    // throw ex; : Nur so zeigt die Stapelüberwachung weiter den Schritt, der den Fehler
    // ausgelöst hat.
    public static void ProtokolliereUndWirfWeiter(IArbeitsschritt schritt, Protokoll protokoll)
    {
        // TODO
        throw new NotImplementedException();
    }
}
