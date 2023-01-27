namespace BlazingPizza.BusinessObjects.Interfaces.GetToppings;
public interface IGetToppingsInputPort
{
    Task<IReadOnlyCollection<Topping>> GetToppingsAsync();
}
