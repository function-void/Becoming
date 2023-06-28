using Microsoft.AspNetCore.Routing;
using System.Text.RegularExpressions;

namespace Becoming.Core.Common.Presentation.Tools;

public class SlugifyParameterTransformer : IOutboundParameterTransformer
{
    public string? TransformOutbound(object? value)
    {
        return value is null
            ? null
            : Regex.Replace(input: value.ToString() ?? String.Empty,
                "([a-z])([A-Z])",
                "$1-$2",
                RegexOptions.CultureInvariant)
            .ToLowerInvariant();
    }
}
