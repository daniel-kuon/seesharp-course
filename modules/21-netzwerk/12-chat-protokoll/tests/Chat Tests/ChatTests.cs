using System.Net;
using System.Net.Sockets;

public class ChatTests
{
    // Die Sicherheitsgrenze verhindert nur, dass ein Test hängen bleibt; sie ist nie Teil einer Prüfung.
    private static readonly TimeSpan Grenze = TimeSpan.FromSeconds(30);

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
            Server = Task.Run(() => ChatServer.BedieneKlienten(Listener));
            Server.ContinueWith(_ => Listener.Stop(), TaskScheduler.Default);
        }

        public Task WarteAufServerAsync() => Server.WaitAsync(Grenze);

        public void Dispose() => Listener.Stop();
    }

    private static Task<string[]> SpricheAsync(Sitzung s, params string[] zeilen)
        => Task.Run(() => Chat.Gespraech(s.Ziel, zeilen)).WaitAsync(Grenze);

    [Fact]
    public async Task SAGE_ohne_NAME_kommt_von_Gast_und_der_Server_endet()
    {
        using var s = new Sitzung();

        var antworten = await SpricheAsync(s, "SAGE Hallo");

        Assert.Equal(new[] { "Gast: Hallo" }, antworten);
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task NAME_setzt_den_Namen_fuer_die_folgenden_SAGE_Zeilen()
    {
        using var s = new Sitzung();

        var antworten = await SpricheAsync(s, "SAGE eins", "NAME Max", "SAGE zwei", "NAME Erika", "SAGE drei");

        Assert.Equal(new[] { "Gast: eins", "OK", "Max: zwei", "OK", "Erika: drei" }, antworten);
    }

    [Fact]
    public async Task Name_und_Text_duerfen_Leerzeichen_enthalten()
    {
        using var s = new Sitzung();

        var antworten = await SpricheAsync(s, "NAME Max Mustermann", "SAGE Das ist   ein Test");

        Assert.Equal(new[] { "OK", "Max Mustermann: Das ist   ein Test" }, antworten);
    }

    [Fact]
    public async Task Text_mit_Umlauten_und_Satzzeichen()
    {
        using var s = new Sitzung();

        var antworten = await SpricheAsync(s, "NAME Jörg", "SAGE Grüße: äöü ß!");

        Assert.Equal(new[] { "OK", "Jörg: Grüße: äöü ß!" }, antworten);
    }

    [Fact]
    public async Task Unbekanntes_und_Unvollstaendiges_ergibt_FEHLER_und_der_Name_bleibt()
    {
        using var s = new Sitzung();

        var antworten = await SpricheAsync(s, "NAME Max", "HALLO", "", "NAME", "NAME   ", "SAGE", "SAGE   ", "sage x", "SAGE ok");

        Assert.Equal(new[] { "OK", "FEHLER", "FEHLER", "FEHLER", "FEHLER", "FEHLER", "FEHLER", "FEHLER", "Max: ok" }, antworten);
    }

    [Fact]
    public async Task Ohne_Zeilen_verbindet_und_beendet_nur()
    {
        using var s = new Sitzung();

        Assert.Empty(await SpricheAsync(s));
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Der_Server_antwortet_sofort_und_schliesst_nach_ENDE()
    {
        using var s = new Sitzung();
        using var klient = new TcpClient();
        await klient.ConnectAsync(s.Ziel);
        using var stream = klient.GetStream();
        using var leser = new StreamReader(stream);
        using var schreiber = new StreamWriter(stream) { AutoFlush = true };

        await schreiber.WriteLineAsync("SAGE hi");
        Assert.Equal("Gast: hi", await leser.ReadLineAsync().WaitAsync(Grenze));

        await schreiber.WriteLineAsync("ENDE");
        Assert.Null(await leser.ReadLineAsync().WaitAsync(Grenze));
        await s.WarteAufServerAsync();
    }

    [Fact]
    public async Task Trennt_der_Klient_ohne_ENDE_endet_der_Server_ohne_Fehler()
    {
        using var s = new Sitzung();
        using (var klient = new TcpClient())
        {
            await klient.ConnectAsync(s.Ziel);
        }

        await s.WarteAufServerAsync();
    }
}
