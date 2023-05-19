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
    public int Autor { get; set; }
    public string CreationTime { get; set; }

    public static Post FromFromData(PostFormData formData, int id)
    {
        return new Post
        {
            Title = formData.Title,
            ImageLink = formData.ImageLink ?? string.Empty,
            Description = formData.Description ?? string.Empty,
            Body = formData.Body ?? string.Empty,
            Autor = id,
            CreationTime = DateTime.Now.ToLongDateString() ?? string.Empty
        };
    }
}