namespace Becoming.Core.Common.Application.Concept;

public interface ICommandWithDto<TRequest, TResponse> : ICommand<TResponse>
{
    TRequest Dto { get; init; }
}
