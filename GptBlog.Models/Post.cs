using System.ComponentModel.DataAnnotations;

namespace GptBlog.Models;

public class Post
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string ImageLink { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
    public string CreationTime { get; set; }

    public static Post FromFromData(PostRequest request)
    {
        return new Post
        {
            Title = request.Title,
            ImageLink = request.ImageLink ?? string.Empty,
            Description = request.Description ?? string.Empty,
            Body = request.Body ?? string.Empty,
            Author = request.Author ?? string.Empty,
            CreationTime = DateTime.Now.ToLongDateString() ?? string.Empty
        };
    }
}