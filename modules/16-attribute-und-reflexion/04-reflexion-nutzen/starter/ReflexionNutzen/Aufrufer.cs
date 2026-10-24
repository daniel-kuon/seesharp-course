using System.Reflection;

public static class Aufrufer
{
    // Ruft die öffentliche Instanzmethode 'methode' von o auf, die KEINE Parameter hat,
    // und liefert ihr Ergebnis. Für eine void-Methode liefert Starte null.
    // Gibt es keine solche Methode, liefert Starte den Text "?" (keine Ausnahme).
    // Hinweis: o.GetType().GetMethod(name, Type.EmptyTypes) wählt die parameterlose Überladung;
    //          MethodInfo.Invoke(o, null) ruft sie auf; mi.ReturnType == typeof(void)
    public static object? Starte(object o, string methode)
    {
        // TODO
        throw new NotImplementedException();
    }
}
