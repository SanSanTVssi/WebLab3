using Backend.Services;
using GptBlog.Data;
using GptBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] UserSignInModel formData)
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            var profile = db.Profiles.ToList().Find(profile =>
                profile.PersonalToken == formData.PersonalToken &&
                profile.PrivateKey == formData.PrivateKey);

            if (profile == null)
            {
                return BadRequest($"Profile not found");
            }

            CookieHelper.CreateCookie("User", profile, formData.RememberMe ? 4000 : 1, Response);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] UserSignUpModel formData)
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            if (db.Profiles.Any(profile => profile.PersonalToken == formData.PersonalToken))
            {
                return BadRequest("Profile with the same personalToken already exists");
            }

            var profile = Profile.FromSignUpData(formData);
            db.Profiles.Add(Profile.FromSignUpData(formData));
            db.SaveChanges();

            CookieHelper.CreateCookie("User", profile, formData.RememberMe ? 4000 : 1, Response);

        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
        return Ok();
    }
}

