using Microsoft.Extensions.DependencyInjection;
using PsychologyApp.Application.Configuration;
using PsychologyApp.Application.DependencyInjection;
using PsychologyApp.Application.Practice;
using PsychologyApp.Application.Conversation.Companion;
using PsychologyApp.Infrastructure.DependencyInjection;
using PsychologyApp.Infrastructure.LocalModel;

namespace PsychologyApp.Bootstrap;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPsychologyAppLocalModelInstaller(
        this IServiceCollection services,
        LocalModelManifest manifest,
        string targetDirectory)
    {
        services.AddSingleton<ILocalModelInstaller>(_ => new HttpLocalModelInstaller(
            new HttpClient { Timeout = Timeout.InfiniteTimeSpan }, manifest, targetDirectory));
        return services;
    }

    public static IServiceCollection AddPsychologyAppCore(
        this IServiceCollection services,
        Action<AppSettings>? configureSettings = null)
    {
        services.AddPsychologyAppInfrastructure(configureSettings);
        services.AddPsychologyAppApplication();
        services.AddSingleton<BuiltInTechniqueCatalogProvider>();
        services.AddCachedTechniqueCatalogProvider();
        return services;
    }
}
