using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Remoting;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Protobuf.WellKnownTypes;
using System.Xml.Serialization;

namespace OrderManagementSystemEF.Class
{ 
    [Serializable]
    public class Order
    {
        [Key]
        public string OrderId { set; get; }

        public string CustomerId { set; get; }
        [ForeignKey("CustomerId")]
        public Customer Customer { set; get; }
        private string _CustomerName { set; get; }

        public string CustomerName
        {
            set
            {
                this.Customer.Name = value;
                _CustomerName = value;
            }
            get
            {
                return _CustomerName;
            }
        }

        public iList<OrderItem> ItemList { set; get; }
        public DateTime CreatTime { set; get; }
        public int Total => ItemList.Sum(item => item.Total);
        //
        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            Customer = new Customer();
            ItemList = new iList<OrderItem>();
            CreatTime = DateTime.Now;
        }
        public Order(String costumer) : this()
        {
            this.Customer.Name = costumer;
        }
        public Order(string costumer, iList<OrderItem> list) : this()
        {
            this.Customer.Name = costumer;
            this.ItemList = new iList<OrderItem>();
            foreach (object o in list)
            {
                this.ItemList.Add(o as OrderItem);
            }
        }
        public Order( iList<OrderItem> list) : this()
        {
            this.ItemList = new iList<OrderItem>();
            foreach (object o in list)
            {
                this.ItemList.Add(o as OrderItem);
            }
        }
        public override string ToString()
        {
            return $"订单号：{OrderId}，顾客：{CustomerName}，总价：{Total}，订单：{ItemList.ToString()}";
        }
        public bool Equals(Order obj)
        {
            if (obj.OrderId != this.OrderId)
                return false;
            return true;
        }
    }
}
