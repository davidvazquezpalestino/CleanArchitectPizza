namespace BlazingPizza.UseCases.PlaceOrder;
internal sealed class PlaceOrderInteractor : IPlaceOrderInputPort
{
    readonly IBlazingPizzaCommandsRepository Repository;
    readonly IValidator<Address> AddressValidator;

    public PlaceOrderInteractor(IBlazingPizzaCommandsRepository repository,
        IValidator<Address> addressValidator)
    {
        Repository = repository;
        AddressValidator = addressValidator;
    }

    public async Task<int> PlaceOrderAsync(PlaceOrderOrderDto order)
    {
        AddressValidator.Guard(order.DeliveryAddress);

        return await Repository.PlaceOrderAsync(order);
    }
}
