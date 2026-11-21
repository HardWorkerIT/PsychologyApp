using System.Linq;
using PsychologyApp.Domain.Tests;
using PsychologyApp.Presentation.Common;

namespace PsychologyApp.Presentation.Shared.Common;

/// <summary>
/// Maps analyzer ids + scores to localized copy. Lives in Core so Features
/// (RunTests, RunTechniqueSession) and net11.0 tests can share without MAUI.
/// </summary>
public static class TestScoreLabelMapper
{
    public static string? GetSummary(string? analyzerId, int score) => analyzerId switch
    {
        PreferenceProfile16.AnalyzerId => Personality16Summary(score),
        BigFiveProfile.AnalyzerId => AppStrings.BigFiveSummary,
        Asrs6Screening.AnalyzerId => Asrs6Summary(score),
        _ when SelfReflectionProfile.IsAnalyzer(analyzerId) => SelfReflectionSummary(score),
        "heck_hess" => AppStrings.HeckHessScore(TestScoreBandClassifier.ClassifyHeckHess(score)),
        "haer" => AppStrings.HaerScore(TestScoreBandClassifier.ClassifyHaer(score)),
        "pochebut" => AppStrings.PochebutScore(TestScoreBandClassifier.ClassifyPochebut(score)),
        "beck" => AppStrings.BeckScore(TestScoreBandClassifier.ClassifyBeck(score)),
        "gad7" => AppStrings.Gad7Score(TestScoreBandClassifier.ClassifyGad7(score)),
        "k10" => AppStrings.K10Score(TestScoreBandClassifier.ClassifyK10(score)),
        "who5" => AppStrings.Who5Score(TestScoreBandClassifier.ClassifyWho5(score)),
        "phq9" => AppStrings.Phq9Score(TestScoreBandClassifier.ClassifyPhq9(score)),
        "isi" => AppStrings.IsiScore(TestScoreBandClassifier.ClassifyIsi(score)),
        "ess" => AppStrings.EssScore(TestScoreBandClassifier.ClassifyEss(score)),
        "phq15" => AppStrings.Phq15Score(TestScoreBandClassifier.ClassifyPhq15(score)),
        "scoff" => AppStrings.ScoffScore(TestScoreBandClassifier.ClassifyScoff(score)),
        "swls" => AppStrings.SwlsScore(TestScoreBandClassifier.ClassifySwls(score)),
        "pss10" => AppStrings.Pss10Score(TestScoreBandClassifier.ClassifyPss10(score)),
        "phq2" => AppStrings.Phq2Score(TestScoreBandClassifier.ClassifyPhq2(score)),
        "gad2" => AppStrings.Gad2Score(TestScoreBandClassifier.ClassifyGad2(score)),
        "hads_a" => AppStrings.HadsAnxietyScore(TestScoreBandClassifier.ClassifyHads(score)),
        "hads_d" => AppStrings.HadsDepressionScore(TestScoreBandClassifier.ClassifyHads(score)),
        "rses" => AppStrings.RsesScore(TestScoreBandClassifier.ClassifyRses(score)),
        "pcptsd5" => AppStrings.PcPtsd5Score(TestScoreBandClassifier.ClassifyPcPtsd5(score)),
        "pcl5" => AppStrings.Pcl5Score(TestScoreBandClassifier.ClassifyPcl5(score)),
        _ => null
    };

