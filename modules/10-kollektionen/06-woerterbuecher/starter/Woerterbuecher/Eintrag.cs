// Vorgegeben, nicht ändern. Ein Wort mit seiner Häufigkeit.
// Sortierreihenfolge: größere Anzahl zuerst, bei gleicher Anzahl alphabetisch.
public class Eintrag(string wort, int anzahl) : IComparable<Eintrag>
{
    public string Wort { get; } = wort;
    public int Anzahl { get; } = anzahl;

    public int CompareTo(Eintrag? other)
    {
        if (other is null)
            return 1;
        int nachAnzahl = other.Anzahl.CompareTo(Anzahl);
        return nachAnzahl != 0 ? nachAnzahl : string.CompareOrdinal(Wort, other.Wort);
    }
}
