﻿using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS;

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, TResponse>
    where TCommand : ICommand<TResponse>
{
    new Task<TResponse> Handle(TCommand command, CancellationToken cancellationToken);
}
