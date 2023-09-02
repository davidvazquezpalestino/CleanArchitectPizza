namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        ConnectionStringsOptions connectionStringsOptions = new ConnectionStringsOptions
        {
            BlazingPizzaDb = 
            "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDBCA"
        };

        return new BlazingPizzaContext(
            Options.Create(connectionStringsOptions));
    }
}
