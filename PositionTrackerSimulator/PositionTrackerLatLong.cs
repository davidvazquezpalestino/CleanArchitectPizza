namespace PositionTrackerSimulator;
public struct PositionTrackerLatLong
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public PositionTrackerLatLong(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }

    public PositionTrackerLatLong AddMeters(double theta, double distance)
    {
        var X = Math.Cos(theta) * distance;
        var Y = Math.Sin(theta) * distance;

        double EarthEquatorialRadiusInMeters = 6378137;
        var DegreesPerMeterOfLatitude =
            360 / (2 * Math.PI * EarthEquatorialRadiusInMeters); // 1 metro en grados
        var NewLatitude = Latitude + Y * DegreesPerMeterOfLatitude;

        var LongitudeGradesToAdd = X * DegreesPerMeterOfLatitude;

        LongitudeGradesToAdd /= Math.Cos(Latitude * (Math.PI / 180));

        var NewLongitude = Longitude + LongitudeGradesToAdd;
        return new PositionTrackerLatLong(NewLatitude, NewLongitude);
    }
}
