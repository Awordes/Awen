using Awen.Core.Abstracts;
using Awen.Core.WorkflowDefinition;

namespace Awen.Core.WorkflowDynamic;

internal class WfEntityState(Guid entityId, WfActivity? currentWfActivity = null) : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public Guid EntityId { get; set; } = entityId;

    public WfActivity? CurrentActivity { get; set; } = currentWfActivity;

    public WfEntityStateChange[]? WfEntityStateChanges { get; set; }
}
