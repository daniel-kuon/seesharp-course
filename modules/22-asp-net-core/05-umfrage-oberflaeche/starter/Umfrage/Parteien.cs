// Die Parteien der Umfrage; Id und Name stehen fest (keine Datenbank).
public record Partei(int Id, string Name);

public static class Parteien
{
    public static IReadOnlyList<Partei> Alle { get; } =
    [
        new(1, "Sonnenpartei"),
        new(2, "Mondbund"),
        new(3, "Sternenliste"),
    ];
}
