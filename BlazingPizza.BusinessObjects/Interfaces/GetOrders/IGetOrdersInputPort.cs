namespace BlazingPizza.BusinessObjects.Interfaces.GetOrders;
public interface IGetOrdersInputPort
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
