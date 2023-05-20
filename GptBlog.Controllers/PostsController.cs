using GptBlog.Data;
using GptBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace GptBlog.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PostsController : ControllerBase
{
    [HttpPost("newpost")]
    public IActionResult NewPost([FromBody] PostRequest postRequest)
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            if (string.IsNullOrEmpty(postRequest.Title))
            {
                return BadRequest("Title is required");
            }

            var post = Post.FromFromData(postRequest);
            db.Posts.Add(post);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }

        return Ok();
    }

    [HttpGet("allposts")]
    public IActionResult GetAllPosts()
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            var posts = db.Posts.ToList();
            return Ok(posts);
        }
        catch (Exception ex)
        {
            // ignore
            return Ok();
        }
    }

    [HttpPost("removepost")]
    public IActionResult RemovePost([FromBody] PostRemoveData postId)
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            db.Posts.Remove(db.Posts.Find(postId.PostId));
            db.SaveChanges();
            return Ok();
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}