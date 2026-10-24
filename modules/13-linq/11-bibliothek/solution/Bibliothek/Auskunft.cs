public record Autor(int Id, string Name);

public record Buch(int Id, string Titel, int AutorId);

public record Ausleihe(int BuchId, string Leser);

public class Auskunft(IEnumerable<Buch> buecher, IEnumerable<Autor> autoren, IEnumerable<Ausleihe> ausleihen)
{
    public List<(string Titel, string Autor)> BuecherMitAutor() =>
        buecher
            .Join(autoren, b => b.AutorId, a => a.Id, (b, a) => (b.Titel, Autor: a.Name))
            .OrderBy(x => x.Titel, StringComparer.Ordinal)
            .ToList();

    public List<string> Ausleihen(string leser) =>
        ausleihen
            .Where(a => a.Leser == leser)
            .Join(buecher, a => a.BuchId, b => b.Id, (a, b) => b.Titel)
            .OrderBy(titel => titel, StringComparer.Ordinal)
            .ToList();

    public List<string> NieAusgeliehen() =>
        buecher
            .GroupJoin(ausleihen, b => b.Id, a => a.BuchId, (b, as_) => (b.Titel, Anzahl: as_.Count()))
            .Where(x => x.Anzahl == 0)
            .Select(x => x.Titel)
            .OrderBy(titel => titel, StringComparer.Ordinal)
            .ToList();
}
