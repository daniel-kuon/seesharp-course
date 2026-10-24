using System.Diagnostics.CodeAnalysis;

namespace Nullsicherheit;

public static class PalindromReverse
{
    /// <summary>Kehrt einen Text um. Für null kommt null zurück, sonst nie.</summary>
    [return: NotNullIfNotNull(nameof(s))]
    public static string? Reverse(string? s)
    {
        if (s is null) return null;
        var zeichen = s.ToCharArray();
        Array.Reverse(zeichen);
        return new string(zeichen);
    }

    /// <summary>Sucht den ersten Eintrag, der mit prefix beginnt.</summary>
    public static bool TryFinde(string[] daten, string prefix, [NotNullWhen(true)] out string? treffer)
    {
        foreach (var eintrag in daten)
        {
            if (eintrag.StartsWith(prefix, StringComparison.Ordinal))
            {
                treffer = eintrag;
                return true;
            }
        }
        treffer = null;
        return false;
    }

    /// <summary>Liefert das erste Element, das nicht null ist.</summary>
    public static string ErstesVorhandenes(string?[] daten)
    {
        if (!daten.Any(d => d is not null))
            throw new InvalidOperationException("Alle Einträge sind null.");
        // ! ist hier begründet: Any hat eben gezeigt, dass ein Eintrag != null existiert.
        // Durch das Lambda sieht die Nullzustandsanalyse das nicht.
        return daten.First(d => d is not null)!;
    }
}
