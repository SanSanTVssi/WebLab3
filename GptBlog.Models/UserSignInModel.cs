namespace GptBlog.Models;

public record UserSignInModel
{
    public string PersonalToken { get; set; }
    public string PrivateKey { get; set; }
    public bool RememberMe { get; set; }
}