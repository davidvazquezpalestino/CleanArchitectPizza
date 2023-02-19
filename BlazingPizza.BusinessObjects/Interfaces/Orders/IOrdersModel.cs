namespace BlazingPizza.BusinessObjects.Interfaces.Orders;
public interface IOrdersModel
{
    Task<IReadOnlyCollection<GetOrdersDto>> GetOrdersAsync();
}
