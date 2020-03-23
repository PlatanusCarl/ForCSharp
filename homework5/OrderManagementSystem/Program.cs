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
using System.Collections.Generic;
using System.Linq;

namespace OrderManagementSystem
{
   class Order
   {
       Order(int orderID,String costumer)
       {
           this.Customer = costumer;
           this.ID = orderID;

       }
       public int ID { set; get; }
       public String Customer { set; get; }
       public int Total { set; get; }

       public List<OrderItem> itemList;

       public override string ToString()
       {
           return base.ToString();
       }
       public bool Equals(Order obj)
       {
           if (obj.ID != this.ID)
               return false;
           return true; 
       }
   }

   class OrderItem
   { 
       OrderItem(int id,int price )
       {
           this.ID = id;
           this.Price = price;
       }
       public int ID { set; get; }
       public int Price { set; get; }
       public override string ToString()
       {
           return base.ToString();
       }
   }

   class OrderService
   {
       private List<Order> orderList;
       public void addOrder(Order theOne)
       {
           this.orderList.Add(theOne);
           this.sortOrder();
       }

       public void deleteOrder(Order theOne)
       {
           var query = from o in this.orderList
                       where o 
       }

       public void editOrder(Order theOne)
       {

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
                       select o;
           var result = query.FirstOrDefault<Order>();

           if (result == null)
           {
               Console.WriteLine("查询订单不存在！");
               return result;
           }
           return result;
       }

       public void sortOrder()
       {

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
