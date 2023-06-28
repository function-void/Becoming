using Microsoft.AspNetCore.Mvc;

namespace Becoming.Core.Common.Presentation.Tools;

[Route(ApiConfigureSettings.API_DEFAULT_ROUTE)]
[ApiController]
public abstract class ApiController : ControllerBase
{
    protected string GenerateIPAddress()
    {
        if (Request.Headers.ContainsKey("X-Forwarded-For"))
            return Request.Headers["X-Forwarded-For"].ToString();
        else
            return HttpContext.Connection.RemoteIpAddress!.MapToIPv4().ToString();
    }
}