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
    [ValueIsOneOf(new []{"Bob", "Rob", "Dob", "Lob"})]
    public string author { get; set; }
}
public class ValueIsOneOf : ValidationAttribute
{
    private readonly string[] _validStrings;
    private readonly string? _errormessage;

    public ValueIsOneOf(string[] validStrings, string? errormessage = "")
    {
        _validStrings = validStrings;
        _errormessage = errormessage;
    }

    protected override ValidationResult IsValid(object? givenString, ValidationContext validationContext)
    {
        if (!_validStrings.Contains(givenString))
        {
            return new ValidationResult(_errormessage);
        }

        return ValidationResult.Success!;
    }
}