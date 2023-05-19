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

    public static Post FromFromData(PostFormData formData)
    {
        return new Post
        {
            Title = formData.Title,
            ImageLink = formData.ImageLink,
            Description = formData.Description,
            Body = formData.Body
        };
    }
}