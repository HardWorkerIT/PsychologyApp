using Android.App;
using Android.OS;
using PsychologyApp.Application.Conversation.Companion;

namespace PsychologyApp.Presentation.Platforms.Android;

internal sealed class AndroidDeviceCapabilities : IDeviceCapabilities
{
    public long TotalMemoryBytes
    {
        get
        {
            ActivityManager? manager = (ActivityManager?)Android.App.Application.Context.GetSystemService(Android.Content.Context.ActivityService);
            ActivityManager.MemoryInfo info = new();
            manager?.GetMemoryInfo(info);
            return info.TotalMem;
        }
    }

    public long AvailableMemoryBytes
    {
        get
        {
            ActivityManager? manager = (ActivityManager?)Android.App.Application.Context.GetSystemService(Android.Content.Context.ActivityService);
            ActivityManager.MemoryInfo info = new();
            manager?.GetMemoryInfo(info);
            return info.AvailMem;
        }
    }

    public long FreeStorageBytes => new StatFs(FileSystem.AppDataDirectory).AvailableBytes;
}
