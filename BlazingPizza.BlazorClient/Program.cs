WebAssemblyHostBuilder builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

EndpointsOptions endpoints = builder.Configuration.GetSection(
    EndpointsOptions.SectionKey)
    .Get<EndpointsOptions>();

builder.Services.Configure<EndpointsOptions>(options =>
    options = endpoints);

builder.Services.AddBlazingPizzaFrontendServices(
    Options.Create(endpoints),
    builder.Configuration["geoapifyApiKey"]);

builder.Services.AddMembershipBlazorServices(
    userEndpoints => builder.Configuration.GetSection(
        UserEndpointsOptions.SectionKey).Bind(userEndpoints));


await builder.Build().RunAsync();
