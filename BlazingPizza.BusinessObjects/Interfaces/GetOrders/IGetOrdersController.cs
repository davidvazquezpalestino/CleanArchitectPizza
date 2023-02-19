namespace BlazingPizza.BusinessObjects.Interfaces.GetOrders;
public interface IGetOrdersController
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
