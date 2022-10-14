using Becoming.Core.Common.Seedwork.Models;


namespace Becoming.Core.Blog.Domain;

public sealed class BlogAggregate : Entity
{
    #region private fields
    private readonly List<Article> _articles = new();
    private readonly List<Author> _authors = new();
    #endregion

    #region ctor
    public BlogAggregate(
        Guid id,
        string title,
        List<Author> authors
       ) : base(id)
    {
        Title = title;
        _authors = authors;
    }
    #endregion

    #region properties
    public string Title { get; private set; }
    public IReadOnlyList<Article> Articles => _articles;
    public IReadOnlyList<Author> Authors => _authors;
    #endregion

    #region methods
    public static BlogAggregate Create(Guid id, string title, List<Author> authors)
    {
        return new BlogAggregate(id, title, authors);
    }

    public Article AddArticle(Author author, string text)
    {
        var newArticle = new Article(
            id: Guid.NewGuid(),
            text: text,
            blog: this,
            author: author);

        _articles.Add(newArticle);

        return newArticle;
    }

    public void PublishArticle() { }
    public void EmbodyArticle() { }
    public void ActualizeArticle() { }
    #endregion
}

public sealed class Author : Entity
{
    public Author(Guid id, string alias) : base(id)
    {
        Alias = alias;
    }

    public string Alias { get; private set; }
}

public sealed class Article : Entity
{
    private readonly List<Comment> _comments = new();

    public Article(
        Guid id,
        string text,
        BlogAggregate blog,
        Author author
        ) : base(id)
    {
        if (blog.Authors.All(x => x != author)) throw new Exception();

        Text = text;
        BlogId = blog.Id;
        AuthorId = author.Id;
    }

    public string Text { get; private set; } = null!;
    public Guid BlogId { get; private set; }
    public Guid AuthorId { get; private set; }
    public IReadOnlyList<Comment> Comments => _comments;


    public Comment UpdateComment(Comment comment)
    {
        _ = _comments.SingleOrDefault(x => x == comment) ?? throw new ArgumentException();
        Update(comment);

        return comment;
    }

    public void AddComment(Comment comment)
    {
        if (comment is null) throw new ArgumentNullException();
        if (comment.ArticleId != default) throw new ArgumentException();

        _comments.Add(comment);
    }


    public void Update(Comment comment) { }
}

public sealed class Comment : Entity
{
    public Comment(
      Guid id,
      string text,
      string createdBy) : base(id)
    {
        Text = text;
        Rating = new Rating(default!);
        CreatedBy = createdBy;
    }

    public string Text { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public string CreatedBy { get; private set; }
    public string UpdatedBy { get; private set; }
    public Guid ArticleId { get; private set; }
    public Rating Rating { get; private set; }

    public void Accept()
    {
    }
}

public class Rating
{
    public Rating(string rationgName)
    {
        RationgName = rationgName;
    }

    public string RationgName { get; private set; }
    public double Number { get; private init; }
}