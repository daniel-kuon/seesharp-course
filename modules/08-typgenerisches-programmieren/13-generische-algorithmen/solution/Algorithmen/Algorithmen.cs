public static class Algorithmen {
    // Jedes Element höchstens so groß wie sein Nachfolger?
    public static bool IstSortiert<T>(T[] werte) where T : IComparable<T> {
        for (int i = 0; i < werte.Length - 1; i++)
            if (werte[i].CompareTo(werte[i + 1]) > 0)
                return false;
        return true;
    }

    // Index von gesucht im sortierten Array oder -1; halbiert den Suchbereich in jedem Schritt.
    public static int BinaereSuche<T>(T[] sortiert, T gesucht) where T : IComparable<T> {
        int links = 0, rechts = sortiert.Length - 1;
        while (links <= rechts) {
            int mitte = links + (rechts - links) / 2;
            int vergleich = gesucht.CompareTo(sortiert[mitte]);
            if (vergleich == 0)
                return mitte;
            if (vergleich < 0)
                rechts = mitte - 1;
            else
                links = mitte + 1;
        }
        return -1;
    }

    // Verschmilzt zwei sortierte Arrays zu einem neuen sortierten Array (Merge-Schritt).
    public static T[] Zusammenfuehren<T>(T[] a, T[] b) where T : IComparable<T> {
        var ergebnis = new T[a.Length + b.Length];
        int i = 0, j = 0, k = 0;
        while (i < a.Length && j < b.Length)
            ergebnis[k++] = a[i].CompareTo(b[j]) <= 0 ? a[i++] : b[j++];
        while (i < a.Length)
            ergebnis[k++] = a[i++];
        while (j < b.Length)
            ergebnis[k++] = b[j++];
        return ergebnis;
    }

    // Kleinstes und größtes Element in einem Durchlauf; leere Serie -> ArgumentException.
    public static (T Min, T Max) MinMax<T>(params T[] werte) where T : IComparable<T> {
        if (werte.Length == 0)
            throw new ArgumentException("Leere Serie", nameof(werte));
        T min = werte[0], max = werte[0];
        for (int i = 1; i < werte.Length; i++) {
            if (werte[i].CompareTo(min) < 0)
                min = werte[i];
            if (werte[i].CompareTo(max) > 0)
                max = werte[i];
        }
        return (min, max);
    }
}
