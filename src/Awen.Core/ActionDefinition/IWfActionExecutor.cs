namespace Awen.Core.ActionDefinition;

public interface IWfActionExecutor<in TWfAction, in TWfActionData>
    where TWfActionData: IWfActionData
    where TWfAction: IWfAction<TWfActionData>
{
    Task Execute(TWfAction action, TWfActionData actionData, CancellationToken cancellationToken);
}
