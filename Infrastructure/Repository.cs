using Dapper;
using Npgsql;
using Infrastructure.models;

namespace Infrastructure;

public class Repository
{
    private readonly string[] validAuthors = { "Bob", "Rob", "Dob", "Lob" };
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource datasource)
    {
        _dataSource = datasource;
    }

    /**
     * Test #1
     */
    public Article CreateArticle(Article article)
    {
        if (validAuthors.Contains(article.author))
        {
            var sql = $@"INSERT INTO news.articles (headline, body, author, articleimgurl)
                    VALUES (@headline, @body, @author, @articleImgUrl) RETURNING *;";
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Article>(sql, article);
            }
        }

        throw new Exception("Invalid authors");
    }
    
    /**
     * A method used for test #2 get Article Feed
     */
    public IEnumerable<NewsFeedItem> GetArticleFeed()
    {
        var sql = $@"SELECT LEFT (body, 50) body, headline, articleId, articleimgurl FROM news.articles;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<NewsFeedItem>(sql);
        }
    }

    /**
     * A method used for test #3 get Full article
     */
    public Article getFullArticle(int articleId)
    {
        var sql = $@"SELECT * FROM news.articles WHERE articleid = @articleId;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql, new {articleId});
        }
    }

    /**
     * A method used for test #4 delete article
     */
    public void DeleteArticle(int articleId)
    {
        var sql = $@"DELETE FROM news.articles WHERE articleid = @articleId;";
        using (var conn = _dataSource.OpenConnection())
        {
            conn.Execute(sql, new { articleId });
        }
    }

    /**
     * A method used for test #5 Update article
     */

    public Article UpdateArticle(Article article, int articleId)
    {
        var sql = $@"UPDATE news.articles SET headline = @headline, body = @body, author = @author, articleimgurl = @articleimgurl 
                     WHERE articleid = @articleId RETURNING *;";
        if (validAuthors.Contains(article.author))
        {
            using (var conn = _dataSource.OpenConnection())
            {
                return conn.QueryFirst<Article>(sql,
                    new { article.headline, article.body, article.author, article.articleImgUrl, articleId });
            } 
        }

        throw new Exception("Could not update article");

    }

    /**
     * A method used for test #6 Search article
     */

    public Article searchArticle(Article article)
    {
        throw new NotImplementedException();
    }
}