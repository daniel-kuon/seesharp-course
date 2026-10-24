public class Person
{
    [Pflicht]
    public string? Name { get; set; }

    [Bereich(0, 120)]
    public int Alter { get; set; }

    // Kein Attribut: wird nicht geprüft.
    public string? Ort { get; set; }
}
