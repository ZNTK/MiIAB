using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MiIAB.Models
{
    public class Product
    {
        public Product()
        {
            this.Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}