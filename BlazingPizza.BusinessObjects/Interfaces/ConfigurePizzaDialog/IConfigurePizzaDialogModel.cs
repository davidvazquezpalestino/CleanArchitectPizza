namespace BlazingPizza.BusinessObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogModel
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
