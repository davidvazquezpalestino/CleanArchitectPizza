namespace BlazingPizza.Gateways;
internal sealed class BlazingPizzaWebApiGateway : IBlazingPizzaWebApiGateway
{
    readonly HttpClient Client;
    readonly EndpointsOptions EndpointsOptions;

    public BlazingPizzaWebApiGateway(HttpClient client,
        IOptions<EndpointsOptions> endpointsOptions)
    {
        Client = client;
        EndpointsOptions = endpointsOptions.Value;
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

    public async Task<int> PlaceOrderAsync(Order order)
    {
        int OrderId = 0;
        var Response = await Client
            .PostAsJsonAsync(EndpointsOptions.PlaceOrder,
                (PlaceOrderOrderDto)order);
        if (Response.IsSuccessStatusCode)
        {
            OrderId = await Response.Content.ReadFromJsonAsync<int>();
        }

        return OrderId;
    }

    public async Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync()
    {
        return await Client
            .GetFromJsonAsync<IReadOnlyCollection<GetOrdersDto>>(
            EndpointsOptions.GetOrders);
    }

    public async Task<GetOrderDto> GetOrderAsync(int id) =>
        await Client
        .GetFromJsonAsync<GetOrderDto>(
            $"{EndpointsOptions.GetOrder}/{id}");
}


