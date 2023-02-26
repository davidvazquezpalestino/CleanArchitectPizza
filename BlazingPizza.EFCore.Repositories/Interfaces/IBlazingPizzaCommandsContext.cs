namespace BlazingPizza.EFCore.Repositories.Interfaces;
internal interface IBlazingPizzaCommandsContext
{
    internal DbSet<EFEntities.Order> Orders { get; set; }
    internal Task<int> SaveChangesAsync();
}
