namespace Infrastructure.models;

public class Article
{
    public int articleId { get; set; }
    public string headline { get; set; }
    public string body { get; set; }
    public string articleImgUrl { get; set; }
    public string author { get; set; }
}