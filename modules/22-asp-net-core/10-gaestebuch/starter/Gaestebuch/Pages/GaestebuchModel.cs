using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// PageModel der Seite "Gaestebuch": Einträge anzeigen und neue entgegennehmen.
public class GaestebuchModel : PageModel
{
    // TODO 1: Dienst per Konstruktor entgegennehmen und in einem Feld speichern.
    public GaestebuchModel(IGaestebuch gaestebuch)
    {
    }

    // TODO 2: Der neue Eintrag kommt aus dem Formular (Modellbindung).
    public Eintrag Neu { get; set; } = new();

    // Die angezeigten Einträge, der neueste zuerst.
    public IReadOnlyList<Eintrag> Eintraege { get; private set; } = [];

    // TODO 3: Eintraege aus dem Dienst füllen, neueste zuerst (Alle() liefert die ältesten zuerst).
    public void OnGet()
    {
        throw new NotImplementedException();
    }

    // TODO 4: Ungültig: Eintraege füllen, Page() zurückgeben, nichts speichern.
    //         Gültig: Neu speichern und auf dieselbe Seite umleiten (RedirectToPage() ohne Seitenname),
    //         damit ein Neuladen nicht noch einmal speichert.
    public IActionResult OnPost()
    {
        throw new NotImplementedException();
    }
}
