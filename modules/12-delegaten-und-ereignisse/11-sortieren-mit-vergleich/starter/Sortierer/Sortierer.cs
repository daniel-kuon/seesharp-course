public record Person(string Name, int Alter);

public static class Sortierer
{
    // TODO: liste.Sort mit einem Ausdruckslambda (a, b) => ...
    public static void NachAlter(List<Person> liste) => throw new NotImplementedException();

    // TODO: Sort; erst CompareOrdinal der Namen, bei Gleichstand das Alter (Lambda mit Anweisungsblock)
    public static void NachNameDannAlter(List<Person> liste) => throw new NotImplementedException();

    // TODO: FindAll; strikt älter als grenze
    public static List<Person> AelterAls(List<Person> liste, int grenze) => throw new NotImplementedException();

    // TODO: RemoveAll (Alter < 18); Rückgabe = Anzahl der gelöschten Personen
    public static int EntferneMinderjaehrige(List<Person> liste) => throw new NotImplementedException();

    // TODO: ForEach mit Anweisungsblock-Lambda und einer lokalen Variablen für das bisherige Minimum
    public static Person? Juengste(List<Person> liste) => throw new NotImplementedException();
}
