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

    public async Task<int> PlaceOrderAsync(Order pOrder)
    {
        int orderId = 0;
        var response = await Client
            .PostAsJsonAsync(EndpointsOptions.PlaceOrder,
                (PlaceOrderOrderDto)pOrder);
        if(response.IsSuccessStatusCode)
        {
            orderId = await response.Content.ReadFromJsonAsync<int>();   
        }

        return orderId;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<GetOrdersDto>>(
            EndpointsOptions.GetOrders);
    }
}


