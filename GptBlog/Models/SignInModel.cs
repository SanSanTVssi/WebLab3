namespace Backend.Models;

public record UserLoginInModel
{
    public string PersonalToken { get; set; }
    public string PrivateKey { get; set; }
    public bool RememberMe { get; set; }
}