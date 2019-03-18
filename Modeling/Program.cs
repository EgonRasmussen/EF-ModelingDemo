using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Modeling
{
    class Program
    {
        static void Main(string[] args)
        {
            using (BloggingContext context = new BloggingContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
                System.Console.WriteLine("Database deleted and created!");
            }
        }
    }
}
