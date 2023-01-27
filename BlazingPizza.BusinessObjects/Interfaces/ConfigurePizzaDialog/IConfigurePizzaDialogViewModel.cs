namespace BlazingPizza.BusinessObjects.Interfaces.ConfigurePizzaDialog;
public interface IConfigurePizzaDialogViewModel
{
    Pizza Pizza { get; set; }
    IReadOnlyCollection<Topping> Toppings { get; }

    Task GetToppingsAsync();
    void AddTopping(Topping pTopping);
    void RemoveTopping(Topping pTopping);

    int ConfiguredPizzaSize { get; set; }
}
