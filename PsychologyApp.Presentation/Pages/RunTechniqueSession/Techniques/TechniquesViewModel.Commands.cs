using PsychologyApp.Application.Articles;
using PsychologyApp.Presentation.Shared.Common;
using PsychologyApp.Application.Models.Practice;
using PsychologyApp.Application.Recommendations;
using PsychologyApp.Presentation.Features.RunTechniqueSession;
using PsychologyApp.Presentation.Models.Practice.Techniques;
using PsychologyApp.Presentation.Shared.Navigation;
using PsychologyApp.Presentation.Shared.Services.Dialogs;
using System.Windows.Input;
using PsychologyApp.Application.Models;
using PsychologyApp.Presentation.Entities.Technique;

namespace PsychologyApp.Presentation.Pages.RunTechniqueSession.Techniques;

public partial class TechniquesViewModel
{
    public ICommand ConstructorTapped { get; private set; } = default!;
    public ICommand StartTodayPracticeCommand { get; private set; } = default!;
    public ICommand FindPracticeCommand { get; private set; } = default!;
    public ICommand StartNextStepCommand { get; private set; } = default!;
    public ICommand StartSavedNextStepCommand { get; private set; } = default!;
    public ICommand ToggleNextStepChooserCommand { get; private set; } = default!;
    public ICommand ToggleSavedNextStepCommand { get; private set; } = default!;
    public ICommand SelectNextStepGroundingCommand { get; private set; } = default!;
    public ICommand SelectNextStepThoughtCommand { get; private set; } = default!;
    public ICommand SelectNextStepSmallStepCommand { get; private set; } = default!;
    public ICommand SelectNextStepMoodCommand { get; private set; } = default!;
    public ICommand OpenCrisisHubCommand { get; private set; } = default!;
    public ICommand OpenExposureCommand { get; private set; } = default!;

    public ICommand OpenTraumaCommand { get; private set; } = default!;
    public ICommand LoadMoreCustomTechniquesCommand { get; private set; } = default!;

    private void WireCommands()
    {
        ConstructorTapped = new AsyncCommand(() => _navigationService.GoToDesignerAsync(-1));
        StartTodayPracticeCommand = new AsyncCommand(StartTodayPracticeAsync);
        FindPracticeCommand = new AsyncCommand(FindPracticeAsync);
        StartNextStepCommand = new AsyncCommand(StartNextStepAsync);
        StartSavedNextStepCommand = new AsyncCommand<SavedNextStepQuickAction>(
            StartSavedNextStepAsync,
            action => action is not null && _savedNextSteps.Contains(action.Step));
        ToggleNextStepChooserCommand = new Command(ToggleNextStepChooser);
        ToggleSavedNextStepCommand = new AsyncCommand(ToggleSavedNextStepAsync);
        SelectNextStepGroundingCommand = new Command(() => SelectNextStep(SavedNextStep.Grounding));
        SelectNextStepThoughtCommand = new Command(() => SelectNextStep(SavedNextStep.ThoughtRecord));
        SelectNextStepSmallStepCommand = new Command(() => SelectNextStep(SavedNextStep.SmallStep));
        SelectNextStepMoodCommand = new Command(() => SelectNextStep(SavedNextStep.MoodCheckIn));
        OpenCrisisHubCommand = new AsyncCommand(() => _navigationService.GoToCrisisHubAsync());
        OpenExposureCommand = new AsyncCommand(() => _navigationService.GoToExposureAsync());
        OpenTraumaCommand = new AsyncCommand(() => _navigationService.GoToArticleAsync(ArticleIds.TraumaStart));

        Cancel = new Command(CancelProgress);
        Reload = new AsyncCommand(() => InitializeAsync(showLoadingOverlay: true));
        LoadMoreCustomTechniquesCommand = new AsyncCommand(LoadMoreCustomTechniquesAsync);
    }

    private async Task StartTodayPracticeAsync()
    {
        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        await _navigationService.GoToTechniqueAsync(_todayTechniqueId);
    }

