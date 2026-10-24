using System.ComponentModel.DataAnnotations;

namespace Blogging;

/// <summary>Eine Entitätsklasse: Jede Instanz entspricht einer Zeile der Tabelle Blogs.</summary>
public class Blog
{
    public int Id { get; set; }

    [Required, MaxLength(100)]
    public string Name { get; set; } = "";

    public string? Beschreibung { get; set; }
}
