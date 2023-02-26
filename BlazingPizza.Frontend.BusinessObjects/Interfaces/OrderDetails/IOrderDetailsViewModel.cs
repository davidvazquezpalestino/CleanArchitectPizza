namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.OrderDetails;
public interface IOrderDetailsViewModel
{
    GetOrderDto Order { get; }
    bool InvalidOrder { get; }
    Task GetOrderAsync(int id);
}
