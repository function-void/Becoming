using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace Becoming.Core.Common.Infrastructure.Routing;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value is null
            ? null
            : Regex.Replace(input: value!.ToString(),
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant)
            .ToLowerInvariant();
    }
}
