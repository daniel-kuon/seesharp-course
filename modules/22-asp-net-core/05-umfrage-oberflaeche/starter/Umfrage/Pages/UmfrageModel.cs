using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class UmfrageModel : PageModel
{
    private readonly IUmfrageDienst _dienst;

    public UmfrageModel(IUmfrageDienst dienst)
    {
        _dienst = dienst;
    }

    [BindProperty]
    public Stimme Eingabe { get; set; } = new();

    public IReadOnlyList<ParteiErgebnis> Ergebnisse { get; private set; } = [];

    // Für ein <select>: die Parteien als Auswahlliste (asp-items).
    public IEnumerable<SelectListItem> ParteiAuswahl { get; } =
        Parteien.Alle.Select(p => new SelectListItem(p.Name, p.Name));

    public void OnGet()
    {
        Ergebnisse = Auswerten();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Ergebnisse = Auswerten();
            return Page();
        }

        _dienst.Abgeben(Eingabe);
        return RedirectToPage("Danke", new { partei = Eingabe.Partei });
    }

    private List<ParteiErgebnis> Auswerten() =>
        _dienst.Stimmen()
            .GroupBy(s => s.Partei)
            .Select(g => new ParteiErgebnis(g.Key, g.Count()))
            .OrderByDescending(e => e.Stimmen)
            .ThenBy(e => e.Partei)
            .ToList();
}
