using Awen.Core.WorkflowDefinition;
using Awen.Core.WorkflowDynamic;
using Awen.Dispatcher.Repositories;

namespace Awen.Dispatcher;

public class WorkflowDispatcher (
    IWorkflowRepository workflowRepository,
    IWfEntityStateRepository wfEntityStateRepository
)
{
    public async Task StartEntityOnWorkflow(Guid entityId, Guid workflowId, CancellationToken cancellationToken = default)
    {
        var workflow = await workflowRepository.GetAsync(workflowId, cancellationToken)
            ?? throw new Exception("Workflow not found");
        
        var initWfActivity = workflow.Activities?.FirstOrDefault(x => x.Type == WfActivityType.Init)
            ?? throw new Exception("Worklow has no Init WfActivity");
        
        var wfEntityState = new WfEntityState(entityId, initWfActivity);

        await wfEntityStateRepository.AddAsync(wfEntityState, cancellationToken);
    }
}
