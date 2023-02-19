using BlazingPizza.BusinessObjects.ValueObjects;
using BlazingPizza.Frontend.IoC;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(pSp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddBlazingPizzaFrontendServices(
    builder.Configuration.GetSection("BlazingPizzaEndpoints")
    .Get<EndpointsOptions>());

await builder.Build().RunAsync();
