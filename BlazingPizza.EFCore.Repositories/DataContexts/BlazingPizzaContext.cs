namespace BlazingPizza.EFCore.Repositories.DataContexts;
public class BlazingPizzaContext : DbContext
{
    public BlazingPizzaContext(DbContextOptions pOptions) : base(pOptions) { }

    public DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
    public DbSet<EFEntities.Topping> Toppings { get; set; }
    public DbSet<EFEntities.Pizza> Pizzas { get; set; }
    public DbSet<EFEntities.Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder pModelBuilder)
    {
        pModelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
