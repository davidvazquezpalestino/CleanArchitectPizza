namespace BlazingPizza.EFCore.Repositories.DataContexts;
class BlazingPizzaContextFactory :
    IDesignTimeDbContextFactory<BlazingPizzaContext>
{
    public BlazingPizzaContext CreateDbContext(string[] args)
    {
        var ConnectionStringsOptions = new ConnectionStringsOptions
        {
            BlazingPizzaDB =
                "Server=dcf74fb.online-server.cloud;Database=BlazingPizza;User Id=sa;Password=Mssql2022;MultipleActiveResultSets=true;encrypt=false;trustServerCertificate=false;"
        };

        return new BlazingPizzaContext(
            Options.Create(ConnectionStringsOptions));
    }
}
