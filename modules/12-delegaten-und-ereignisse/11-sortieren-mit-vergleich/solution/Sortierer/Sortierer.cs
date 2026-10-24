public record Person(string Name, int Alter);

public static class Sortierer
{
    public static void NachAlter(List<Person> liste) =>
        liste.Sort((a, b) => a.Alter.CompareTo(b.Alter));

    public static void NachNameDannAlter(List<Person> liste) =>
        liste.Sort((a, b) =>
        {
            int name = string.CompareOrdinal(a.Name, b.Name);
            return name != 0 ? name : a.Alter.CompareTo(b.Alter);
        });

    public static List<Person> AelterAls(List<Person> liste, int grenze) =>
        liste.FindAll(p => p.Alter > grenze);

    public static int EntferneMinderjaehrige(List<Person> liste) =>
        liste.RemoveAll(p => p.Alter < 18);

    public static Person? Juengste(List<Person> liste)
    {
        Person? juengste = null;
        liste.ForEach(p =>
        {
            if (juengste is null || p.Alter < juengste.Alter)
                juengste = p;
        });
        return juengste;
    }
}
