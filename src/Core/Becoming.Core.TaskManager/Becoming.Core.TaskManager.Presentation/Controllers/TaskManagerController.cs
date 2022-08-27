using MediatR;
using AutoMapper;
using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Becoming.Core.Common.Presentation;
using Becoming.Core.TaskManager.Application.TaskManager.Commands.CreateTaskManager;

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


	[HttpPost("{action}")]
	[Produces(MediaTypeNames.Application.Json, MediaTypeNames.Application.Xml)]
	[ProducesResponseType(typeof(object), StatusCodes.Status201Created)]
	[ProducesResponseType(typeof(ProblemDetails), StatusCodes.Status400BadRequest)]
	public async Task<IActionResult> Create()
	{
		_ = await Sender.Send(new CreateTaskManagerCommand());

		return Created("", null);
	}

	[HttpGet("{taskManagerId:guid}")]
	public async Task<IActionResult> Get(Guid taskManagerId)
	{
		return Ok(taskManagerId);
	}
}
