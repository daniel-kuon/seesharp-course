public static class Serie {
    // Größtes Element der Serie; leere Serie -> ArgumentException.
    public static T Max<T>(params T[] werte) where T : IComparable<T> {
        if (werte.Length == 0)
            throw new ArgumentException("Leere Serie", nameof(werte));
        T max = werte[0];
        for (int i = 1; i < werte.Length; i++)
            if (werte[i].CompareTo(max) > 0)
                max = werte[i];
        return max;
    }

    // Kleinstes Element der Serie; leere Serie -> ArgumentException.
    public static T Min<T>(params T[] werte) where T : IComparable<T> {
        if (werte.Length == 0)
            throw new ArgumentException("Leere Serie", nameof(werte));
        T min = werte[0];
        for (int i = 1; i < werte.Length; i++)
            if (werte[i].CompareTo(min) < 0)
                min = werte[i];
        return min;
    }

    // Wie Max, aber null statt Ausnahme bei leerer Serie. Nur für Werttypen sinnvoll.
    public static T? MaxOderNull<T>(params T[] werte) where T : struct, IComparable<T> {
        if (werte.Length == 0)
            return null;
        return Max(werte);
    }

    // Begrenzt wert auf den Bereich min..max.
    public static T Klemme<T>(T wert, T min, T max) where T : IComparable<T> {
        if (wert.CompareTo(min) < 0)
            return min;
        if (wert.CompareTo(max) > 0)
            return max;
        return wert;
    }
}
