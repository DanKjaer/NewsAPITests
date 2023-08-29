using Infrastructure.models;
using Microsoft.AspNetCore.Mvc;
using service;

namespace NewsApi.Controllers;

[ApiController]
public class ArticleController : ControllerBase
{
    private readonly Service _service;

    public ArticleController(Service service)
    {
        _service = service;
    }

    [HttpPost]
    [Route("/api/articles")]
    public Article createArticle(Article article)
    {
        return _service.createArticle(article);
    }

    [HttpGet]
    [Route("/api/articles")]
    public IEnumerable<Article> getArticleFeed(Article article)
    {
        return _service.getArticleFeed(article);
    }
}