namespace BlazingPizza.Frontend.BusinessObjects.Interfaces.Common;

public interface IOrderStatusNotificator
{
    Task<LatLong> SubscribeAsync(GetOrderDto order,
        Action<OrderStatusNotification> callback);

    void UnSubscribe(int orderId);
}
