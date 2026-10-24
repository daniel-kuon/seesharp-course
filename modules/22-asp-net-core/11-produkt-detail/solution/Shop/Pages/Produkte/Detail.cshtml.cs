using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Seite /Produkte/Detail/{id}: ein Produkt.
public class ProduktDetailModel(IProduktkatalog katalog) : PageModel
{
    public Produkt? Produkt { get; private set; }

    public IActionResult OnGet(int id)
    {
        Produkt = katalog.Finde(id);
        return Produkt is null ? NotFound() : Page();
    }
}
