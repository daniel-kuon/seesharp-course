using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Die Eingabe des Kontaktformulars.
public class Anfrage
{
    // TODO 1: Pflichtfeld, Meldung "Name fehlt".
    public string Name { get; set; } = "";

    // TODO 2: Pflichtfeld, Meldung "E-Mail fehlt"; muss eine E-Mail-Adresse sein, Meldung "E-Mail-Adresse ungültig".
    public string Email { get; set; } = "";

    // TODO 3: Pflichtfeld, Meldung "Nachricht fehlt"; mindestens 10 Zeichen,
    //         Meldung "Nachricht muss mindestens 10 Zeichen lang sein" (StringLength mit MinimumLength).
    public string Nachricht { get; set; } = "";
}

public class KontaktModel : PageModel
{
    // TODO 4: Die Eingabe wird per Modellbindung aus dem Formular gefüllt.
    public Anfrage Eingabe { get; set; } = new();

    // TODO 5: Ungültig (ModelState.IsValid ist false): Page(). Gültig: Weiterleitung zur Seite "Danke".
    public IActionResult OnPost()
    {
        throw new NotImplementedException();
    }
}
