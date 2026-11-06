using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Practice;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Presentation.Shared.Services.Preferences;
using PsychologyApp.Presentation.UI.Components;
using MvvmHelpers;
using System.Windows.Input;

namespace PsychologyApp.Presentation.Shared.ViewModels;

public partial class BaseViewModel
{
    protected INavigationService? NavigationService { get; private set; }
    protected ITechniqueCatalogService? TechniqueCatalogService { get; set; }
    protected IUserPreferencesStore UserPreferencesStore { get; private set; } = new MauiUserPreferencesStore();
    protected string? TheoryInfo { get; set; }
    protected TechniqueDefinition? AppliedDefinition { get; private set; }
    protected TechniqueUiKind AppliedUiKind => AppliedDefinition?.UiKind ?? default;
    private TechniqueId? _appliedTechniqueId;
    private string? _appliedTechniqueLanguageKey;
    private int _techniqueDefinitionRequestId;
    protected bool IsTechniqueLocalizationRefresh { get; private set; }

    public string TechniquePageTitle => AppStrings.TechniqueTitle;
    public string TheoryToolbarText => AppStrings.TechniqueTheory;
    public string FormSectionTitle => AppStrings.FormLabel;
    public string AddButtonText => AppStrings.Add;

    public ObservableRangeCollection<string> Algorithm { get; protected set; } = [];

    public List<EntryItem> Entries { get; protected set; } = [];

    private string _preIntensityText = string.Empty;
    public string PreIntensityText
    {
        get => _preIntensityText;
        set => SetProperty(ref _preIntensityText, value);
    }

    public string PreIntensityLabel => AppStrings.PracticePreSudsLabel;

    protected int? TryGetPreIntensity() =>
        int.TryParse(PreIntensityText, out int parsed) && parsed is >= 0 and <= 10
            ? parsed
            : null;

    protected void BindNavigation(INavigationService navigationService)
    {
        NavigationService = navigationService;
        Finish = new AsyncCommand(GoBackAsync);
        Theory = new Command(() =>
        {
            string content = TheoryInfo ?? string.Empty;
            navigationService.GoToTheoryAsync(content, _appliedTechniqueId).FireAndForget();
        });
    }

    private void HandlePreferencesChanged()
    {
        OnUiPreferencesChanged();
        RefreshLocalizedProperties();
    }

    private void OnUiPreferencesChanged()
    {
        Notify(
            nameof(TechniquePageTitle),
            nameof(TheoryToolbarText),
            nameof(FormSectionTitle),
            nameof(AddButtonText),
            nameof(PreIntensityLabel));

        string languageKey = AppStrings.Language;
        if (_appliedTechniqueId is TechniqueId techniqueId
            && !string.Equals(_appliedTechniqueLanguageKey, languageKey, StringComparison.Ordinal))
        {
            ApplyTechniqueAsync(techniqueId, preserveEntryValues: true).FireAndForget();
        }
    }

    protected Task GoBackAsync() => NavigationService!.GoBackAsync();

    protected Task GoToRootAsync() => NavigationService!.GoToRootAsync();

    public Task InitializeTechniqueAsync(TechniqueId id) => ApplyTechniqueAsync(id);

    protected async Task ApplyTechniqueAsync(TechniqueId id, bool preserveEntryValues = false)
    {
        if (TechniqueCatalogService is null)
        {
            throw new InvalidOperationException("TechniqueCatalogService must be set before ApplyTechnique.");
        }

        _appliedTechniqueId = id;
        string languageKey = AppStrings.Language;
        _appliedTechniqueLanguageKey = languageKey;
        int requestId = Interlocked.Increment(ref _techniqueDefinitionRequestId);
        BuiltInTechniqueDefinition builtIn = await TechniqueCatalogService.GetAsync(id).ConfigureAwait(false);
        if (requestId != Volatile.Read(ref _techniqueDefinitionRequestId)
            || !string.Equals(languageKey, AppStrings.Language, StringComparison.Ordinal))
        {
            return;
        }

        TechniqueDefinition definition = TechniqueDefinitionMapper.ToPresentation(builtIn);

        await UiThread.RunAsync(() =>
        {
            if (requestId == Volatile.Read(ref _techniqueDefinitionRequestId)
                && string.Equals(languageKey, AppStrings.Language, StringComparison.Ordinal))
            {
                ApplyDefinition(definition, preserveEntryValues);
            }
        }).ConfigureAwait(false);
    }

    private void ApplyDefinition(TechniqueDefinition def, bool preserveEntryValues)
    {
        string[] previousAnswers = preserveEntryValues ? Entries.Select(entry => entry.Text).ToArray() : [];
        AppliedDefinition = def;
        ModuleName = def.ModuleName;
        PageName = def.PageName;
        Algorithm.Clear();
        Algorithm.AddRange(def.Algorithm);
        TheoryInfo = def.TheoryInfo;
        if (def.Entries is not null)
        {
            Entries.Clear();
            for (int i = 0; i < def.Entries.Count; i++)
            {
                EntryItem entry = def.Entries[i].CloneEmpty();
                if (preserveEntryValues && i < previousAnswers.Length)
                {
                    entry.Text = previousAnswers[i];
                }

                Entries.Add(entry);
            }

            OnPropertyChanged(nameof(Entries));
        }

        IsTechniqueLocalizationRefresh = preserveEntryValues;
        try
        {
            OnTechniqueContentChanged();
        }
        finally
        {
            IsTechniqueLocalizationRefresh = false;
        }
    }

    protected virtual void OnTechniqueContentChanged()
    {
    }
}
