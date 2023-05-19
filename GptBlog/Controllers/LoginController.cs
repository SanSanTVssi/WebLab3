using Backend.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    [HttpPost("signin")]
    public IActionResult SignIn([FromBody] UserLoginInModel formData)
    {
        Console.WriteLine(formData);
        return Ok();
    }

    [HttpPost("signup")]
    public IActionResult SignUp([FromBody] UserModel formData)
    {
        Console.WriteLine(formData);
        return Ok();
    }
}

