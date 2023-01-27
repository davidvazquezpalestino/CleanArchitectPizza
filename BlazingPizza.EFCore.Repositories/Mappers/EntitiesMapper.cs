namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class EntitiesMapper
{
    public static BusinessObjects.Entities.PizzaSpecial ToPizzaSpecial(
        this Repositories.Entities.PizzaSpecial pIzzaSpecial) =>
        new BusinessObjects.Entities.PizzaSpecial
        {
            Id = pIzzaSpecial.Id,
            Name = pIzzaSpecial.Name,
            BasePrice = pIzzaSpecial.BasePrice,
            Description = pIzzaSpecial.Description,
            ImageUrl = pIzzaSpecial.ImageUrl
        };

    public static BusinessObjects.Entities.Topping ToTopping(
        this Repositories.Entities.Topping pTopping) =>
        new BusinessObjects.Entities.Topping
        {
            Id = pTopping.Id,
            Name = pTopping.Name,
            Price = pTopping.Price
        };
}

