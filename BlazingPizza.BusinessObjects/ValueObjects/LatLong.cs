namespace BlazingPizza.BusinessObjects.ValueObjects;
public record LatLong
{
    public double Latitude { get; init; }
    public double Longitude { get; init; }

    public static LatLong Interpolate(LatLong pStart, LatLong pEnd,
        double pRoportion)
    {
        double newLatitude = pStart.Latitude +
            (pEnd.Latitude - pStart.Latitude) * pRoportion;
        double newLongitude = pStart.Longitude +
            (pEnd.Longitude - pStart.Longitude) * pRoportion;
        return new LatLong
        {
            Latitude = newLatitude,
            Longitude = newLongitude
        };
    }
}
