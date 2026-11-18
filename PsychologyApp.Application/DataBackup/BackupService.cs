using System.Buffers;
using System.Text;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Articles;
using PsychologyApp.Application.Body;
using PsychologyApp.Application.Chat;
using PsychologyApp.Application.ClinicalCare;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Application.Exposure;
using PsychologyApp.Application.Models;
using PsychologyApp.Application.UserProgress;
using PsychologyApp.Domain.Exposure;
using System.Text.Json;

namespace PsychologyApp.Application.DataBackup;

public sealed class BackupService(
    IUserProgressRepository progress,
    IChatRepository chatRepository,
    IClinicalCareRepository clinicalCareRepository,
    IFavoriteQuoteTextStore favoriteQuoteTextStore,
    IBackupRepository backupRepository,
    IExposureRepository exposureRepository,
    IReadingRepository readingRepository,
    IBodyRepository bodyRepository) : IBackupService
{
    private const int ExportLimit = 100_000;
    private const int ExportProbeLimit = ExportLimit + 1;

    /// <summary>A real backup is a few MB; this only stops a wrong file (a video, a database) from being read into memory.</summary>
    internal const int MaxImportCharacters = 64 * 1024 * 1024;

    /// <summary>
    /// Caps the picked file before reading it. It also bounds the largest UTF-8 text that can be loaded into memory; accepting
    /// three times this many bytes lets an ASCII file exceed the character limit before the parser can reject it.
    /// </summary>
    public const long MaxImportFileBytes = MaxImportCharacters;

    private const int MaxEscalations = 1_000;

    public async Task<string> ExportAsync(CancellationToken cancellationToken = default)
    {
        BackupExportMetrics exportMetrics = await backupRepository.GetExportMetricsAsync(cancellationToken).ConfigureAwait(false);
        if (exportMetrics.MoodEntryCount > ExportLimit
            || exportMetrics.TestResultCount > ExportLimit
            || exportMetrics.CompletionCount > ExportLimit
            || exportMetrics.SessionResultCount > ExportLimit
            || exportMetrics.TechniqueCount > ExportLimit
            || exportMetrics.EscalationCount > MaxEscalations
            || exportMetrics.Utf8PayloadBytes > MaxImportFileBytes)
        {
            throw new BackupFormatException("The saved data is too large to export and restore on this device.");
        }

        ChatExportMetrics chatMetrics = await chatRepository.GetExportMetricsAsync(cancellationToken).ConfigureAwait(false);
        if (chatMetrics.SessionCount > ExportLimit
            || chatMetrics.MessageCount > ExportLimit
            || chatMetrics.MemoryCount > ExportLimit
            || chatMetrics.Utf8PayloadBytes > MaxImportFileBytes)
        {
            throw new BackupFormatException("The chat history is too large to export and restore on this device.");
        }

        IReadOnlyList<MoodEntryDTO> moods = await progress.GetMoodsAsync(null, null, ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<TestResultDTO> testResults = await progress.GetAllTestResultsAsync(ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<CompletionDTO> completions = await progress.GetRecentTechniqueCompletionsAsync(ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<SessionResultDTO> sessionResults = await progress.GetRecentSessionResultsAsync(ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<BackupTechniqueDTO> techniques = await backupRepository.GetTechniquesAsync(ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<EscalationEventDTO> escalations = await clinicalCareRepository.GetRecentEscalationsAsync(MaxEscalations + 1, cancellationToken).ConfigureAwait(false);

        if (moods.Count > ExportLimit
            || testResults.Count > ExportLimit
            || completions.Count > ExportLimit
            || sessionResults.Count > ExportLimit
            || techniques.Count > ExportLimit
            || escalations.Count > MaxEscalations)
        {
            throw new BackupFormatException("The saved data is too large to export and restore on this device.");
        }

        SafetyPlanDTO? safetyPlan = await clinicalCareRepository.GetSafetyPlanAsync(cancellationToken).ConfigureAwait(false);
        ChatExportSnapshot chatSnapshot = await chatRepository.GetExportSnapshotAsync(ExportProbeLimit, cancellationToken).ConfigureAwait(false);
        IReadOnlyList<ChatSessionDTO> sessions = chatSnapshot.Sessions;
        IReadOnlyList<ChatMessageDTO> exportMessages = chatSnapshot.Messages;
        IReadOnlyDictionary<string, string> chatMemory = chatSnapshot.Memory;
        if (sessions.Count > ExportLimit || exportMessages.Count > ExportLimit || chatMemory.Count > ExportLimit)
        {
            throw new BackupFormatException("The chat history is too large to export and restore on this device.");
        }

        Dictionary<long, List<ChatMessageDTO>> messagesBySession = new();
        foreach (ChatMessageDTO message in exportMessages)
        {
            if (!messagesBySession.TryGetValue(message.SessionId, out List<ChatMessageDTO>? sessionMessages))
            {
                sessionMessages = [];
                messagesBySession.Add(message.SessionId, sessionMessages);
            }

            sessionMessages.Add(message);
        }

        List<BackupChatSessionDTO> chatSessions = new(sessions.Count);
        foreach (ChatSessionDTO session in sessions)
        {
            messagesBySession.Remove(session.Id, out List<ChatMessageDTO>? messages);
            chatSessions.Add(new BackupChatSessionDTO
            {
                Session = new BackupChatSessionInfoDTO
                {
                    Id = session.Id,
                    Title = session.Title,
                    CreatedAt = session.CreatedAt,
                    UpdatedAt = session.UpdatedAt,
                    Emotion = session.Emotion,
                    Theme = session.Theme,
                    FirstIntensity = session.FirstIntensity,
                    LastIntensity = session.LastIntensity,
                    StateJson = session.StateJson,
                    BackupKey = session.BackupKey
                },
                Messages = messages is null ? Array.Empty<ChatMessageDTO>() : messages
            });
        }
        messagesBySession.Clear();
        exportMessages = Array.Empty<ChatMessageDTO>();
        sessions = Array.Empty<ChatSessionDTO>();

        IReadOnlySet<string> favourites = await favoriteQuoteTextStore.GetTextsAsync(cancellationToken).ConfigureAwait(false);
        if (favourites.Count > ExportLimit)
        {
            throw new BackupFormatException("The saved data is too large to export and restore on this device.");
        }

        AppBackupDTO backup = new()
        {
            ExportedAtUtc = DateTime.UtcNow,
            MoodEntries = moods,
            TestResults = testResults,
            Completions = completions,
            SessionResults = sessionResults,
            ChatSessions = chatSessions,
            SafetyPlan = safetyPlan is null || safetyPlan.IsEmpty ? null : safetyPlan,
            ChatMemory = chatMemory,
            FavoriteQuoteTexts = favourites.OrderBy(text => text, StringComparer.Ordinal).ToList(),
            Techniques = techniques,
            LatestRiskAssessment = await clinicalCareRepository.GetLatestRiskAssessmentAsync(cancellationToken).ConfigureAwait(false),
            TherapyProgram = await clinicalCareRepository.GetActiveProgramAsync(cancellationToken).ConfigureAwait(false),
            Escalations = escalations,
            ExposurePlan = await exposureRepository.GetAsync(cancellationToken).ConfigureAwait(false),
            Reading = await readingRepository.GetAsync(cancellationToken).ConfigureAwait(false),
            Body = await bodyRepository.GetAsync(cancellationToken).ConfigureAwait(false),
            SavedNextStep = SavedNextStepCollection.Serialize(
                await progress.GetSavedNextStepsAsync(cancellationToken).ConfigureAwait(false))
        };

        BoundedBackupBufferWriter output = new(MaxImportCharacters);
        using Utf8JsonWriter jsonWriter = new(output);
        JsonSerializer.Serialize(jsonWriter, backup, BackupJsonContext.Default.AppBackupDTO);
        jsonWriter.Flush();
        return Encoding.UTF8.GetString(output.WrittenSpan);
    }

    public async Task<string> ExportEncryptedAsync(string passphrase, CancellationToken cancellationToken = default)
    {
        string plain = await ExportAsync(cancellationToken).ConfigureAwait(false);
        int plaintextByteCount = Encoding.UTF8.GetByteCount(plain);
        if (BackupEncryption.GetEncryptedFileLength(plaintextByteCount) > MaxImportFileBytes)
        {
            throw new BackupFormatException("The protected backup is too large to import on this device.");
        }

        // PBKDF2 with a high iteration count takes a moment: off the caller thread.
        string encrypted = await Task.Run(() => BackupEncryption.Encrypt(plain, passphrase), cancellationToken).ConfigureAwait(false);
        if (System.Text.Encoding.UTF8.GetByteCount(encrypted) > MaxImportFileBytes)
        {
            throw new BackupFormatException("The protected backup is too large to import on this device.");
        }

        return encrypted;
    }

    public async Task<BackupImportResult> ImportEncryptedAsync(string file, string passphrase, CancellationToken cancellationToken = default)
    {
        if (file.Length > MaxImportCharacters)
        {
            throw new BackupFormatException("The file is too large to be a backup.");
        }

        string plain = await Task.Run(() => BackupEncryption.Decrypt(file, passphrase), cancellationToken).ConfigureAwait(false);
        return await ImportAsync(plain, cancellationToken).ConfigureAwait(false);
    }

    public bool IsEncrypted(string file) =>
        !string.IsNullOrEmpty(file)
        && file.Length <= MaxImportCharacters
        && BackupEncryption.IsEncrypted(file);

    private sealed class BoundedBackupBufferWriter(int maximumBytes) : IBufferWriter<byte>
    {
        private byte[] _buffer = new byte[Math.Min(4096, maximumBytes)];
        private int _written;

        public ReadOnlySpan<byte> WrittenSpan => _buffer.AsSpan(0, _written);

        public void Advance(int count)
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if ((long)_written + count > maximumBytes)
            {
                throw TooLarge();
            }

            if (count > _buffer.Length - _written)
            {
                throw new ArgumentException("The buffer was advanced beyond the available memory.", nameof(count));
            }

            _written += count;
        }

        public Memory<byte> GetMemory(int sizeHint = 0)
        {
            EnsureAvailable(sizeHint);
            return _buffer.AsMemory(_written);
        }

        public Span<byte> GetSpan(int sizeHint = 0)
        {
            EnsureAvailable(sizeHint);
            return _buffer.AsSpan(_written);
        }

        private void EnsureAvailable(int sizeHint)
        {
            if (sizeHint < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(sizeHint));
            }

            int requiredSize = Math.Max(sizeHint, 1);
            if ((long)_written + requiredSize > maximumBytes)
            {
                throw TooLarge();
            }

            int requiredCapacity = _written + requiredSize;
            if (requiredCapacity <= _buffer.Length)
            {
                return;
            }

            int doubledCapacity = _buffer.Length <= maximumBytes / 2 ? _buffer.Length * 2 : maximumBytes;
            Array.Resize(ref _buffer, Math.Max(requiredCapacity, doubledCapacity));
        }

        private static BackupFormatException TooLarge() =>
            new("The backup is too large to export and restore on this device.");
    }

    public async Task<BackupImportResult> ImportAsync(string json, CancellationToken cancellationToken = default)
    {
        AppBackupDTO backup = await Task.Run(() => ParseImport(json), cancellationToken).ConfigureAwait(false);
        AppBackupDTO clean = Sanitize(backup);
        int sourceRows = clean.MoodEntries.Count + clean.TestResults.Count + clean.Completions.Count
            + clean.SessionResults.Count + clean.Techniques.Count
            + clean.ChatSessions.Sum(chat => chat.Messages.Count + 1);
        BackupImportResult result = await backupRepository.ImportAsync(clean, cancellationToken).ConfigureAwait(false);

        int added = result.MoodEntries + result.TestResults + result.Completions + result.SessionResults
            + result.ChatSessions + result.Techniques + result.ChatMessages;
        return result with
        {
            SkippedDuplicates = Math.Max(0, sourceRows - added)
        };
    }

    private static AppBackupDTO ParseImport(string json)
    {
        // Check before probing the JSON envelope, so direct callers cannot make detection parse an oversized payload.
        if (json.Length > MaxImportCharacters)
        {
            throw new BackupFormatException("The file is too large to be a backup.");
        }

        if (BackupEncryption.IsEncrypted(json))
        {
            throw new BackupPassphraseException("A passphrase is needed to open this backup.");
        }

        return Parse(json);
    }

    private static AppBackupDTO Parse(string json)
    {
        if (string.IsNullOrWhiteSpace(json))
        {
            throw new BackupFormatException("The backup file is empty.");
        }

        if (json.Length > MaxImportCharacters)
        {
            throw new BackupFormatException("The file is too large to be a backup.");
        }

        AppBackupDTO? backup;
        try
        {
            backup = JsonSerializer.Deserialize(json, BackupJsonContext.Default.AppBackupDTO);
        }
        catch (JsonException ex)
        {
            throw new BackupFormatException("The file is not a valid backup.", ex);
        }

        if (backup is null)
        {
            throw new BackupFormatException("The backup file could not be read.");
        }

        if (backup.FormatVersion is < AppBackupDTO.OldestSupportedFormatVersion or > AppBackupDTO.CurrentFormatVersion)
        {
            throw new BackupFormatException(
                $"The backup format {backup.FormatVersion} is not supported (this version reads {AppBackupDTO.OldestSupportedFormatVersion}-{AppBackupDTO.CurrentFormatVersion}).");
        }

        ValidateRequiredData(backup);
        ValidateImportLimits(backup);
        return backup;
    }

    private static void ValidateImportLimits(AppBackupDTO backup)
    {
        if (backup.MoodEntries.Count > ExportLimit
            || backup.TestResults.Count > ExportLimit
            || backup.Completions.Count > ExportLimit
            || backup.SessionResults.Count > ExportLimit
            || backup.ChatSessions.Count > ExportLimit
            || backup.Techniques.Count > ExportLimit
            || backup.ChatMemory.Count > ExportLimit
            || backup.Escalations.Count > MaxEscalations
            || backup.FavoriteQuoteTexts.Count > ExportLimit)
        {
            throw new BackupFormatException("The saved data is too large to import and restore on this device.");
        }

        long messageCount = 0;
        foreach (BackupChatSessionDTO session in backup.ChatSessions)
        {
            messageCount += session.Messages.Count;
            if (messageCount > ExportLimit)
            {
                throw new BackupFormatException("The chat history is too large to import and restore on this device.");
            }
        }
    }

    // Nullable annotations do not reject explicit JSON nulls or null array elements.
    // Reject damaged required data before any repository can persist it.
    private static void ValidateRequiredData(AppBackupDTO backup)
    {
        RequireItems(backup.MoodEntries);
        RequireItems(backup.TestResults);
        RequireItems(backup.Completions);
        RequireItems(backup.SessionResults);
        RequireItems(backup.ChatSessions);
        RequireItems(backup.Techniques);
        RequireItems(backup.Escalations);
        RequireItems(backup.FavoriteQuoteTexts);
        if (backup.ChatMemory is null)
        {
            throw new BackupFormatException("The backup contains missing required data.");
        }
        foreach (BackupChatSessionDTO chat in backup.ChatSessions)
        {
            if (chat.Session is null)
            {
                throw new BackupFormatException("The backup contains a missing chat session.");
            }

            if (chat.Session.BackupKey is { Length: > 128 })
            {
                throw new BackupFormatException("The backup contains an invalid chat session key.");
            }

            RequireItems(chat.Messages);
        }
        if (backup.ChatSessions.Where(chat => !string.IsNullOrWhiteSpace(chat.Session.BackupKey))
            .GroupBy(chat => chat.Session.BackupKey!, StringComparer.Ordinal)
            .Any(group => group.Count() > 1))
        {
            throw new BackupFormatException("The backup contains duplicate chat sessions.");
        }
        if (backup.ChatSessions.Where(chat => string.IsNullOrWhiteSpace(chat.Session.BackupKey))
            .GroupBy(chat => (chat.Session.Id, chat.Session.CreatedAt))
            .Any(group => group.Count() > 1))
        {
            throw new BackupFormatException("The backup contains ambiguous legacy chat sessions.");
        }
        if (backup.SafetyPlan is { } plan)
        {
            RequireItems(plan.WarningSigns);
            RequireItems(plan.CopingStrategies);
            RequireItems(plan.Reasons);
            RequireItems(plan.Contacts);
            if (plan.Contacts.Any(contact => contact.Name is null || contact.Phone is null))
            {
                throw new BackupFormatException("The backup contains an invalid safety plan contact.");
            }
        }
    }

    private static void RequireItems<T>(IReadOnlyList<T>? items)
    {
        if (items is null || items.Any(item => item is null))
        {
            throw new BackupFormatException("The backup contains missing required data.");
        }
    }

    /// <summary>Drops rows a hand-edited or damaged file could not have come from the app with (no key, no date, impossible role).</summary>
    private static AppBackupDTO Sanitize(AppBackupDTO backup)
    {
        DateTime nowUtc = DateTime.UtcNow;
        return new AppBackupDTO
        {
            FormatVersion = backup.FormatVersion,
            ExportedAtUtc = backup.ExportedAtUtc,
            MoodEntries = backup.MoodEntries.Where(m => m.RecordedAt != default).ToList(),
            TestResults = backup.TestResults.Where(t => !string.IsNullOrWhiteSpace(t.TestId) && t.CompletedAt != default).ToList(),
            Completions = backup.Completions.Where(c => !string.IsNullOrWhiteSpace(c.ItemKey) && c.CompletedAt != default).ToList(),
            SessionResults = backup.SessionResults.Where(s => !string.IsNullOrWhiteSpace(s.ItemKey) && s.CompletedAt != default).ToList(),
            ChatSessions = backup.ChatSessions
                .Select(chat => new BackupChatSessionDTO
                {
                    Session = SanitizeChatSession(chat.Session),
                    Messages = chat.Messages.Where(m => Enum.IsDefined(m.Role) && m.CreatedAt != default).ToList()
                })
                .Where(chat => chat.Session.CreatedAt != default)
                .ToList(),
            SafetyPlan = SanitizeSafetyPlan(backup.SafetyPlan, nowUtc),
            ChatMemory = backup.ChatMemory
                .Where(pair => !string.IsNullOrWhiteSpace(pair.Key) && pair.Value is not null)
                .ToDictionary(pair => pair.Key, pair => pair.Value, StringComparer.Ordinal),
            FavoriteQuoteTexts = backup.FavoriteQuoteTexts.Where(text => !string.IsNullOrWhiteSpace(text)).ToList(),
            Techniques = backup.Techniques
                .Where(t => !string.IsNullOrWhiteSpace(t.Header) && !string.IsNullOrWhiteSpace(t.Algorithm))
                .ToList(),
            LatestRiskAssessment = SanitizeRiskAssessment(backup.LatestRiskAssessment, nowUtc),
            TherapyProgram = SanitizeTherapyProgram(backup.TherapyProgram, nowUtc),
            Escalations = SanitizeEscalations(backup.Escalations, nowUtc),
            ExposurePlan = SanitizeExposurePlan(backup.ExposurePlan),
            Reading = SanitizeReading(backup.Reading),
            Body = BodyService.Sanitize(backup.Body),
            SavedNextStep = SavedNextStepCollection.Serialize(SavedNextStepCollection.Parse(backup.SavedNextStep))
        };
    }

    private static SafetyPlanDTO? SanitizeSafetyPlan(SafetyPlanDTO? plan, DateTime nowUtc)
    {
        if (plan is null)
        {
            return null;
        }

        DateTime? updatedAtUtc = plan.UpdatedAt is { } updatedAt && updatedAt != default
            ? NormalizeUtc(updatedAt)
            : null;
        if (updatedAtUtc > nowUtc)
        {
            // An untrusted future timestamp must not make this backup replace a newer local safety plan.
            updatedAtUtc = null;
        }

        return new SafetyPlanDTO
        {
            WarningSigns = plan.WarningSigns,
            CopingStrategies = plan.CopingStrategies,
            Contacts = plan.Contacts,
            Reasons = plan.Reasons,
            UpdatedAt = updatedAtUtc
        };
    }

    private static RiskAssessmentDTO? SanitizeRiskAssessment(RiskAssessmentDTO? assessment, DateTime nowUtc)
    {
        if (assessment is null
            || assessment.AssessedAt == default
            || !Enum.IsDefined(assessment.RiskLevel))
        {
            return null;
        }

        DateTime assessedAtUtc = NormalizeUtc(assessment.AssessedAt);
        if (assessedAtUtc > nowUtc)
        {
            return null;
        }

        return new RiskAssessmentDTO
        {
            AssessedAt = assessedAtUtc,
            Source = assessment.Source ?? string.Empty,
            Notes = assessment.Notes ?? string.Empty,
            HasSelfHarmThoughts = assessment.HasSelfHarmThoughts,
            HasSevereDisorientation = assessment.HasSevereDisorientation,
            HasSubstanceRisk = assessment.HasSubstanceRisk,
            HasSevereInsomnia = assessment.HasSevereInsomnia,
            RiskLevel = assessment.RiskLevel
        };
    }

    private static IReadOnlyList<EscalationEventDTO> SanitizeEscalations(
        IReadOnlyList<EscalationEventDTO> events,
        DateTime nowUtc)
    {
        List<EscalationEventDTO> sanitized = [];
        foreach (EscalationEventDTO item in events)
        {
            if (item.CreatedAt == default || !Enum.IsDefined(item.RiskLevel))
            {
                continue;
            }

            DateTime createdAtUtc = NormalizeUtc(item.CreatedAt);
            if (createdAtUtc > nowUtc)
            {
                continue;
            }

            sanitized.Add(new EscalationEventDTO
            {
                CreatedAt = createdAtUtc,
                RiskLevel = item.RiskLevel,
                TriggerSource = item.TriggerSource ?? string.Empty,
                Action = item.Action ?? string.Empty,
                Notes = item.Notes ?? string.Empty
            });
        }

        return sanitized;
    }

    private static DateTime NormalizeUtc(DateTime value) => value.Kind == DateTimeKind.Unspecified
        ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
        : value.ToUniversalTime();

    private static TherapyProgramStateDTO? SanitizeTherapyProgram(TherapyProgramStateDTO? program, DateTime nowUtc)
    {
        if (program is null
            || !Enum.IsDefined(program.ProgramType)
            || program.StartedAt == default
            || program.CurrentWeek is < 1 or > TherapyProgramCatalog.TotalWeeks)
        {
            return null;
        }

        DateTime startedAtUtc = NormalizeUtc(program.StartedAt);
        if (startedAtUtc > nowUtc)
        {
            return null;
        }

        return new TherapyProgramStateDTO
        {
            ProgramType = program.ProgramType,
            StartedAt = startedAtUtc,
            CurrentWeek = program.CurrentWeek,
            IsActive = program.IsActive
        };
    }

    private static ReadingState? SanitizeReading(ReadingState? reading)
    {
        if (reading is null)
        {
            return null;
        }

        DateTime nowUtc = DateTime.UtcNow;

        HashSet<string> articleIds = ArticleContent.All("en")
            .Select(article => article.Id)
            .ToHashSet(StringComparer.Ordinal);
        IReadOnlyList<string> KeepKnownArticles(IEnumerable<string>? values) =>
            (values ?? [])
                .Where(value => !string.IsNullOrWhiteSpace(value) && articleIds.Contains(value))
                .Distinct(StringComparer.Ordinal)
                .ToArray();

        string? lastArticleId = reading.LastArticleId is { } articleId && articleIds.Contains(articleId)
            ? articleId
            : null;
        DateTime? lastOpenedUtc = reading.LastOpenedUtc is { } opened
            ? NormalizeUtc(opened)
            : null;
        if (lastArticleId is null || lastOpenedUtc is not { } validOpened || validOpened == default || validOpened > nowUtc)
        {
            lastOpenedUtc = null;
        }

        Dictionary<string, Course> coursesById = ArticleContent.Courses("en")
            .ToDictionary(course => course.Id, StringComparer.Ordinal);
        List<CourseProgress> sanitizedCourses = [];
        foreach (IGrouping<string, CourseProgress> courseGroup in (reading.Courses ?? [])
                     .OfType<CourseProgress>()
                     .Where(progress => !string.IsNullOrWhiteSpace(progress.CourseId)
                         && coursesById.ContainsKey(progress.CourseId))
                     .GroupBy(progress => progress.CourseId, StringComparer.Ordinal))
        {
            Course course = coursesById[courseGroup.Key];
            List<CourseDayRecord> candidates = courseGroup
                .SelectMany(progress => progress.Days ?? [])
                .OfType<CourseDayRecord>()
                .Select(record => record with { CompletedUtc = NormalizeUtc(record.CompletedUtc) })
                .Where(record => record.Day >= 1
                    && record.Day <= course.Days.Count
                    && record.CompletedUtc != default
                    && record.CompletedUtc <= nowUtc)
                .GroupBy(record => record.Day)
                .Select(day => day.OrderByDescending(record => record.CompletedUtc).First())
                .OrderBy(record => record.Day)
                .ToList();

            List<CourseDayRecord> days = [];
            foreach (CourseDayRecord candidate in candidates)
            {
                // Course days are sequential; a damaged gap must not unlock a later day or mark the course complete.
                if (candidate.Day != days.Count + 1)
                {
                    break;
                }

                string? reflection = string.IsNullOrWhiteSpace(candidate.Reflection)
                    ? null
                    : candidate.Reflection.Trim();
                if (reflection is { Length: > ReadingService.MaxReflection })
                {
                    reflection = reflection[..ReadingService.MaxReflection];
                }

                days.Add(candidate with { Reflection = reflection });
            }

            DateTime startedUtc = courseGroup
                .Select(progress => progress.StartedUtc)
                .Where(started => started != default)
                .Select(NormalizeUtc)
                .Where(started => started <= nowUtc)
                .DefaultIfEmpty(days.Count > 0 ? days[0].CompletedUtc : default)
                .Min();
            if (startedUtc == default)
            {
                continue;
            }

            DateTime? finishedUtc = null;
            if (days.Count > 0 && days.Count == course.Days.Count)
            {
                DateTime lastDayCompletedUtc = days[^1].CompletedUtc;
                finishedUtc = courseGroup
                    .Select(progress => progress.FinishedUtc.GetValueOrDefault())
                    .Where(finished => finished != default)
                    .Select(NormalizeUtc)
                    .Where(finished => finished >= lastDayCompletedUtc && finished <= nowUtc)
                    .DefaultIfEmpty(lastDayCompletedUtc)
                    .Max();
            }

            sanitizedCourses.Add(new CourseProgress(courseGroup.Key, startedUtc, days, finishedUtc));
        }

        return new ReadingState
        {
            Read = KeepKnownArticles(reading.Read),
            Saved = KeepKnownArticles(reading.Saved),
            LastArticleId = lastArticleId,
            LastOpenedUtc = lastOpenedUtc,
            Courses = sanitizedCourses
        };
    }

    private static ExposurePlan? SanitizeExposurePlan(ExposurePlan? plan)
    {
        if (plan is null)
        {
            return null;
        }

        DateTime nowUtc = DateTime.UtcNow;
        static DateTime NormalizeUtc(DateTime value) => value.Kind == DateTimeKind.Unspecified
            ? DateTime.SpecifyKind(value, DateTimeKind.Utc)
            : value.ToUniversalTime();
        static string CleanText(string? value, int maxLength)
        {
            string trimmed = (value ?? string.Empty).Trim();
            return trimmed.Length <= maxLength ? trimmed : trimmed[..maxLength].TrimEnd();
        }
        static string CleanId(string? value) => (value ?? string.Empty).Trim();
        static List<string> CleanList(IReadOnlyList<string>? values) => (values ?? [])
            .OfType<string>()
            .Select(value => CleanText(value, ExposureService.MaxStepText))
            .Where(value => value.Length > 0)
            .Distinct(StringComparer.OrdinalIgnoreCase)
            .ToList();

        List<ExposureStep> steps = (plan.Steps ?? [])
            .OfType<ExposureStep>()
            .Select(step => step with
            {
                Id = CleanId(step.Id),
                Text = CleanText(step.Text, ExposureService.MaxStepText),
                ExpectedDistress = Math.Clamp(step.ExpectedDistress, 0, 100)
            })
            .Where(step => step.Id.Length is > 0 and <= 128 && step.Text.Length > 0)
            .GroupBy(step => step.Id, StringComparer.Ordinal)
            .Select(group => group.First())
            .ToList();
        HashSet<string> stepIds = steps.Select(step => step.Id).ToHashSet(StringComparer.Ordinal);

        List<ExposureSession> sessions = (plan.Sessions ?? [])
            .OfType<ExposureSession>()
            .Select(session =>
            {
                DateTime createdAt = session.CreatedAt == default ? default : NormalizeUtc(session.CreatedAt);
                DateTime? reportedAt = session.ReportedAt is { } reported && reported != default
                    ? NormalizeUtc(reported)
                    : null;
                PredictionOutcome? outcome = session.Outcome is { } value && Enum.IsDefined(value) ? value : null;
                return session with
                {
                    Id = CleanId(session.Id),
                    StepId = CleanId(session.StepId),
                    CreatedAt = createdAt,
                    Prediction = CleanText(session.Prediction, ExposureService.MaxFreeText),
                    BeliefBefore = Math.Clamp(session.BeliefBefore, 0, 100),
                    DroppedSafetyBehaviours = CleanList(session.DroppedSafetyBehaviours),
                    ReportedAt = reportedAt is { } valueAt && valueAt >= createdAt && valueAt <= nowUtc ? valueAt : null,
                    WhatHappened = CleanText(session.WhatHappened, ExposureService.MaxFreeText),
                    Outcome = outcome,
                    BeliefAfter = session.BeliefAfter is { } belief ? Math.Clamp(belief, 0, 100) : null,
                    PeakDistress = session.PeakDistress is { } distress ? Math.Clamp(distress, 0, 100) : null,
                    Learned = CleanText(session.Learned, ExposureService.MaxFreeText),
                    Interrupted = session.Interrupted && outcome is null
                };
            })
            .Where(session => session.Id.Length > 0
                && session.Id.Length <= 128
                && session.StepId.Length > 0
                && session.StepId.Length <= 128
                && stepIds.Contains(session.StepId)
                && session.CreatedAt != default
                && session.CreatedAt <= nowUtc)
            .GroupBy(session => session.Id, StringComparer.Ordinal)
            .Select(group => group.First())
            .ToList();

        ExposureScreeningResult screening = Enum.IsDefined(plan.Screening)
            ? plan.Screening
            : ExposureScreeningResult.NotScreened;
        DateTime? screenedAt = plan.ScreenedAt is { } screened && screened != default
            ? NormalizeUtc(screened)
            : null;
        if (screenedAt is { } screeningTime && screeningTime > nowUtc)
        {
            screening = ExposureScreeningResult.NotScreened;
            screenedAt = null;
        }

        return plan with
        {
            Kind = Enum.IsDefined(plan.Kind) ? plan.Kind : FearKind.Other,
            FearedOutcome = CleanText(plan.FearedOutcome, ExposureService.MaxFreeText),
            FearedOutcomeBelief = Math.Clamp(plan.FearedOutcomeBelief, 0, 100),
            AvoidedSituations = CleanList(plan.AvoidedSituations),
            SafetyBehaviours = CleanList(plan.SafetyBehaviours),
            Steps = steps,
            Sessions = sessions,
            Screening = screening,
            ScreenedAt = screenedAt
        };
    }

    private static BackupChatSessionInfoDTO SanitizeChatSession(BackupChatSessionInfoDTO session) => new()
    {
        Id = session.Id,
        BackupKey = session.BackupKey,
        Title = session.Title,
        CreatedAt = session.CreatedAt,
        UpdatedAt = session.UpdatedAt,
        Emotion = DefinedEnumName<CompanionEmotion>(session.Emotion),
        Theme = DefinedEnumName<CompanionTheme>(session.Theme),
        FirstIntensity = Intensity(session.FirstIntensity),
        LastIntensity = Intensity(session.LastIntensity),
        StateJson = session.StateJson
    };

    private static string? DefinedEnumName<TEnum>(string? name) where TEnum : struct, Enum =>
        Enum.TryParse(name, out TEnum value) && Enum.IsDefined(value) ? value.ToString() : null;

    private static int? Intensity(int? value) => value is >= 0 and <= 10 ? value : null;
}
