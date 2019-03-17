using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
                Console.WriteLine("Database deleted and created!");

                var blog = new Blog
                {
                    Url = "https://itdata.net/blog/1",
                    Posts = new List<Post>
                    {
                        new Post { Title = "Post1 title", Content = "Post1 content"},
                        new Post { Title = "Post2 title", Content = "Post2 content"}
                    }
                };
                       
                context.Add<Blog>(blog);
                context.SaveChanges();

                Blog firstBlog = context.Blogs.Include(b => b.Posts).FirstOrDefault();

                Console.WriteLine($"Blog Id: {firstBlog.BlogId} - Blog URL: {firstBlog.Url}");
                foreach (Post post in firstBlog.Posts)
                {
                    Console.WriteLine($"\tPost title: {post.Title}");
                }                
            } 
        }
    }
}
