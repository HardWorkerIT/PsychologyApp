using PsychologyApp.Presentation.Features.ManageProfile.DependencyInjection;

namespace PsychologyApp.Presentation.Pages.ManageProfile.ProfileDataBackup;

public partial class DataBackupPage : ContentPage
{
    public DataBackupPage(IDataBackupViewModelFactory viewModelFactory)
    {
        InitializeComponent();
        BindingContext = viewModelFactory.Create(this);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if (BindingContext is DataBackupViewModel viewModel)
        {
            viewModel.CancelPendingOperations();
        }
    }
}
