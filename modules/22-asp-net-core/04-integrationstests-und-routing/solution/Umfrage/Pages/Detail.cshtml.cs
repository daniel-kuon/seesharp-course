using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Detailseite einer Partei. Der Parameter id kommt aus der Route (siehe @page in Detail.cshtml).
public class DetailModel(IUmfrageDienst dienst) : PageModel
{
    public Partei? Partei { get; private set; }
    public int Stimmen { get; private set; }

    public IActionResult OnGet(int id)
    {
        Partei = Parteien.Alle.FirstOrDefault(p => p.Id == id);
        if (Partei is null)
            return NotFound();

        Stimmen = dienst.Stimmen().Count(s => s.Partei == Partei.Name);
        return Page();
    }
}
