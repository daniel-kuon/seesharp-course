using System.ComponentModel.DataAnnotations;

// Eingabemodell eines Anmeldeformulars (Buch 22.9). Die Regeln stehen als Attribute an den Eigenschaften;
// die Regel über mehrere Eigenschaften steht in Validate.
public class Anmeldung : IValidatableObject
{
    [Required(ErrorMessage = "Name fehlt")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "Name muss 2 bis 50 Zeichen lang sein")]
    public string Name { get; set; } = "";

    [Range(18, 120, ErrorMessage = "Alter muss zwischen 18 und 120 liegen")]
    public int Alter { get; set; }

    [EmailAddress(ErrorMessage = "E-Mail-Adresse ungültig")]
    public string? Email { get; set; }

    public DateOnly Beginn { get; set; }
    public DateOnly Ende { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Ende < Beginn)
            yield return new ValidationResult("Ende liegt vor dem Beginn", [nameof(Ende)]);
    }
}
