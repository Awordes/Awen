using Awen.Core.Abstracts;

namespace Awen.Core.Entities;

public class WfAction (WfActivity wfActivity) : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public WfActivity WfActivity { get; set; } = wfActivity;
}
