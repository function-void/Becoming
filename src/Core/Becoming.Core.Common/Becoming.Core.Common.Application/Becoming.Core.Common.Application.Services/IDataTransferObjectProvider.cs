namespace Becoming.Core.Common.Application.Services;

public interface IDataTransferObjectProvider
{
    MemoryStream RequestBody { get; set; }
}
