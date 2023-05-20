using Backend.Services;
using GptBlog.Data;
using GptBlog.Models;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

public class PostsController : Controller
{
    public IActionResult Index()
    {
        using var db = new ApplicationContext(OptionsBuilder.Options);
        var posts = db.Posts.ToList();
        var profiles = db.Profiles.ToList();
        var model = new Tuple<List<Post>, List<Profile>>(posts, profiles);
        return View(model);
    }

    public IActionResult WritePost()
    {
        return View();
    }

    public IActionResult ReadPost([FromForm] int postId)
    {
        using var db = new ApplicationContext(OptionsBuilder.Options);
        var existingPost = db.Posts.Find(postId);
        if (existingPost == null)
        {
            return RedirectToAction("Index", "Posts");
        }
        return View(existingPost);
    }

    [HttpPost]
    public IActionResult RemovePost([FromForm] int postId)
    {
        using var db = new ApplicationContext(OptionsBuilder.Options);
        var existingPost = db.Posts.Find(postId);
        if (existingPost == null)
        {
            return RedirectToAction("Index", "Posts");
        }
        db.Posts.Remove(existingPost);
        db.SaveChanges();

        return RedirectToAction("Index", "Posts");
    }


    [HttpPost]
    public IActionResult CreatePost([FromForm] PostRequest request)
    {
        try
        {
            using var db = new ApplicationContext(OptionsBuilder.Options);
            if (string.IsNullOrEmpty(request.Title))
            {
                return BadRequest(new { error = "Title is required" });
            }

            var userCookie = Request.Cookies["User"];
            var profile0 = CookieHelper.DeserializeJsonCookie<Profile>(userCookie);
            var profile = db.Profiles.ToList().Find(p=> profile0.PersonalToken == p.PersonalToken);

            var post = Post.FromFromData(request);
            db.Posts.Add(post);
            db.SaveChanges();
        }
        catch (Exception ex)
        {
            return BadRequest(new { error = ex.Message });
        }

        return Ok();
    }
}