public static class ParallelRechner
{
    // Summe der Quadrate aller Elemente als long.
    // Mit Parallel.For über die Indizes; die Iterationen laufen auf mehreren Threads und addieren in EINE
    // gemeinsame long-Variable: Dafür gibt es Interlocked.Add(ref summe, wert). Ein einfaches "summe += ..."
    // wäre eine Race Condition.
    public static long SummeQuadrate(int[] a)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Alle geraden Elemente (mit Wiederholungen), in beliebiger Reihenfolge.
    // Mit Parallel.ForEach; die Ergebnisse kommen in eine gemeinsame List<int>. Eine List<T> verträgt kein
    // gleichzeitiges Add: Schütze es mit lock auf ein privates Objekt.
    public static List<int> SammleGerade(int[] a)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Vorgegeben und absichtlich FALSCH (die Tests rufen sie nicht auf): Mehrere Threads fügen gleichzeitig in
    // eine List<int> ein. List<T> ist dafür nicht gebaut: Es gehen Elemente verloren, es können doppelte
    // Einträge oder sogar Ausnahmen entstehen, und das Ergebnis ändert sich von Lauf zu Lauf.
    // So sieht der Fehler aus, den SammleGerade mit dem lock vermeiden soll.
    public static List<int> SammleGeradeUnsicher(int[] a)
    {
        var ergebnis = new List<int>();
        Parallel.ForEach(a, x =>
        {
            if (x % 2 == 0)
                ergebnis.Add(x);   // RACE CONDITION
        });
        return ergebnis;
    }

    // Führt die drei Aktionen gleichzeitig aus und kehrt erst zurück, wenn alle drei fertig sind.
    // Hinweis: Parallel.Invoke(a, b, c)
    public static void Gleichzeitig(Action a, Action b, Action c)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Führt 'koerper' genau 'anzahl' Mal aus, parallel, aber mit höchstens 'maxGrad' gleichzeitig laufenden
    // Iterationen. Hinweis: Parallel.For(0, anzahl, new ParallelOptions { MaxDegreeOfParallelism = maxGrad }, ...)
    public static void WiederholeParallel(int anzahl, int maxGrad, Action koerper)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Vorgegeben: Probedivision.
    public static bool IstPrim(int n)
    {
        if (n < 2) return false;
        if (n % 2 == 0) return n == 2;
        for (int teiler = 3; (long)teiler * teiler <= n; teiler += 2)
            if (n % teiler == 0)
                return false;
        return true;
    }

    // Alle Primzahlen von 2 bis einschließlich 'bis', aufsteigend. Mit PLINQ:
    // Enumerable.Range(2, bis - 1).AsParallel().AsOrdered().Where(IstPrim).ToList()
    // AsOrdered() sorgt dafür, dass das parallele Ergebnis in derselben Reihenfolge wie das sequenzielle
    // kommt (ohne AsOrdered ist die Reihenfolge nicht zugesichert). Für bis < 2 ist das Ergebnis leer.
    public static List<int> Primzahlen(int bis)
    {
        // TODO
        throw new NotImplementedException();
    }
}
