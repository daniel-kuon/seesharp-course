using System.Text.Json;

namespace EinstellungenJson;

public record Einstellungen(string Sprache, int Schriftgroesse, bool Dunkel);

public static class Speicher
{
    public static readonly Einstellungen Standard = new("de", 12, false);

    // TODO: Lege JsonSerializerOptions an: WriteIndented = true und PropertyNamingPolicy = JsonNamingPolicy.CamelCase.

    // TODO: Lies die Einstellungen mit File.ReadAllText und JsonSerializer.Deserialize<Einstellungen>.
    //       Gibt es die Datei nicht, ist ihr Inhalt kein gültiges JSON (JsonException, auch bei einer leeren
    //       Datei) oder ergibt Deserialize null (Inhalt "null"), kommen die Standardwerte zurück.
    public static Einstellungen Lade(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Schreibe die Einstellungen als eingerücktes JSON mit camelCase-Namen
    //       ("schriftgroesse": 14) in die Datei.
    public static void Speichere(string pfad, Einstellungen einstellungen)
    {
        throw new NotImplementedException();
    }
}
