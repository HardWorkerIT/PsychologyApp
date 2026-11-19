using Microsoft.Extensions.Logging;
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
    public ICommand OpenCrisisHubCommand { get; private set; } = default!;
    public ICommand OpenExposureCommand { get; private set; } = default!;

    public ICommand OpenTraumaCommand { get; private set; } = default!;
    public ICommand LoadMoreCustomTechniquesCommand { get; private set; } = default!;

    private void WireCommands()
    {
        ConstructorTapped = new AsyncCommand(() => _navigationService.GoToDesignerAsync(-1));
        StartTodayPracticeCommand = new AsyncCommand(StartTodayPracticeAsync);
        FindPracticeCommand = new AsyncCommand(FindPracticeAsync);
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
        while (true)
        {
            if (await RouteToCrisisHubIfNeededAsync())
            {
                return;
            }

            DialogOptionItem[] featureOptions =
            [
                new DialogOptionItem(
                    QuickActionsFeatureOptionId,
                    AppStrings.NextStepTitle,
                    AppStrings.PracticeFinderQuickActionsDescription),
                new DialogOptionItem(
                    PracticeFinderFeatureOptionId,
                    AppStrings.PracticeFinderContextHeader,
                    AppStrings.PracticeFinderSituationDescription)
            ];
            string? selectedFeatureId = await _dialogService.PickOptionAsync(
                AppStrings.PracticeFinderTitle,
                featureOptions,
                AppStrings.Cancel);
            if (await RouteToCrisisHubIfNeededAsync())
            {
                return;
            }
            if (selectedFeatureId is null)
            {
                return;
            }

            if (selectedFeatureId == QuickActionsFeatureOptionId)
            {
                if (!await ReloadSavedNextStepsAsync())
                {
                    if (await RouteToCrisisHubIfNeededAsync())
                    {
                        return;
                    }

                    await _dialogService.ShowAsync(AppStrings.ErrorTitle, AppStrings.UnexpectedErrorMessage);
                    return;
                }
                if (!await OpenQuickActionsAsync(
                    AllQuickActionSteps,
                    AppStrings.NextStepSetup,
                    AppStrings.PracticeFinderQuickActionsPrompt))
                {
                    continue;
                }
                return;
            }

            if (selectedFeatureId != PracticeFinderFeatureOptionId)
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
                new(PracticeFinderNeed.BeforeConversation, AppStrings.PracticeFinderBeforeConversation, IsSituationBundle: true),
                new(PracticeFinderNeed.PassengerCommute, AppStrings.PracticeFinderPassengerCommute, IsSituationBundle: true),
                new(PracticeFinderNeed.BeforeSleep, AppStrings.PracticeFinderBeforeSleep, IsSituationBundle: true),
                new(PracticeFinderNeed.AfterConflict, AppStrings.PracticeFinderAfterConflict, IsSituationBundle: true),
                new(PracticeFinderNeed.Connection, AppStrings.PracticeFinderConnection, IsSituationBundle: true)
            ];
            DialogOptionItem[] situationOptions =
            [
                DialogOptionItem.SectionHeader(AppStrings.PracticeFinderConditionsSection),
                .. choices
                    .Where(item => !item.IsSituationBundle)
                    .Select(item => new DialogOptionItem(GetPracticeFinderNeedOptionId(item.Need), item.Label)),
                DialogOptionItem.SectionHeader(AppStrings.PracticeFinderSituationsSection),
                .. choices
                    .Where(item => item.IsSituationBundle)
                    .Select(item => new DialogOptionItem(GetPracticeFinderNeedOptionId(item.Need), item.Label))
            ];
            while (true)
            {
                if (await RouteToCrisisHubIfNeededAsync())
                {
                    return;
                }

                string? selectedNeedId = await _dialogService.PickOptionAsync(
                    AppStrings.PracticeFinderNeedPrompt,
                    situationOptions,
                    AppStrings.Back);
                if (selectedNeedId is null)
                {
                    break;
                }

                if (await RouteToCrisisHubIfNeededAsync())
                {
                    return;
                }

                PracticeFinderChoice? choice = choices.FirstOrDefault(item =>
                    string.Equals(GetPracticeFinderNeedOptionId(item.Need), selectedNeedId, StringComparison.Ordinal));
                if (choice is null)
                {
                    return;
                }

                IReadOnlyList<TechniqueListEntry> suggestions;
                try
                {
                    suggestions = await _techniqueListBuilder.FindSuitablePracticesAsync(choice.Need);
                }
                catch (Exception exception) when (exception is not OperationCanceledException)
                {
                    if (await RouteToCrisisHubIfNeededAsync())
                    {
                        return;
                    }

                    _logger.LogWarning("Failed to find suitable practices ({ExceptionType}).", exception.GetType().Name);
                    await _dialogService.ShowAsync(AppStrings.ErrorTitle, AppStrings.UnexpectedErrorMessage);
                    return;
                }

                if (await RouteToCrisisHubIfNeededAsync())
                {
                    return;
                }

                if (suggestions.Count == 0)
                {
                    await _dialogService.ShowAsync(AppStrings.PracticeFinderNoResultsTitle, AppStrings.PracticeFinderNoResultsBody);
                    continue;
                }

                string resultTitle = AppStrings.PracticeFinderResultsTitle;
                DialogOptionItem[] practiceOptions =
                [
                    DialogOptionItem.SectionHeader(GetPracticeFinderMatchReason(choice.Need)),
                    CreatePracticeFinderOption(suggestions[0]),
                    .. suggestions.Count > 1
                        ? new[] { new DialogOptionItem(PracticeFinderMoreOptionsOptionId, AppStrings.PracticeFinderMoreOptions) }
                        : Array.Empty<DialogOptionItem>()
                ];
                while (true)
                {
                    if (await RouteToCrisisHubIfNeededAsync())
                    {
                        return;
                    }

                    string? selectedPracticeId = await _dialogService.PickOptionAsync(resultTitle, practiceOptions, AppStrings.Back);
                    if (selectedPracticeId == PracticeFinderMoreOptionsOptionId)
                    {
                        if (await RouteToCrisisHubIfNeededAsync())
                        {
                            return;
                        }

                        DialogOptionItem[] otherPracticeOptions =
                        [
                            DialogOptionItem.SectionHeader(GetPracticeFinderMatchReason(choice.Need)),
                            .. suggestions.Skip(1).Select(CreatePracticeFinderOption)
                        ];
                        selectedPracticeId = await _dialogService.PickOptionAsync(
                            AppStrings.PracticeFinderOtherOptionsTitle,
                            otherPracticeOptions,
                            AppStrings.Back);
                        if (selectedPracticeId is null)
                        {
                            continue;
                        }
                    }

                    if (selectedPracticeId is null)
                    {
                        break;
                    }

                    TechniqueListEntry? selectedPractice = suggestions.FirstOrDefault(entry =>
                        string.Equals(entry.TechniqueId.ToString(), selectedPracticeId, StringComparison.Ordinal));
                    if (selectedPractice is null || await RouteToCrisisHubIfNeededAsync())
                    {
                        return;
                    }

                    await _navigationService.GoToTechniqueAsync(selectedPractice.TechniqueId);
                    return;
                }
            }
        }
    }

    private sealed record PracticeFinderChoice(PracticeFinderNeed Need, string Label, bool IsSituationBundle = false);

    private const string QuickActionsFeatureOptionId = "feature:quick-actions";
    private const string PracticeFinderFeatureOptionId = "feature:practice-finder";
    private const string PracticeFinderMoreOptionsOptionId = "practice-finder:more-options";
    private const string SavedQuickActionOptionPrefix = "saved-quick-action:";
    private const string ManageQuickActionsOptionId = "manage-quick-actions";

    private static readonly IReadOnlyList<SavedNextStep> AllQuickActionSteps =
        Enum.GetValues<SavedNextStep>();

    private static string GetSavedQuickActionOptionId(SavedNextStep step) =>
        $"{SavedQuickActionOptionPrefix}{step}";

    private static string GetPracticeFinderNeedOptionId(PracticeFinderNeed need) =>
        $"practice-need:{need}";

    private static DialogOptionItem CreatePracticeFinderOption(TechniqueListEntry entry) =>
        new(
            entry.TechniqueId.ToString(),
            entry.Title,
            entry.Subtitle,
            AppStrings.TechniqueDuration(entry.DurationMinutes));

    private static string GetPracticeFinderMatchReason(PracticeFinderNeed need) =>
        need switch
        {
            PracticeFinderNeed.Quick => AppStrings.PracticeFinderQuickMatchReason,
            PracticeFinderNeed.EyesOpen => AppStrings.PracticeFinderEyesOpenMatchReason,
            PracticeFinderNeed.NoBreathFocus => AppStrings.PracticeFinderNoBreathMatchReason,
            PracticeFinderNeed.NoTyping => AppStrings.PracticeFinderNoTypingMatchReason,
            PracticeFinderNeed.Public => AppStrings.PracticeFinderPublicMatchReason,
            PracticeFinderNeed.BeforeConversation => AppStrings.PracticeFinderBeforeConversationMatchReason,
            PracticeFinderNeed.PassengerCommute => AppStrings.PracticeFinderPassengerCommuteMatchReason,
            PracticeFinderNeed.BeforeSleep => AppStrings.PracticeFinderBeforeSleepMatchReason,
            PracticeFinderNeed.AfterConflict => AppStrings.PracticeFinderAfterConflictMatchReason,
            PracticeFinderNeed.Connection => AppStrings.PracticeFinderConnectionMatchReason,
            _ => string.Empty
        };

    private async Task<bool> OpenQuickActionsAsync(
        IReadOnlyList<SavedNextStep> categorySteps,
        string setupTitle,
        string quickActionsTitle)
    {
        while (true)
        {
            if (await RouteToCrisisHubIfNeededAsync())
            {
                return true;
            }

            SavedNextStep[] savedInCategory = _savedNextSteps.Where(categorySteps.Contains).ToArray();
            if (savedInCategory.Length == 0)
            {
                await ManageQuickActionsForCategoryAsync(categorySteps, setupTitle);
                if (!_savedNextSteps.Any(categorySteps.Contains))
                {
                    return false;
                }

                continue;
            }

            DialogOptionItem[] options =
            [
                .. savedInCategory.Select(step => new DialogOptionItem(GetSavedQuickActionOptionId(step), GetNextStepLabel(step))),
                new DialogOptionItem(ManageQuickActionsOptionId, AppStrings.NextStepChange)
            ];
            string? selectedOptionId = await _dialogService.PickOptionAsync(quickActionsTitle, options, AppStrings.Back);
            if (selectedOptionId is null)
            {
                return false;
            }

            if (selectedOptionId == ManageQuickActionsOptionId)
            {
                if (await RouteToCrisisHubIfNeededAsync())
                {
                    return true;
                }

                await ManageQuickActionsForCategoryAsync(categorySteps, setupTitle);
                if (!_savedNextSteps.Any(categorySteps.Contains))
                {
                    return false;
                }

                continue;
            }

            if (selectedOptionId.StartsWith(SavedQuickActionOptionPrefix, StringComparison.Ordinal))
            {
                string savedValue = selectedOptionId[SavedQuickActionOptionPrefix.Length..];
                if (Enum.TryParse(savedValue, out SavedNextStep selectedStep)
                    && Enum.IsDefined(selectedStep)
                    && categorySteps.Contains(selectedStep)
                    && savedInCategory.Contains(selectedStep))
                {
                    await OpenNextStepAsync(selectedStep);
                    return true;
                }
            }

            return false;
        }
    }

    private async Task ManageQuickActionsForCategoryAsync(
        IReadOnlyList<SavedNextStep> categorySteps,
        string categoryTitle)
    {
        int otherSavedCount = _savedNextSteps.Count(step => !categorySteps.Contains(step));
        int categoryCapacity = SavedNextStepCollection.MaximumCount - otherSavedCount;
        SavedNextStep[] savedInCategory = _savedNextSteps.Where(categorySteps.Contains).ToArray();
        if (categoryCapacity == 0 && savedInCategory.Length == 0)
        {
            await _dialogService.ShowAsync(
                AppStrings.NextStepTitle,
                AppStrings.NextStepLimitReached(SavedNextStepCollection.MaximumCount));
            return;
        }

        DialogOptionItem[] options = categorySteps
            .Select(step => new DialogOptionItem(step.ToString(), GetNextStepLabel(step)))
            .ToArray();
        IReadOnlyList<string>? selectedValues = await _dialogService.PickMultipleOptionsAsync(
            categoryTitle,
            options,
            savedInCategory.Select(step => step.ToString()).ToArray(),
            categoryCapacity,
            count => otherSavedCount + count == 0
                ? AppStrings.NextStepPrompt
                : AppStrings.NextStepCapacity(otherSavedCount + count, SavedNextStepCollection.MaximumCount),
            AppStrings.NextStepSaveHint,
            AppStrings.NextStepRemoveHint,
            AppStrings.NextStepLimitReached(SavedNextStepCollection.MaximumCount),
            AppStrings.Save,
            AppStrings.Cancel);
        if (selectedValues is null)
        {
            return;
        }

        List<SavedNextStep> selectedInCategory = [];
        foreach (string value in selectedValues)
        {
            if (Enum.TryParse(value, out SavedNextStep step)
                && Enum.IsDefined(step)
                && categorySteps.Contains(step)
                && !selectedInCategory.Contains(step)
                && selectedInCategory.Count < categoryCapacity)
            {
                selectedInCategory.Add(step);
            }
        }

        List<SavedNextStep> orderedSteps = _savedNextSteps
            .Where(step => !categorySteps.Contains(step) || selectedInCategory.Contains(step))
            .ToList();
        orderedSteps.AddRange(selectedInCategory.Where(step => !orderedSteps.Contains(step)));
        if (orderedSteps.SequenceEqual(_savedNextSteps))
        {
            return;
        }

        try
        {
            await _dashboardLoader.SetSavedNextStepsAsync(orderedSteps);
        }
        catch (Exception exception)
        {
            _logger.LogWarning("Failed to save quick actions ({ExceptionType}).", exception.GetType().Name);
            await _dialogService.ShowAsync(AppStrings.NextStepTitle, AppStrings.NextStepSaveFailed);
            return;
        }

        ApplySavedNextSteps(orderedSteps);
    }

    private async Task OpenNextStepAsync(SavedNextStep nextStep)
    {
        if (await RouteToCrisisHubIfNeededAsync())
        {
            return;
        }

        if (nextStep == SavedNextStep.MoodCheckIn)
        {
            await _navigationService.GoToJournalAsync();
            return;
        }

        if (GetTechniqueId(nextStep) is { } techniqueId)
        {
            await _navigationService.GoToTechniqueAsync(techniqueId);
        }
    }

    private void ApplySavedNextSteps(IReadOnlyList<SavedNextStep> nextSteps)
    {
        Interlocked.Increment(ref _savedNextStepsLoadVersion);
        _savedNextSteps = nextSteps.ToArray();
    }

    private async Task<bool> ReloadSavedNextStepsAsync()
    {
        int loadVersion = Interlocked.Increment(ref _savedNextStepsLoadVersion);
        try
        {
            IReadOnlyList<SavedNextStep> nextSteps = await _dashboardLoader.GetSavedNextStepsAsync();
            ApplyLoadedSavedNextSteps(nextSteps, loadVersion);
            return true;
        }
        catch (OperationCanceledException)
        {
            throw;
        }
        catch (Exception exception)
        {
            _logger.LogWarning("Failed to refresh saved quick actions before opening the picker ({ExceptionType}).", exception.GetType().Name);
            return false;
        }
    }

    private void ApplyLoadedSavedNextSteps(IReadOnlyList<SavedNextStep> nextSteps, int loadVersion)
    {
        if (Volatile.Read(ref _savedNextStepsLoadVersion) != loadVersion)
        {
            return;
        }

        _savedNextSteps = nextSteps.ToArray();
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
