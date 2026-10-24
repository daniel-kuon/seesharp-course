public static class Statistik
{
    // Die Summe aller Zahlen als long, berechnet mit Parallel.For. Alle Iterationen addieren in dieselbe
    // Variable: mit Interlocked.Add, nicht mit "+=".
    public static long Summe(int[] daten)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Das größte Element. Teile das Array in vier Abschnitte, bestimme das Maximum jedes Abschnitts in einer
    // eigenen Task.Run-Aufgabe und nimm dann das größte der vier Teilergebnisse.
    // Ein leeres Array ist ein Fehler: InvalidOperationException (wie bei Enumerable.Max).
    // Hinweis: Abschnitte können bei kurzen Arrays leer sein: Dafür keine Aufgabe starten.
    public static int Maximum(int[] daten)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Zählt, wie viele Zahlen in jede von 'klassen' gleich breiten Klassen fallen. Die Zahlen liegen zwischen
    // 0 und 99; die Klasse von w ist w * klassen / 100 (ganzzahlig). Beispiel klassen = 10: 0 bis 9 -> Klasse 0,
    // 10 bis 19 -> Klasse 1, und so weiter. Mit Parallel.For; jede Iteration erhöht ihren Zähler mit
    // Interlocked.Increment(ref ergebnis[klasse]). klassen < 1: ArgumentOutOfRangeException.
    public static int[] Histogramm(int[] daten, int klassen)
    {
        // TODO
        throw new NotImplementedException();
    }
}
