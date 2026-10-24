using System.ComponentModel.DataAnnotations;

// Eine abgegebene Stimme; wird vom Formular gebunden und validiert.
public class Stimme
{
    [Required(ErrorMessage = "Bitte eine Partei angeben")]
    public string Partei { get; set; } = "";

    public string? Name { get; set; }
}

// Zeile der Ergebnistabelle: Partei und Anzahl ihrer Stimmen.
public record ParteiErgebnis(string Partei, int Stimmen);
