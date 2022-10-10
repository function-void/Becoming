using Becoming.Core.Common.Abstractions.CQRS.Interfaces;
using Becoming.Core.Common.Abstractions.Interfaces;
using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.Common.Abstractions.CQRS;

public abstract record class CommandWithDto<TRequest, TResponse>(TRequest Dto) : ICommand<TResponse>
    where TRequest : IDtoObject<Entity>;
