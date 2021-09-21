using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;

namespace Modeling
{
    class AppContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .LogTo(Console.WriteLine,
                    new[]
                    {
                        DbLoggerCategory.Database.Command.Name
                    },
                    LogLevel.Information)
                .UseSqlServer("Server = (localdb)\\mssqllocaldb; Database = BloggingDb; Trusted_Connection = True; ");
        }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<BlogImage> BlogImages { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        public string Url { get; set; }

        public BlogImage BlogImage { get; set; }
    }

    public class BlogImage
    {
        public int BlogImageId { get; set; }
        public byte[] Image { get; set; }
        public string Caption { get; set; }

        public int BlogId { get; set; }     // FK
        public Blog Blog { get; set; }
    }
}
