public static class Protokoll
{
    // Liefert "<aufrufende Methode>:<Zeile>: <text>".
    // Der Aufrufer soll Methodenname und Zeilennummer nicht selbst angeben müssen.
    // TODO: Versieh 'member' und 'zeile' mit den passenden Aufruferinformations-Attributen
    //       ([CallerMemberName], [CallerLineNumber], Namensraum System.Runtime.CompilerServices).
    public static string Log(string text, string? member = null, int zeile = 0)
    {
        // TODO: "<member>:<zeile>: <text>" zurückgeben
        throw new NotImplementedException();
    }
}
