using System.Text.Json;

namespace EinstellungenJson;

public record Einstellungen(string Sprache, int Schriftgroesse, bool Dunkel);

public static class Speicher
{
    public static readonly Einstellungen Standard = new("de", 12, false);

    static readonly JsonSerializerOptions Optionen = new()
    {
        WriteIndented = true,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
    };

    /// <summary>Liest die Einstellungen; fehlt die Datei oder ist ihr Inhalt kein gültiges JSON, kommen die Standardwerte.</summary>
    public static Einstellungen Lade(string pfad)
    {
        if (!File.Exists(pfad))
            return Standard;
        try
        {
            return JsonSerializer.Deserialize<Einstellungen>(File.ReadAllText(pfad), Optionen) ?? Standard;
        }
        catch (JsonException)
        {
            return Standard;
        }
    }

    /// <summary>Schreibt die Einstellungen als eingerücktes JSON mit camelCase-Namen.</summary>
    public static void Speichere(string pfad, Einstellungen einstellungen) =>
        File.WriteAllText(pfad, JsonSerializer.Serialize(einstellungen, Optionen));
}
