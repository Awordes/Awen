using Awen.Core.Abstracts;

namespace Awen.Core.WorkflowDefinition;


internal class Workflow : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; } = DateTime.Now;

    public WfActivity[]? Activities { get; set; }
}
