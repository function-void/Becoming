using Microsoft.AspNetCore.Mvc;

namespace Becoming.Core.Common.Presentation;

[Route(ApiConfigureSettings.API_DEFAULT_ROUTE)]
[ApiVersion(ApiConfigureSettings.API_ACTRUAL_VERSION)]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected string GenerateIPAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"];
        else
            return HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString();
    }
}