    public static string? GetDetail(string? analyzerId, int score) => analyzerId switch
    {
        PreferenceProfile16.AnalyzerId => Personality16Detail(score),
        BigFiveProfile.AnalyzerId => BigFiveDetail(score),
        Asrs6Screening.AnalyzerId => Asrs6Detail(score),
        _ when SelfReflectionProfile.IsAnalyzer(analyzerId) => SelfReflectionDetail(score),
        "heck_hess" => AppStrings.HeckHessScoreDetail(TestScoreBandClassifier.ClassifyHeckHess(score)),
        "haer" => AppStrings.HaerScoreDetail(TestScoreBandClassifier.ClassifyHaer(score)),
        "pochebut" => AppStrings.PochebutScoreDetail(TestScoreBandClassifier.ClassifyPochebut(score)),
        "beck" => AppStrings.BeckScoreDetail(TestScoreBandClassifier.ClassifyBeck(score)),
        "gad7" => AppStrings.Gad7ScoreDetail(TestScoreBandClassifier.ClassifyGad7(score)),
        "k10" => AppStrings.K10ScoreDetail(TestScoreBandClassifier.ClassifyK10(score)),
        "who5" => AppStrings.Who5ScoreDetail(TestScoreBandClassifier.ClassifyWho5(score)),
        "phq9" => AppStrings.Phq9ScoreDetail(TestScoreBandClassifier.ClassifyPhq9(score)),
        "isi" => AppStrings.IsiScoreDetail(TestScoreBandClassifier.ClassifyIsi(score)),
        "ess" => AppStrings.EssScoreDetail(TestScoreBandClassifier.ClassifyEss(score)),
        "phq15" => AppStrings.Phq15ScoreDetail(TestScoreBandClassifier.ClassifyPhq15(score)),
        "scoff" => AppStrings.ScoffScoreDetail(TestScoreBandClassifier.ClassifyScoff(score)),
        "swls" => AppStrings.SwlsScoreDetail(TestScoreBandClassifier.ClassifySwls(score)),
        "pss10" => AppStrings.Pss10ScoreDetail(TestScoreBandClassifier.ClassifyPss10(score)),
        "phq2" => AppStrings.Phq2ScoreDetail(TestScoreBandClassifier.ClassifyPhq2(score)),
        "gad2" => AppStrings.Gad2ScoreDetail(TestScoreBandClassifier.ClassifyGad2(score)),
        "hads_a" => AppStrings.HadsAnxietyScoreDetail(TestScoreBandClassifier.ClassifyHads(score)),
        "hads_d" => AppStrings.HadsDepressionScoreDetail(TestScoreBandClassifier.ClassifyHads(score)),
        "rses" => AppStrings.RsesScoreDetail(TestScoreBandClassifier.ClassifyRses(score)),
        "pcptsd5" => AppStrings.PcPtsd5ScoreDetail(TestScoreBandClassifier.ClassifyPcPtsd5(score)),
        "pcl5" => AppStrings.Pcl5ScoreDetail(TestScoreBandClassifier.ClassifyPcl5(score)),
        _ => null
    };

    public static string? GetRecommendationReason(string? analyzerId, int score) => analyzerId switch
    {
        BigFiveProfile.AnalyzerId => AppStrings.BigFivePracticeHint,
        _ when SelfReflectionProfile.IsAnalyzer(analyzerId) => AppStrings.SelfReflectionPracticeHint,
        "beck" => AppStrings.TestRecommendationReasonBeck(TestScoreBandClassifier.RecommendBeck(score)),
        "heck_hess" => AppStrings.TestRecommendationReasonHeckHess(TestScoreBandClassifier.RecommendHeckHess(score)),
        "haer" => AppStrings.TestRecommendationReasonHaer(TestScoreBandClassifier.RecommendHaer(score)),
        "pochebut" => AppStrings.TestRecommendationReasonPochebut(TestScoreBandClassifier.RecommendPochebut(score)),
        "gad7" => AppStrings.TestRecommendationReasonGad7(TestScoreBandClassifier.RecommendGad7(score)),
        "k10" => AppStrings.TestRecommendationReasonK10(TestScoreBandClassifier.RecommendK10(score)),
        "who5" => AppStrings.TestRecommendationReasonWho5(TestScoreBandClassifier.RecommendWho5(score)),
        "phq9" => AppStrings.TestRecommendationReasonPhq9(TestScoreBandClassifier.RecommendPhq9(score)),
        "isi" => AppStrings.TestRecommendationReasonIsi(TestScoreBandClassifier.RecommendIsi(score)),
        "ess" => AppStrings.TestRecommendationReasonEss(TestScoreBandClassifier.RecommendEss(score)),
        "phq15" => AppStrings.TestRecommendationReasonPhq15(TestScoreBandClassifier.RecommendPhq15(score)),
        "scoff" => AppStrings.TestRecommendationReasonScoff(TestScoreBandClassifier.RecommendScoff(score)),
        "swls" => AppStrings.TestRecommendationReasonSwls(TestScoreBandClassifier.RecommendSwls(score)),
        "pss10" => AppStrings.TestRecommendationReasonPss10(TestScoreBandClassifier.RecommendPss10(score)),
        "phq2" => AppStrings.TestRecommendationReasonPhq2(TestScoreBandClassifier.RecommendPhq2(score)),
        "gad2" => AppStrings.TestRecommendationReasonGad2(TestScoreBandClassifier.RecommendGad2(score)),
        "hads_a" => AppStrings.TestRecommendationReasonHadsAnxiety(TestScoreBandClassifier.RecommendHadsAnxiety(score)),
        "hads_d" => AppStrings.TestRecommendationReasonHadsDepression(TestScoreBandClassifier.RecommendHadsDepression(score)),
        "rses" => AppStrings.TestRecommendationReasonRses(TestScoreBandClassifier.RecommendRses(score)),
        "pcptsd5" => AppStrings.TestRecommendationReasonPcPtsd5(TestScoreBandClassifier.RecommendPcPtsd5(score)),
        "pcl5" => AppStrings.TestRecommendationReasonPcl5(TestScoreBandClassifier.RecommendPcl5(score)),
        _ => null
    };

