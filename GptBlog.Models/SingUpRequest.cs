namespace GptBlog.Models;

public record SingUpRequest
{
    public string GptName { get; set; }
    public string GptFamily { get; set; }
    public string PersonalToken { get; set; }
    public string PrivateKey { get; set; }
    public bool RememberMe { get; set; }
}