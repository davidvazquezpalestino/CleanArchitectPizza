namespace BlazingPizza.BusinessObjects.Interfaces.Index;
public interface IIndexViewModel
{
    Pizza ConfiguringPizza { get; set; }
    bool ShowingConfigureDialog { get; set; }
    void ShowConfigurePizzaDialog(PizzaSpecial pSpecial);
    void CancelConfigurePizzaDialog();
    void ConfirmConfigurePizzaDialog();
}
