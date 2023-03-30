using Microsoft.AspNetCore.Components.Forms;

namespace BlazingPizza.Razor.Views.Components;

public partial class AddressEditor
{
    [Parameter]
    public Address Address { get; set; }

    InputText NameInput;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            await NameInput.Element.Value.FocusAsync();
        }
    }
}