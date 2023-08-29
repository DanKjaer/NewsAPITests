using Dapper;
using Npgsql;
using Infrastructure.models;

namespace Infrastructure;

public class Repository
{
    private readonly NpgsqlDataSource _dataSource;

    public Repository(NpgsqlDataSource datasource)
    {
        _dataSource = datasource;
    }

    public Article CreateArticle(Article article)
    {
        var sql = $@"INSERT INTO news.articles (headline, body, author, articleImgUrl)
                    VALUES (@headline, @body, @author, @articleImgUrl) RETURNING *;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.QueryFirst<Article>(sql,
                new { article.headline, article.author, article.body, article.articleImgUrl });
        }
    }

    public IEnumerable<Article> GetArticleFeed(Article article)
    {
        var sql = $@"SELECT * FROM news.article;";
        using (var conn = _dataSource.OpenConnection())
        {
            return conn.Query<Article>(sql);
        }
    }
}