using Becoming.Core.Common.Application.Services;
using Becoming.Core.Common.Presentation.Tools.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace HostApp.Middleware;

public class DataTransferObjectMiddleware
{
    private readonly RequestDelegate _next;

    public DataTransferObjectMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, IDataTransferObjectProvider provider)
    {
        if (context.Request.Method == "POST")
        {
            var endpoint = context.GetEndpoint();

            var serviceFilter = endpoint?.Metadata?.GetMetadata<ServiceFilterAttribute>();

            if (serviceFilter?.ServiceType == typeof(DataTransferObjecFilterAttribute))
            {
                context.Request.EnableBuffering();

                context.Request.Body.Position = 0;
                await context.Request.Body.CopyToAsync(provider.RequestBody);
            }
        }

        await _next(context);
    }
}
