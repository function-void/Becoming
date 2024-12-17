using MediatR;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Becoming.Core.Common.Presentation.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using Becoming.Core.Common.Presentation.Tools.Attributes;
using Becoming.Core.TaskManager.Application.Root.Commands.Create;
using Becoming.Core.TaskManager.Application.Root.Queries;
using Becoming.Core.TaskManager.Application.Root.Commands.Update;

namespace Becoming.Core.TaskManager.Presentation.Controllers;

[ApiVersion(ApiConfigurationProvider.API_ACTUAL_VERSION)]
public sealed class TaskManagerController : ApiController
{
    #region ctor
    public ISender Sender { get; }

    public TaskManagerController(ISender sender) => Sender = sender;
    #endregion

    #region commands
    [HttpPost]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateTaskManagerRequest request, CancellationToken token)
    {
        var taskManagerId = await Sender.Send(new CreateTaskManagerCommand(request), token);
        return CreatedAtAction(nameof(Get), new { taskManagerId }, taskManagerId);
    }

    [HttpPatch("{taskManagerId:guid}/{summaryTaskId:guid}")]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Update(
        Guid taskManagerId,
        Guid summaryTaskId,
        [FromBody] UpdateSummaryTaskRequest request,
        CancellationToken token)
    {
        await Sender.Send(new UpdateSummaryTaskCommand(taskManagerId, summaryTaskId, request), token);
        return NoContent();
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

    [HttpGet("ttt")]
    public Results<JsonHttpResult<TaskManagerResponse>, BadRequest> GetT()
    {
        Task.Run(() =>
        {
            Thread.Sleep(5000);
            Console.WriteLine("Sleep - 5000");
        });

        var test = new TaskManagerResponse(Guid.NewGuid(), "");
        var result = JsonSerializer.Serialize(test, new JsonSerializerOptions()
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        });

        return TypedResults.Json(test);
    }

    [Authorize]
    [HttpGet("test")]
    public IActionResult Get()
    {
        return Ok();
    }
    #endregion
}