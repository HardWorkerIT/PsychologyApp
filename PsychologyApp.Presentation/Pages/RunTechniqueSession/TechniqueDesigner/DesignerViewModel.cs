using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.Technique;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using PsychologyApp.Presentation.Shared.Services.Toasts;
using PsychologyApp.Presentation.Shared.ViewModels;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.TechniqueDesigner;

public partial class DesignerViewModel : BaseViewModel
{
    private readonly long _techniqueId;
    private readonly ITechniqueService _techniqueService;
    private readonly ITechniqueMessenger _techniqueMessenger;
    private readonly DesignerTechniqueOperations _techniqueOperations;
    private readonly IToastService _toastService;
    private readonly ILogger<DesignerViewModel> _logger;
    private readonly IOptions<AppSettings> _settings;
    private readonly INavigationService _navigationService;
    private readonly IDialogService _dialogService;
    private readonly SemaphoreSlim _initGate = new(1, 1);
    private bool _initialized;
    private bool _isSaving;
    private CancellationTokenSource? _initCts;
    private DesignerTechniqueForm? _savedForm;

    public bool HasInitialized => _initialized;

    public ICommand ExecuteTechnique { get; private set; } = default!;

    public bool IsSaving
    {
        get => _isSaving;
        private set
        {
            if (SetProperty(ref _isSaving, value))
            {
                OnPropertyChanged(nameof(SaveButtonText));
                (ExecuteTechnique as AsyncCommand)?.RaiseCanExecuteChanged();
            }
        }
    }

    public DesignerViewModel(
        long techniqueId,
        ITechniqueService techniqueService,
        ITechniqueMessenger techniqueMessenger,
        DesignerTechniqueOperations techniqueOperations,
        IToastService toastService,
        ILogger<DesignerViewModel> logger,
        IOptions<AppSettings> settings,
        INavigationService navigationService,
        IDialogService dialogService)
    {
        _techniqueService = techniqueService;
        _techniqueMessenger = techniqueMessenger;
        _techniqueOperations = techniqueOperations;
        _toastService = toastService;
        _logger = logger;
        _settings = settings;
        _navigationService = navigationService;
        _dialogService = dialogService;
        _techniqueId = techniqueId;

        Path = "method.png";
        ReadStepsFromActions();

        ModuleName = AppStrings.ShellTabPractice;
        PageName = AppStrings.PracticeConstructor;

        BindNavigation(_navigationService);
        Finish = new AsyncCommand(ConfirmExitAsync);

        ExecuteTechnique = new AsyncCommand(ExecuteOperationAsync, CanSave);
        Cancel = new Command(CancelInit);
        Reload = new AsyncCommand(ReloadAsync);

        if (_techniqueId <= 0)
        {
            _savedForm = CaptureForm();
            SetDone();
            _initialized = true;
        }
    }

    private async Task ConfirmExitAsync()
    {
        if (IsSaving)
        {
            return;
        }

        if (_savedForm is null || CaptureForm() == _savedForm
            || await _dialogService.AskSheetAsync(AppStrings.UnsavedExitTitle, AppStrings.DesignerDiscardChanges,
                AppStrings.ChatDiscardDraftAccept, AppStrings.Cancel, isDestructive: true))
        {
            if (!IsSaving)
            {
                await GoBackAsync();
            }
        }
    }

    public Task EnsureInitializedAsync()
    {
        if (_initialized && !IsFail)
        {
            return Task.CompletedTask;
        }

        return InitializeAsync();
    }

    private async Task InitializeAsync()
    {
        await _initGate.WaitAsync();
        try
        {
            if (_initialized && !IsFail)
            {
                return;
            }

            _initCts?.Cancel();
            _initCts?.Dispose();
            CancellationTokenSource initCts = OperationCancellation.CreateSmallTimeoutSource(_settings);
            _initCts = initCts;
            try
            {
                await InitAsync(initCts.Token);
            }
            finally
            {
                if (ReferenceEquals(_initCts, initCts))
                {
                    _initCts = null;
                }

                initCts.Dispose();
            }
        }
        finally
        {
            _initGate.Release();
        }
    }

    private async Task ReloadAsync()
    {
        _initialized = false;
        await EnsureInitializedAsync();
    }

    private void CancelInit() => _initCts?.Cancel();
}
