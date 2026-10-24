using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Das PageModel der Seite "Umfrage" (Buch 22.5). Es kennt keinen HTTP-Kram außer ModelState und den Ergebnistypen.
public class UmfrageModel : PageModel
{
    private readonly IUmfrageDienst _dienst;

    public UmfrageModel(IUmfrageDienst dienst)
    {
        _dienst = dienst;
    }

    [BindProperty]
    public Stimme Eingabe { get; set; } = new();

    // Die Ergebnistabelle der Seite: eine Zeile je Partei, die meisten Stimmen zuerst.
    public IReadOnlyList<ParteiErgebnis> Ergebnisse { get; private set; } = [];

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
