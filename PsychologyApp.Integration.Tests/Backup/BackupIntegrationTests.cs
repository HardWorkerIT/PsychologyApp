using Microsoft.Extensions.DependencyInjection;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.DataBackup;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Testing.Data;
using System.Text.Json;
using System.Data.Common;
using Xunit;

namespace PsychologyApp.Integration.Tests.Backup;

public sealed class BackupIntegrationTests : IAsyncLifetime
{
    private static readonly DateTime LongAgo = new(2020, 1, 2, 3, 4, 5, DateTimeKind.Utc);

    private readonly SharedMemoryConnectionFactory _sourceFactory = new();
    private readonly SharedMemoryConnectionFactory _targetFactory = new();
    private ServiceProvider _source = null!;
    private ServiceProvider _target = null!;

    public Task InitializeAsync()
    {
        _source = IntegrationTestServiceCollection.BuildCoreProvider(_sourceFactory);
        _target = IntegrationTestServiceCollection.BuildCoreProvider(_targetFactory);
        return Task.CompletedTask;
    }

    [Fact]
    public async Task ExportExcludesAPracticeSavedAfterTheSnapshotWasRequested()
    {
        var gated = new GatedExportConnectionFactory(_sourceFactory);
        await using ServiceProvider services = IntegrationTestServiceCollection.BuildCoreProvider(
            _sourceFactory, registrations => IntegrationTestServiceCollection.ReplaceSingleton<IDbConnectionFactory>(registrations, gated));
        IBackupService backup = services.GetRequiredService<IBackupService>();
        IUserProgressService progress = services.GetRequiredService<IUserProgressService>();

        Task<string> export = backup.ExportAsync();
        Task<long> save;
        try
        {
            await gated.ExportOpened.Task.WaitAsync(TimeSpan.FromSeconds(5));
            save = progress.RecordSessionOutcomeAsync(new SessionOutcomeRequest
            {
                ItemKey = "Breathing",
                ModuleName = "Practice",
                PageName = "Breathing",
                PreIntensity = 8,
                PostIntensity = 4
            });
        }
        finally
        {
            gated.ContinueExport.TrySetResult();
        }

        AppBackupDTO first = JsonSerializer.Deserialize(await export, BackupJsonContext.Default.AppBackupDTO)!;
        Assert.Empty(first.Completions);
        Assert.Empty(first.SessionResults);
        await save;

        AppBackupDTO second = JsonSerializer.Deserialize(await backup.ExportAsync(), BackupJsonContext.Default.AppBackupDTO)!;
        Assert.Equal("Breathing", Assert.Single(second.Completions).ItemKey);
        Assert.Equal("Breathing", Assert.Single(second.SessionResults).ItemKey);
        PracticeIntensitySample sample = Assert.Single(await progress.GetRecentPracticeIntensityAsync(300));
        Assert.Equal("Breathing", sample.ItemKey);
        Assert.Equal(8, sample.PreIntensity);
        Assert.Equal(4, sample.PostIntensity);
    }

    private sealed class GatedExportConnectionFactory(SharedMemoryConnectionFactory inner) : IDbConnectionFactory
    {
        private int _opened;
        public TaskCompletionSource ExportOpened { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public TaskCompletionSource ContinueExport { get; } = new(TaskCreationOptions.RunContinuationsAsynchronously);
        public string DatabasePath => inner.DatabasePath;

        public async Task<DbConnection> CreateOpenConnectionAsync(CancellationToken cancellationToken = default)
        {
            if (Interlocked.Increment(ref _opened) == 1)
            {
                ExportOpened.TrySetResult();
                await ContinueExport.Task.WaitAsync(cancellationToken);
            }

            return await inner.CreateOpenConnectionAsync(cancellationToken);
        }
    }

