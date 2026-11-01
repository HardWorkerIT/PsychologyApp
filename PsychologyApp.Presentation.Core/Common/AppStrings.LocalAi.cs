namespace PsychologyApp.Presentation.Common;

public static partial class AppStrings
{
    public static string SettingsLocalAiSection => R(nameof(SettingsLocalAiSection));
    public static string SettingsLocalAiDescription => R(nameof(SettingsLocalAiDescription));
    public static string SettingsLocalAiDownload => R(nameof(SettingsLocalAiDownload));
    public static string SettingsLocalAiDelete => R(nameof(SettingsLocalAiDelete));
    public static string SettingsLocalAiNotInstalled => R(nameof(SettingsLocalAiNotInstalled));
    public static string SettingsLocalAiInstalled => R(nameof(SettingsLocalAiInstalled));
    public static string SettingsLocalAiNotEnoughMemory => R(nameof(SettingsLocalAiNotEnoughMemory));
    public static string SettingsLocalAiNotEnoughStorage => R(nameof(SettingsLocalAiNotEnoughStorage));
    public static string SettingsLocalAiDownloading => R(nameof(SettingsLocalAiDownloading));
    public static string SettingsLocalAiProgress(int percent) => F(nameof(SettingsLocalAiProgress), percent);
    public static string SettingsLocalAiConsentTitle => R(nameof(SettingsLocalAiConsentTitle));
    public static string SettingsLocalAiConsentMessage => R(nameof(SettingsLocalAiConsentMessage));
    public static string SettingsLocalAiConsentMessageFor(string name, string sizeGb, string licenseUrl) =>
        F(nameof(SettingsLocalAiConsentMessage), name, sizeGb, licenseUrl);
    public static string SettingsLocalAiDeleteTitle => R(nameof(SettingsLocalAiDeleteTitle));
    public static string SettingsLocalAiDeleteMessage => R(nameof(SettingsLocalAiDeleteMessage));
}
