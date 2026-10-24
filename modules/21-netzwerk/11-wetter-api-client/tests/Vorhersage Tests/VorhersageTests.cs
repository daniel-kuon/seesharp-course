using System.Net;
using System.Text;

public class VorhersageTests
{
    // Test-Handler: liefert die vorbereiteten Antworten der Reihe nach (die letzte wiederholt sich) und zählt
    // die Anforderungen. Es verlässt nichts den Rechner.
    private class StubHandler : HttpMessageHandler
    {
        private readonly Queue<Func<HttpResponseMessage>> _antworten;
        private Func<HttpResponseMessage>? _letzte;
        public List<Uri> Urls { get; } = new();
        public int Anzahl => Urls.Count;

        public StubHandler(params Func<HttpResponseMessage>[] antworten) => _antworten = new(antworten);

        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            Urls.Add(request.RequestUri!);
            if (_antworten.Count > 0)
                _letzte = _antworten.Dequeue();
            return Task.FromResult(_letzte!());
        }
    }

    private static Func<HttpResponseMessage> Status(HttpStatusCode status) => () => new HttpResponseMessage(status);

    private static Func<HttpResponseMessage> Json(string json)
        => () => new HttpResponseMessage(HttpStatusCode.OK) { Content = new StringContent(json, Encoding.UTF8, "application/json") };

    private const string DreiTage = """[{"tag":"Mo","temperatur":12.5},{"tag":"Di","temperatur":14},{"tag":"Mi","temperatur":9.25}]""";

    private static (VorhersageClient Client, StubHandler Handler) Aufbau(params Func<HttpResponseMessage>[] antworten)
    {
        var handler = new StubHandler(antworten);
        return (new VorhersageClient(new HttpClient(handler) { BaseAddress = new Uri("http://api.test/") }), handler);
    }

    [Fact]
    public async Task TageAsync_liest_die_JSON_Liste()
    {
        var (client, handler) = Aufbau(Json(DreiTage));

        var tage = await client.TageAsync("Köln", 3);

        Assert.Equal(new[] { new Vorhersage("Mo", 12.5), new Vorhersage("Di", 14), new Vorhersage("Mi", 9.25) }, tage);
        Assert.Equal(1, handler.Anzahl);
    }

    [Theory]
    [InlineData("Köln", 3, "/vorhersage?ort=K%C3%B6ln&tage=3")]
    [InlineData("Bad Homburg", 7, "/vorhersage?ort=Bad%20Homburg&tage=7")]
    [InlineData("A&B", 1, "/vorhersage?ort=A%26B&tage=1")]
    public async Task TageAsync_baut_die_Adresse_mit_kodiertem_Ort(string ort, int anzahl, string erwartet)
    {
        var (client, handler) = Aufbau(Json("[]"));

        await client.TageAsync(ort, anzahl);

        Assert.Equal(erwartet, Assert.Single(handler.Urls).PathAndQuery);
    }

    [Fact]
    public async Task TageAsync_liefert_bei_leerer_Liste_eine_leere_Liste()
    {
        var (client, _) = Aufbau(Json("[]"));

        Assert.Empty(await client.TageAsync("Köln", 3));
    }

    [Fact]
    public async Task Status_404_ergibt_eine_leere_Liste_ohne_Wiederholung()
    {
        var (client, handler) = Aufbau(Status(HttpStatusCode.NotFound));

        var tage = await client.TageAsync("Nirgendwo", 3);

        Assert.Empty(tage);
        Assert.Equal(1, handler.Anzahl);
    }

    [Fact]
    public async Task Status_503_wird_wiederholt_bis_es_klappt()
    {
        var (client, handler) = Aufbau(Status(HttpStatusCode.ServiceUnavailable), Status(HttpStatusCode.ServiceUnavailable), Json(DreiTage));

        var tage = await client.TageAsync("Köln", 3);

        Assert.Equal(3, tage.Count);
        Assert.Equal(3, handler.Anzahl);
    }

    [Fact]
    public async Task Status_503_nach_dem_ersten_Versuch_kostet_nur_zwei_Anforderungen()
    {
        var (client, handler) = Aufbau(Status(HttpStatusCode.ServiceUnavailable), Json(DreiTage));

        await client.TageAsync("Köln", 3);

        Assert.Equal(2, handler.Anzahl);
    }

    [Fact]
    public async Task Dreimal_503_ergibt_HttpRequestException_nach_genau_drei_Versuchen()
    {
        var (client, handler) = Aufbau(Status(HttpStatusCode.ServiceUnavailable));

        var e = await Assert.ThrowsAsync<HttpRequestException>(() => client.TageAsync("Köln", 3));

        Assert.Equal(HttpStatusCode.ServiceUnavailable, e.StatusCode);
        Assert.Equal(3, handler.Anzahl);
    }

    [Theory]
    [InlineData(HttpStatusCode.InternalServerError)]
    [InlineData(HttpStatusCode.BadRequest)]
    [InlineData(HttpStatusCode.Unauthorized)]
    public async Task Andere_Fehlerstatus_werden_nicht_wiederholt(HttpStatusCode status)
    {
        var (client, handler) = Aufbau(Status(status));

        var e = await Assert.ThrowsAsync<HttpRequestException>(() => client.TageAsync("Köln", 3));

        Assert.Equal(status, e.StatusCode);
        Assert.Equal(1, handler.Anzahl);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public async Task Anzahl_kleiner_1_wirft_vor_dem_Senden(int anzahl)
    {
        var (client, handler) = Aufbau(Json("[]"));

        await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => client.TageAsync("Köln", anzahl));

        Assert.Equal(0, handler.Anzahl);
    }

    [Fact]
    public async Task Der_Client_kann_mehrfach_benutzt_werden()
    {
        var (client, handler) = Aufbau(Json(DreiTage));

        await client.TageAsync("Köln", 3);
        await client.TageAsync("Bonn", 3);

        Assert.Equal(2, handler.Anzahl);
    }
}
