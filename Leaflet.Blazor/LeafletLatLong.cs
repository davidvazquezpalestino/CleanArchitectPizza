namespace Leaflet.Blazor;
public struct LeafletLatLong
{
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    public LeafletLatLong(double latitude, double longitude)
    {
        Latitude = latitude;
        Longitude = longitude;
    }
}