    [Fact]
    public async Task RoundTrip_KeepsOriginalTimestampsAndChats()
    {
        await _source.GetRequiredService<IUserProgressService>().RecordMoodAsync(4, "calm", LongAgo);
        IChatRepository sourceChat = _source.GetRequiredService<IChatRepository>();
        long sessionId = await sourceChat.CreateSessionAsync("first", LongAgo);
        await sourceChat.AddMessageAsync(new ChatMessageDTO { SessionId = sessionId, Role = ChatRole.User, Text = "hi", CreatedAt = LongAgo });
        await sourceChat.SetMemoryAsync("name", "Sam");

        string json = await _source.GetRequiredService<IBackupService>().ExportAsync();
        BackupImportResult result = await _target.GetRequiredService<IBackupService>().ImportAsync(json);

        Assert.Equal(1, result.MoodEntries);
        Assert.Equal(1, result.ChatSessions);
        IReadOnlyList<MoodEntryDTO> moods = await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync();
        Assert.Equal(LongAgo, Assert.Single(moods).RecordedAt);
        IChatRepository targetChat = _target.GetRequiredService<IChatRepository>();
        ChatSessionDTO session = Assert.Single(await targetChat.GetSessionsAsync());
        Assert.Equal("hi", Assert.Single(await targetChat.GetMessagesAsync(session.Id)).Text);
        Assert.Equal("Sam", (await targetChat.GetMemoryAsync())["name"]);
    }

    [Fact]
    public async Task ImportNormalizesAliasesOfTheSamePracticeCounter()
    {
        string canonical = ChatMemoryKeys.Tried(PsychologyApp.Domain.Practice.TechniqueId.Breathing);
        string legacy = ChatMemoryKeys.TriedPrefix + PsychologyApp.Domain.Practice.TechniqueId.Breathing.ToString("D");
        IChatRepository sourceChat = _source.GetRequiredService<IChatRepository>();
        await sourceChat.SetMemoryAsync(canonical, "2");
        await sourceChat.SetMemoryAsync(legacy, "3");
        await sourceChat.SetMemoryAsync(ChatMemoryKeys.Name, "Sam");
        string json = await _source.GetRequiredService<IBackupService>().ExportAsync();

        await _target.GetRequiredService<IBackupService>().ImportAsync(json);

        IReadOnlyDictionary<string, string> memory = await _target.GetRequiredService<IChatRepository>().GetMemoryAsync();
        Assert.Equal("3", memory[canonical]);
        Assert.DoesNotContain(legacy, memory.Keys);
        Assert.Equal("Sam", memory[ChatMemoryKeys.Name]);
    }

    [Fact]
    public async Task EncryptedBackup_NeedsThePassphrase_AndRestoresTheSameData()
    {
        await _source.GetRequiredService<IUserProgressService>().RecordMoodAsync(4, "a private note", LongAgo);
        IBackupService source = _source.GetRequiredService<IBackupService>();
        IBackupService target = _target.GetRequiredService<IBackupService>();

        string file = await source.ExportEncryptedAsync("correct horse battery");

        Assert.True(target.IsEncrypted(file));
        Assert.DoesNotContain("a private note", file);
        await Assert.ThrowsAsync<BackupPassphraseException>(() => target.ImportAsync(file));
        await Assert.ThrowsAsync<BackupPassphraseException>(() => target.ImportEncryptedAsync(file, "wrong passphrase"));
        Assert.Empty(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync());

        BackupImportResult result = await target.ImportEncryptedAsync(file, "correct horse battery");

        Assert.Equal(1, result.MoodEntries);
        Assert.Equal("a private note", Assert.Single(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync()).Note);
    }

    [Fact]
    public async Task Import_SameFileTwice_AddsNothingTheSecondTime()
    {
        await _source.GetRequiredService<IUserProgressService>().RecordMoodAsync(2, null, LongAgo);
        await _source.GetRequiredService<IUserProgressService>().SaveTestResultAsync("gad7", 5, "mild");
        IBackupService target = _target.GetRequiredService<IBackupService>();
        string json = await _source.GetRequiredService<IBackupService>().ExportAsync();

        await target.ImportAsync(json);
        BackupImportResult second = await target.ImportAsync(json);

        Assert.Equal(0, second.MoodEntries);
        Assert.Equal(0, second.TestResults);
        Assert.True(second.SkippedDuplicates >= 2);
        Assert.Equal(1, await _target.GetRequiredService<IUserProgressService>().CountTestResultsAsync());
        Assert.Single(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync());
    }

