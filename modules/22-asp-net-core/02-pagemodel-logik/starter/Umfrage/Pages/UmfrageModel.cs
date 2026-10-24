using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Das PageModel der Seite "Umfrage" (Buch 22.5). Es kennt keinen HTTP-Kram außer ModelState und den Ergebnistypen.
public class UmfrageModel : PageModel
{
    // TODO 1: Speichere den per Konstruktor injizierten Dienst in einem Feld (Konstruktorinjektion, Buch 22.3).
    public UmfrageModel(IUmfrageDienst dienst)
    {
    }

    // TODO 2: Der Formularinhalt wird per Modellbindung in diese Eigenschaft geschrieben ([BindProperty], Buch 22.8).
    public Stimme Eingabe { get; set; } = new();

    // Die Ergebnistabelle der Seite: eine Zeile je Partei, die meisten Stimmen zuerst.
    public IReadOnlyList<ParteiErgebnis> Ergebnisse { get; private set; } = [];

    // TODO 3: Fülle Ergebnisse aus dienst.Stimmen(): je Partei die Anzahl der Stimmen,
    // absteigend nach Stimmen, bei Gleichstand alphabetisch nach Partei (GroupBy, Select, OrderByDescending, ThenBy).
    public void OnGet()
    {
        throw new NotImplementedException();
    }

    // TODO 4: Ungültige Eingabe (ModelState.IsValid ist false): Ergebnisse füllen und Page() zurückgeben,
    //         der Dienst wird nicht aufgerufen.
    //         Gültige Eingabe: Eingabe mit dienst.Abgeben speichern und nach dem Post-Redirect-Get-Muster
    //         zur Seite "Danke" weiterleiten; der Routenwert "partei" enthält Eingabe.Partei.
    public IActionResult OnPost()
    {
        throw new NotImplementedException();
    }
}
