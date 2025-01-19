namespace Awen.Core.WorkflowDynamic;

public class WfEntityStateChange
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; } = DateTime.Now;

    public object? ActionData { get; set; }
}
