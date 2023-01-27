using ObjCRuntime;
using UIKit;

namespace BlazingPizza.MAUIClient;
public class Program
{
    // This is the main entry point of the application.
    static void Main(string[] pArgs)
    {
        // if you want to use a different Application Delegate class from "AppDelegate"
        // you can specify it here.
        UIApplication.Main(pArgs, null, typeof(AppDelegate));
    }
}