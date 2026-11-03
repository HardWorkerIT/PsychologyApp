using System.Text.Json;
using PsychologyApp.Application.Conversation.Companion;
using Xunit;
using Xunit.Abstractions;

namespace PsychologyApp.Application.Tests.Conversation;

/// <summary>
/// Accuracy of the lexicon analyzer on labelled messages (Data/*.json). Two sets on purpose:
/// <c>nlu-dataset.json</c> is the development set the lexicon was tuned on (so its accuracy is inflated and only guards regressions);
/// <c>nlu-heldout.json</c> was written afterwards and never used for tuning, so it is the honest estimate of how the lexicon
/// copes with unseen phrasing. Do not add terms based on held-out misses without replacing that set with a fresh one.
/// </summary>
public class AnalyzerDatasetTests(ITestOutputHelper output)
{
    private sealed record Item(string Lang, string Label, string Text);

    private static Item[] Load(string file) => JsonSerializer.Deserialize<Item[]>(
        File.ReadAllText(Path.Combine(AppContext.BaseDirectory, "Data", file)),
        new JsonSerializerOptions { PropertyNameCaseInsensitive = true })!;

    private double Measure(string file, string name)
    {
        LexiconSituationAnalyzer analyzer = new();
        Item[] items = Load(file);
        List<string> misses = [];
        Dictionary<string, (int Total, int Correct)> byLabel = [];
        Dictionary<string, int> predictedCounts = new(StringComparer.Ordinal);
        Dictionary<(string Expected, string Actual), int> confusions = [];
        int hits = 0;

        foreach (Item item in items)
        {
            string predicted = analyzer.Analyze(item.Text).Emotion.ToString();
            (int total, int correct) = byLabel.GetValueOrDefault(item.Label);
            byLabel[item.Label] = (total + 1, correct + (predicted == item.Label ? 1 : 0));
            predictedCounts[predicted] = predictedCounts.GetValueOrDefault(predicted) + 1;
            if (predicted != item.Label)
            {
                (string Expected, string Actual) key = (item.Label, predicted);
                confusions[key] = confusions.GetValueOrDefault(key) + 1;
            }
            if (predicted == item.Label)
            {
                hits++;
            }
            else
            {
                misses.Add($"[{item.Label} -> {predicted}] {item.Text}");
            }
        }

        double accuracy = (double)hits / items.Length;
        output.WriteLine($"{name}: {hits}/{items.Length} = {accuracy:P0}");
        foreach (KeyValuePair<string, (int Total, int Correct)> pair in byLabel.OrderBy(pair => pair.Key))
        {
            int predicted = predictedCounts.GetValueOrDefault(pair.Key);
            double precision = predicted == 0 ? 0 : (double)pair.Value.Correct / predicted;
            double recall = (double)pair.Value.Correct / pair.Value.Total;
            double f1 = precision + recall == 0 ? 0 : 2 * precision * recall / (precision + recall);
            output.WriteLine($"  {pair.Key}: precision {precision:P0}, recall {recall:P0}, F1 {f1:P0} ({pair.Value.Correct}/{pair.Value.Total})");
        }

        foreach (((string expected, string actual), int count) in confusions.OrderByDescending(pair => pair.Value).ThenBy(pair => pair.Key.Expected, StringComparer.Ordinal).Take(10))
        {
            output.WriteLine($"  Confusion {expected} -> {actual}: {count}");
        }

        misses.ForEach(output.WriteLine);
        return accuracy;
    }

