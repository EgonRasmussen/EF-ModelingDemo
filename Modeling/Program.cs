using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Modeling
{
    class Program
    {
        static void Main(string[] args)
        {
            using (AppContext context = new AppContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                System.Console.WriteLine("Database deleted and created!");

                var blog = new Blog
                {
                    Url = "https://itdata.net/blog/1",
                    BlogImage = new BlogImage
                        {
                            Caption = "Image Blog 1"
                        }
                };
                context.Add<Blog>(blog);
                context.SaveChanges();

                Blog firstBlog = context.Blogs.Include(b => b.BlogImage).FirstOrDefault();

                System.Console.WriteLine($"Blog URL: {firstBlog.Url} - Image caption: {firstBlog.BlogImage.Caption}");
            }
        }
    }
}
