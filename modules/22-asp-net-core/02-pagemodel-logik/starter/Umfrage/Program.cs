// Start der Webanwendung (siehe Buch 22.2). Diese Datei ist hier fertig; in Aufgabe 4 schreibst du sie selbst.
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUmfrageDienst, SpeicherDienst>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

// Macht die Klasse Program für Testprojekte sichtbar (wird erst in Aufgabe 4 gebraucht).
public partial class Program { }
