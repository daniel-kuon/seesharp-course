using System.Reflection;

// Alle Methoden werten per Reflexion die Metadaten eines Typs aus.
// Listen werden mit List<string>.Sort(StringComparer.Ordinal) sortiert.
public static class Dokumentation
{
    // Die Namen aller [Autor]-Attribute der Klasse t, sortiert (es dürfen mehrere sein).
    // Hinweis: t.GetCustomAttributes<AutorAttribute>() (Namensraum System.Reflection)
    public static List<string> AutorenVon(Type t)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Namen der öffentlichen Instanzmethoden von t, die [Autor] tragen, sortiert.
    // Hinweis: t.GetMethods(BindingFlags.Public | BindingFlags.Instance) schließt statische Methoden aus;
    //          MemberInfo.IsDefined(typeof(AutorAttribute)) fragt nach dem Attribut.
    public static List<string> MethodenMitAutor(Type t)
    {
        // TODO
        throw new NotImplementedException();
    }

    // "Name:Typ" für jede öffentliche Eigenschaft, sortiert, z. B. "Alter:Int32".
    // Hinweis: t.GetProperties(), PropertyInfo.PropertyType.Name
    public static List<string> Eigenschaften(Type t)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Name des Laufzeittyps von o (o.GetType()).
    public static string TypName(object o)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Name des Typparameters T, ohne ein Objekt zu brauchen (typeof(T)).
    public static string TypNameStatisch<T>()
    {
        // TODO
        throw new NotImplementedException();
    }

    // Die Meldung des [Obsolete]-Attributs von t, oder null, wenn t nicht veraltet ist.
    // Hinweis: t.GetCustomAttribute<ObsoleteAttribute>() liefert null, wenn das Attribut fehlt.
    public static string? Veraltet(Type t)
    {
        // TODO
        throw new NotImplementedException();
    }
}
