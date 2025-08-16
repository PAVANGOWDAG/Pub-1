using Microsoft.EntityFrameworkCore;
using Pub_Mangement.Models;

namespace Pub_Mangement.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<MenuItem> MenuItems { get; set; }
       
    }
   
}
