var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUmfrageDienst, SpeicherDienst>();

var app = builder.Build();

// Tipp: Dateien aus wwwroot (Stylesheet) liefert erst die Middleware UseStaticFiles aus.
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
