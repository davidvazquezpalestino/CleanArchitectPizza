namespace BlazingPizza.EFCore.Repositories.Mappers;
internal static class PizzaSpecialMapper
{
    internal static BusinessObjects.Entities.PizzaSpecial ToPizzaSpecial(
    this Repositories.Entities.PizzaSpecial pIzzaSpecial) =>
    new BusinessObjects.Entities.PizzaSpecial
    {
        Id = pIzzaSpecial.Id,
        Name = pIzzaSpecial.Name,
        BasePrice = pIzzaSpecial.BasePrice,
        Description = pIzzaSpecial.Description,
        ImageUrl = pIzzaSpecial.ImageUrl
    };
}
