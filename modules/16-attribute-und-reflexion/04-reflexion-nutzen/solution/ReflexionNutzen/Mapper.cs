using System.Globalization;
using System.Reflection;

public static class Mapper
{
    public static List<string> NachZeilen(object o)
    {
        var zeilen = new List<string>();
        foreach (PropertyInfo p in o.GetType().GetProperties())
        {
            var spalte = p.GetCustomAttribute<SpalteAttribute>();
            if (spalte == null)
                continue;
            string wert = Convert.ToString(p.GetValue(o), CultureInfo.InvariantCulture) ?? "";
            zeilen.Add($"{spalte.Name}={wert}");
        }
        return zeilen;
    }

    public static T VonZeilen<T>(string[] zeilen) where T : class
    {
        T objekt = Activator.CreateInstance<T>();
        PropertyInfo[] eigenschaften = typeof(T).GetProperties();

        foreach (string zeile in zeilen)
        {
            int gleich = zeile.IndexOf('=');
            if (gleich < 0)
                continue;

            string schluessel = zeile[..gleich];
            string text = zeile[(gleich + 1)..];

            PropertyInfo? ziel = eigenschaften.FirstOrDefault(
                p => p.GetCustomAttribute<SpalteAttribute>()?.Name == schluessel);
            if (ziel == null)
                continue;

            try
            {
                object wert = Convert.ChangeType(text, ziel.PropertyType, CultureInfo.InvariantCulture);
                ziel.SetValue(objekt, wert);
            }
            catch (Exception ex) when (ex is FormatException or OverflowException)
            {
                // Wert unlesbar: Eigenschaft bleibt unverändert.
            }
        }
        return objekt;
    }
}
