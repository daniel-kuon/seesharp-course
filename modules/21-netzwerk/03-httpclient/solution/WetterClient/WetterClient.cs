using System.Net;
using System.Net.Http.Json;

public record Wetter(string Stadt, double Temperatur);

public class WetterClient
{
    private readonly HttpClient _http;

    // Den HttpClient bekommt der Konstruktor von außen (ein Client für das ganze Programm, in den Tests mit
    // einem Test-Handler). WetterClient gibt ihn deshalb nicht frei.
    public WetterClient(HttpClient http) => _http = http;

    public Task<string> HoleTextAsync(string pfad) => _http.GetStringAsync(pfad);

    public async Task<Wetter?> HoleWetterAsync(string stadt)
        => await _http.GetFromJsonAsync<Wetter>($"wetter?stadt={Uri.EscapeDataString(stadt)}");

    public async Task<bool> MeldeAsync(string stadt, double temperatur)
    {
        using var antwort = await _http.PostAsJsonAsync("meldung", new Wetter(stadt, temperatur));
        return antwort.IsSuccessStatusCode;
    }

    public async Task<bool> ExistiertAsync(string pfad)
    {
        using var anfrage = new HttpRequestMessage(HttpMethod.Head, pfad);
        using var antwort = await _http.SendAsync(anfrage);
        return antwort.IsSuccessStatusCode;
    }

    public async Task<string?> HoleOderNullAsync(string pfad)
    {
        try
        {
            using var antwort = await _http.GetAsync(pfad);
            antwort.EnsureSuccessStatusCode();
            return await antwort.Content.ReadAsStringAsync();
        }
        catch (HttpRequestException e) when (e.StatusCode == HttpStatusCode.InternalServerError)
        {
            return null;
        }
    }
}
