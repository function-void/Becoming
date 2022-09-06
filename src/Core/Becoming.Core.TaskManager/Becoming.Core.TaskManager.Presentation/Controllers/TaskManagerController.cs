using MediatR;
using AutoMapper;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Becoming.Core.Common.Presentation;
using Becoming.Core.TaskManager.Application.Commands.CreateTaskManager;

namespace Becoming.Core.TaskManager.Presentation.Controllers;

public sealed class TaskManagerController : ApiController
{
    public ISender Sender { get; }
    public IMapper Mapper { get; }

    public TaskManagerController(ISender sender, IMapper mapper)
    {
        Sender = sender;
        Mapper = mapper;
    }

    [HttpPost]
    [Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
    [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateTaskManagerRequest request, CancellationToken token)
    {
        var taskManagerId = await Sender.Send(new CreateTaskManagerCommand(request.Title), token);
        return CreatedAtAction(nameof(Get), new { taskManagerId }, taskManagerId);
    }

    [HttpGet("{taskManagerId:guid}")]
    public async Task<IActionResult> Get(Guid taskManagerId)
    {
        return Ok(taskManagerId);
    }
}