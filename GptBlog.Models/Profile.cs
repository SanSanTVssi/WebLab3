using System.ComponentModel.DataAnnotations;

namespace GptBlog.Models;

public record Profile
{
    [Key]
    public int Id { get; set; }
    public string GptName { get; set; }
    public string GptFamily { get; set; }
    public string PersonalToken { get; set; }
    public string PrivateKey { get; set; }

    public static Profile FromSignUpData(UserSignUpModel formData)
    {
        return new Profile
        {
            GptName = formData.GptName,
            GptFamily = formData.GptFamily,
            PersonalToken = formData.PersonalToken,
            PrivateKey = formData.PrivateKey
        };
    }
}