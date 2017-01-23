using MiIAB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiIAB.IRepo
{
    public interface IOrderRepo
    {
        IQueryable<Order> GetOrders();
        IQueryable<Order> GetOrdersForUser(string name);
        Order GetOrderById(int id);
        void DeleteOrder(int id);
        void SaveChanges();
    }
}
