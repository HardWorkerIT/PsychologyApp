using Microsoft.Maui.Storage;

namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>Voluntary support transfer details and one-time prompt state, both local to the device.</summary>
internal static class DonationConfiguration
{
    private const string SupportPromptShownKey = "DonationSupportPromptShown";

    internal const string SberTransferPhoneNumber = "79963904980";

    internal static bool HasSberTransferPhoneNumber =>
        SberTransferPhoneNumber.Length == 11
        && SberTransferPhoneNumber[0] == '7'
        && SberTransferPhoneNumber.All(char.IsAsciiDigit);

    internal static string SberTransferPhoneNumberDisplay => HasSberTransferPhoneNumber
        ? $"+{SberTransferPhoneNumber[..1]} {SberTransferPhoneNumber[1..4]} {SberTransferPhoneNumber[4..7]}-{SberTransferPhoneNumber[7..9]}-{SberTransferPhoneNumber[9..11]}"
        : SberTransferPhoneNumber;

    internal static bool HasShownSupportPrompt =>
        Preferences.Default.Get(SupportPromptShownKey, false);

    internal static void MarkSupportPromptShown() =>
        Preferences.Default.Set(SupportPromptShownKey, true);
}
