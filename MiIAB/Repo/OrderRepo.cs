using MiIAB.IRepo;
using MiIAB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace MiIAB.Repo
{
    public class OrderRepo : IOrderRepo
    {
        private readonly IMiIABContext _db;
        public OrderRepo(IMiIABContext db)
        {
            _db = db;
        }

        public IQueryable<Order> GetOrders()
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            return _db.Order.AsNoTracking();
        }

        public Order GetOrderById(int id)
        {
            Order order = _db.Order.Find(id);
            return order;
        }

        public void DeleteOrder(int id)
        {
            Order order = _db.Order.Find(id);
            _db.Order.Remove(order);           
        }

        public void SaveChanges()
        {
            _db.SaveChanges();
        }

        public IQueryable<Order> GetOrdersForUser(string name)
        {
            _db.Database.Log = message => Trace.WriteLine(message);
            IQueryable<Order> orders = _db.Order.Where(x => x.User.Name == name);
            return orders;
        }
    }
}