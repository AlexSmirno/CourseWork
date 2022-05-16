using Blazor;
using Blazor.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:44317") });

builder.Services.AddScoped<IProductProvider, ProductProvider>();
builder.Services.AddScoped<IClientProvider, ClientProvider>();
builder.Services.AddScoped<ISupplyProvider, SupplyProvider>();
builder.Services.AddScoped<ISupplierProvider, SupplierProvider>();

await builder.Build().RunAsync();
