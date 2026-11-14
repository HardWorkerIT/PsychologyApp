namespace PsychologyApp.Presentation.Common;

/// <summary>Copy for filling practices without typing (chips, voice, emotion palette) and for the interactive practice stages.</summary>
public static partial class AppStrings
{
    public static string PracticeVoiceStart => R(nameof(PracticeVoiceStart));
    public static string PracticeVoiceStop => R(nameof(PracticeVoiceStop));
    public static string PracticeVoiceListening => R(nameof(PracticeVoiceListening));
    public static string PracticeVoiceHolding => R(nameof(PracticeVoiceHolding));
    public static string PracticeVoiceNothingHeard => R(nameof(PracticeVoiceNothingHeard));
    public static string PracticeVoicePermissionDenied => R(nameof(PracticeVoicePermissionDenied));
    public static string PracticeVoiceUnavailable => R(nameof(PracticeVoiceUnavailable));
    public static string PracticeRecentProblem(string problem) => F(nameof(PracticeRecentProblem), problem);
    public static string PracticeAssistTitle => R(nameof(PracticeAssistTitle));
    public static string PracticeEmotionHint => R(nameof(PracticeEmotionHint));
    public static string TechniqueStepSkip => R(nameof(TechniqueStepSkip));
    public static string TechniqueStepsSummary(int count) => F(nameof(TechniqueStepsSummary), count);
    public static string PracticeMoreChips(int count) => F(nameof(PracticeMoreChips), count);
    public static string PracticeAnswersTitle => R(nameof(PracticeAnswersTitle));
    public static string NextStepTitle => R(nameof(NextStepTitle));
    public static string NextStepPrompt => R(nameof(NextStepPrompt));
    public static string NextStepGrounding => R(nameof(NextStepGrounding));
    public static string NextStepThought => R(nameof(NextStepThought));
    public static string NextStepSmallStep => R(nameof(NextStepSmallStep));
    public static string NextStepMood => R(nameof(NextStepMood));
    public static string NextStepChoose => R(nameof(NextStepChoose));
    public static string NextStepStart => R(nameof(NextStepStart));
    public static string NextStepSave => R(nameof(NextStepSave));
    public static string NextStepRemove => R(nameof(NextStepRemove));
    public static string NextStepChange => R(nameof(NextStepChange));
    public static string NextStepCollapse => R(nameof(NextStepCollapse));
    public static string NextStepSelectHint => R(nameof(NextStepSelectHint));
    public static string NextStepToggleHint => R(nameof(NextStepToggleHint));
    public static string NextStepSaveHint => R(nameof(NextStepSaveHint));
    public static string NextStepRemoveHint => R(nameof(NextStepRemoveHint));
    public static string NextStepOpenHint => R(nameof(NextStepOpenHint));
    public static string NextStepChooseHint => R(nameof(NextStepChooseHint));
    public static string NextStepChoiceSelected(string choice) => F(nameof(NextStepChoiceSelected), choice);
    public static string NextStepSavedSummary(int count) => F(nameof(NextStepSavedSummary), count);
    public static string NextStepCapacity(int count) => F(nameof(NextStepCapacity), count);
    public static string NextStepLimitReached => R(nameof(NextStepLimitReached));

    public static string PracticeFinderButton => R(nameof(PracticeFinderButton));
    public static string PracticeFinderAccessibilityHint => R(nameof(PracticeFinderAccessibilityHint));
    public static string PracticeFinderTitle => R(nameof(PracticeFinderTitle));
    public static string PracticeFinderQuick => R(nameof(PracticeFinderQuick));
    public static string PracticeFinderEyesOpen => R(nameof(PracticeFinderEyesOpen));
    public static string PracticeFinderNoBreath => R(nameof(PracticeFinderNoBreath));
    public static string PracticeFinderNoTyping => R(nameof(PracticeFinderNoTyping));
    public static string PracticeFinderPublic => R(nameof(PracticeFinderPublic));
    public static string PracticeFinderSituations => R(nameof(PracticeFinderSituations));
    public static string PracticeFinderBeforeConversation => R(nameof(PracticeFinderBeforeConversation));
    public static string PracticeFinderPassengerCommute => R(nameof(PracticeFinderPassengerCommute));
    public static string PracticeFinderBeforeSleep => R(nameof(PracticeFinderBeforeSleep));
    public static string PracticeFinderAfterConflict => R(nameof(PracticeFinderAfterConflict));
    public static string PracticeFinderResultsTitle(string context) => F(nameof(PracticeFinderResultsTitle), context);
    public static string PracticeFinderBundleResultsTitle(string situation) => F(nameof(PracticeFinderBundleResultsTitle), situation);
    public static string PracticeFinderNoTypingResultsTitle => R(nameof(PracticeFinderNoTypingResultsTitle));
    public static string PracticeFinderNoResultsTitle => R(nameof(PracticeFinderNoResultsTitle));
    public static string PracticeFinderNoResultsBody => R(nameof(PracticeFinderNoResultsBody));

    public static string StageEmptyText => R(nameof(StageEmptyText));
    public static string StageAgain => R(nameof(StageAgain));

    public static string StageResizeTitle => R(nameof(StageResizeTitle));
    public static string StageResizeHint => R(nameof(StageResizeHint));
    public static string StageResizeAction => R(nameof(StageResizeAction));
    public static string StageResizeDone => R(nameof(StageResizeDone));

    public static string StageWhiteSpotTitle => R(nameof(StageWhiteSpotTitle));
    public static string StageWhiteSpotHint => R(nameof(StageWhiteSpotHint));
    public static string StageWhiteSpotAction => R(nameof(StageWhiteSpotAction));
    public static string StageWhiteSpotStop => R(nameof(StageWhiteSpotStop));
    public static string StageWhiteSpotSeconds(int seconds) => F(nameof(StageWhiteSpotSeconds), seconds);
    public static string StageWhiteSpotDone => R(nameof(StageWhiteSpotDone));

    public static string StagePaperTitle => R(nameof(StagePaperTitle));
    public static string StagePaperHint => R(nameof(StagePaperHint));
    public static string StagePaperCrumple => R(nameof(StagePaperCrumple));
    public static string StagePaperTear => R(nameof(StagePaperTear));
    public static string StagePaperThrow => R(nameof(StagePaperThrow));
    public static string StagePaperDone => R(nameof(StagePaperDone));

    public static string StageRepeatTitle => R(nameof(StageRepeatTitle));
    public static string StageRepeatHint => R(nameof(StageRepeatHint));
    public static string StageRepeatCount(int count) => F(nameof(StageRepeatCount), count);
    public static string StageRepeatCheck => R(nameof(StageRepeatCheck));
    public static string StageRepeatButton => R(nameof(StageRepeatButton));

    public static string StagePauseTitle => R(nameof(StagePauseTitle));
    public static string StagePauseHint => R(nameof(StagePauseHint));
    public static string StagePauseStart => R(nameof(StagePauseStart));
    public static string StagePauseStop => R(nameof(StagePauseStop));
    public static string StagePauseDone => R(nameof(StagePauseDone));

    public static string StageFutureTitle => R(nameof(StageFutureTitle));
    public static string StageFutureHint => R(nameof(StageFutureHint));

    /// <summary>The marks along the "view from the future" slider: now, a month, a year, 5, 10 and 50 years.</summary>
    public static string StageFutureStop(int index) => R($"StageFutureStop{Math.Clamp(index, 0, StageFutureStopCount - 1)}");

    public const int StageFutureStopCount = 6;
}
