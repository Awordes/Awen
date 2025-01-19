namespace Awen.Core.WorkflowDefinition;

public class WfActivity(Workflow workflow, WfActivityType wfActivityType, WfActivityState? state = null)
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Workflow Workflow { get; set; } = workflow;

    public WfActivityType Type { get; set; } = wfActivityType;

    public WfActivityState? State { get; set; } = state;

    public WfAction[]? Actions { get; set; }
}
