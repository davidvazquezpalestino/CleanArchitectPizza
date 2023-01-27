namespace BlazingPizza.Razor.Views.Components;
public partial class ConfiguredPizzaItem
{
    [Parameter]
    public Pizza Pizza { get; set; }

    [Parameter]
    public EventCallback OnRemoved { get; set; }

}
