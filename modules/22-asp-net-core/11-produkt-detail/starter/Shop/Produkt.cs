public record Produkt(int Id, string Name, string Beschreibung);

// Abhängigkeit der Seiten: der Produktkatalog.
public interface IProduktkatalog
{
    IReadOnlyList<Produkt> Alle();
    Produkt? Finde(int id);
}

public class FesterKatalog : IProduktkatalog
{
    private static readonly Produkt[] Produkte =
    [
        new(1, "Kaffeemuehle", "Handmuehle aus Holz"),
        new(2, "Teekanne", "Kanne aus Porzellan mit Sieb"),
        new(3, "Wasserkessel", "Kessel aus Edelstahl, 1,5 Liter"),
    ];

    public IReadOnlyList<Produkt> Alle() => Produkte;

    public Produkt? Finde(int id) => Produkte.FirstOrDefault(p => p.Id == id);
}
