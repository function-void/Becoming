using Becoming.Core.Common.Presentation.Tools;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Tests;

public sealed class PresentationArchitectureTests
{
    private const string BUILDS_NAME = "Becoming";

    [Fact]
    public void Controllers_Should_Be_Inheritanced_By_With_ApiController()
    {
        // Arrange
        List<Assembly> presentationAssemblyList = DependencyContext.Default!.RuntimeLibraries
            .Where(x => x.Name.Contains(BUILDS_NAME))
            .Select(x => Assembly.Load(x.Name))
            .Where(assembly => assembly.DefinedTypes.Where(t => !t.IsAbstract)
                .Any(t => t.BaseType == typeof(ControllerBase)))
            .ToList();

        // Act

        // Assert
        presentationAssemblyList.Should().BeOfType<List<Assembly>>();
        presentationAssemblyList.Should().NotBeNull().And.HaveCount(0);
    }

    [Fact]
    public void Endpoints_Which_Post_Should_Be_Async()
    {
        // Arrange
        var presentationAssemblyList = DependencyContext.Default.RuntimeLibraries
            .Where(x => x.Name.Contains(BUILDS_NAME))
            .Select(x => Assembly.Load(x.Name))
            .Where(assembly => assembly.DefinedTypes.Where(t => !t.IsAbstract)
                .Any(t => t.BaseType == typeof(ApiController)))
            .ToList();

        var apiControllerTypes = Types.InAssemblies(presentationAssemblyList)
            .GetTypes()
            .ThatAreClasses()
            .ThatAreDecoratedWithOrInherit<ApiControllerAttribute>()
            .ToList();

        // Act

        // Assert
        foreach (var controllerType in apiControllerTypes)
        {
            controllerType.Methods()
                .ThatReturn<ActionResult>()
                .ThatReturn<IActionResult>()
                .ThatAreDecoratedWith<HttpPostAttribute>()
                .Should()
                .BeAsync();
        }
    }
}
