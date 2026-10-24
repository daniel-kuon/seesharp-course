using System.Text.Json;
using JsonSerialisierung;

public class PersonJsonTests : IDisposable
{
    readonly TestOrdner _ordner = new();

    public void Dispose() => _ordner.Dispose();

    static Person Ada() => new()
    {
        Vorname = "Ada",
        Nachname = "Lovelace",
        Geburtstag = new DateOnly(1815, 12, 10),
        Passwort = "geheim123",
        Status = Status.Aktiv,
        Adresse = new Adresse { Strasse = "Hauptstrasse 1", Ort = "London" },
    };

    static Abteilung Entwicklung()
    {
        var abteilung = new Abteilung { Name = "Entwicklung" };
        foreach (var name in new[] { "Anna", "Bernd" })
            abteilung.Mitarbeiter.Add(new Mitarbeiter { Name = name, Abteilung = abteilung });
        return abteilung;
    }

    [Fact]
    public void ZuJson_ist_mehrzeilig_und_schreibt_camelCase()
    {
        var json = PersonJson.ZuJson(Ada());
        Assert.Contains("\n", json);
        Assert.Contains("\"vorname\": \"Ada\"", json);
        Assert.Contains("\"geburtstag\": \"1815-12-10\"", json);
        Assert.Contains("\"adresse\": {", json);
        Assert.Contains("\"strasse\": \"Hauptstrasse 1\"", json);
    }

    [Fact]
    public void ZuJson_schreibt_Enums_als_Text()
    {
        var json = PersonJson.ZuJson(Ada());
        Assert.Contains("\"status\": \"Aktiv\"", json);
    }

    [Fact]
    public void Attribut_benennt_die_Eigenschaft_um()
    {
        var json = PersonJson.ZuJson(Ada());
        Assert.Contains("\"familienname\": \"Lovelace\"", json);
        Assert.DoesNotContain("nachname", json, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void Das_Passwort_steht_nie_im_JSON()
    {
        var json = PersonJson.ZuJson(Ada());
        Assert.DoesNotContain("geheim123", json);
        Assert.DoesNotContain("passwort", json, StringComparison.OrdinalIgnoreCase);
    }

    [Fact]
    public void AusJson_liest_was_ZuJson_geschrieben_hat()
    {
        var p = PersonJson.AusJson(PersonJson.ZuJson(Ada()));

        Assert.NotNull(p);
        Assert.Equal("Ada", p!.Vorname);
        Assert.Equal("Lovelace", p.Nachname);
        Assert.Equal(new DateOnly(1815, 12, 10), p.Geburtstag);
        Assert.Equal(Status.Aktiv, p.Status);
        Assert.Equal("London", p.Adresse!.Ort);
        Assert.Null(p.Passwort);
    }

    [Fact]
    public void AusJson_ignoriert_unbekannte_Eigenschaften_und_setzt_kein_Passwort()
    {
        var json = """
            {
              "vorname": "Grace",
              "familienname": "Hopper",
              "geburtstag": "1906-12-09",
              "status": "Gesperrt",
              "lieblingsfarbe": "blau",
              "passwort": "eingeschleust",
              "adresse": null
            }
            """;

        var p = PersonJson.AusJson(json);

        Assert.NotNull(p);
        Assert.Equal("Grace", p!.Vorname);
        Assert.Equal("Hopper", p.Nachname);
        Assert.Equal(Status.Gesperrt, p.Status);
        Assert.Null(p.Adresse);
        Assert.Null(p.Passwort);
    }

    [Fact]
    public void Speichern_und_Laden_in_einem_Ordner_mit_Sonderzeichen()
    {
        var pfad = _ordner.Datei("ada.json");
        PersonJson.Speichern(Ada(), pfad);

        Assert.Contains("\"familienname\"", File.ReadAllText(pfad));
        var p = PersonJson.Laden(pfad);
        Assert.Equal("Lovelace", p!.Nachname);
        Assert.Equal(Status.Aktiv, p.Status);
        TestOrdner.PruefeDateiFrei(pfad);
    }

    [Fact]
    public void ZuJsonMitZyklen_wirft_nicht_und_ersetzt_den_Rueckverweis_durch_null()
    {
        var json = PersonJson.ZuJsonMitZyklen(Entwicklung());

        using var dokument = JsonDocument.Parse(json);
        var wurzel = dokument.RootElement;
        Assert.Equal("Entwicklung", wurzel.GetProperty("name").GetString());
        var mitarbeiter = wurzel.GetProperty("mitarbeiter");
        Assert.Equal(2, mitarbeiter.GetArrayLength());
        Assert.Equal("Anna", mitarbeiter[0].GetProperty("name").GetString());
        Assert.Equal(JsonValueKind.Null, mitarbeiter[0].GetProperty("abteilung").ValueKind);
        Assert.Equal("Bernd", mitarbeiter[1].GetProperty("name").GetString());
    }

    [Fact]
    public void ZuJsonMitPreserve_schreibt_id_und_ref()
    {
        var json = PersonJson.ZuJsonMitPreserve(Entwicklung());

        Assert.Contains("\"$id\"", json);
        Assert.Contains("\"$ref\"", json);
        Assert.Contains("Entwicklung", json);
    }
}
