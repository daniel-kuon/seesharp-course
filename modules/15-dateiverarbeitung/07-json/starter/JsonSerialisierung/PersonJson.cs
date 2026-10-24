using System.Text.Json;
using System.Text.Json.Serialization;

namespace JsonSerialisierung;

public static class PersonJson
{
    // TODO: Lege einmal JsonSerializerOptions an und verwende sie in allen Methoden, damit Schreiben und
    //       Lesen zusammenpassen:
    //         WriteIndented = true                          (mehrzeilig, eingerückt)
    //         PropertyNamingPolicy = JsonNamingPolicy.CamelCase   (vorname statt Vorname)
    //         Converters = { new JsonStringEnumConverter() }      (Status als "Aktiv", nicht als 0)
    //       Für die Zyklen brauchst du Kopien mit ReferenceHandler.IgnoreCycles bzw. ReferenceHandler.Preserve:
    //         new JsonSerializerOptions(basis) { ReferenceHandler = ... }

    // TODO: JsonSerializer.Serialize mit den Optionen.
    public static string ZuJson(Person person)
    {
        throw new NotImplementedException();
    }

    // TODO: JsonSerializer.Deserialize<Person> mit denselben Optionen. Unbekannte Eigenschaften im JSON
    //       werden dabei ignoriert (das ist die Voreinstellung).
    public static Person? AusJson(string json)
    {
        throw new NotImplementedException();
    }

    // TODO: Mit File.WriteAllText bzw. File.ReadAllText.
    public static void Speichern(Person person, string pfad)
    {
        throw new NotImplementedException();
    }

    public static Person? Laden(string pfad)
    {
        throw new NotImplementedException();
    }

    // TODO: Abteilung und Mitarbeiter verweisen aufeinander. Ohne Behandlung wirft Serialize eine JsonException.
    //       ReferenceHandler.IgnoreCycles schreibt den Rückverweis als null.
    public static string ZuJsonMitZyklen(Abteilung abteilung)
    {
        throw new NotImplementedException();
    }

    // TODO: Variante mit ReferenceHandler.Preserve: Objekte bekommen "$id", Wiederholungen werden zu "$ref".
    public static string ZuJsonMitPreserve(Abteilung abteilung)
    {
        throw new NotImplementedException();
    }
}
