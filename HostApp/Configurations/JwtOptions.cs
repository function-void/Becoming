namespace HostApp.Configurations;

public sealed class JwtOptions
{
    public const string SectionName = "JwtSettings";
    public const string SecretKeySectionName = "SecretKey";
    public string SecretKey { get; init; } = null!;
    public int ExpiryMinutes { get; init; }
    public string Issuer { get; init; } = null!;
    public string Audience { get; init; } = null!;
    public bool SaveToken { get; init; }
    public bool ValidateIssuer { get; init; }
    public bool ValidateAudience { get; init; }
    public bool ValidateLifetime { get; init; }
    public bool ValidateIssuerSigningKey { get; init; }
}
