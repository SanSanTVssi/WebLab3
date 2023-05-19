using Microsoft.EntityFrameworkCore;

namespace GptBlog.Data;

public class OptionsBuilder
{
    public static DbContextOptions<ApplicationContext> Options
    {
        get
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
            optionsBuilder.UseSqlite("Data Source=gptBlog_profiles.db");

            return optionsBuilder.Options;
        }
    }
}