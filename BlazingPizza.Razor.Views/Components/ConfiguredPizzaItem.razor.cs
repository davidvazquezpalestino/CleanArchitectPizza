namespace BlazingPizza.Razor.Views.Components;
public partial class ConfiguredPizzaItem
{
    [Parameter]
    public Pizza Pizza { get; set; }

    [Parameter]
    public EventCallback OnRemoved { get; set; }

    [Inject]
    SweetAlertService SweetAlertService { get; set; }

    async Task RemovePizzaConfirmation()
    {

        ConfirmArgs messageParameters = new ConfirmArgs(
            "¿Eliminar la pizza?",
            $"¿Eliminar la pizza {Pizza.Special.Name} de la orden?",
            Icon.Warning,
            "No, quiero mi pizza",
            "Si, eliminar la pizza",
            true
             );


        bool remove = await SweetAlertService.ConfirmAsync(messageParameters);

        if (remove)
        {
            await OnRemoved.InvokeAsync();
        }
    }
}
