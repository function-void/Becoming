namespace HostApp.Configurations.Model;

public sealed class JwtModelOptions
{
    public const string SectionName = nameof(JwtModelOptions);
    public const string SecretKeySectionName = "SecretKey";

    required public string SecretKey { get; set; }
    required public int ExpiryMinutes { get; set; }
    required public string Issuer { get; set; }
    required public string Audience { get; set; }
    required public bool SaveToken { get; set; }
    required public bool ValidateIssuer { get; set; }
    required public bool ValidateAudience { get; set; }
    required public bool ValidateLifetime { get; set; }
    required public bool ValidateIssuerSigningKey { get; set; }
}
