using Timer = System.Timers.Timer;

namespace PositionTrackerSimulator;
public class GoToDestinationSimulator : IDisposable
{
    readonly Dictionary<int, TrackedRoute> TrackedRoutes = new();
    readonly Dictionary<int, RouteCached> RoutesCache = new();
    public Task<PositionTrackerLatLong> SubscribeAsync(RouteInfo routeInfo)
    {
        TrackedRoute trackedRoute = GetTrackedRouteData(routeInfo);
        TrackedRoutes.TryAdd(routeInfo.RouteId, trackedRoute);

        NotifyPosition(routeInfo.RouteId);

        return Task.FromResult(trackedRoute.Origin);
    }

    public void UnSubscribe(int routeId)
    {
        if (TrackedRoutes.TryGetValue(routeId, out TrackedRoute route))
        {
            route.Timer.Dispose();
            TrackedRoutes.Remove(routeId);
        }
    }

    private TrackedRoute GetTrackedRouteData(RouteInfo routeInfo)
    {
        RouteCached route ;
        if (!RoutesCache.TryGetValue(routeInfo.RouteId, out route))
        {
            route = new();
            route.Degree = new Random().Next(0, 360);
            double distanceInMeters = routeInfo.RouteDistanceKm * 1000.0;
            route.Origin = routeInfo.Destination.AddMeters(
                route.Degree, -distanceInMeters);
            RoutesCache.Add(routeInfo.RouteId, route);
        }

        Timer timer = new System.Timers.Timer(
            routeInfo.NotificationIntervalInSeconds * 1000);
        timer.Elapsed += (sender, e) => NotifyPosition(routeInfo.RouteId);
        timer.Start();

        return new TrackedRoute(route.Origin, routeInfo.Destination, route.Degree,
            routeInfo.RouteDistanceKm, routeInfo.SpeedKmXHr,
            routeInfo.TravelStartTime, routeInfo.Callback, timer);
    }

    private void NotifyPosition(int routeId)
    {
        TrackedRoute trackedRoute = TrackedRoutes[routeId];
        PositionNotification notification = GetPositionNotification(routeId);
        trackedRoute.Callback(notification);
        if(notification.Finished)
        {
            UnSubscribe(routeId);
        }
    }

    private PositionNotification GetPositionNotification(int routeId)
    {
        TrackedRoute trackedRoute = TrackedRoutes[routeId];
        PositionNotification notification;

        var hoursInRoute = (DateTime.Now - trackedRoute.TravelStartTime).TotalHours;
        if( hoursInRoute >= 0)
        {
            double currentDistanceInKm = trackedRoute.SpeedKmXHr * hoursInRoute;
            if(currentDistanceInKm >= trackedRoute.TotalDistanceKm)
            {
                currentDistanceInKm = trackedRoute.TotalDistanceKm;
            }
            PositionTrackerLatLong currentPosition = trackedRoute.Origin.AddMeters(
                trackedRoute.Degree, currentDistanceInKm * 1000.0);
            notification = new PositionNotification(routeId, currentPosition,
                currentDistanceInKm * 1000.0,
                currentDistanceInKm == trackedRoute.TotalDistanceKm);
        }
        else
        {
            notification = new PositionNotification(routeId,
                trackedRoute.Origin, 0, false);
        }
        return notification;
    }

    public void Dispose()
    {
        foreach(var route in TrackedRoutes)
        {
            route.Value.Timer.Dispose();
        }
        TrackedRoutes.Clear();
    }
}
