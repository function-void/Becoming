namespace Becoming.Core.Common.Infrastructure.Settings;

public class ProviderModelOptions
{
    public const string SectionName = nameof(ProviderModelOptions);

    required public string Name { get; set; }
}
