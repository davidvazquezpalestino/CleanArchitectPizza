namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static EFEntities.LatLong ToEfLatLong(
        this BusinessObjects.ValueObjects.LatLong pLatLong) =>
        new EFEntities.LatLong
        {
            Latitude = pLatLong.Latitude,
            Longitude = pLatLong.Longitude
        };

    internal static BusinessObjects.ValueObjects.LatLong ToLatLong(
        this EFEntities.LatLong pLatLong) =>
        new BusinessObjects.ValueObjects.LatLong
        {
            Latitude = pLatLong.Latitude,
            Longitude = pLatLong.Longitude
        };
}
