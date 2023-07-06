using Becoming.Core.Common.Application.Services;

namespace Becoming.Core.Common.Infrastructure.Services;

public sealed class DataTransferObjectProvider : IDataTransferObjectProvider
{
    public MemoryStream RequestBody { get; set; } = new MemoryStream();
}
