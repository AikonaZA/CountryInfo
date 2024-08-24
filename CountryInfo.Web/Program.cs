using CountryInfo.Web;
using CountryInfo.Web.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Register HttpClient with the base address of the API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7186/") });

// Register CountryService
builder.Services.AddScoped<CountryService>();

await builder.Build().RunAsync();