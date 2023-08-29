using System.ComponentModel.DataAnnotations;

namespace Infrastructure.models;

public class NewsFeedItem
{
    
    public string Headline { get; set; }
    public int ArticleId { get; set; }
    public string ArticleImgUrl { get; set; }
    public string Body { get; set; }
}