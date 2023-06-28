using MediatR;

namespace Becoming.Core.Common.Application.Concept;

public interface IQuery : IRequest { }

public interface IQuery<out TResponse> : IRequest<TResponse> { }
