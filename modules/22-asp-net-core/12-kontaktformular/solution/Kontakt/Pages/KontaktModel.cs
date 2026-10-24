using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Die Eingabe des Kontaktformulars.
public class Anfrage
{
    [Required(ErrorMessage = "Name fehlt")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "E-Mail fehlt")]
    [EmailAddress(ErrorMessage = "E-Mail-Adresse ungültig")]
    public string Email { get; set; } = "";

    [Required(ErrorMessage = "Nachricht fehlt")]
    [StringLength(2000, MinimumLength = 10, ErrorMessage = "Nachricht muss mindestens 10 Zeichen lang sein")]
    public string Nachricht { get; set; } = "";
}

public class KontaktModel : PageModel
{
    [BindProperty]
    public Anfrage Eingabe { get; set; } = new();

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        return RedirectToPage("Danke");
    }
}
