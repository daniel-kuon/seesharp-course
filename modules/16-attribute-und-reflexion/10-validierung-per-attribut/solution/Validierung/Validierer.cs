using System.Reflection;

public static class Validierer
{
    public static List<string> Pruefe(object o)
    {
        var fehler = new List<string>();

        foreach (PropertyInfo p in o.GetType().GetProperties())
        {
            object? wert = p.GetValue(o);

            if (p.IsDefined(typeof(PflichtAttribute)) && (wert == null || (wert is string s && string.IsNullOrWhiteSpace(s))))
                fehler.Add($"{p.Name}: ist ein Pflichtfeld");

            var bereich = p.GetCustomAttribute<BereichAttribute>();
            if (bereich != null && wert != null)
            {
                int zahl = Convert.ToInt32(wert);
                if (zahl < bereich.Min || zahl > bereich.Max)
                    fehler.Add($"{p.Name}: muss zwischen {bereich.Min} und {bereich.Max} liegen");
            }
        }
        return fehler;
    }
}
