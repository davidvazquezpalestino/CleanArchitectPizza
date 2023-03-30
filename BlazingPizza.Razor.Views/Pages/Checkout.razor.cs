using ExceptionHandler.Blazor;
using Microsoft.AspNetCore.Components.Web;
using SpecificationValidation.Entities;
using Toast.Blazor;

namespace BlazingPizza.Razor.Views.Pages;
public partial class Checkout
{
    [Inject]
    public ICheckoutViewModel ViewModel { get; set; }

    [Inject]
    public NavigationManager NavigationManager { get; set; }

    [Inject]
    public IValidator<Address> AddressValidator { get; set; }

    [Inject]
    IToastService ToastService { get; set; }

    async Task PlaceOrder()
    {
        int OrderId = await ViewModel.PlaceOrderAsync();
        if (ViewModel.PlaceOrderSuccess)
        {
            ToastService.ShowSuccess("Gracias", "Tu pedido ha sido registrado.");
            NavigationManager.NavigateTo($"orderdetails/{OrderId}");
        }
        else
        {
            ToastService.ShowError(ViewModel.PlaceOrderException.Message, 
                ExceptionMarkupBuilder.Build(
                    ViewModel.PlaceOrderException), 0);
        }
    }   
}
