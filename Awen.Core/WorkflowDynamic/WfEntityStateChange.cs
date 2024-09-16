using Awen.Core.Abstracts;

namespace Awen.Core.WorkflowDynamic;

internal class WfEntityStateChange : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public DateTime Created { get; set; } = DateTime.Now;

    public object? ActionData { get; set; }
}
