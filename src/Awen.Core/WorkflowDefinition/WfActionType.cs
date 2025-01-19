namespace Awen.Core.WorkflowDefinition;

public class WfActionType(string name, string? title = null)
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = name;

    public string Title { get; set; } = title ?? name;
}
