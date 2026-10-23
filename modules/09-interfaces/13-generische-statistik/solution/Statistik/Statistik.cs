using System.Numerics;

// Statistik für jeden Zahltyp: int, long, double, decimal, ...
public static class Statistik {
    public static T Summe<T>(params T[] werte) where T : INumber<T> {
        T summe = T.Zero;
        foreach (T w in werte)
            summe += w;
        return summe;
    }

    // Wie Summe, aber ein Überlauf wirft OverflowException.
    public static T SummeGeprueft<T>(params T[] werte) where T : INumber<T> {
        T summe = T.Zero;
        foreach (T w in werte)
            summe = checked(summe + w);
        return summe;
    }

    public static T Produkt<T>(params T[] werte) where T : INumber<T> {
        T produkt = T.One;
        foreach (T w in werte)
            produkt *= w;
        return produkt;
    }

    // Summe geteilt durch Anzahl; bei Ganzzahltypen ganzzahlig.
    public static T Mittelwert<T>(params T[] werte) where T : INumber<T> {
        PruefeNichtLeer(werte);
        return Summe(werte) / T.CreateChecked(werte.Length);
    }

    public static T Minimum<T>(params T[] werte) where T : INumber<T> {
        PruefeNichtLeer(werte);
        T min = werte[0];
        foreach (T w in werte)
            if (w < min)
                min = w;
        return min;
    }

    public static T Maximum<T>(params T[] werte) where T : INumber<T> {
        PruefeNichtLeer(werte);
        T max = werte[0];
        foreach (T w in werte)
            if (w > max)
                max = w;
        return max;
    }

    public static T Spannweite<T>(params T[] werte) where T : INumber<T> => Maximum(werte) - Minimum(werte);

    static void PruefeNichtLeer<T>(T[] werte) {
        if (werte.Length == 0)
            throw new ArgumentException("Leere Serie", nameof(werte));
    }
}