    [Theory]
    [InlineData(false)]
    [InlineData(true)]
    public async Task Import_RestoresQuickActionsOnlyWhenThereIsNoLocalSelection(bool hasLocalSelection)
    {
        IUserProgressService source = _source.GetRequiredService<IUserProgressService>();
        IUserProgressService target = _target.GetRequiredService<IUserProgressService>();
        SavedNextStep[] sourceActions = [SavedNextStep.MuscleRelax, SavedNextStep.ThoughtRecord];
        SavedNextStep[] localActions = [SavedNextStep.Breathing, SavedNextStep.Grounding];
        await source.SetSavedNextStepsAsync(sourceActions);
        if (hasLocalSelection)
        {
            await target.SetSavedNextStepsAsync(localActions);
        }

        string json = await _source.GetRequiredService<IBackupService>().ExportAsync();
        await _target.GetRequiredService<IBackupService>().ImportAsync(json);

        Assert.Equal(hasLocalSelection ? localActions : sourceActions, await target.GetSavedNextStepsAsync());
    }

    [Fact]
    public async Task Import_PreservesDifferentResultsAtTheSameTimestampWithoutDuplicatingThem()
    {
        AppBackupDTO backup = new()
        {
            TestResults =
            [
                new TestResultDTO { TestId = "gad7", CompletedAt = LongAgo, Score = 5, Summary = "mild" },
                new TestResultDTO { TestId = "gad7", CompletedAt = LongAgo, Score = 12, Summary = "moderate" }
            ],
            SessionResults =
            [
                new SessionResultDTO { ItemKey = "breathing", CompletedAt = LongAgo, Note = "first" },
                new SessionResultDTO { ItemKey = "breathing", CompletedAt = LongAgo, Note = "second" }
            ]
        };
        string json = JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO);
        IBackupService service = _target.GetRequiredService<IBackupService>();
        IUserProgressService progress = _target.GetRequiredService<IUserProgressService>();

        await service.ImportAsync(json);
        BackupImportResult repeat = await service.ImportAsync(json);

        Assert.Equal(0, repeat.TestResults);
        Assert.Equal(0, repeat.SessionResults);
        Assert.Equal(new int?[] { 5, 12 }, (await progress.GetAllTestResultsAsync()).Select(result => result.Score).Order());
        Assert.Equal(new[] { "first", "second" }, (await progress.GetRecentSessionResultsAsync()).Select(result => result.Note).Order());
    }

    [Fact]
    public async Task Import_SessionResults_KeepTheirDateAndDoNotCreateCompletionsNow()
    {
        AppBackupDTO backup = new()
        {
            SessionResults = [new SessionResultDTO { ItemKey = "breathing", CompletedAt = LongAgo, DurationSeconds = 60, PreIntensity = 7, PostIntensity = 3, Note = "better" }]
        };
        IUserProgressService progress = _target.GetRequiredService<IUserProgressService>();

        await _target.GetRequiredService<IBackupService>().ImportAsync(JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO));

