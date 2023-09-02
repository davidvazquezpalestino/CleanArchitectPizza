namespace BlazingPizza.EFCore.Repositories.DataContexts;
internal class BlazingPizzaContext : DbContext
{
    readonly ConnectionStringsOptions ConnectionStringOptions;

    public BlazingPizzaContext(
        IOptions<ConnectionStringsOptions> connectionStringOptions)
    {
        ConnectionStringOptions = connectionStringOptions.Value;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            ConnectionStringOptions.BlazingPizzaDb);
    }

    public DbSet<EFEntities.PizzaSpecial> Specials { get; set; }
    public DbSet<EFEntities.Topping> Toppings { get; set; }
    public DbSet<EFEntities.Pizza> Pizzas { get; set; }
    public DbSet<EFEntities.Order> Orders { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly());
    }
}
