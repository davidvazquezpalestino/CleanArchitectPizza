﻿namespace PositionTrackerSimulator;
public class RouteInfo
{
    public int RouteId { get; }
    public PositionTrackerLatLong Destination { get; }
    public DateTime TravelStartTime { get; }
    public double SpeedKmXHr { get; }
    public double RouteDistanceKm { get; }
    public double NotificationIntervalInSeconds { get; }
    public Action<PositionNotification> Callback { get; }

    public RouteInfo(int routeId,
        PositionTrackerLatLong destination, DateTime travelStartTime,
        double speedKmXHr, double routeDistanceKm,
        double notificationIntervalInSeconds,
        Action<PositionNotification> callback)
    {
        RouteId = routeId;
        Destination = destination;
        TravelStartTime = travelStartTime;
        SpeedKmXHr = speedKmXHr;
        RouteDistanceKm = routeDistanceKm;
        NotificationIntervalInSeconds = notificationIntervalInSeconds;
        Callback = callback;
    }
}
