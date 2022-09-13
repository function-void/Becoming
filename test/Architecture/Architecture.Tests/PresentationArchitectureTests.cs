using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyModel;
using System.Reflection;

namespace Architecture.Tests;

public sealed class PresentationArchitectureTests
{
    [Fact]
    public void Controllers_Should_Be_Inheritanced_By_With_ApiController()
    {
        // Arrange
        var presentationAssemblyList = DependencyContext.Default.RuntimeLibraries
            .Where(x => x.Name.Contains("Becoming"))
            .Select(x => Assembly.Load(x.Name))
            .Where(assembly => assembly.DefinedTypes.Where(t => !t.IsAbstract)
                .Any(t => t.BaseType == typeof(ControllerBase)))
            .ToList();

        // Act
        var result = presentationAssemblyList.Count;

        // Assert
        Assert.Equal(0, result);
    }
}
