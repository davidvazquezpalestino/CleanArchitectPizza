namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class LatLongMapper
{
    internal static EFEntities.LatLong ToEfLatLong(
        this SharedValueObjects.LatLong latLong) =>
        new EFEntities.LatLong
        {
            Latitude = latLong.Latitude,
            Longitude = latLong.Longitude
        };

    internal static SharedValueObjects.LatLong ToLatLong(
        this EFEntities.LatLong latLong) =>
        new SharedValueObjects.LatLong
        {
            Latitude = latLong.Latitude,
            Longitude = latLong.Longitude
        };
}
