namespace BlazingPizza.EFCore.Repositories.Interfaces;
internal interface IBlazingPizzaQueriesContext
{
    internal DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
    internal DbSet<EFEntities.Topping> Toppings { get; set; }
    internal DbSet<EFEntities.Order> Orders { get; set; }
}
