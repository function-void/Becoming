using Becoming.Core.Common.Seedwork.Models;

namespace Becoming.Core.TaskManager.Domain.Models
{
    public sealed class Content : ValueObject
    {
        public const int TitleMaxSize = 256;
        public const int DescriptionMaxSize = 3072;

        private Content(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public string? Title { get; }
        public string? Description { get; }

        public static Content Create(string title, string description)
        {
            if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(description))
                throw new ArgumentException($"'{nameof(title)}' and '{nameof(description)}' cannot be null or empty.", nameof(title));

            return new Content(title, description);
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Title ?? string.Empty;
            yield return Description ?? string.Empty;
        }
    }
}