    private double MeasureOfflinePipeline(string file, string name, bool printMisses = false, double minGuessMargin = EmotionGuesser.MinMargin, bool printClassMetrics = true)
    {
        LexiconSituationAnalyzer analyzer = new();
        EmotionGuesser guesser = EmotionGuesser.Bundled;
        Item[] items = Load(file);
        int hits = 0;
        int guessed = 0;
        Dictionary<string, (int Total, int Correct)> byLabel = [];
        Dictionary<string, int> predictedCounts = new(StringComparer.Ordinal);
        Dictionary<(string Expected, string Actual), int> confusions = [];
        foreach (Item item in items)
        {
            CompanionEmotion emotion = analyzer.Analyze(item.Text).Emotion;
            EmotionGuess? guess = null;
            if (emotion == CompanionEmotion.Unknown
                && item.Lang == "ru"
                && item.Text.Split((char[]?)null, StringSplitOptions.RemoveEmptyEntries).Length >= EmotionGuesser.MinWords
                && guesser.Rank(item.Text) is { Emotion: not CompanionEmotion.Unknown } ranked
                && ranked.Margin >= minGuessMargin)
            {
                guess = ranked;
            }

            if (guess is not null)
            {
                emotion = guess.Emotion;
                guessed++;
            }

            bool correct = emotion.ToString() == item.Label;
            (int total, int correctCount) = byLabel.GetValueOrDefault(item.Label);
            byLabel[item.Label] = (total + 1, correctCount + (correct ? 1 : 0));
            predictedCounts[emotion.ToString()] = predictedCounts.GetValueOrDefault(emotion.ToString()) + 1;
            if (correct)
            {
                hits++;
            }
            else
            {
                (string Expected, string Actual) key = (item.Label, emotion.ToString());
                confusions[key] = confusions.GetValueOrDefault(key) + 1;
                if (printMisses)
                {
                    output.WriteLine($"  [{item.Label} -> {emotion}] {item.Text}");
                }
            }
        }

        double accuracy = (double)hits / items.Length;
        output.WriteLine($"{name}: offline lexicon + Russian suggestion gate (margin {minGuessMargin:0}) {hits}/{items.Length} = {accuracy:P0}; suggestions used {guessed}");
        foreach ((string label, (int total, int correct)) in byLabel.OrderBy(pair => pair.Key, StringComparer.Ordinal).Where(_ => printClassMetrics))
        {
            int predicted = predictedCounts.GetValueOrDefault(label);
            double precision = predicted == 0 ? 0 : (double)correct / predicted;
            double recall = (double)correct / total;
            double f1 = precision + recall == 0 ? 0 : 2 * precision * recall / (precision + recall);
            output.WriteLine($"  {label}: precision {precision:P0}, recall {recall:P0}, F1 {f1:P0} ({correct}/{total})");
        }

        foreach (((string expected, string actual), int count) in confusions
            .OrderByDescending(pair => pair.Value)
            .ThenBy(pair => pair.Key.Expected, StringComparer.Ordinal)
            .Take(10))
        {
            output.WriteLine($"  Confusion {expected} -> {actual}: {count}");
        }

        return accuracy;
    }

