using BlazingPizza.BusinessObjects.Interfaces.Common;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Index
{
    [Inject]
    public IIndexViewModel ViewModel { get; set; }

    [Inject]
    public IOrderStateService OrderStateService { get; set; }
}
