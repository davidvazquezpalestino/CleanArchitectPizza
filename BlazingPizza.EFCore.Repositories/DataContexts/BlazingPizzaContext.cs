namespace BlazingPizza.EFCore.Repositories.DataContexts;
public class BlazingPizzaContext : DbContext
{
    public BlazingPizzaContext(DbContextOptions pOptions) : base(pOptions) { }

    public DbSet<Repositories.Entities.PizzaSpecial> Specials { get; set; }
    public DbSet<Repositories.Entities.Topping> Toppings { get; set; }

    protected override void OnModelCreating(ModelBuilder pModelBuilder)
    {
        pModelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());

    }
}
