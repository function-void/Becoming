﻿using MediatR;

namespace Becoming.Core.Common.Abstractions.CQRS.Interfaces;

public interface IQuery : IRequest { }

public interface IQuery<out TResponse> : IRequest<TResponse> { }