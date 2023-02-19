namespace BlazingPizza.Models;
public class CheckoutModel : ICheckoutModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public CheckoutModel(IBlazingPizzaWebApiGateway pGateway)
    {
        Gateway = pGateway;
    }

    public async Task<int> PlaceOrderAsync(Order pOrder)
    {
        return await Gateway.PlaceOrderAsync(pOrder);
    }
}
