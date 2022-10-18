using Becoming.Core.Common.Seedwork.Models;
using Becoming.Core.TaskManager.Domain.Exceptions;
using Becoming.Core.TaskManager.Domain.Exceptions.Errors;

namespace Becoming.Core.TaskManager.Domain.Models
{
    public sealed class Content : ValueObject
    {
        public const int TitleMaxSize = 256;
        public const int DescriptionMaxSize = 3072;

        private Content(string title, string description, Guid? storageId)
        {
            Title = title;
            Description = description;
            StorageId = storageId;
        }

        public string? Title { get; private init; }
        public string? Description { get; private init; }
        public Guid? StorageId { get; private init; }

        public static Content Create(string title, string description, Guid? storageId = default)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description))
                throw new ContentDomainException(DomainExceptionMessages.ContentIsNotFilled);

            return new Content(title, description, storageId);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title ?? string.Empty;
            yield return Description ?? string.Empty;
            yield return StorageId ?? Guid.Empty;
        }
    }
}
