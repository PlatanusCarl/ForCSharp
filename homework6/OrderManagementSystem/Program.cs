/*
 *1、在OrderService中添加一个Export方法，可以将所有的订单序列化为XML文件；添加一个Import方法可以从XML文件中载入订单。
 *2、对订单程序中OrderService的各个Public方法添加测试用例。
*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;

namespace OrderManagementSystem
{
    public class mList<order> : List<Order>
    {
        public override string ToString()
        {
            string s = "\n";
            int count = 1;
            Array.ForEach(this.ToArray(), i => s += (count++) + "." + i.ToString() + "\n");
            return $"{s}";
        }
    }

    public class nlist<orderitem> : List<OrderItem>
    {
        public override string ToString()
        {
            string s = "\n";
            int count = 1;
            Array.ForEach(this.ToArray(), i => s += (count++) + "." + i.ToString() + "\n");
            return $"{s}";
        }

        public bool Contains(OrderItem item)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this[i].Equals(item))
                    return true;
            }
            return false;
        }
    }

    [Serializable]
    public class Order
    {
        public Order()
        {
            ID = 0;
            Customer = "";
            itemList = new nlist<OrderItem>();
        }
        public Order(int orderID, String costumer)
        {
            this.Customer = costumer;
            this.ID = orderID;
        }
        
        public Order(int orderID, string costumer, nlist<OrderItem> list)
        {
            this.Customer = costumer;
            this.ID = orderID;
            this.itemList = new nlist<OrderItem>();
            foreach(object o in list)
            {
                this.itemList.Add(o as OrderItem);
            }
        }
        public int ID { set; get; }
        public String Customer { set; get; }
        public int Total { 
            get
            {
                int sum = 0;
                foreach (OrderItem o in itemList) 
                {
                    sum += o.Total;
                }
                return sum;
            }
        }

        public nlist<OrderItem> itemList;

        public override string ToString()
        {
            return $"订单号：{ID}，顾客：{Customer}，总价：{Total}，订单：{itemList.ToString()}";
        }
        public bool Equals(Order obj)
        {
            if (obj.ID != this.ID)
                return false;
            return true;
        }
    }

    [Serializable]
    public class OrderItem
    {
        public OrderItem()
        {
            ID = 0;
            Price = 0;
            Amount = 0;
        }
        public OrderItem(int id, int price,int amount)
        {
            this.ID = id;
            this.Price = price;
            this.Amount = amount;
        }
        public int ID { set; get; }
        public int Price { set; get; }
        public int Amount { set; get; }
        public int Total => Price * Amount;
        public override string ToString()
        {
            return $"商品号：{ID}，商品价格：{Price}，商品数量：{Amount}";
        }
    }

    public class OrderService
    {
        public mList<Order> orderList;

        public OrderService()
        {
            orderList = new mList<Order>();
        }
        public void addOrder(Order theOne)
        {
            foreach(Order o in orderList)
            {
                if(o.Equals(theOne))
                {
                    Console.WriteLine("订单已存在！");
                    return;
                }
            }
            this.orderList.Add(theOne);
            this.sortOrder();
        }

        public bool deleteOrder(Order theOne)
        {
            for (int i = 0; i < this.orderList.Count; i++)
            {
                if (orderList[i].Equals(theOne))
                {
                    orderList.RemoveAt(i);
                    return true;
                }
            }
            Console.WriteLine("订单不存在！");
            return false;
       }

        public void editOrder(Order theOne)
        {
            for (int i = 0; i < this.orderList.Count; i++)
            {
                if (orderList[i].Equals(theOne))
                {
                    orderList[i] = theOne;
                }
            }
        }

        public Order searchOrder(int id)
        {
            var query = from o in this.orderList
                        where o.ID == id
                        select o;
            var result = query.FirstOrDefault<Order>();

            if (result == null)
            {
                Console.WriteLine("查询订单不存在！");
                return result;
            }
            return result;
        }
        public Order searchOrder(string customer)
        {
            var query = from o in this.orderList
                        where o.Customer == customer
                        select o;
            var result = query.FirstOrDefault<Order>();

            if (result == null)
            {
                Console.WriteLine("查询订单不存在！");
                return result;
            }
            return result;
        }

        public List<Order> searchOrder(OrderItem theOne)
        {
            var query = from o in this.orderList
                        where o.itemList.Contains(theOne)
                        select o;
            List<Order> result = query.ToList() as List<Order>;
            return result;
        }
        public void sortOrder()
        {
            orderList.Sort((left, right) =>
            {
                if (left.ID >= right.ID)
                    return 1;
                else
                    return 0;
            });
        }
    
        public void Export(string path)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(mList<Order>));
            using(FileStream exportStream = new FileStream(path, FileMode.Create))
            {
                xmlserializer.Serialize(exportStream, this.orderList);
            }
        }

        public void Import(string path)
        {
            XmlSerializer xmlserializer = new XmlSerializer(typeof(mList<Order>));
            using(FileStream importStream = new FileStream(path, FileMode.Open))
            {
                mList<Order> temp = (mList<Order>)xmlserializer.Deserialize(importStream);
                temp.ForEach(o =>
                {
                    if (!orderList.Contains(o))
                        orderList.Add(o);
                });
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
