using MUGS2024dEMO.Web.Components;
using MUGS2024dEMO.Web.Components.Interface;
using Refit;

var builder = WebApplication.CreateBuilder(args);

// Add service defaults & Aspire client integrations.
builder.AddServiceDefaults();

// Load configuration
var backendBaseUrl = builder.Configuration.GetSection("ApiSettings:BackendBaseUrl").Value;
var frontendBaseUrl = builder.Configuration.GetSection("ApiSettings:FrontendBaseUrl").Value;

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(frontendBaseUrl) });
builder.Services.AddRefitClient<ICountryDataApi>()
    .ConfigureHttpClient(c => c.BaseAddress = new Uri(backendBaseUrl));





var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.MapDefaultEndpoints();

app.Run();
