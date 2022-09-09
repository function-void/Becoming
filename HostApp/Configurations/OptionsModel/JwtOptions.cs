﻿namespace HostApp.Configurations.OptionsModel;

public sealed class JwtOptions
{
    public const string SectionName = nameof(JwtOptions);
    public const string SecretKeySectionName = "SecretKey";

    public string SecretKey { get; set; } = null!;
    public int ExpiryMinutes { get; set; }
    public string Issuer { get; set; } = null!;
    public string Audience { get; set; } = null!;
    public bool SaveToken { get; set; }
    public bool ValidateIssuer { get; set; }
    public bool ValidateAudience { get; set; }
    public bool ValidateLifetime { get; set; }
    public bool ValidateIssuerSigningKey { get; set; }
}
