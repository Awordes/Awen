using System.Collections.Concurrent;
using Awen.Core.WorkflowDefinition;

namespace Awen.Repository.InMemory;

internal class WorkflowStorage
{
    public ConcurrentDictionary<Guid, Workflow> Workflows = [];
}
