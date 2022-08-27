using NetArchTest.Rules;
using FluentAssertions;

namespace Architecture.Tests;

public class BlogArchitectureTests
{
    private const string DomainNamespace = "Becoming.Core.Blog.Domain";
    private const string ApplicationNamespace = "Becoming.Core.Blog.Application";
    private const string InfrastructureNamespace = "Becoming.Core.Blog.Infrastructure";
    private const string PresentationNamespace = "Becoming.Core.Blog.Presentation";
    private const string HostAppNamespace = "HostApp";
    private const string MediatRNamespace = "MediatR";

    #region dependency on other projects
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Becoming.Core.Blog.Domain.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Application_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Becoming.Core.Blog.Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            HostAppNamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Infrastructure_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Becoming.Core.Blog.Infrastructure.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            PresentationNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Presentation_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var assembly = typeof(Becoming.Core.Blog.Presentation.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            InfrastructureNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    #endregion

    #region cqrs handle with DDD and MediatR
    [Fact]
    public void Handlers_Should_HaveDependencyOnDomain()
    {
        // Arrange
        var assebly = typeof(Becoming.Core.Blog.Application.AssemblyReference).Assembly;

        // Act
        var testResult = Types
            .InAssembly(assebly)
            .That()
            .HaveNameEndingWith("Handler")
            .Should()
            .HaveDependencyOn(DomainNamespace)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void Controllers_Should_HaveDependencyOnMediatR()
    {
        // Arrange
        var assebly = typeof(Becoming.Core.Blog.Presentation.AssemblyReference).Assembly;

        // Act
        var testResult = Types
            .InAssembly(assebly)
            .That()
            .HaveNameEndingWith("Controller")
            .Should()
            .HaveDependencyOn(MediatRNamespace)
            .GetResult();

        // Assert
        testResult.IsSuccessful.Should().BeTrue();
    }
    #endregion
}