using MudBlazor.Services;
using listorize.Components;
using MudBlazor;
using listorize.Model;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudServices(config => {
    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
    config.SnackbarConfiguration.VisibleStateDuration = 1000;
    config.SnackbarConfiguration.HideTransitionDuration = 200;
    config.SnackbarConfiguration.ShowTransitionDuration = 200;
    config.SnackbarConfiguration.PreventDuplicates = false;
});

var configPath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
configPath = Path.Combine(configPath, "listorize");
if (!Directory.Exists(configPath)) {
    Directory.CreateDirectory(configPath);
}
configPath = Path.Combine(configPath, "config.json");
if (!File.Exists(configPath)) {
    try {
        var sourceConfig = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "appsettings.json");
        File.Copy(sourceConfig, configPath);
    }
    catch {}
}

builder.Configuration.AddJsonFile(configPath,
        optional: true,
        reloadOnChange: true);

builder.Services.AddDbContext<ListorizeContext>();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
