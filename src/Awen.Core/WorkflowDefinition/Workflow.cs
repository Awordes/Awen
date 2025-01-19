namespace Awen.Core.WorkflowDefinition;

public class Workflow
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; } = DateTime.Now;

    public WfActivity[]? Activities { get; set; }
}
