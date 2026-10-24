using System.Globalization;
using System.Reflection;

public static class Mapper
{
    // Schreibt jede Eigenschaft von o, die [Spalte("name")] trägt, als "name=wert".
    // Reihenfolge: wie die Eigenschaften im Quelltext deklariert sind (GetProperties()).
    // Eigenschaften ohne [Spalte] werden übersprungen. Zahlen immer mit InvariantCulture
    // formatieren (2.5, nicht 2,5); null wird zum leeren Text.
    // Hinweis: PropertyInfo.GetValue(o), Convert.ToString(wert, CultureInfo.InvariantCulture)
    public static List<string> NachZeilen(object o)
    {
        // TODO
        throw new NotImplementedException();
    }

    // Erzeugt ein T mit Activator.CreateInstance<T>() und setzt die Eigenschaften aus Zeilen
    // der Form "name=wert". Gesucht wird die Eigenschaft, deren [Spalte]-Name zum Schlüssel passt.
    // - Geteilt wird am ersten '=' (der Wert darf selbst ein '=' enthalten).
    // - Zeilen ohne '=' und unbekannte Schlüssel werden ignoriert.
    // - Der Wert wird mit Convert.ChangeType(wert, p.PropertyType, CultureInfo.InvariantCulture)
    //   umgewandelt und mit PropertyInfo.SetValue(objekt, wert) gesetzt.
    // - Lässt sich ein Wert nicht umwandeln (FormatException, OverflowException), bleibt die
    //   Eigenschaft unverändert; die übrigen Zeilen werden trotzdem gelesen.
    public static T VonZeilen<T>(string[] zeilen) where T : class
    {
        // TODO
        throw new NotImplementedException();
    }
}
