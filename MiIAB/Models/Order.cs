using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiIAB.Models
{
    public class Order
    {
        public Order()
        {

        }

        public int Id { get; set; }
        [Display(Name = "Data złożenia zamówienia")]
        public DateTime Date { get; set; }
        [Display(Name = "Ilość")]
        public int Amount { get; set; }
        public Guid UserId { get; set; }
        public int ProductId { get; set; }

        public virtual User User { get; set; }
        public virtual Product Product { get; set; }
    }
}