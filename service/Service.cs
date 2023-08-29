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
        catch (Exception)
        {
            throw new Exception("Could not create article");
        }
    }

    public IEnumerable<Article> getArticleFeed(Article article)
    {
        try
        {
            return _repository.GetArticleFeed(article);
        }
        catch (Exception)
        {
            throw new Exception("could not get article");
        }
    }
}