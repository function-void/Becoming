namespace Becoming.Core.Common.Application.Concept;

public abstract class CommandWithDto<TRequest, TResponse> : ICommand<TResponse>
{
    public required TRequest Dto { get; init; }
}
