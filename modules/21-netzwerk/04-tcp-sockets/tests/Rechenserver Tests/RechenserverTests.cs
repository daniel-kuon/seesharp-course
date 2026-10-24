using System.Net;
using System.Net.Sockets;

public class RechenserverTests
{
    // Die Sicherheitsgrenze verhindert nur, dass ein Test hängen bleibt; sie ist nie Teil einer Prüfung.
    private static readonly TimeSpan Grenze = TimeSpan.FromSeconds(30);

    // Startet einen Listener auf einem freien Port (Port 0) und die Servermethode der Trainee auf einer Task.
    private sealed class Sitzung : IDisposable
    {
        public TcpListener Listener { get; }
        public IPEndPoint Ziel { get; }
        public Task Server { get; }

        public Sitzung()
        {
            Listener = new TcpListener(IPAddress.Loopback, 0);
            Listener.Start();
            Ziel = new IPEndPoint(IPAddress.Loopback, ((IPEndPoint)Listener.LocalEndpoint).Port);
            Server = Task.Run(() => RechenServer.BedieneEinenKlienten(Listener));
            // Ist die Servermethode fertig (oder abgestürzt), werden hängende Verbindungen beendet.
            Server.ContinueWith(_ => Listener.Stop(), TaskScheduler.Default);
        }

        public async Task WarteAufServerAsync() => await Server.WaitAsync(Grenze);

        public void Dispose() => Listener.Stop();
    }

    private static async Task<string[]> FrageAsync(Sitzung s, params string[] zeilen)
        => await Task.Run(() => Klient.Frage(s.Ziel, zeilen)).WaitAsync(Grenze);

    // ----- Klient und Server zusammen ------------------------------------------------------

    [Fact]
    public async Task Addiert_und_multipliziert_und_beendet_sich_nach_ENDE()
    {
        using var s = new Sitzung();

        var antworten = await FrageAsync(s, "ADD 2 3", "MUL 4 5");

        Assert.Equal(new[] { "5", "20" }, antworten);
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Negative_und_grosse_Zahlen()
    {
        using var s = new Sitzung();

        var antworten = await FrageAsync(s, "ADD -5 3", "MUL -4 -5", "ADD 2147483646 1", "MUL 46340 46340");

        Assert.Equal(new[] { "-2", "20", "2147483647", "2147395600" }, antworten);
    }

    [Fact]
    public async Task Unbekanntes_und_Fehlerhaftes_ergibt_FEHLER()
    {
        using var s = new Sitzung();

        var antworten = await FrageAsync(s, "DIV 4 2", "hallo", "", "ADD 2", "ADD 2 3 4", "ADD a b", "add 2 3", "ADD 2,5 1");

        Assert.Equal(Enumerable.Repeat("FEHLER", 8), antworten);
    }

    [Fact]
    public async Task Ueberlauf_ergibt_FEHLER_und_der_Server_macht_weiter()
    {
        using var s = new Sitzung();

        var antworten = await FrageAsync(s, "ADD 99999999999 1", "ADD 2147483647 1", "MUL 65536 65536", "ADD 1 1");

        Assert.Equal(new[] { "FEHLER", "FEHLER", "FEHLER", "2" }, antworten);
    }

    [Fact]
    public async Task Klient_ohne_Fragen_liefert_ein_leeres_Array_und_der_Server_endet()
    {
        using var s = new Sitzung();

        var antworten = await FrageAsync(s);

        Assert.Empty(antworten);
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Die_Antworten_kommen_in_der_Reihenfolge_der_Fragen()
    {
        using var s = new Sitzung();
        var fragen = Enumerable.Range(1, 50).Select(i => $"ADD {i} {i}").ToArray();

        var antworten = await FrageAsync(s, fragen);

        Assert.Equal(Enumerable.Range(1, 50).Select(i => (2 * i).ToString()), antworten);
    }

    // ----- Der Server mit einem Klienten von Hand ------------------------------------------

    [Fact]
    public async Task Der_Server_antwortet_sofort_pro_Zeile_ohne_auf_ENDE_zu_warten()
    {
        using var s = new Sitzung();
        using var klient = new TcpClient();
        await klient.ConnectAsync(s.Ziel);
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        await schreiber.WriteLineAsync("ADD 1 2");
        var antwort = await leser.ReadLineAsync().WaitAsync(Grenze); // hängt, wenn der Server nicht flusht

        Assert.Equal("3", antwort);
        await schreiber.WriteLineAsync("ENDE");
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Nach_ENDE_schliesst_der_Server_die_Verbindung()
    {
        using var s = new Sitzung();
        using var klient = new TcpClient();
        await klient.ConnectAsync(s.Ziel);
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        await schreiber.WriteLineAsync("ENDE");

        Assert.Null(await leser.ReadLineAsync().WaitAsync(Grenze)); // Ende des Streams, keine Antwort auf ENDE
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Trennt_der_Klient_ohne_ENDE_endet_der_Server_ohne_Fehler()
    {
        using var s = new Sitzung();
        using (var klient = new TcpClient())
        {
            await klient.ConnectAsync(s.Ziel);
        } // Verbindung schließt ohne ENDE und ohne ein Wort

        await s.WarteAufServerAsync(); // wirft, wenn die Servermethode mit einer Ausnahme endete
    }

    // ----- Antwort (reine Logik) -----------------------------------------------------------

    [Theory]
    [InlineData("ADD 2 3", "5")]
    [InlineData("MUL 4 5", "20")]
    [InlineData("ADD  2   3", "5")]
    [InlineData("MUL 0 99", "0")]
    [InlineData("ADD 2147483647 1", "FEHLER")]
    [InlineData("MUL -2147483648 -1", "FEHLER")]
    [InlineData("SUB 3 1", "FEHLER")]
    [InlineData("ADD 1", "FEHLER")]
    public void Antwort_rechnet_Zeile_fuer_Zeile(string zeile, string erwartet)
    {
        Assert.Equal(erwartet, RechenServer.Antwort(zeile));
    }
}
