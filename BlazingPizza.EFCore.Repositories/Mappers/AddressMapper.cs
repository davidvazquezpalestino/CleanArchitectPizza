namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class AddressMapper
{
    internal static EFEntities.Address ToEfAddress(
        this BusinessObjects.ValueObjects.Address pAddress) =>
        new EFEntities.Address
        {
            Name = pAddress.Name,
            AddressLine1 = pAddress.AddressLine1,
            AddressLine2 = pAddress.AddressLine2,
            City = pAddress.City,
            Region = pAddress.Region,
            PostalCode = pAddress.PostalCode
        };

    internal static BusinessObjects.ValueObjects.Address ToAddress(
        this EFEntities.Address pAddress) =>
        new BusinessObjects.ValueObjects.Address
        (
            Name: pAddress.Name,
            AddressLine1: pAddress.AddressLine1,
            AddressLine2: pAddress.AddressLine2,
            City: pAddress.City,
            Region: pAddress.Region,
            PostalCode: pAddress.PostalCode
         );
}
