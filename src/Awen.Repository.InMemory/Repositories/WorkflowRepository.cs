using System;
using Awen.Core.WorkflowDefinition;
using Awen.Dispatcher.Repositories;

namespace Awen.Repository.InMemory.Repositories;

internal class WorkflowRepository(WorkflowStorage workflowStorage) : IWorkflowRepository
{
    public Task AddAsync(Workflow entity, CancellationToken cancellationToken)
    {
        if (!workflowStorage.Workflows.TryAdd(entity.Id, entity))
            throw new Exception($"Error inserting {nameof(Workflow)} entity into storage");

        return Task.CompletedTask;
    }

    public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!workflowStorage.Workflows.TryRemove(id, out _))
            throw new Exception($"Error deleting {nameof(Workflow)} entity from storage");

        return Task.CompletedTask;
    }

    public Task<Workflow> GetAsync(Guid id, CancellationToken cancellationToken)
    {
        if (!workflowStorage.Workflows.TryGetValue(id, out var workflow))
            throw new Exception($"Error getting {nameof(Workflow)} entity from storage");
        
        return Task.FromResult<Workflow>(workflow);
    }

    public Task UpdateAsync(Workflow entity, CancellationToken cancellationToken)
    {
        if (!workflowStorage.Workflows.TryGetValue(entity.Id, out var workflow))
            throw new Exception($"Error getting {nameof(Workflow)} entity from storage");

        workflow = entity;

        return Task.CompletedTask;
    }
}
