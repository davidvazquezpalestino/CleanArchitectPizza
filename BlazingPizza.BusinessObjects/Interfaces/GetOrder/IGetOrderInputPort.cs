namespace BlazingPizza.BusinessObjects.Interfaces.GetOrder;
public interface IGetOrderInputPort
{
    Task<GetOrderDto> GetOrderAsync(int pId);
}
