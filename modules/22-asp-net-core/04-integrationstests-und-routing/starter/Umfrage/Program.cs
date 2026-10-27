var builder = WebApplication.CreateBuilder(args);

// TODO 1: Registriere die Razor-Pages-Dienste im Service-Container (Buch 22.2.1).
// TODO 2: Registriere IUmfrageDienst mit der Implementierung SpeicherDienst als Singleton. Die Zeile ist
//         nicht im Buch (22.3 zeigt nur AddTransient) und hier vorgegeben:
//             builder.Services.AddSingleton<IUmfrageDienst, SpeicherDienst>();
//         Ein Singleton lebt so lange wie die Anwendung; das PageModel dagegen entsteht bei jeder Anforderung neu.

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();

// TODO 3: Verbinde die Razor Pages mit der Routing-Pipeline (MapRazorPages).

app.Run();

// Macht die Klasse Program für das Testprojekt sichtbar (WebApplicationFactory<Program>).
public partial class Program { }
