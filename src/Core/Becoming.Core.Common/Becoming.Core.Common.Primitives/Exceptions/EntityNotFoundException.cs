namespace Becoming.Core.Common.Primitives.Exceptions;

[Serializable]
public sealed class EntityNotFoundException : ApplicationException
{
    private const string DefaultMessage = "Entity does not exist.";

    public EntityNotFoundException() : base(DefaultMessage) { }

    public EntityNotFoundException(string message) : base(message) { }

    public EntityNotFoundException(string message, Exception ex) : base(message, ex) { }

    public EntityNotFoundException(string name, object key)
            : base($"Entity \"{name}\" ({key}) was not found.") { }
}
