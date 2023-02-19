namespace BlazingPizza.BusinessObjects.Interfaces.GetOrder;
public interface IGetOrderController
{
    Task<GetOrderDto> GetOrderAsync(int pId);
}
