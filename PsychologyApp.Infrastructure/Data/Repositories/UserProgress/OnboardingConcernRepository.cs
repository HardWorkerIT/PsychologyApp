using Microsoft.Extensions.Options;
using PsychologyApp.Application.Abstractions.Persistence;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Infrastructure.Data.Repositories.Base;
using System.Text.Json.Serialization;

namespace PsychologyApp.Infrastructure.Data.Repositories.UserProgress;

/// <summary>The selected onboarding topic is personal data, so it stays in encrypted AppMetadata rather than Preferences.</summary>
internal sealed class OnboardingConcernRepository(IDbConnectionFactory connectionFactory, IOptions<AppSettings> settings)
    : AppMetadataDocumentRepository<OnboardingConcernDocument>(
        connectionFactory,
        settings,
        MetadataKey,
        OnboardingConcernJsonContext.Default.OnboardingConcernDocument), IOnboardingConcernRepository
{
    public const string MetadataKey = "OnboardingConcern";

    public async Task<string?> GetAsync(CancellationToken cancellationToken = default)
    {
        OnboardingConcernDocument? document = await ReadAsync(cancellationToken).ConfigureAwait(false);
        return document?.Concern;
    }

    public Task SaveAsync(string concern, CancellationToken cancellationToken = default) =>
        WriteAsync(new OnboardingConcernDocument(concern), cancellationToken);
}

internal sealed record OnboardingConcernDocument(string Concern);

/// <summary>Source-generated so the document survives trimming and AOT in release builds.</summary>
[JsonSerializable(typeof(OnboardingConcernDocument))]
internal sealed partial class OnboardingConcernJsonContext : JsonSerializerContext;
