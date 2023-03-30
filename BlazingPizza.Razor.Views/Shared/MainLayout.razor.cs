using ExceptionHandler.Blazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazingPizza.Razor.Views.Shared;
public partial class MainLayout
{
    CustomErrorBoundary CustomErrorBoundaryRef;

    void OnException(Exception ex)
    {
        Console.WriteLine($"Error en MainLayout: {ex.Message}");
    }

    protected override void OnParametersSet()
    {
        CustomErrorBoundaryRef?.Recover();
    }
}
