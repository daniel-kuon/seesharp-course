public static class Serie {
    // Größtes Element der Serie; leere Serie -> ArgumentException.
    public static T Max<T>(params T[] werte) where T : IComparable<T> {
        // TODO
        throw new NotImplementedException();
    }

    // Kleinstes Element der Serie; leere Serie -> ArgumentException.
    public static T Min<T>(params T[] werte) where T : IComparable<T> {
        // TODO
        throw new NotImplementedException();
    }

    // Wie Max, aber null statt Ausnahme bei leerer Serie. Nur für Werttypen sinnvoll:
    // TODO: Einschränkung ergänzen, damit T? ein Nullable<T> ist (where T : struct, IComparable<T>)
    public static T? MaxOderNull<T>(params T[] werte) where T : IComparable<T> {
        // TODO
        throw new NotImplementedException();
    }

    // Begrenzt wert auf den Bereich min..max.
    public static T Klemme<T>(T wert, T min, T max) where T : IComparable<T> {
        // TODO
        throw new NotImplementedException();
    }
}
