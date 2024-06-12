using Becoming.Core.Common.Application.Concept;

namespace Becoming.Core.TaskManager.Application.Root.Queries;

public sealed record class GetTaskManagerByIdQuery(Guid Id) : IQuery<TaskManagerResponse>;