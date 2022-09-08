using MediatR;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Becoming.Core.Common.Presentation;
using Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;
using Becoming.Core.TaskManager.Application.Queries.GetTaskManager;

namespace Becoming.Core.TaskManager.Presentation.Controllers;

[ApiVersion(ApiConfigureSettings.API_ACTRUAL_VERSION)]
public sealed class TaskManagerController : ApiController
{
    #region ctor
    public ISender Sender { get; }

    public TaskManagerController(ISender sender)
    {
        Sender = sender;
    }
    #endregion

    #region commands
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateTaskManagerRequest request, CancellationToken token)
    {
        var taskManagerId = await Sender.Send(new CreateTaskManagerCommand(request.Title, request.Category), token);
        return CreatedAtAction(nameof(Get), new { taskManagerId }, taskManagerId);
    }
    #endregion

    #region queries
    [HttpGet("{taskManagerId:guid}")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ProducesResponseType(typeof(TaskManagerResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Get(Guid taskManagerId, CancellationToken token)
    {
        return Ok(await Sender.Send(new GetTaskManagerByIdQuery(taskManagerId), token));
    }
    #endregion
}