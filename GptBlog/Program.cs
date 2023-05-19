using Microsoft.EntityFrameworkCore;
using GptBlog.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context
builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlite("Data Source=gptBlog.db"));

var app = builder.Build();

// Create the database if it doesn't exist
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var dbContext = services.GetRequiredService<ApplicationContext>();
    dbContext.Database.EnsureCreated();
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "api",
    pattern: "api/{controller}/{action}/{id?}");

app.Run();