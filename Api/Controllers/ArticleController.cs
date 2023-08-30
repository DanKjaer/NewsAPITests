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

    /**
     * Method used for the CreateArticle or test #1
     */
    [HttpPost]
    [Route("/api/articles")]
    public Article createArticle([FromBody]Article article)
    {
        return _service.createArticle(article);
    }

    /**
     * A method used for the getArticleFeed or test #2
     */
    [HttpGet]
    [Route("/api/feed")]
    public IEnumerable<NewsFeedItem> GetArticleFeed()
    {
        return _service.getArticleFeed();
    }

    /**
     * A method used for the get full article or test #3
     */
    [HttpGet]
    [Route("/api/articles/{articleId}")]
    public Article GetFullArticle([FromRoute]int articleId)
    {
        return _service.getFullArticle(articleId);
    }

    /**
     * A method used for to delete an article or test #4
     */
    [HttpDelete]
    [Route("/api/articles/{articleId}")]
    public void DeleteArticle([FromRoute] int articleId)
    {
        _service.deleteArticle(articleId);
    }

    /**
     * a method used to update an article or test #5
     */
    [HttpPut]
    [Route("/api/articles/{articleId}")]
    public Article UpdateArticle([FromBody] Article article, [FromRoute] int articleId)
    {
        return _service.UpdateArticle(article, articleId);
    }
}