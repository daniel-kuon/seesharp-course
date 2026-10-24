public static class Parallelrechner
{
    // Quadriert jedes Element. Die Arbeit erledigt Berechne.
    public static int[] Quadrate(int[] eingabe, int threads) => Berechne(eingabe, threads, x => x * x);

    // Wendet f auf jedes Element von eingabe an und liefert die Ergebnisse in derselben Reihenfolge.
    //
    // - Das Array wird in zusammenhängende Blöcke gleicher Größe zerlegt (der letzte darf kürzer sein),
    //   höchstens 'threads' Blöcke. Für jeden Block läuft genau ein eigener Thread, der die Ergebnisse
    //   in ein gemeinsames Ergebnisarray schreibt. Verschiedene Threads schreiben auf verschiedene
    //   Elemente, deshalb braucht das Ergebnisarray kein lock.
    // - Alle Threads werden gestartet, dann wird mit Join() auf jeden gewartet.
    // - threads < 1: ArgumentOutOfRangeException. Ein leeres Array liefert ein leeres Ergebnis.
    //
    // Hinweis: Die Schleifenvariable nicht direkt im Lambda des Threads verwenden, sondern vorher in
    //          eine lokale Variable kopieren (Closure!), sonst sehen alle Threads den letzten Wert.
    public static int[] Berechne(int[] eingabe, int threads, Func<int, int> f)
    {
        // TODO
        throw new NotImplementedException();
    }
}
