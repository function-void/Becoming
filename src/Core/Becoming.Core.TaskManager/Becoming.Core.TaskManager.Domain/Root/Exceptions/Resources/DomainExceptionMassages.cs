namespace Becoming.Core.TaskManager.Domain.Root.Exceptions.Resources;

static class DomainExceptionMessages
{
    #region category
    public const string CategoryIsEmpty = "The category is not filled";
    public const string CategoryLengthIncorrect = "The category should not exceed 50 characters";
    #endregion

    #region content
    public const string ContentIsNotFilled = "The content must have a title or description";
    #endregion

    #region task manager
    public const string DeadlinesNotValid = "Deadlines are not valid";
    #endregion
}
