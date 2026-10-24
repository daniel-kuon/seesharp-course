using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialisierung;

public static class PersonJson
{
    // Gemeinsame Einstellungen: eingerückt, camelCase, Enums als Text.
    static readonly JsonSerializerOptions Optionen = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        Converters = { new JsonStringEnumConverter() },
    };

    static readonly JsonSerializerOptions ZyklenIgnorieren = new(Optionen)
    {
        ReferenceHandler = ReferenceHandler.IgnoreCycles,
    };

    static readonly JsonSerializerOptions ZyklenErhalten = new(Optionen)
    {
        ReferenceHandler = ReferenceHandler.Preserve,
    };

    public static string ZuJson(Person person) => JsonSerializer.Serialize(person, Optionen);

    public static Person? AusJson(string json) => JsonSerializer.Deserialize<Person>(json, Optionen);

    public static void Speichern(Person person, string pfad) => File.WriteAllText(pfad, ZuJson(person));

    public static Person? Laden(string pfad) => AusJson(File.ReadAllText(pfad));

    /// <summary>Serialisiert eine Abteilung samt Rückverweisen; der Kreis wird beim zweiten Besuch durch null ersetzt.</summary>
    public static string ZuJsonMitZyklen(Abteilung abteilung) => JsonSerializer.Serialize(abteilung, ZyklenIgnorieren);

    /// <summary>Wie ZuJsonMitZyklen, aber mit Preserve: Objekte bekommen $id, Wiederholungen werden zu $ref.</summary>
    public static string ZuJsonMitPreserve(Abteilung abteilung) => JsonSerializer.Serialize(abteilung, ZyklenErhalten);
}
