using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// PageModel der Seite "Gaestebuch": Einträge anzeigen und neue entgegennehmen.
public class GaestebuchModel : PageModel
{
    private readonly IGaestebuch _gaestebuch;

    public GaestebuchModel(IGaestebuch gaestebuch)
    {
        _gaestebuch = gaestebuch;
    }

    [BindProperty]
    public Eintrag Neu { get; set; } = new();

    // Die angezeigten Einträge, der neueste zuerst.
    public IReadOnlyList<Eintrag> Eintraege { get; private set; } = [];

    public void OnGet()
    {
        Eintraege = Neueste();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            Eintraege = Neueste();
            return Page();
        }

        _gaestebuch.Hinzufuegen(Neu);
        return RedirectToPage();
    }

    private IReadOnlyList<Eintrag> Neueste() => _gaestebuch.Alle().Reverse().ToList();
}