    public static string? GetProfileCode(string? analyzerId, int score) => analyzerId switch
    {
        PreferenceProfile16.AnalyzerId => PreferenceProfile16.DecodeTypeCode(score),
        BigFiveProfile.AnalyzerId => AppStrings.BigFiveProfileShort,
        Asrs6Screening.AnalyzerId => AppStrings.Asrs6Score(score),
        _ when SelfReflectionProfile.IsAnalyzer(analyzerId) =>
            AppStrings.SelfReflectionResultTitle(TestScoreBandClassifier.ClassifySelfReflection(score)),
        _ => null
    };

    public static string? GetProfileName(string? analyzerId, int score) =>
        analyzerId == PreferenceProfile16.AnalyzerId
            ? AppStrings.Personality16TypeName(PreferenceProfile16.DecodeTypeCode(score))
            : null;

    public static bool ShouldLoadTrend(string? analyzerId) =>
        analyzerId != PreferenceProfile16.AnalyzerId
        && analyzerId != BigFiveProfile.AnalyzerId
        && analyzerId != Asrs6Screening.AnalyzerId
        && !SelfReflectionProfile.IsAnalyzer(analyzerId);

    public static string? GetHistoryScore(string? analyzerId, int score) => analyzerId switch
    {
        PreferenceProfile16.AnalyzerId or BigFiveProfile.AnalyzerId => null,
        Asrs6Screening.AnalyzerId => AppStrings.Asrs6Score(score),
        _ when SelfReflectionProfile.IsAnalyzer(analyzerId) => null,
        _ => AppStrings.TestHistoryScore(score)
    };

    private static string SelfReflectionSummary(int score) =>
        AppStrings.SelfReflectionSummary(TestScoreBandClassifier.ClassifySelfReflection(score));

    private static string SelfReflectionDetail(int score) =>
        AppStrings.SelfReflectionDetail(TestScoreBandClassifier.ClassifySelfReflection(score));

    private static string Asrs6Summary(int score) =>
        AppStrings.Asrs6Summary(TestScoreBandClassifier.ClassifyAsrs6(score));

    private static string Asrs6Detail(int score) =>
        AppStrings.Asrs6Detail(TestScoreBandClassifier.ClassifyAsrs6(score));

    private static string BigFiveDetail(int score) => string.Join(
        Environment.NewLine,
        BigFiveProfile.Decode(score).Select(item => AppStrings.BigFiveTraitScore(
            AppStrings.BigFiveTraitName(item.Trait), item.Score)));

    private static string Personality16Summary(int score)
    {
        string code = PreferenceProfile16.DecodeTypeCode(score);
        return AppStrings.Personality16TypeResult(AppStrings.Personality16TypeName(code), code);
    }

    private static string Personality16Detail(int score)
    {
        string code = PreferenceProfile16.DecodeTypeCode(score);
        string preferences = string.Join(" · ", PreferenceProfile16.DecodePreferences(code)
            .Select(AppStrings.Personality16PreferenceLabel));
        return AppStrings.Personality16ResultDetail(preferences);
    }
}
