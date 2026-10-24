using System.Reflection;

public static class Laeufer
{
    public static List<(string Name, bool Bestanden)> Starte(Type t)
    {
        List<MethodInfo> tests = t.GetMethods(BindingFlags.Public | BindingFlags.Instance)
            .Where(m => m.IsDefined(typeof(MeinTestAttribute)) && m.GetParameters().Length == 0)
            .OrderBy(m => m.Name, StringComparer.Ordinal)
            .ToList();

        var ergebnis = new List<(string Name, bool Bestanden)>();
        if (tests.Count == 0)
            return ergebnis;

        object instanz = Activator.CreateInstance(t)!;
        foreach (MethodInfo test in tests)
        {
            bool bestanden;
            try
            {
                test.Invoke(instanz, null);
                bestanden = true;
            }
            catch (TargetInvocationException)
            {
                bestanden = false;
            }
            ergebnis.Add((test.Name, bestanden));
        }
        return ergebnis;
    }
}
