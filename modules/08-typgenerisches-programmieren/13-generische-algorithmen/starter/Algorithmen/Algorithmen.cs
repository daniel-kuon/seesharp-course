// TODO: Jede Methode braucht die Einschränkung where T : IComparable<T>, damit CompareTo bekannt ist.
public static class Algorithmen {
    // Jedes Element höchstens so groß wie sein Nachfolger?
    public static bool IstSortiert<T>(T[] werte) {
        // TODO
        throw new NotImplementedException();
    }

    // Index von gesucht im sortierten Array oder -1; halbiert den Suchbereich in jedem Schritt.
    public static int BinaereSuche<T>(T[] sortiert, T gesucht) {
        // TODO: links, rechts, mitte
        throw new NotImplementedException();
    }

    // Verschmilzt zwei sortierte Arrays zu einem neuen sortierten Array (Merge-Schritt).
    public static T[] Zusammenfuehren<T>(T[] a, T[] b) {
        // TODO: zwei Indizes, jeweils das kleinere Element übernehmen, dann den Rest
        throw new NotImplementedException();
    }

    // Kleinstes und größtes Element in einem Durchlauf; leere Serie -> ArgumentException.
    public static (T Min, T Max) MinMax<T>(params T[] werte) {
        // TODO
        throw new NotImplementedException();
    }
}
