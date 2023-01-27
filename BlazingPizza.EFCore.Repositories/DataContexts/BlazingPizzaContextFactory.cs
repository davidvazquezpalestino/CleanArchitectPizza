namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] pArgs)
    {
        DbContextOptionsBuilder<BlazingPizzaContext> optionsBuilder =
            new DbContextOptionsBuilder<BlazingPizzaContext>();
        optionsBuilder.UseSqlServer(
            "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDBCA");
        return new BlazingPizzaContext(optionsBuilder.Options);
    }
}
