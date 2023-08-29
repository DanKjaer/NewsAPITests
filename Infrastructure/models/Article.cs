using System.ComponentModel.DataAnnotations;

namespace Infrastructure.models;

public class Article
{
    public int articleId { get; set; }
    [MinLength(5)] [MaxLength(30)] 
    public string headline { get; set; }
    [MaxLength(1000)] 
    public string body { get; set; }
    public string articleImgUrl { get; set; }
    public string author { get; set; }
}