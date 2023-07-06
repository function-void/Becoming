using Becoming.Core.Common.Application.Services;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Becoming.Core.Common.Presentation.Tools.Attributes;

public class DataTransferObjecFilterAttribute : IAsyncActionFilter
{
    private readonly IDataTransferObjectProvider _provider;

    public DataTransferObjecFilterAttribute(IDataTransferObjectProvider provider)
    {
        _provider = provider;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        var result = await next();
    }
}