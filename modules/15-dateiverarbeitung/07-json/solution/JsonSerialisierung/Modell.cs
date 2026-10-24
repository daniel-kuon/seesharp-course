using System.Text.Json.Serialization;

namespace JsonSerialisierung;

public enum Status { Aktiv, Gesperrt }

public class Adresse
{
    public string Strasse { get; set; } = "";
    public string Ort { get; set; } = "";
}

public class Person
{
    public string Vorname { get; set; } = "";

    // Im JSON heißt die Eigenschaft anders als in C#.
    [JsonPropertyName("familienname")]
    public string Nachname { get; set; } = "";

    public DateOnly Geburtstag { get; set; }

    // Geheimnisse gehören nicht in eine Datei.
    [JsonIgnore]
    public string? Passwort { get; set; }

    public Status Status { get; set; }

    public Adresse? Adresse { get; set; }
}

public class Abteilung
{
    public string Name { get; set; } = "";
    public List<Mitarbeiter> Mitarbeiter { get; set; } = new();
}

public class Mitarbeiter
{
    public string Name { get; set; } = "";

    // Rückverweis: Zusammen mit Abteilung.Mitarbeiter ergibt das einen Kreis.
    public Abteilung? Abteilung { get; set; }
}
