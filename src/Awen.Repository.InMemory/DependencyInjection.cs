using Awen.Dispatcher.Repositories;
using Awen.Repository.InMemory.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Awen.Repository.InMemory;

public static class DependencyInjection
{
    public static IServiceCollection AddInMemoryAwenRepository(this IServiceCollection services)
    {
        services.AddSingleton<WorkflowStorage>();
        services.AddTransient<IWorkflowRepository, WorkflowRepository>();

        return services;
    }
}
