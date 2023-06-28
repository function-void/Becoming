namespace Becoming.Core.Common.Presentation.Tools;

[AttributeUsage(AttributeTargets.Method)]
public class GroupNameAttribute : Attribute
{
    public GroupNameAttribute(string groupName) => GroupName = groupName;
    public string GroupName { get; }
}
