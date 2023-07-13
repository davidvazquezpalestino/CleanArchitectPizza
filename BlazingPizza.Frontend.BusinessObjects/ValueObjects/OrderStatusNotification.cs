namespace BlazingPizza.Frontend.BusinessObjects.ValueObjects;

public class OrderStatusNotification
{
    public LatLong CurrentPosition { get; }
    public double CurrentDistance { get; }
    public OrderStatus OrderStatus { get; }

    public OrderStatusNotification(LatLong currentPosition,
        double currentDistance, OrderStatus orderStatus)
    {
        CurrentPosition = currentPosition;
        CurrentDistance = currentDistance;
        OrderStatus = orderStatus;
    }
}
