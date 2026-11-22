namespace PsychologyApp.Presentation.Pages.ManageProfile.AppLock;

public partial class AppLockPage : ContentPage
{
    private readonly AppLockViewModel _viewModel;
    private bool _initialized;

    public AppLockPage(AppLockViewModel viewModel)
    {
        _viewModel = viewModel;
        BindingContext = viewModel;
        InitializeComponent();
    }

    public Task Unlocked => _viewModel.Unlocked;

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        if (_initialized)
        {
            return;
        }

        _initialized = true;
        await _viewModel.InitializeAsync();
    }

    // Back must not step past the lock into the app. Doing nothing would look like a frozen app, so it leaves to the home
    // screen, as the phone's own lock screens do.
    protected override bool OnBackButtonPressed()
    {
#if ANDROID
        Platform.CurrentActivity?.MoveTaskToBack(true);
#endif
        return true;
    }
}
