using Microsoft.Extensions.DependencyInjection;

namespace Notes.Persistence;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddRepositories(this IServiceCollection services) =>
        services.AddSingleton<INotesRepository, InMemoryNotesRepository>();
}
