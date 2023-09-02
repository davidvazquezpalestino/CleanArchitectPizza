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
        var x = Math.Cos(theta) * distance;
        var y = Math.Sin(theta) * distance;

        double earthEquatorialRadiusInMeters = 6378137;
        var degreesPerMeterOfLatitude =
            360 / (2 * Math.PI * earthEquatorialRadiusInMeters); // 1 metro en grados
        var newLatitude = Latitude + y * degreesPerMeterOfLatitude;

        var longitudeGradesToAdd = x * degreesPerMeterOfLatitude;

        longitudeGradesToAdd /= Math.Cos(Latitude * (Math.PI / 180));

        var newLongitude = Longitude + longitudeGradesToAdd;
        return new PositionTrackerLatLong(newLatitude, newLongitude);
    }
}
