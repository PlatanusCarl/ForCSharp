using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Order
    {
        public Order()
        {

        }
        public Order(int id, string customer, OrderItem item)
        {
            Id = id;
            Customer = customer;
            Items.Add(item);
        }

        public int Id { get; set; }
        public string Customer{ get; set; }
        public List<OrderItem> Items { get; set; }
    }
}
