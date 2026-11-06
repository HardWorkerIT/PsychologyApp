using PsychologyApp.Application.Body;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.Models;
using PsychologyApp.Domain.Exposure;

namespace PsychologyApp.Application.DataBackup;

public sealed class AppBackupDTO
{
    /// <summary>2 added chat memory, favourite quotes, custom techniques, the risk check, the therapy program and escalations.</summary>
    public const int CurrentFormatVersion = 2;

    public const int OldestSupportedFormatVersion = 1;

    public int FormatVersion { get; init; } = CurrentFormatVersion;
    public DateTime ExportedAtUtc { get; init; }
    public IReadOnlyList<MoodEntryDTO> MoodEntries { get; init; } = [];
    public IReadOnlyList<TestResultDTO> TestResults { get; init; } = [];
    public IReadOnlyList<CompletionDTO> Completions { get; init; } = [];
    public IReadOnlyList<SessionResultDTO> SessionResults { get; init; } = [];
    public IReadOnlyList<BackupChatSessionDTO> ChatSessions { get; init; } = [];
    public SafetyPlanDTO? SafetyPlan { get; init; }

    // Format version 2.
    public IReadOnlyDictionary<string, string> ChatMemory { get; init; } = new Dictionary<string, string>();
    public IReadOnlyList<string> FavoriteQuoteTexts { get; init; } = [];
    public IReadOnlyList<BackupTechniqueDTO> Techniques { get; init; } = [];
    public RiskAssessmentDTO? LatestRiskAssessment { get; init; }
    public TherapyProgramStateDTO? TherapyProgram { get; init; }
    public IReadOnlyList<EscalationEventDTO> Escalations { get; init; } = [];

    // Optional, so the format stays 2: older versions of the app skip it and still read the rest.
    public ExposurePlan? ExposurePlan { get; init; }
    public PsychologyApp.Application.Articles.ReadingState? Reading { get; init; }
    public BodyLog? Body { get; init; }
}

public sealed class BackupChatSessionDTO
{
    public BackupChatSessionInfoDTO Session { get; init; } = new();
    public IReadOnlyList<ChatMessageDTO> Messages { get; init; } = [];
}

/// <summary>Persisted chat fields only; preview and counts are derived from messages and do not belong in a backup.</summary>
public sealed class BackupChatSessionInfoDTO
{
    public long Id { get; init; }
    public string? BackupKey { get; init; }
    public string Title { get; init; } = string.Empty;
    public DateTime CreatedAt { get; init; }
    public DateTime UpdatedAt { get; init; }
    public string? Emotion { get; init; }
    public string? Theme { get; init; }
    public int? FirstIntensity { get; init; }
    public int? LastIntensity { get; init; }
    public string? StateJson { get; init; }
}

/// <summary>Counts and UTF-8 payload size used to reject incomplete or oversized exports before loading their rows.</summary>
public sealed class BackupExportMetrics
{
    public long MoodEntryCount { get; set; }
    public long TestResultCount { get; set; }
    public long CompletionCount { get; set; }
    public long SessionResultCount { get; set; }
    public long TechniqueCount { get; set; }
    public long EscalationCount { get; set; }
    public long Utf8PayloadBytes { get; set; }
}

/// <summary>A technique the person built in the designer (built-in techniques ship with the app and are not part of a backup).</summary>
public sealed class BackupTechniqueDTO
{
    public string Number { get; init; } = string.Empty;
    public string Date { get; init; } = string.Empty;
    public string Header { get; init; } = string.Empty;
    public string Description { get; init; } = string.Empty;
    public string Subject { get; init; } = string.Empty;
    public string Author { get; init; } = string.Empty;
    public string Algorithm { get; init; } = string.Empty;
    public string? Image { get; init; }
    public bool IsCompleted { get; init; }
}

/// <summary>Rows actually added. Rows the database already had (same moment, same content) are counted in <see cref="SkippedDuplicates"/>.</summary>
public sealed record BackupImportResult(
    int MoodEntries,
    int TestResults,
    int Completions,
    int SessionResults,
    int ChatSessions,
    bool SafetyPlanImported,
    int Techniques = 0,
    int SkippedDuplicates = 0);
