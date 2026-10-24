public record Autor(int Id, string Name);

public record Buch(int Id, string Titel, int AutorId);

public record Ausleihe(int BuchId, string Leser);

public class Auskunft(IEnumerable<Buch> buecher, IEnumerable<Autor> autoren, IEnumerable<Ausleihe> ausleihen)
{
    // TODO: Join(autoren, ...) -> (Titel, Autorname), nach Titel sortiert (StringComparer.Ordinal)
    public List<(string Titel, string Autor)> BuecherMitAutor() => throw new NotImplementedException();

    // TODO: Ausleihen des Lesers filtern, mit den Büchern verknüpfen, Titel sortieren
    public List<string> Ausleihen(string leser) => throw new NotImplementedException();

    // TODO: GroupJoin der Bücher mit den Ausleihen; Bücher mit leerer Gruppe, Titel sortiert
    public List<string> NieAusgeliehen() => throw new NotImplementedException();
}
