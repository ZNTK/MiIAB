using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace MiIAB.Models
{
    // You can add profile data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    
    public class MiIABContext : IdentityDbContext
    {
        public MiIABContext()
            : base("DefaultConnection")
        {
        }

        public static MiIABContext Create()
        {
            return new MiIABContext();
        }

        public DbSet<Order> Order { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}