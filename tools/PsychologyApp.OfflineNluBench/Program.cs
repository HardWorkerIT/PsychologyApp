using System.Diagnostics;
using System.Runtime.InteropServices;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Conversation.Companion;

const int WarmupIterations = 2_000;
const int DefaultIterations = 20_000;

if (args.Length > 1 || (args.Length == 1 && (!int.TryParse(args[0], out int requested) || requested < 100 || requested > 1_000_000)))
{
    Console.Error.WriteLine("Usage: dotnet run -c Release --project tools/PsychologyApp.OfflineNluBench -- [iterations: 100..1000000]");
    return 2;
}

int iterations = args.Length == 0 ? DefaultIterations : int.Parse(args[0]);
LexiconSituationAnalyzer analyzer = new();
string[] messages =
[
    "Я сильно тревожусь из-за работы, сердце колотится и не могу уснуть.",
    "Мы поссорились с мамой, мне больно и обидно.",
    "Я злюсь на себя за то, что опять всё отложил.",
    "Чувствую себя одиноко, будто поговорить не с кем.",
    "Я устал и ничего не хочется, даже вставать тяжело.",
    "Мысли крутятся по кругу, боюсь принять неправильное решение.",
    "Мне страшно, накрывает паника, трудно дышать.",
    "Не понимаю, что чувствую, просто сейчас очень тяжело."
];

Console.WriteLine($"Offline Russian NLU benchmark | {RuntimeInformation.FrameworkDescription} | {RuntimeInformation.OSDescription}");
Console.WriteLine($"Architecture: {RuntimeInformation.ProcessArchitecture}; processors: {Environment.ProcessorCount}; warmup: {WarmupIterations}; measured: {iterations}");
Console.WriteLine("Synthetic phrases only. Host results are not representative of Android/AOT performance.");

Measure("utterance classification", text => _ = UtteranceClassifier.Classify(text, hasFeeling: false));
Measure("situation analysis", text => _ = analyzer.Analyze(text));
Measure("analysis + practice choice + reply", text =>
{
    SituationAnalysis analysis = analyzer.Analyze(text);
    _ = TechniqueSuggester.Recommend(analysis);
    _ = CompanionContent.Reflection(analysis, english: false, random: Random.Shared);
});
return 0;

void Measure(string name, Action<string> operation)
{
    for (int i = 0; i < WarmupIterations; i++)
    {
        operation(messages[i % messages.Length]);
    }

    GC.Collect();
    GC.WaitForPendingFinalizers();
    GC.Collect();

    long[] durations = new long[iterations];
    long allocatedBefore = GC.GetAllocatedBytesForCurrentThread();
    long totalTicks = 0;

    for (int i = 0; i < iterations; i++)
    {
        long started = Stopwatch.GetTimestamp();
        operation(messages[i % messages.Length]);
        long elapsed = Stopwatch.GetTimestamp() - started;
        durations[i] = elapsed;
        totalTicks += elapsed;
    }

    long allocatedBytes = GC.GetAllocatedBytesForCurrentThread() - allocatedBefore;
    Array.Sort(durations);
    double meanMicroseconds = ToMicroseconds(totalTicks) / iterations;
    double p50Microseconds = ToMicroseconds(durations[(iterations - 1) / 2]);
    double p95Microseconds = ToMicroseconds(durations[(int)Math.Ceiling(iterations * 0.95) - 1]);
    double allocatedPerOperation = allocatedBytes / (double)iterations;

    Console.WriteLine($"{name}: p50={p50Microseconds:F1} us, p95={p95Microseconds:F1} us, mean={meanMicroseconds:F1} us, allocated={allocatedPerOperation:F0} B/op");
}

static double ToMicroseconds(long stopwatchTicks) => stopwatchTicks * 1_000_000d / Stopwatch.Frequency;
