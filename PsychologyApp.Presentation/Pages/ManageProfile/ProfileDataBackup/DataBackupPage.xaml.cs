using CommunityToolkit.Maui.Extensions;
using PsychologyApp.Presentation.Features.ManageProfile.DependencyInjection;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileDataBackup;

public partial class DataBackupPage : ContentPage
{
    public DataBackupPage(IDataBackupViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        BindingContext = viewModelFactory.Create(this);
    }

    protected override void OnNavigatedFrom(NavigatedFromEventArgs args)
    {
        base.OnNavigatedFrom(args);
        // The backup dialogs cover this page while the same operation is waiting for their result.
        if (!args.IsDestinationPageACommunityToolkitPopupPage() && BindingContext is DataBackupViewModel viewModel)
        {
            viewModel.CancelPendingOperations();
        }
    }
}
