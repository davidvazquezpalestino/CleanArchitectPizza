namespace BlazingPizza.BusinessObjects.ValueObjects;
public record struct EndpointsOptions(string WebApiBaseAddress,
    string Specials, string Toppings);
