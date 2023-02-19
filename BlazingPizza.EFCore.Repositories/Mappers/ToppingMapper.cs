namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class ToppingMapper
{
    internal static BusinessObjects.Entities.Topping ToTopping(
    this Repositories.Entities.Topping pTopping) =>
    new BusinessObjects.Entities.Topping
    {
        Id = pTopping.Id,
        Name = pTopping.Name,
        Price = pTopping.Price
    };
}