    private async Task FindPracticeAsync()
    {
        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        PracticeFinderChoice[] choices =
        [
            new(PracticeFinderNeed.Quick, AppStrings.PracticeFinderQuick),
            new(PracticeFinderNeed.EyesOpen, AppStrings.PracticeFinderEyesOpen),
            new(PracticeFinderNeed.NoBreathFocus, AppStrings.PracticeFinderNoBreath),
            new(PracticeFinderNeed.NoTyping, AppStrings.PracticeFinderNoTyping),
            new(PracticeFinderNeed.Public, AppStrings.PracticeFinderPublic),
            new(PracticeFinderNeed.Situations, AppStrings.PracticeFinderSituations)
        ];

        DialogOptionItem[] choiceOptions = choices
            .Select(item => new DialogOptionItem(item.Need.ToString(), item.Label))
            .ToArray();
        string? selectedChoiceId = await _dialogService.PickOptionAsync(
            AppStrings.PracticeFinderTitle,
            choiceOptions,
            AppStrings.Cancel);
        PracticeFinderChoice? choice = choices.FirstOrDefault(item =>
            string.Equals(item.Need.ToString(), selectedChoiceId, StringComparison.Ordinal));
        if (choice is null)
        {
            return;
        }

        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        if (choice.Need == PracticeFinderNeed.Situations)
        {
            PracticeFinderChoice[] situationChoices =
            [
                new(PracticeFinderNeed.BeforeConversation, AppStrings.PracticeFinderBeforeConversation, IsSituationBundle: true),
                new(PracticeFinderNeed.PassengerCommute, AppStrings.PracticeFinderPassengerCommute, IsSituationBundle: true),
                new(PracticeFinderNeed.BeforeSleep, AppStrings.PracticeFinderBeforeSleep, IsSituationBundle: true),
                new(PracticeFinderNeed.AfterConflict, AppStrings.PracticeFinderAfterConflict, IsSituationBundle: true)
            ];
            DialogOptionItem[] situationOptions = situationChoices
                .Select(item => new DialogOptionItem(item.Need.ToString(), item.Label))
                .ToArray();
            string? selectedSituationId = await _dialogService.PickOptionAsync(
                AppStrings.PracticeFinderSituations,
                situationOptions,
                AppStrings.Cancel);
            choice = situationChoices.FirstOrDefault(item =>
                string.Equals(item.Need.ToString(), selectedSituationId, StringComparison.Ordinal));
            if (choice is null)
            {
                return;
            }
        }

        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        IReadOnlyList<TechniqueListEntry> suggestions = await _techniqueListBuilder.FindSuitablePracticesAsync(choice.Need);
        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        if (suggestions.Count == 0)
        {
            await _dialogService.ShowAsync(AppStrings.PracticeFinderNoResultsTitle, AppStrings.PracticeFinderNoResultsBody);
            return;
        }

        string resultTitle = choice.Need switch
        {
            PracticeFinderNeed.NoTyping => AppStrings.PracticeFinderNoTypingResultsTitle,
            _ when choice.IsSituationBundle => AppStrings.PracticeFinderBundleResultsTitle(choice.Label),
            _ => AppStrings.PracticeFinderResultsTitle(choice.Label)
        };
        DialogOptionItem[] practiceOptions = suggestions
            .Select(entry => new DialogOptionItem(
                entry.TechniqueId.ToString(),
                entry.Title,
                entry.Subtitle,
                AppStrings.TechniqueDuration(entry.DurationMinutes)))
            .ToArray();
        string? selectedPracticeId = await _dialogService.PickOptionAsync(resultTitle, practiceOptions, AppStrings.Cancel);
        TechniqueListEntry? selectedPractice = suggestions.FirstOrDefault(entry =>
            string.Equals(entry.TechniqueId.ToString(), selectedPracticeId, StringComparison.Ordinal));
        if (selectedPractice is null || await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        await _navigationService.GoToTechniqueAsync(selectedPractice.TechniqueId);
    }

    private sealed record PracticeFinderChoice(PracticeFinderNeed Need, string Label, bool IsSituationBundle = false);

    private async Task StartNextStepAsync()
    {
        if (_selectedNextStep is not { } selected)
        {
            _isNextStepChooserExpanded = true;
            NotifyNextStepProperties();
            return;
        }

        await OpenNextStepAsync(selected);
    }

    private async Task StartSavedNextStepAsync(SavedNextStepQuickAction? quickAction)
    {
        if (quickAction is null || !_savedNextSteps.Contains(quickAction.Step))
        {
            return;
        }

        await OpenNextStepAsync(quickAction.Step);
    }

    private async Task OpenNextStepAsync(SavedNextStep nextStep)
    {
        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        switch (nextStep)
        {
            case SavedNextStep.Grounding:
                await _navigationService.GoToTechniqueAsync(TechniqueId.Grounding);
                break;
            case SavedNextStep.ThoughtRecord:
                await _navigationService.GoToTechniqueAsync(TechniqueId.ThoughtRecord);
                break;
            case SavedNextStep.SmallStep:
                await _navigationService.GoToTechniqueAsync(TechniqueId.SmallStep);
                break;
            case SavedNextStep.MoodCheckIn:
                await _navigationService.GoToJournalAsync();
                break;
        }
    }

    private void ToggleNextStepChooser()
    {
        _isNextStepChooserExpanded = !_isNextStepChooserExpanded;
        NotifyNextStepProperties();
    }

    private void SelectNextStep(SavedNextStep nextStep)
    {
        _selectedNextStep = nextStep;
        NotifyNextStepProperties();
    }

    private void ApplySavedNextSteps(IReadOnlyList<SavedNextStep> nextSteps)
    {
        _savedNextSteps = nextSteps;
        _selectedNextStep = nextSteps.Count > 0 ? nextSteps[0] : null;
        _isNextStepChooserExpanded = false;
        NotifyNextStepProperties();
    }

    private async Task ToggleSavedNextStepAsync()
    {
        if (_selectedNextStep is not { } selected)
        {
            return;
        }

        List<SavedNextStep> nextSavedSteps = [.. _savedNextSteps];
        if (nextSavedSteps.Contains(selected))
        {
            nextSavedSteps.Remove(selected);
            _selectedNextStep = nextSavedSteps.Count > 0 ? nextSavedSteps[0] : null;
        }
        else
        {
            if (nextSavedSteps.Count >= SavedNextStepCollection.MaximumCount)
            {
                return;
            }

            nextSavedSteps.Add(selected);
        }

        await _dashboardLoader.SetSavedNextStepsAsync(nextSavedSteps);
        _savedNextSteps = nextSavedSteps;
        NotifyNextStepProperties();
    }

    private async Task<bool> RouteToCrisisHubIfNeededAsync()
    {
        if (!await _clinicalCareService.ShouldRouteToCrisisHubAsync())
        {
            return false;
        }

        await _navigationService.GoToCrisisHubAsync();
        return true;
    }
}
