namespace GptBlog.Models;

public class PostRequest
{
    public string Title { get; set; }
    public string ImageLink { get; set; }
    public string Description { get; set; }
    public string Body { get; set; }
    public string Author { get; set; }
}