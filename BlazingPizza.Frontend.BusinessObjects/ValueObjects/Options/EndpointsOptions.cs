namespace BlazingPizza.Frontend.BusinessObjects.ValueObjects.Options;
public class EndpointsOptions
{
    public const string SectionKey = "Endpoints";
    public string WebApiBaseAddress { get; set; }
    public string Specials { get; set; } = nameof(Specials);
    public string Toppings { get; set; }
    public string PlaceOrder { get; set; }
    public string GetOrders { get; set; }
    public string GetOrder { get; set; }
}
