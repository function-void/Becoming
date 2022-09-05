namespace Architecture.Tests;

public class TaskManagerArchitectureTests : BaseArchitectureTests
{
    public TaskManagerArchitectureTests()
        : base(
              typeof(Becoming.Core.TaskManager.Domain.AssemblyReference).Assembly,
              typeof(Becoming.Core.TaskManager.Application.AssemblyReference).Assembly,
              typeof(Becoming.Core.TaskManager.Infrastructure.AssemblyReference).Assembly,
              typeof(Becoming.Core.TaskManager.Presentation.AssemblyReference).Assembly
              )
    {
    }

    protected override string DomainNamespace => "Becoming.Core.TaskManager.Domain";
    protected override string ApplicationNamespace => "Becoming.Core.TaskManager.Application";
    protected override string InfrastructureNamespace => "Becoming.Core.TaskManager.Infrastructure";
    protected override string PresentationNamespace => "Becoming.Core.TaskManager.Presentation";
}
