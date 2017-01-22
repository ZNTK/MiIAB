using MiIAB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiIAB.IRepo
{
    public interface IMiIABContext
    {
        DbSet<Order> Order { get; set; }
        DbSet<User> User { get; set; }
        DbSet<Product> Product { get; set; }
        int SaveChanges();
        Database Database { get; }
    }
}
