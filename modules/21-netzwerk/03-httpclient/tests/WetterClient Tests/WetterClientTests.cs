using System.Net;
using System.Text;
using System.Text.Json;

public class WetterClientTests
{
    private record Anfrage(HttpMethod Methode, Uri Url, string Body, string? ContentType);

    // Test-Handler: zeichnet jede Anforderung auf und antwortet mit einer vorbereiteten Antwort.
    // Es verlässt nichts den Rechner.
    private class StubHandler : HttpMessageHandler
    {
        private readonly Func<HttpRequestMessage, HttpResponseMessage> _antwort;
        public List<Anfrage> Anfragen { get; } = new();

        public StubHandler(Func<HttpRequestMessage, HttpResponseMessage> antwort) => _antwort = antwort;

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var body = request.Content is null ? "" : await request.Content.ReadAsStringAsync(cancellationToken);
            Anfragen.Add(new Anfrage(request.Method, request.RequestUri!, body, request.Content?.Headers.ContentType?.MediaType));
            return _antwort(request);
        }
    }

    private static HttpResponseMessage Json(string json, HttpStatusCode status = HttpStatusCode.OK)
        => new(status) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    private static HttpResponseMessage Status(HttpStatusCode status) => new(status);

    private static (WetterClient Client, StubHandler Handler, HttpClient Http) Aufbau(Func<HttpRequestMessage, HttpResponseMessage> antwort)
    {
        var handler = new StubHandler(antwort);
        var http = new HttpClient(handler) { BaseAddress = new Uri("http://wetter.test/") };
        return (new WetterClient(http), handler, http);
    }

    // ----- HoleTextAsync -------------------------------------------------------------------

    [Fact]
    public async Task HoleTextAsync_liefert_den_Text_per_GET()
    {
        var (client, handler, _) = Aufbau(_ => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Hallo Welt") });

        var text = await client.HoleTextAsync("hallo.txt");

        Assert.Equal("Hallo Welt", text);
        var anfrage = Assert.Single(handler.Anfragen);
        Assert.Equal(HttpMethod.Get, anfrage.Methode);
        Assert.Equal("http://wetter.test/hallo.txt", anfrage.Url.ToString());
    }

    [Fact]
    public async Task HoleTextAsync_wirft_bei_404_HttpRequestException_mit_Statuscode()
    {
        var (client, _, _) = Aufbau(_ => Status(HttpStatusCode.NotFound));

        var e = await Assert.ThrowsAsync<HttpRequestException>(() => client.HoleTextAsync("gibts-nicht"));

        Assert.Equal(HttpStatusCode.NotFound, e.StatusCode);
    }

    // ----- HoleWetterAsync -----------------------------------------------------------------

    [Fact]
    public async Task HoleWetterAsync_deserialisiert_die_JSON_Antwort()
    {
        var (client, _, _) = Aufbau(_ => Json("""{"stadt":"Köln","temperatur":18.5}"""));

        var wetter = await client.HoleWetterAsync("Köln");

        Assert.Equal(new Wetter("Köln", 18.5), wetter);
    }

    [Theory]
    [InlineData("Köln", "/wetter?stadt=K%C3%B6ln")]
    [InlineData("Bad Homburg", "/wetter?stadt=Bad%20Homburg")]
    [InlineData("A&B=C", "/wetter?stadt=A%26B%3DC")]
    public async Task HoleWetterAsync_kodiert_den_Parameter_in_der_Adresse(string stadt, string erwartet)
    {
        var (client, handler, _) = Aufbau(_ => Json("""{"stadt":"x","temperatur":0}"""));

        await client.HoleWetterAsync(stadt);

        var anfrage = Assert.Single(handler.Anfragen);
        Assert.Equal(HttpMethod.Get, anfrage.Methode);
        Assert.Equal(erwartet, anfrage.Url.PathAndQuery);
    }

    [Fact]
    public async Task HoleWetterAsync_wirft_bei_Fehlerstatus()
    {
        var (client, _, _) = Aufbau(_ => Status(HttpStatusCode.ServiceUnavailable));

        var e = await Assert.ThrowsAsync<HttpRequestException>(() => client.HoleWetterAsync("Köln"));

        Assert.Equal(HttpStatusCode.ServiceUnavailable, e.StatusCode);
    }

    // ----- MeldeAsync ----------------------------------------------------------------------

    [Fact]
    public async Task MeldeAsync_sendet_JSON_per_POST()
    {
        var (client, handler, _) = Aufbau(_ => Status(HttpStatusCode.Created));

        var ok = await client.MeldeAsync("Köln", 18.5);

        Assert.True(ok);
        var anfrage = Assert.Single(handler.Anfragen);
        Assert.Equal(HttpMethod.Post, anfrage.Methode);
        Assert.Equal("/meldung", anfrage.Url.PathAndQuery);
        Assert.Equal("application/json", anfrage.ContentType);
        using var json = JsonDocument.Parse(anfrage.Body);
        Assert.Equal("Köln", json.RootElement.GetProperty("stadt").GetString());
        Assert.Equal(18.5, json.RootElement.GetProperty("temperatur").GetDouble());
    }

    [Theory]
    [InlineData(HttpStatusCode.OK, true)]
    [InlineData(HttpStatusCode.Created, true)]
    [InlineData(HttpStatusCode.NoContent, true)]
    [InlineData(HttpStatusCode.BadRequest, false)]
    [InlineData(HttpStatusCode.UnprocessableEntity, false)]
    [InlineData(HttpStatusCode.InternalServerError, false)]
    public async Task MeldeAsync_meldet_Erfolg_ohne_Ausnahme(HttpStatusCode status, bool erwartet)
    {
        var (client, _, _) = Aufbau(_ => Status(status));

        Assert.Equal(erwartet, await client.MeldeAsync("Köln", 1));
    }

    // ----- ExistiertAsync ------------------------------------------------------------------

    [Fact]
    public async Task ExistiertAsync_sendet_HEAD_und_liefert_true_bei_200()
    {
        var (client, handler, _) = Aufbau(_ => Status(HttpStatusCode.OK));

        Assert.True(await client.ExistiertAsync("bild.png"));

        var anfrage = Assert.Single(handler.Anfragen);
        Assert.Equal(HttpMethod.Head, anfrage.Methode);
        Assert.Equal("/bild.png", anfrage.Url.PathAndQuery);
    }

    [Fact]
    public async Task ExistiertAsync_liefert_false_bei_404_ohne_Ausnahme()
    {
        var (client, _, _) = Aufbau(_ => Status(HttpStatusCode.NotFound));

        Assert.False(await client.ExistiertAsync("fehlt.png"));
    }

    // ----- HoleOderNullAsync ---------------------------------------------------------------

    [Fact]
    public async Task HoleOderNullAsync_liefert_den_Text_bei_Erfolg()
    {
        var (client, _, _) = Aufbau(_ => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent("Inhalt") });

        Assert.Equal("Inhalt", await client.HoleOderNullAsync("seite"));
    }

    [Fact]
    public async Task HoleOderNullAsync_liefert_null_bei_500()
    {
        var (client, handler, _) = Aufbau(_ => Status(HttpStatusCode.InternalServerError));

        Assert.Null(await client.HoleOderNullAsync("seite"));
        Assert.Single(handler.Anfragen);
    }

    [Fact]
    public async Task HoleOderNullAsync_gibt_andere_Fehler_weiter()
    {
        var (client, _, _) = Aufbau(_ => Status(HttpStatusCode.NotFound));

        var e = await Assert.ThrowsAsync<HttpRequestException>(() => client.HoleOderNullAsync("seite"));

        Assert.Equal(HttpStatusCode.NotFound, e.StatusCode);
    }

    // ----- Lebensdauer des HttpClient ------------------------------------------------------

    [Fact]
    public async Task Der_uebergebene_HttpClient_bleibt_fuer_weitere_Aufrufe_nutzbar()
    {
        var (client, handler, http) = Aufbau(_ => Json("""{"stadt":"x","temperatur":1}"""));

        await client.HoleWetterAsync("a");
        await client.HoleWetterAsync("b");
        await client.MeldeAsync("c", 1);

        Assert.Equal(3, handler.Anfragen.Count);
        // Wäre der Client von WetterClient freigegeben worden, würde dieser Aufruf ObjectDisposedException werfen.
        using var antwort = await http.GetAsync("noch-einer");
        Assert.Equal(4, handler.Anfragen.Count);
    }
}
