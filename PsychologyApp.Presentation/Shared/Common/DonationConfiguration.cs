using Microsoft.Maui.Storage;

namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>External voluntary support link and one-time prompt state, both local to the device.</summary>
internal static class DonationConfiguration
{
    private const string SupportPromptShownKey = "DonationSupportPromptShown";

    // The owner supplied this Sber SBP link for voluntary support; the app never verifies payment.
    internal const string SberPaymentUrl = "https://www.sberbank.ru/ru/choise_bank?requisiteNumber=79963904980&bankCode=100000000111";

    internal static Uri? SberPaymentUri =>
        Uri.TryCreate(SberPaymentUrl, UriKind.Absolute, out Uri? uri)
        && string.Equals(uri.Scheme, Uri.UriSchemeHttps, StringComparison.OrdinalIgnoreCase)
            ? uri
            : null;

    internal static bool HasShownSupportPrompt =>
        Preferences.Default.Get(SupportPromptShownKey, false);

    internal static void MarkSupportPromptShown() =>
        Preferences.Default.Set(SupportPromptShownKey, true);
}
