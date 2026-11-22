using PsychologyApp.Domain.Base.Constants;

namespace PsychologyApp.Application.Configuration;

public sealed class AppSettings
{
    public string ReviewEmailAddress { get; set; } = Constants.ReviewEmailAddress;
    public int SmallTimeoutMs { get; set; } = 5000;
    public int MiddleTimeoutMs { get; set; } = 10000;
    public int LargeTimeoutMs { get; set; } = 15000;
    public int DbCommandTimeoutSeconds { get; set; } = 30;
    public string ReviewSmsRecipient { get; set; } = string.Empty;
}
