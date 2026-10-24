using Microsoft.AspNetCore.Mvc.RazorPages;

// Startseite: stellt die Parteiliste für das Markup bereit.
public class IndexModel : PageModel
{
    public IReadOnlyList<Partei> Alle => Parteien.Alle;
}
