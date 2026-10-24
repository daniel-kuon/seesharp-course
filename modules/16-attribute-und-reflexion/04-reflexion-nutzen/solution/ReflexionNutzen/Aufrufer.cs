using System.Reflection;

public static class Aufrufer
{
    public static object? Starte(object o, string methode)
    {
        MethodInfo? mi = o.GetType().GetMethod(methode, Type.EmptyTypes);
        if (mi == null)
            return "?";

        object? ergebnis = mi.Invoke(o, null);
        return mi.ReturnType == typeof(void) ? null : ergebnis;
    }
}
