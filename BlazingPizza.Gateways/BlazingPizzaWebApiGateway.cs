namespace BlazingPizza.Gateways;
public class BlazingPizzaWebApiGateway : IBlazingPizzaWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions EndpointsOptions;

    public BlazingPizzaWebApiGateway(HttpClient pClient,
        EndpointsOptions pEndpointsOptions)
    {
        Client = pClient;
        EndpointsOptions = pEndpointsOptions;
    }

    public async Task<IReadOnlyCollection<PizzaSpecial>> GetSpecialsAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<PizzaSpecial>>(
            EndpointsOptions.Specials);
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<Topping>>(
            EndpointsOptions.Toppings);
    }
}
