using System.Text;

public static class Fabrik
{
    // TODO: ein Lambda zurückgeben, das k einfängt (Predicate<int>: x <= k)
    public static Predicate<int> KleinerGleich(int k) => throw new NotImplementedException();

    // TODO: lokale Variable anlegen und ein Lambda zurückgeben, das sie bei jedem Aufruf erhöht
    public static Func<int> Zaehler() => throw new NotImplementedException();

    // TODO: Lambda, das n addiert
    public static Func<int, int> Addierer(int n) => throw new NotImplementedException();

    // TODO: x => g(f(x))
    public static Func<int, int> Komponiere(Func<int, int> f, Func<int, int> g) => throw new NotImplementedException();

    // TODO: alle Aktionen der Reihe nach aufrufen
    public static void FuehreAus(IEnumerable<Action> aktionen) => throw new NotImplementedException();

    // TODO: n Aktionen erzeugen; Aktion i hängt i an sb an. Welche Variable fängt dein Lambda ein?
    public static List<Action> ErzeugeAktionen(StringBuilder sb, int n) => throw new NotImplementedException();

    // TODO: Dictionary in der Closure; f nur aufrufen, wenn das Argument noch nicht bekannt ist
    public static Func<int, int> Merke(Func<int, int> f) => throw new NotImplementedException();
}
