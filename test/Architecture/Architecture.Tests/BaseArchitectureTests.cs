using FluentAssertions;
using NetArchTest.Rules;
using System.Reflection;

namespace Architecture.Tests;

public abstract class BaseArchitectureTests
{
    private const string HostAppNamespace = "HostApp";
    private const string MediatRNamespace = "MediatR";

    private readonly Assembly _domainAssembly;
    private readonly Assembly _applicationAssembly;
    private readonly Assembly _infrastructureAssembly;
    private readonly Assembly _presentationAssembly;

    protected BaseArchitectureTests(
        Assembly domainAssembly,
        Assembly applicationAssembly,
        Assembly infrastructureAssembly,
        Assembly presentationAssembly)
    {
        _domainAssembly = domainAssembly;
        _applicationAssembly = applicationAssembly;
        _infrastructureAssembly = infrastructureAssembly;
        _presentationAssembly = presentationAssembly;
    }

    protected abstract string DomainNamespace { get; }
    protected abstract string ApplicationNamespace { get; }
    protected abstract string InfrastructureNamespace { get; }
    protected abstract string PresentationNamespace { get; }



    #region dependency on other projects
    [Fact]
    public void Domain_Should_Not_HaveDependencyOnOtherProjects()
    {
        // Arrange
        var otherProjects = new[]
        {
            ApplicationNamespace,
            InfrastructureNamespace,
            PresentationNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(_domainAssembly)
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
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            PresentationNamespace,
            HostAppNamespace,
        };

        // Act
        var testResult = Types
            .InAssembly(_applicationAssembly)
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
        var otherProjects = new[]
        {
            PresentationNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(_infrastructureAssembly)
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
        var otherProjects = new[]
        {
            InfrastructureNamespace,
            HostAppNamespace
        };

        // Act
        var testResult = Types
            .InAssembly(_presentationAssembly)
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

        // Act
        var testResult = Types
            .InAssembly(_applicationAssembly)
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

        // Act
        var testResult = Types
            .InAssembly(_presentationAssembly)
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
