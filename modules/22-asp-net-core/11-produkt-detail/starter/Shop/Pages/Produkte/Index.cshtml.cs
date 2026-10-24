using Microsoft.AspNetCore.Mvc.RazorPages;

// Seite /Produkte: die Liste aller Produkte.
public class ProdukteModel(IProduktkatalog katalog) : PageModel
{
    public IReadOnlyList<Produkt> Liste { get; private set; } = [];

    public void OnGet()
    {
        Liste = katalog.Alle();
    }
}
