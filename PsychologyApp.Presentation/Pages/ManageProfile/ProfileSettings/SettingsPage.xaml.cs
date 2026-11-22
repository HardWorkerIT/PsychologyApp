using CommunityToolkit.Maui.Views;
using CommunityToolkit.Maui.Extensions;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.UI.Components;
using PsychologyApp.Presentation.Shared.UI.Overlays;
using PsychologyApp.Presentation.Features.ManageProfile.DependencyInjection;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsPage : ContentPage
{
    public SettingsPage(
        IPageViewModelActivator pageViewModelActivator,
        ISettingsViewModelFactory settingsViewModelFactory)
    {
        InitializeComponent();
        this.ActivateViewModel(pageViewModelActivator, page => settingsViewModelFactory.Create(page));
    }

    private void OnSettingSelectionRequested(object? sender, EventArgs e) =>
        SafeAsync.Run(() => PickSettingAsync(sender));

    private void OnAdsDisclosureTapped(object? sender, TappedEventArgs e) =>
        SafeAsync.Run(ShowAdsDisclosureAsync);

    private async Task ShowAdsDisclosureAsync()
    {
        var popup = new AdsDisclosurePopup();
        await this.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
    }

    private async Task PickSettingAsync(object? sender)
    {
        if (sender is not SettingPickerRowView row)
        {
            return;
        }

        IReadOnlyList<string> options = row.GetOptionLabels();
        if (options.Count == 0)
        {
            return;
        }

        var popup = new AppOptionsSheetPopup(
            row.PickerTitle,
            options,
            AppStrings.Cancel);
        await this.ShowPopupAsync(popup, AppPopupOptions.OptionsSheet);
        string? selected = popup.SelectedValue;
        if (selected is not null)
        {
            row.SelectOption(selected);
        }
    }
}
