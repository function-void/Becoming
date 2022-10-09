using Becoming.Core.Common.Abstractions.Interfaces;
using Becoming.Core.Common.Seedwork.Models;
using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface ICommand<out TResponse> : IRequest<TResponse> { }

public abstract record class CommandWithDto<TRequest, TResponse>(TRequest Dto) : ICommand<TResponse>
    where TRequest : IDtoObject<Entity>;
