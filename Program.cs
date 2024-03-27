using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using DemoLocalizationBlazorServer6.Data; // Asegúrate de que este namespace sea correcto
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Localization;
using System.Globalization;
using Microsoft.AspNetCore.Mvc.Razor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddLocalization(options => options.ResourcesPath = "Locales");
builder.Services.AddControllers();

builder.Services.AddRazorPages()
    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
    .AddDataAnnotationsLocalization();

builder.Services.AddServerSideBlazor();
builder.Services.AddSingleton<WeatherForecastService>();

var supportedCultures = new[] { "en-US", "es-ES" };
var localizationOptions = new RequestLocalizationOptions()
    .SetDefaultCulture("en-US")
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures); // Asegúrate de pasar supportedCultures aquí también.

// Configurar el CookieRequestCultureProvider como el primer proveedor
localizationOptions.RequestCultureProviders.Insert(0, new CookieRequestCultureProvider()
{
    CookieName = CookieRequestCultureProvider.DefaultCookieName
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseRequestLocalization(localizationOptions); // Asegúrate de que esta llamada esté después de UseRouting() y antes de UseEndpoints() o MapBlazorHub().

app.MapControllers();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
