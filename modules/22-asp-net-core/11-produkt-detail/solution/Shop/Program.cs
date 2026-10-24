var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IProduktkatalog, FesterKatalog>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();

// Macht die Klasse Program für das Testprojekt sichtbar (WebApplicationFactory<Program>).
public partial class Program { }
