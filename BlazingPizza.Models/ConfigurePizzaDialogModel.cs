namespace BlazingPizza.Models;
public class ConfigurePizzaDialogModel : IConfigurePizzaDialogModel
{
    readonly IBlazingPizzaWebApiGateway Gateway;

    public ConfigurePizzaDialogModel(IBlazingPizzaWebApiGateway pGateway)
    {
        Gateway = pGateway;
    }

    public async Task<IReadOnlyCollection<Topping>> GetToppingsAsync()
    {
        return await Gateway.GetToppingsAsync();
    }
}
