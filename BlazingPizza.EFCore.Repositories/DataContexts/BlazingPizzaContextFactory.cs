namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        var ConnectionStringsOptions = new ConnectionStringsOptions
        {
            BlazingPizzaDB = 
            "Server=(localdb)\\mssqllocaldb;database=BlazingPizzaDBCA"
        };

        return new BlazingPizzaContext(
            Options.Create(ConnectionStringsOptions));
    }
}
