namespace BlazingPizza.Shared.BusinessObjects.ValueObjects;
public record LatLong
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public static LatLong Interpolate(LatLong start, LatLong end,
        double proportion)
    {
        double NewLatitude = start.Latitude +
            (end.Latitude - start.Latitude) * proportion;
        double NewLongitude = start.Longitude +
            (end.Longitude - start.Longitude) * proportion;
        return new LatLong
        {
            Latitude = NewLatitude,
            Longitude = NewLongitude
        };
    }
}
