using Android.App;
using Android.Runtime;

namespace BlazingPizza.MAUIClient;
[Application]
public class MainApplication : MauiApplication
{
    public MainApplication(IntPtr pHandle, JniHandleOwnership pOwnership)
        : base(pHandle, pOwnership)
    {
    }

    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
