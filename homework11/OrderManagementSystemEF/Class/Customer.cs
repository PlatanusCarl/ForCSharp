using System;
using System.ComponentModel.DataAnnotations;

namespace OrderManagementSystemEF.Class
{
    [Serializable]
    public class Customer
    {
        [Key]
        public string OrderId { get; set; }
        public string Name { get; set; }
        public Customer()
        {
            OrderId = Guid.NewGuid().ToString();
        }
        public Customer(string name):this()
        {
            Name = name;
        }
        public bool Equals(Customer obj)
        {
            if (obj.OrderId != this.OrderId)
                return false;
            return true;
        }
    }
}