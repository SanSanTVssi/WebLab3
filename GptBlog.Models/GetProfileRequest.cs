namespace GptBlog.Models;

public record GetProfileRequest
{
    public string PersonalToken { get; set; }
}