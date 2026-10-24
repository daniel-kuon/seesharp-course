var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IUmfrageDienst, SpeicherDienst>();

var app = builder.Build();

app.UseStaticFiles();   // liefert wwwroot/css/site.css aus
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
