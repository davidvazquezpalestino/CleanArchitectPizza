namespace BlazingPizza.WinFormsClient;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
        RegisterServices();
    }

    void RegisterServices()
    {
        IServiceCollection services = new ServiceCollection();
        services.AddWindowsFormsBlazorWebView();

        IConfiguration configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();


        EndpointsOptions endpoints = configuration.GetSection(
            EndpointsOptions.SectionKey)
            .Get<EndpointsOptions>();

        services.Configure<EndpointsOptions>(options => options = endpoints);


        services.AddBlazingPizzaFrontendServices(
            Options.Create(endpoints),
            configuration["geoapifyApiKey"]);

        blazorWebView1.HostPage = "wwwroot\\index.html";
        blazorWebView1.Services = services.BuildServiceProvider();
        blazorWebView1.RootComponents.Add<App>(
            "#app");
    }
}
