using Awen.Core.Abstracts;

namespace Awen.Core.Entities;

public class Workflow : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
}
