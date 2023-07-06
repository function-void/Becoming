using MediatR;
using Becoming.Core.Common.Domain.Seedwork.Interfaces;

namespace Becoming.Core.Common.Application.Concept;

public interface IEvent : IDomainEvent, INotification { }
