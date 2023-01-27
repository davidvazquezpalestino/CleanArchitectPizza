namespace BlazingPizza.ViewModels;
public class ConfigurePizzaDialogViewModel : IConfigurePizzaDialogViewModel
{
    readonly IConfigurePizzaDialogModel Model;

    public ConfigurePizzaDialogViewModel(IConfigurePizzaDialogModel pModel)
    {
        Model = pModel;
    }

    public Pizza Pizza { get; set; }

    IReadOnlyCollection<Topping> ToppingsField;
    public IReadOnlyCollection<Topping> Toppings
    {
        get
        {
            return ToppingsField?.OrderBy(pT => pT.Name).ToList();
        }

        private set 
        {
            ToppingsField = value;
        }
   }

    public void AddTopping(Topping pTopping) =>
        Pizza.AddTopping(pTopping);

    public async Task GetToppingsAsync()
    {
        if (Toppings == null)
        {
            Toppings = await Model.GetToppingsAsync();
        }
    }

    public void RemoveTopping(Topping pTopping) =>
        Pizza.RemoveTopping(pTopping);

    public int ConfiguredPizzaSize 
    { 
        get => Pizza.Size; 
        set => Pizza.SetSize(value);
    }
}
