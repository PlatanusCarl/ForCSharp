using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystemEF.Class
{
    public class OrderContext:DbContext
    {
        public OrderContext(): base("name = orderDataBase")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OrderContext>());
        }
        public DbSet<Order> Orders { set; get; }
        public DbSet<OrderItem> OrderItems { set; get; }
        public DbSet<Item> Items { set; get; }
        public DbSet<Customer> Customers { set; get; }
    }
}
