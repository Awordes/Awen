using Awen.Core.Abstracts;

namespace Awen.Core.WorkflowDefinition;

internal class WfAction(WfActivity wfActivityFrom, WfActivity wfActivityTo, WfActionType? wfActionType = null) : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public WfActionType? Type { get; set; } = wfActionType;

    public WfActivity From { get; set; } = wfActivityFrom;

    public WfActivity To { get; set; } = wfActivityTo;

    public object? Properties { get; set; }
}
