var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddSingleton<IGaestebuch, SpeicherGaestebuch>();

var app = builder.Build();

app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();

app.Run();
