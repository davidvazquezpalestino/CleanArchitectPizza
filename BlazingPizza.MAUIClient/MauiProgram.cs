using BlazingPizza.BusinessObjects.ValueObjects;
using BlazingPizza.Frontend.IoC;
using BlazingPizza.MAUIClient.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BlazingPizza.MAUIClient;
public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(pFonts =>
            {
                pFonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

        builder.Services.AddSingleton<WeatherForecastService>();

        using Stream stream = FileSystem.OpenAppPackageFileAsync(
            "appsettings.json").Result;
        builder.Configuration.AddJsonStream(stream);

#if ANDROID
        string configurationSection = "android";
#else
    configurationSection = "others";
#endif
        EndpointsOptions options =
            builder.Configuration.GetSection(
                $"BlazingPizzaEndpoints:{configurationSection}")
            .Get<EndpointsOptions>();

#if ANDROID || IOS
        Action<IHttpClientBuilder> configurator = pConfigurator =>
        {
            Services.HttpsClientHandlerService handlerService = new Services.HttpsClientHandlerService();
            pConfigurator.ConfigurePrimaryHttpMessageHandler(() =>
                handlerService.GetPlatformMessageHandler());
        };
#else
    configurator = null;
#endif

        builder.Services.AddBlazingPizzaFrontendServices(options, configurator);

        return builder.Build();
    }
}
