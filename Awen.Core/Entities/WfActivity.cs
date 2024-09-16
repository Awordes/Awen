using Awen.Core.Abstracts;

namespace Awen.Core.Entities;

public class WfActivity(Workflow workflow, WfActivityType wfActivityType) : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Workflow Workflow { get; set; } = workflow;

    public WfActivityType Type { get; set; } = wfActivityType;
}
