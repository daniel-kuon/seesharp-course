using System.Reflection;

public static class Validierer
{
    // Prüft alle öffentlichen Eigenschaften von o in Deklarationsreihenfolge und liefert die Fehlermeldungen
    // (leere Liste = alles in Ordnung):
    // - [Pflicht]: Der Wert ist null oder (bei Text) leer bzw. nur Leerraum -> "<Name>: ist ein Pflichtfeld"
    // - [Bereich(min, max)]: Der Wert (Convert.ToInt32) liegt außerhalb -> "<Name>: muss zwischen <min> und <max> liegen"
    //   Ein null-Wert wird nicht auf den Bereich geprüft (dafür gibt es [Pflicht]).
    // Hat eine Eigenschaft beide Attribute, kommt die Pflicht-Meldung zuerst; ist sie null, entfällt die Bereichsprüfung.
    // Hinweis: GetProperties(), GetCustomAttribute<T>(), PropertyInfo.GetValue(o)
    public static List<string> Pruefe(object o)
    {
        // TODO
        throw new NotImplementedException();
    }
}
