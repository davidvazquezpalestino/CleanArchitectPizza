namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.OrderDetails;
public interface IOrderDetailsModel
{
    Task<GetOrderDto> GetOrderAsync(int id);
}
