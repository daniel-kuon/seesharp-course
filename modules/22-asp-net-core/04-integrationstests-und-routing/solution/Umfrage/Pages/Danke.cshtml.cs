using Microsoft.AspNetCore.Mvc.RazorPages;

// Danke-Seite nach dem Post-Redirect-Get; der Parteiname kommt als Abfrageparameter (?partei=...).
public class DankeModel : PageModel
{
    public string Partei { get; private set; } = "";

    public void OnGet(string? partei)
    {
        Partei = partei ?? "";
    }
}
