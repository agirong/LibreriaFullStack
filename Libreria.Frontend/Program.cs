using Libreria.Frontend;
using Libreria.Frontend.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using MudBlazor.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7010/") });

builder.Services.AddScoped<ILibroService, LibroServiceImpl>();
builder.Services.AddScoped<IAutorService, AutorServiceImpl>();

builder.Services.AddMudServices();
await builder.Build().RunAsync();
