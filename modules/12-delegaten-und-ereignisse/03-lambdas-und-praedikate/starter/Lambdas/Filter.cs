public static class Filter
{
    // TODO: FindAll mit einem Ausdruckslambda (Predicate<string>): Länge > 5
    public static List<string> LangeWoerter(List<string> woerter) => throw new NotImplementedException();

    // TODO: RemoveAll mit string.IsNullOrWhiteSpace; Rückgabe = Anzahl der gelöschten Einträge
    public static int OhneLeere(List<string?> woerter) => throw new NotImplementedException();

    // TODO: Exists
    public static bool Existiert(List<int> werte, int wert) => throw new NotImplementedException();

    // TODO: Find; null, wenn kein Wort mit dem Zeichen beginnt (leere Wörter beachten)
    public static string? ErstesMit(List<string> woerter, char anfang) => throw new NotImplementedException();

    // TODO: Sort mit einem Lambda mit Anweisungsblock { ... }: erst Länge, dann string.CompareOrdinal
    public static void SortiereNachLaenge(List<string> woerter) => throw new NotImplementedException();

    // TODO: ForEach und eine lokale Variable summe, die das Lambda verändert
    public static int Summe(List<int> werte) => throw new NotImplementedException();
}
