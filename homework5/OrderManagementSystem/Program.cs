/*
 写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单（按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
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
    public class mArrayList : ArrayList
    {
        public override string ToString()
        {
            string s = "\n";
            int count = 1;
            Array.ForEach(this.ToArray(), i => s += (count++) + "." + i.ToString() + "\n");
            return $"{s}";
        }
    }
    [Serializable]
    public class Order
    {
        public Order()
        {
            ID = 0;
            Customer = "";
        }
        public Order(int orderID, String costumer)
        {
            this.Customer = costumer;
            this.ID = orderID;
        }
        public int ID { get; }
        public String Customer { get; }
        public int Total
        {
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

        public mArrayList itemList { get; }

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

    public class OrderItem
    {
        OrderItem(int id, int price, int amount)
        {
            this.ID = id;
            this.Price = price;
            this.Amount = amount;
        }
        OrderItem()
        {
            ID = 0;
            Price = 0;
            Amount = 0;
        }
        public int ID { set; get; }
        public int Price { set; get; }
        public int Amount { set; get; }
        public int Total
        {
            get
            {
                return Price * Amount;
            }
        }
        public override string ToString()
        {
            return $"商品号：{ID}，商品价格：{Price}，商品数量：{Amount}";
        }
    }

    public class OrderService
    {
        private mList<Order> orderList;
        public void addOrder(Order theOne)
        {
            foreach (Order o in orderList)
            {
                if (o.Equals(theOne))
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
                        orderby o.Total
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
                        orderby o.ID
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
                        orderby o.ID
                        select o;
            List<Order> result = query.ToList();
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

        public void sortOrder(Func<Order,Order,int> func)
        {
            orderList.Sort((left, right) => func(left, right));
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
