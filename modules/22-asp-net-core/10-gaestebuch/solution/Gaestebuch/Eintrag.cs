using System.ComponentModel.DataAnnotations;

// Ein Gästebucheintrag; die Regeln gelten bei der Modellbindung.
public class Eintrag
{
    [Required(ErrorMessage = "Name fehlt")]
    public string Name { get; set; } = "";

    [Required(ErrorMessage = "Text fehlt")]
    [StringLength(200, ErrorMessage = "Text ist zu lang")]
    public string Text { get; set; } = "";
}
