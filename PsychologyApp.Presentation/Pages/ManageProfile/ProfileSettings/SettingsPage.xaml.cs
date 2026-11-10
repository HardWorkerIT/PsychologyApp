using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.UI.Components;
using PsychologyApp.Presentation.Features.ManageProfile.DependencyInjection;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileSettings;

public partial class SettingsPage : ContentPage
{
    private readonly IDialogService _dialogService;

    public SettingsPage(
        IPageViewModelActivator pageViewModelActivator,
        ISettingsViewModelFactory settingsViewModelFactory,
        IDialogService dialogService)
    {
        _dialogService = dialogService;
        InitializeComponent();
        this.ActivateViewModel(pageViewModelActivator, page => settingsViewModelFactory.Create(page));
    }

    private async void OnSettingSelectionRequested(object? sender, EventArgs e)
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

        string? selected = await _dialogService.PickOptionAsync(row.PickerTitle, options, AppStrings.Cancel);
        if (selected is not null)
        {
            row.SelectOption(selected);
        }
    }
}
