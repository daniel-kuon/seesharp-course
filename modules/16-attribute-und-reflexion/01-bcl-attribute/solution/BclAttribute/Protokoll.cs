using System.Runtime.CompilerServices;

public static class Protokoll
{
    // Der Compiler setzt Methodenname und Zeilennummer der Aufrufstelle selbst ein.
    public static string Log(string text,
        [CallerMemberName] string? member = null,
        [CallerLineNumber] int zeile = 0)
    {
        return $"{member}:{zeile}: {text}";
    }
}
