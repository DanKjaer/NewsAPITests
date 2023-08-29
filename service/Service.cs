using Infrastructure;
using Infrastructure.models;

namespace service;

public class Service
{
    private readonly Repository _repository;

    public Service(Repository repository)
    {
        _repository = repository;
    }

    public Article createArticle(Article article)
    {
        try
        {
            return _repository.CreateArticle(article);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("Could not create article");
        }
    }

    public IEnumerable<NewsFeedItem> getArticleFeed()
    {
        try
        {
            return _repository.GetArticleFeed();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("could not get article feed");
        }
    }

    public IEnumerable<Article> getFullArticle(Article article)
    {
        try
        {
            return _repository.getFullArticle(article);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("could not get full article");
        }
    }

    public object deleteArticle(int articleId)
    {
        try
        {
            return _repository.DeleteArticle(articleId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("could not delete article");
        }
    }

    public Article UpdateArticle(Article article, int articleId)
    {
        try
        {
            return _repository.UpdateArticle(article, articleId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("could not update article");
        }
    }

    public Article SearchArticle(Article article)
    {
        try
        {
            return _repository.searchArticle(article);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            Console.WriteLine(e.InnerException);
            throw new Exception("could not search article");
        }
    }
}