namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory : IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        var ConnectionStringsOptions = new ConnectionStringsOptions
        {
            BlazingPizzaDB =
            "Server=dcf74fb.online-server.cloud;database=BlazingPizza"
        };

        return new BlazingPizzaContext(
            Options.Create(ConnectionStringsOptions));
    }
}
