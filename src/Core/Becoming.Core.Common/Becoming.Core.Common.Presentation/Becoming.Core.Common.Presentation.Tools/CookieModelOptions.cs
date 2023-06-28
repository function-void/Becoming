namespace Becoming.Core.Common.Presentation.Tools;

public sealed class CookieModelOptions
{
    public const string SectionName = nameof(CookieModelOptions);

    public required string AccessTokenCookieName { get; set; }
    public required string RefreshTokenCookieName { get; set; }
}
