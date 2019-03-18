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
            }
        }
    }
}
