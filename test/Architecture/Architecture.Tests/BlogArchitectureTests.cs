namespace Architecture.Tests;

public class BlogArchitectureTests : BaseArchitectureTests
{
    public BlogArchitectureTests()
        : base(
              typeof(Becoming.Core.Blog.Domain.AssemblyReference).Assembly,
              typeof(Becoming.Core.Blog.Application.AssemblyReference).Assembly,
              typeof(Becoming.Core.Blog.Infrastructure.AssemblyReference).Assembly,
              typeof(Becoming.Core.Blog.Presentation.AssemblyReference).Assembly
              )
    {
    }

    protected override string DomainNamespace => "Becoming.Core.Blog.Domain";
    protected override string ApplicationNamespace => "Becoming.Core.Blog.Application";
    protected override string InfrastructureNamespace => "Becoming.Core.Blog.Infrastructure";
    protected override string PresentationNamespace => "Becoming.Core.Blog.Presentation";
}