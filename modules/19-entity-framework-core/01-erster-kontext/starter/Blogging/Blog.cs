namespace Blogging;

/// <summary>Eine Entitätsklasse: Jede Instanz entspricht einer Zeile der Tabelle Blogs.</summary>
public class Blog
{
    // Eine Eigenschaft Id (oder BlogId) erkennt EF Core per Konvention als Primärschlüssel.
    public int Id { get; set; }

    // TODO: Name ist Pflicht und höchstens 100 Zeichen lang: Annotationen [Required] und [MaxLength(100)]
    // (Namensraum System.ComponentModel.DataAnnotations).
    public string Name { get; set; } = "";

    public string? Beschreibung { get; set; }
}