    [Fact]
    public void Development_set_accuracy_does_not_regress()
    {
        double accuracy = Measure("nlu-dataset.json", "Development set (tuned on)");

        Assert.True(accuracy >= 0.95, $"Development-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Held_out_accuracy_is_recorded_and_does_not_collapse()
    {
        double accuracy = Measure("nlu-heldout.json", "Held-out set (never tuned on)");

        // This is the second held-out set: the first was spent (read and tuned against, then folded into
        // nlu-dataset.json — see its trailing entries) after a round of lexicon expansion. Measured 33% on
        // this fresh one, up from an initial 24% on the first. The floor only detects breakage.
        Assert.True(accuracy >= 0.20, $"Held-out accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Fresh_set_accuracy_is_recorded_and_does_not_collapse()
    {
        double accuracy = Measure("nlu-fresh.json", "Fresh set (written before the third lexicon round)");

        Assert.True(accuracy >= 0.20, $"Fresh-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Final_set_accuracy_is_recorded_and_does_not_collapse()
    {
        // Written after the third lexicon round and never tuned on: the honest estimate. Do not add terms from its misses.
        double accuracy = Measure("nlu-fresh2.json", "Final set (written after the third round, never tuned on)");

        Assert.True(accuracy >= 0.20, $"Final-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Third_final_set_accuracy_is_recorded_and_does_not_collapse()
    {
        double accuracy = Measure("nlu-fresh3.json", "Third final set (written before the guesser was extended)");

        Assert.True(accuracy >= 0.20, $"Third-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Fourth_final_set_accuracy_is_recorded_and_does_not_collapse()
    {
        double accuracy = Measure("nlu-fresh4.json", "Fourth final set (never tuned on)");

        Assert.True(accuracy >= 0.20, $"Fourth-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_development_set_is_recorded()
    {
        double accuracy = Measure("nlu-ru-expansion-dev.json", "Russian vocabulary expansion development set");

        Assert.True(accuracy >= 0.20, $"Development-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Lexicon_accuracy_on_classifier_training_phrases_is_reported()
    {
        Measure("nlu-train-extra.json", "Lexicon on the guesser training phrases (development only)");
    }

    [Fact]
    public void Russian_vocabulary_expansion_heldout_set_is_recorded()
    {
        double accuracy = Measure("nlu-ru-expansion-heldout.json", "Russian vocabulary expansion held-out set");

        Assert.True(accuracy >= 0.20, $"Held-out-set accuracy fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v5_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v5.json", "Russian v5 (spent), lexicon only");
        MeasureOfflinePipeline("nlu-ru-expansion-heldout-v5.json", "Russian v5 (spent), live offline pipeline");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v6_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v6.json", "Russian v6 (spent), lexicon only");
        MeasureOfflinePipeline("nlu-ru-expansion-heldout-v6.json", "Russian v6 (spent), live offline pipeline");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v7_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v7.json", "Russian v7 (spent), lexicon only");
        MeasureOfflinePipeline("nlu-ru-expansion-heldout-v7.json", "Russian v7 (spent), live offline pipeline");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v8_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v8.json", "Russian v8 (spent), lexicon only");
        MeasureOfflinePipeline("nlu-ru-expansion-heldout-v8.json", "Russian v8 (spent), live offline pipeline");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v9_reports_current_offline_accuracy()
    {
        Measure("nlu-ru-expansion-heldout-v9.json", "Russian held-out v9, lexicon only");
        double accuracy = MeasureOfflinePipeline("nlu-ru-expansion-heldout-v9.json", "Russian held-out v9, live offline pipeline");

        // Synthetic development target is 90%; this floor only guards against collapse until independently labelled data is available.
        Assert.True(accuracy >= 0.80, $"Live offline pipeline accuracy on the reserved Russian set fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v10_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v10.json", "Russian v10 (spent), lexicon only");
        double accuracy = MeasureOfflinePipeline("nlu-ru-expansion-heldout-v10.json", "Russian v10 (spent), live offline pipeline");

        Assert.True(accuracy >= 0.80, $"Live offline pipeline accuracy on the spent Russian set fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v11_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v11.json", "Russian v11 (spent), lexicon only");
        double accuracy = MeasureOfflinePipeline("nlu-ru-expansion-heldout-v11.json", "Russian v11 (spent), live offline pipeline");

        Assert.True(accuracy >= 0.80, $"Live offline pipeline accuracy on the spent Russian set fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v12_reports_its_spent_check_result()
    {
        Measure("nlu-ru-expansion-heldout-v12.json", "Russian v12 (spent), lexicon only");
        double accuracy = MeasureOfflinePipeline("nlu-ru-expansion-heldout-v12.json", "Russian v12 (spent), live offline pipeline");

        Assert.True(accuracy >= 0.80, $"Live offline pipeline accuracy on the spent Russian set fell to {accuracy:P0}.");
    }

    [Fact]
    public void Russian_vocabulary_expansion_v13_reaches_ninety_five_percent_offline_accuracy()
    {
        Measure("nlu-ru-expansion-heldout-v13.json", "Russian held-out v13, lexicon only");
        double accuracy = MeasureOfflinePipeline("nlu-ru-expansion-heldout-v13.json", "Russian held-out v13, live offline pipeline");

        Assert.True(accuracy >= 0.95, $"Live offline pipeline accuracy on the fresh Russian set was {accuracy:P0}; the target is 95%.");
    }

    [Theory]
    [InlineData("nlu-dataset.json")]
    [InlineData("nlu-train-extra.json")]
    [InlineData("nlu-heldout.json")]
    [InlineData("nlu-fresh.json")]
    [InlineData("nlu-fresh2.json")]
    [InlineData("nlu-fresh3.json")]
    [InlineData("nlu-fresh4.json")]
    [InlineData("nlu-ru-expansion-dev.json")]
    [InlineData("nlu-ru-expansion-heldout.json")]
    [InlineData("nlu-ru-expansion-heldout-v2.json")]
    [InlineData("nlu-ru-expansion-heldout-v3.json")]
    [InlineData("nlu-ru-expansion-heldout-v4.json")]
    [InlineData("nlu-ru-expansion-heldout-v5.json")]
    [InlineData("nlu-ru-expansion-heldout-v6.json")]
    [InlineData("nlu-ru-expansion-heldout-v7.json")]
    [InlineData("nlu-ru-expansion-heldout-v8.json")]
    [InlineData("nlu-ru-expansion-heldout-v9.json")]
    [InlineData("nlu-ru-expansion-heldout-v10.json")]
    [InlineData("nlu-ru-expansion-heldout-v11.json")]
    [InlineData("nlu-ru-expansion-heldout-v12.json")]
    [InlineData("nlu-ru-expansion-heldout-v13.json")]
    public void Datasets_are_well_formed(string file)
    {
        Item[] items = Load(file);

        Assert.True(items.Length >= 45);
        Assert.All(Enum.GetNames<CompanionEmotion>(), name => Assert.True(items.Count(i => i.Label == name) >= 2, $"{file}: {name}"));
        Assert.All(items, i => Assert.False(string.IsNullOrWhiteSpace(i.Text)));
    }
}
