using System.Reflection;

public static class Dokumentation
{
    public static List<string> AutorenVon(Type t)
    {
        List<string> namen = t.GetCustomAttributes<AutorAttribute>().Select(a => a.Name).ToList();
        namen.Sort(StringComparer.Ordinal);
        return namen;
    }

    public static List<string> MethodenMitAutor(Type t)
    {
        List<string> namen = t.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.IsDefined(typeof(AutorAttribute)))
            .Select(m => m.Name)
            .ToList();
        namen.Sort(StringComparer.Ordinal);
        return namen;
    }

    public static List<string> Eigenschaften(Type t)
    {
        List<string> eintraege = t.GetProperties()
            .Select(p => $"{p.Name}:{p.PropertyType.Name}")
            .ToList();
        eintraege.Sort(StringComparer.Ordinal);
        return eintraege;
    }

    // GetType() liefert den Typ des Objekts zur Laufzeit ...
    public static string TypName(object o) => o.GetType().Name;

    // ... typeof(T) den Typ, der zur Übersetzungszeit feststeht.
    public static string TypNameStatisch<T>() => typeof(T).Name;

    public static string? Veraltet(Type t) => t.GetCustomAttribute<ObsoleteAttribute>()?.Message;
}
