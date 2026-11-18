using Foundation;
using Microsoft.Maui;
using Microsoft.Maui.Hosting;

using PsychologyApp.Presentation.App;

namespace PsychologyApp.Presentation;

[Register("AppDelegate")]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
