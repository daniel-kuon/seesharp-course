using System.ComponentModel.DataAnnotations;

// Eingabemodell eines Anmeldeformulars (Buch 22.9). Die Regeln stehen als Attribute an den Eigenschaften;
// die Regel über mehrere Eigenschaften steht in Validate.
public class Anmeldung : IValidatableObject
{
    // TODO 1: Pflichtfeld, Meldung "Name fehlt".
    //         Länge 2 bis 50 Zeichen, Meldung "Name muss 2 bis 50 Zeichen lang sein".
    public string Name { get; set; } = "";

    // TODO 2: Werte von 18 bis 120, Meldung "Alter muss zwischen 18 und 120 liegen".
    public int Alter { get; set; }

    // TODO 3: Wenn angegeben, muss es eine E-Mail-Adresse sein; Meldung "E-Mail-Adresse ungültig".
    //         null ist erlaubt. Das Attribut steht nicht im Buch und ist hier vorgegeben:
    //         [EmailAddress(ErrorMessage = "E-Mail-Adresse ungültig")]
    public string? Email { get; set; }

    public DateOnly Beginn { get; set; }
    public DateOnly Ende { get; set; }

    // Deep Dive (optional, nicht im Buch): Liegt Ende vor Beginn, liefere genau ein ValidationResult
    //         mit der Meldung "Ende liegt vor dem Beginn" und dem Eigenschaftsnamen "Ende" (nameof). Sonst nichts.
    //         Ohne Deep Dive bleibt die Methode, wie sie ist: Sie meldet keinen Fehler.
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        yield break;
    }
}
