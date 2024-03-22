using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Pokedex;
using Pokedex.Util;
using Blazored.LocalStorage;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<PokeClient>();
builder.Services.AddSingleton<FavoriteService>();
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<FavoriteService>();

await builder.Build().RunAsync();
