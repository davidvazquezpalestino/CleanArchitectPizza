namespace BlazingPizza.OrderTrackerSimulator;
internal class OrderStatusNotificatorSimulator : IOrderStatusNotificator, IDisposable
{
    #region Constantes
    const int PreparationTime = 10;
    const double SpeedKmXHr = 100.0;
    const double DistanceKm = 2.5;
    const double NotificationIntervalInSeconds = 2.5;
    #endregion

    readonly GoToDestinationSimulator Simulator = new();
    readonly Dictionary<int, Action<OrderStatusNotification>> TrackedOrders = new();

    public async Task<LatLong> SubscribeAsync(GetOrderDto order, 
        Action<OrderStatusNotification> callback)
    {
        TrackedOrders.TryAdd(order.Id, callback);
        RouteInfo routeInfo = new RouteInfo(
            order.Id,
            new PositionTrackerLatLong(order.DeliveryLocation.Latitude,
            order.DeliveryLocation.Longitude),
            order.CreatedTime.AddSeconds(PreparationTime),
            SpeedKmXHr, DistanceKm, NotificationIntervalInSeconds,
            OnChangePosition);

        PositionTrackerLatLong origin = await Simulator.SubscribeAsync(routeInfo);
        return new LatLong(origin.Latitude, origin.Longitude);
    }

    void OnChangePosition(PositionNotification notification)
    {
        TrackedOrders[notification.RouteId].Invoke(new OrderStatusNotification
        (
            new LatLong(notification.CurrentPosition.Latitude,
            notification.CurrentPosition.Longitude),
            notification.CurrentDistanceInMeters,
            notification.CurrentDistanceInMeters == 0 ? OrderStatus.Preparing :
            notification.Finished ? OrderStatus.Delivered : OrderStatus.OutForDelivery
        ));
    }

    public void UnSubscribe(int orderId)
    {
        if(TrackedOrders.ContainsKey(orderId))
        {
            Simulator.UnSubscribe(orderId);
            TrackedOrders.Remove(orderId);
        }
    }

    public void Dispose()
    {
        foreach(var order in TrackedOrders)
        {
            UnSubscribe(order.Key);
        }
        TrackedOrders.Clear();
    }
}
