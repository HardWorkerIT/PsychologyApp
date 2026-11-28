namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>Opens the phone app with a help number filled in. Used where a person in distress must reach a line in one tap.</summary>
public static class PhoneCall
{
    public static Task DialAsync(string number) => TryDialAsync(number);

    public static async Task<bool> TryDialAsync(string number)
    {
        try
        {
            if (PhoneDialer.Default.IsSupported)
            {
                PhoneDialer.Default.Open(number);
                return true;
            }
        }
        catch (Exception bestEffortError)
        {
            BestEffort.Report(bestEffortError);
        }

        try
        {
            return await Launcher.Default.OpenAsync($"tel:{number}");
        }
        catch (Exception bestEffortError)
        {
            BestEffort.Report(bestEffortError);
            return false;
        }
    }
}