        SessionResultDTO restored = Assert.Single(await progress.GetRecentSessionResultsAsync());
        Assert.Equal(LongAgo, restored.CompletedAt);
        Assert.Equal(3, restored.PostIntensity);
        Assert.Equal("better", restored.Note);
        Assert.Equal(0, await progress.CountTechniqueCompletionsAsync());
        Assert.Null(await progress.GetLastTechniqueCompletionDateAsync());
        Assert.Equal(0, await progress.GetStreakDaysAsync());
    }

    [Fact]
    public async Task Import_AnOlderPracticeCopy_PreservesLocalEditsWithoutHidingAnotherResult()
    {
        AppBackupDTO backup = new()
        {
            SessionResults = [new SessionResultDTO { ItemKey = "breathing", CompletedAt = LongAgo, DurationSeconds = 60 }]
        };
        IBackupService service = _target.GetRequiredService<IBackupService>();
        IUserProgressService progress = _target.GetRequiredService<IUserProgressService>();
        string older = JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO);
        await service.ImportAsync(older);
        SessionResultDTO saved = Assert.Single(await progress.GetRecentSessionResultsAsync());
        await progress.UpdateSessionResultNoteAsync(saved.SessionResultId, "local note");
        await progress.UpdateSessionResultPostIntensityAsync(saved.SessionResultId, 4);

        await service.ImportAsync(older);

        SessionResultDTO edited = Assert.Single(await progress.GetRecentSessionResultsAsync());
        Assert.Equal("local note", edited.Note);
        Assert.Equal(4, edited.PostIntensity);

        AppBackupDTO twoResults = new()
        {
            SessionResults =
            [
                backup.SessionResults[0],
                new SessionResultDTO { ItemKey = "breathing", CompletedAt = LongAgo, DurationSeconds = 60, Note = "another result" }
            ]
        };
        string twoResultsJson = JsonSerializer.Serialize(twoResults, BackupJsonContext.Default.AppBackupDTO);
        await service.ImportAsync(twoResultsJson);
        await service.ImportAsync(twoResultsJson);

        Assert.Equal(new[] { "another result", "local note" },
            (await progress.GetRecentSessionResultsAsync()).Select(result => result.Note).Order());
    }

    [Fact]
    public async Task Import_MatchesTheExistingPracticeBeforeAddingAnotherAtTheSameTimestamp()
    {
        SessionResultDTO existing = new() { ItemKey = "breathing", CompletedAt = LongAgo, Note = "existing" };
        SessionResultDTO other = new() { ItemKey = "breathing", CompletedAt = LongAgo, Note = "different" };
        IBackupService service = _target.GetRequiredService<IBackupService>();
        await service.ImportAsync(JsonSerializer.Serialize(new AppBackupDTO { SessionResults = [existing] },
            BackupJsonContext.Default.AppBackupDTO));

        await service.ImportAsync(JsonSerializer.Serialize(new AppBackupDTO { SessionResults = [other, existing] },
            BackupJsonContext.Default.AppBackupDTO));

        IUserProgressService progress = _target.GetRequiredService<IUserProgressService>();
        Assert.Equal(new[] { "different", "existing" },
            (await progress.GetRecentSessionResultsAsync()).Select(result => result.Note).Order());
    }

    [Fact]
    public async Task Import_WhenARowFails_RollsEverythingBack()
    {
        string json = """
            {
              "FormatVersion": 2,
              "MoodEntries": [ { "MoodLevel": 3, "RecordedAt": "2020-01-02T03:04:05Z" } ],
              "ChatSessions": [ {
                "Session": { "Title": "t", "CreatedAt": "2020-01-02T03:04:05Z", "UpdatedAt": "2020-01-02T03:04:05Z" },
                "Messages": [ { "Role": 0, "Text": null, "CreatedAt": "2020-01-02T03:04:05Z" } ]
              } ]
            }
            """;

        await Assert.ThrowsAnyAsync<Exception>(() => _target.GetRequiredService<IBackupService>().ImportAsync(json));

        Assert.Empty(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync());
        Assert.Empty(await _target.GetRequiredService<IChatRepository>().GetSessionsAsync());
    }

    [Fact]
    public async Task Import_WhenDocumentWriteFails_RollsBackRows()
    {
        await using var connection = await _targetFactory.CreateOpenConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = "CREATE TRIGGER FailSafetyPlan BEFORE INSERT ON AppMetadata WHEN NEW.Key = 'SafetyPlan' BEGIN SELECT RAISE(ABORT, 'injected failure'); END;";
        await command.ExecuteNonQueryAsync();
        AppBackupDTO backup = new()
        {
            MoodEntries = [new MoodEntryDTO { MoodLevel = 3, RecordedAt = LongAgo }],
            SafetyPlan = new SafetyPlanDTO { WarningSigns = ["warning"] }
        };
        await Assert.ThrowsAnyAsync<Exception>(() => _target.GetRequiredService<IBackupService>().ImportAsync(
            JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO)));
        Assert.Empty(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync());
    }

    [Fact]
    public async Task Import_ContinuedChat_MergesMessagesAndKeepsNewestState()
    {
        IBackupService target = _target.GetRequiredService<IBackupService>();
        string Snapshot(int count) => JsonSerializer.Serialize(new AppBackupDTO
        {
            ChatSessions = [new BackupChatSessionDTO
            {
                Session = new BackupChatSessionInfoDTO { Title = "chat", CreatedAt = LongAgo, UpdatedAt = LongAgo.AddMinutes(count), StateJson = count.ToString() },
                Messages = Enumerable.Range(1, count).Select(i => new ChatMessageDTO
                { Id = i, Role = ChatRole.User, Text = "repeated message", CreatedAt = LongAgo }).ToList()
            }]
        }, BackupJsonContext.Default.AppBackupDTO);
        await target.ImportAsync(Snapshot(1));
        await target.ImportAsync(Snapshot(2));
        await target.ImportAsync(Snapshot(2));
        await target.ImportAsync(Snapshot(1));
        IChatRepository chat = _target.GetRequiredService<IChatRepository>();
        ChatSessionDTO session = Assert.Single(await chat.GetSessionsAsync());
        Assert.Equal("2", session.StateJson);
        Assert.Equal(2, (await chat.GetMessagesAsync(session.Id)).Count);
    }

    [Fact]
    public async Task Import_ChatDiscardsUndefinedFeelingsAndOutOfRangeTension()
    {
        AppBackupDTO backup = new()
        {
            ChatSessions = [new BackupChatSessionDTO
            {
                Session = new BackupChatSessionInfoDTO
                {
                    Title = "chat",
                    CreatedAt = LongAgo,
                    UpdatedAt = LongAgo,
                    Emotion = "999",
                    Theme = "999",
                    FirstIntensity = 99,
                    LastIntensity = -1
                },
                Messages = [new ChatMessageDTO { Role = ChatRole.User, Text = "привет", CreatedAt = LongAgo }]
            }]
        };

        await _target.GetRequiredService<IBackupService>().ImportAsync(
            JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO));

        ChatSessionDTO session = Assert.Single(await _target.GetRequiredService<IChatRepository>().GetSessionsAsync());
        Assert.Null(session.Emotion);
        Assert.Null(session.Theme);
        Assert.Null(session.FirstIntensity);
        Assert.Null(session.LastIntensity);
    }

    [Theory]
    [InlineData("\"MoodEntries\": null")]
    [InlineData("\"ChatSessions\": [null]")]
    [InlineData("\"ChatSessions\": [{\"Session\":null}]")]
    [InlineData("\"SafetyPlan\": {\"WarningSigns\":[\"warning\"],\"Contacts\":[null]}")]
    [InlineData("\"SafetyPlan\": {\"Contacts\":[{\"Name\":null,\"Phone\":null}]}")]
    public async Task Import_NullRequiredData_IsRejectedBeforeAnyWrites(string property)
    {
        await _target.GetRequiredService<IUserProgressService>().RecordMoodAsync(4, "existing", LongAgo);
        string json = "{\"FormatVersion\":2," + property + "}";

        await Assert.ThrowsAsync<BackupFormatException>(() => _target.GetRequiredService<IBackupService>().ImportAsync(json));

        Assert.Equal("existing", Assert.Single(await _target.GetRequiredService<IUserProgressService>().GetMoodsAsync()).Note);
        Assert.Null(await _target.GetRequiredService<IClinicalCareRepository>().GetSafetyPlanAsync());
    }

    [Theory]
    [InlineData("")]
    [InlineData("not json")]
    [InlineData("{}")]
    [InlineData("{\"MoodEntries\":[{\"MoodLevel\":3,\"RecordedAt\":\"2020-01-02T03:04:05Z\"}]}")]
    [InlineData("{\"FormatVersion\": 99}")]
    [InlineData("{\"FormatVersion\": 0}")]
    public async Task Import_UnreadableOrUnsupportedFile_ThrowsBackupFormatException(string json)
    {
        await Assert.ThrowsAsync<BackupFormatException>(() => _target.GetRequiredService<IBackupService>().ImportAsync(json));
    }

    [Fact]
    public async Task Import_OlderRiskAssessment_NeverReplacesANewerOne()
    {
        IClinicalCareRepository clinical = _target.GetRequiredService<IClinicalCareRepository>();
        await clinical.SaveRiskAssessmentAsync(new RiskAssessmentDTO { AssessedAt = DateTime.UtcNow, Source = "manual", RiskLevel = PsychologyApp.Domain.ClinicalCare.RiskLevel.Green });
        AppBackupDTO backup = new()
        {
            LatestRiskAssessment = new RiskAssessmentDTO { AssessedAt = LongAgo, Source = "manual", RiskLevel = PsychologyApp.Domain.ClinicalCare.RiskLevel.Red }
        };

        await _target.GetRequiredService<IBackupService>().ImportAsync(JsonSerializer.Serialize(backup, BackupJsonContext.Default.AppBackupDTO));

        RiskAssessmentDTO? latest = await clinical.GetLatestRiskAssessmentAsync();
        Assert.Equal(PsychologyApp.Domain.ClinicalCare.RiskLevel.Green, latest?.RiskLevel);
    }

    public async Task DisposeAsync()
    {
        await _sourceFactory.DisposeAsync();
        await _targetFactory.DisposeAsync();
        await _source.DisposeAsync();
        await _target.DisposeAsync();
    }
}
