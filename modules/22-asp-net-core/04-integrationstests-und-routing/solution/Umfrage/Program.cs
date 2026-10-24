var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
// Singleton: Die Stimmen müssen länger leben als eine einzelne Anforderung.
builder.Services.AddSingleton<IUmfrageDienst, SpeicherDienst>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

// Macht die Klasse Program für das Testprojekt sichtbar (WebApplicationFactory<Program>).
public partial class Program { }
