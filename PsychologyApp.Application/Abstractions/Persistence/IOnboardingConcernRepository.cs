namespace PsychologyApp.Application.Abstractions.Persistence;

/// <summary>The onboarding topic used to tailor local recommendations, kept in the encrypted database.</summary>
public interface IOnboardingConcernRepository
{
    Task<string?> GetAsync(CancellationToken cancellationToken = default);

    Task SaveAsync(string concern, CancellationToken cancellationToken = default);
}
