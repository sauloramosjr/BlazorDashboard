using UseallConecta.Components;
using UseallConecta.Services;
using MudBlazor.Services;
using MudBlazor.Translations;
using MudBlazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMudTranslations();

builder.Services.AddTransient<MudLocalizer, CustomMudLocalizerImpl>();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddMudServices();
builder.Services.AddSingleton<DrawerService>();
builder.Services.AddScoped<DrawerService>();
builder.Services.AddHttpClient();

var app = builder.Build();
// 

// Configure the HTTP request pipeline.
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

app.Run();
