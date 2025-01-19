using System.Reflection;
using Awen.Core.ActionDefinition;
using Microsoft.Extensions.DependencyInjection;

namespace Awen.DependencyInjection;

public static class DependencyInjection
{
    private record ActionRecord(Type ActionType, Type ExecutionType, Type ExecutionInterface);

    public static IServiceCollection AddWorkflow(this IServiceCollection services, params Assembly[] assemblies)
    {
        var actions = new Dictionary<string, ActionRecord>();
        
        var actionTypes = assemblies
            .SelectMany(x => x.GetTypes())
            .Where(x => x
                .GetInterfaces()
                .Any(y => y.IsGenericType
                    && y.GetGenericTypeDefinition() == typeof(IWfAction<>)))
            .ToArray();

        foreach (var actionType in actionTypes)
        {
            var executorType = assemblies
                .SelectMany(x => x.GetTypes())
                .FirstOrDefault(x => x
                    .GetInterfaces()
                    .Any(y => y.IsGenericType
                        && y.GetGenericTypeDefinition() == typeof(IWfActionExecutor<,>))
                    && x.GetInterface(typeof(IWfActionExecutor<,>).Name)?.GetGenericArguments()[0] == actionType
                    && x.GetInterface(typeof(IWfActionExecutor<,>).Name)?.GetGenericArguments()[1]
                        == actionType?.GetInterface(typeof(IWfAction<>).Name)?.GetGenericArguments()[0]);

            if (executorType is not null)
            {
                var executorInterface = executorType
                    .GetInterfaces()
                    .First(y => y.IsGenericType
                        && y.GetGenericTypeDefinition() == typeof(IWfActionExecutor<,>));
            
                actions.Add(actionType.Name, new ActionRecord(actionType, executorType, executorInterface));
            }
        }

        var actionExecutorBase = typeof(IWfActionExecutor<,>);

        foreach (var actionType in actionTypes)
        {
            var actionInterface = actionType
                .GetInterfaces()
                .FirstOrDefault(x => x.GetTypeInfo().IsGenericType
                    && x.GetGenericTypeDefinition() == actionExecutorBase);
            
            if (actionInterface is not null)
                services.AddTransient(actionInterface, actionType);
        }

        return services;
    }
}
