namespace Artikelverwaltung;

/// <summary>Ein Artikel. Kategorie ist null, wenn der Artikel keiner Kategorie zugeordnet ist.</summary>
public record Artikel(int Id, string Name, decimal Preis, int Bestand, string? Kategorie);
