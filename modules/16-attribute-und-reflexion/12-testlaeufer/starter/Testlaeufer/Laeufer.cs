using System.Reflection;

public static class Laeufer
{
    // Führt alle Tests der Klasse t aus:
    // - Es wird EINE Instanz von t erzeugt (Activator.CreateInstance(t)); alle Tests laufen auf ihr.
    // - Tests sind die öffentlichen Instanzmethoden ohne Parameter, die [MeinTest] tragen.
    // - Sie laufen in der Reihenfolge ihrer Namen (Ordinal-Vergleich).
    // - Wirft eine Methode eine Ausnahme, ist der Test nicht bestanden; die übrigen laufen trotzdem.
    //   Hinweis: MethodInfo.Invoke verpackt die Ausnahme in eine TargetInvocationException.
    // Ergebnis: pro Test (Name, bestanden). Ohne Tests: leere Liste.
    public static List<(string Name, bool Bestanden)> Starte(Type t)
    {
        // TODO
        throw new NotImplementedException();
    }
}
