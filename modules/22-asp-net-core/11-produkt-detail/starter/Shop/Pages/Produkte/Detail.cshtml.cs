using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Seite /Produkte/Detail/{id}: ein Produkt.
public class ProduktDetailModel(IProduktkatalog katalog) : PageModel
{
    public Produkt? Produkt { get; private set; }

    // TODO: Produkt mit katalog.Finde(id) suchen und in Produkt speichern.
    //       Gibt es keins, ist die Antwort NotFound() (404), sonst Page().
    public IActionResult OnGet(int id)
    {
        throw new NotImplementedException();
    }
}
