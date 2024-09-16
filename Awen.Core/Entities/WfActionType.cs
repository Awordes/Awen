using Awen.Core.Abstracts;

namespace Awen.Core.Entities;

public class WfActionType(string name, string? title = null) : IAwenEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;

    public string Title { get; set; } = title ?? name;
}
